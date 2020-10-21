import Vue from 'vue'
import * as SignalR from '@microsoft/signalr'

declare module 'vue/types/vue' {
  interface Vue {
    $ommiHub: Vue;
    $activateSignalR: Function;
    $connectSignalR: Function;
    $roomCreated: Function;
    $joinedToTheRoom: Function;
    $connection: SignalR.HubConnection;
    $receiveMessage: Function;
  }
}

export default {
  install (Vue: any) {
    Vue.prototype.$connection = null
    const ommiHub = new Vue()
    Vue.prototype.$ommiHub = ommiHub

    Vue.prototype.$connectSignalR = function () {
      Vue.prototype.$connection = new SignalR.HubConnectionBuilder()
        .configureLogging(SignalR.LogLevel.Information)
        .withUrl(process.env.VUE_APP_API_BASEURL + '/ommihub')
        .build()

      Vue.prototype.$connection.on('receiveMessage', (message: string) => {
        Vue.prototype.$ommiHub.$emit('receiveMessage', message)
      })

      Vue.prototype.$connection.on('roomCreated', (roomName) => {
        Vue.prototype.$ommiHub.$emit('roomCreated', roomName)
      })

      Vue.prototype.$connection.on('joinedToTheRoom', (roomName) => {
        Vue.prototype.$ommiHub.$emit('joinedToTheRoom', roomName)
      })

      Vue.prototype.$connection.start()
    }

    Vue.prototype.$activateSignalR = function () {
      return Vue.prototype.$connection.invoke('ActivateSignalR')
    }
  }
}
