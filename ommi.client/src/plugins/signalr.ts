import Vue from 'vue'
import * as SignalR from '@microsoft/signalr'

declare module 'vue/types/vue' {
  interface Vue {
    $ommiHub: Vue;

    $sendUpdatedBoardState: Function;

    $updateBoardState: Function;
    $connectSignalR: Function;
    $roomCreated: Function;
    $joinedToTheRoom: Function;
    $connection: SignalR.HubConnection;
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

      Vue.prototype.$connection.on('updateBoardState', (newBoardState) => {
        Vue.prototype.$ommiHub.$emit('updateBoardState', newBoardState)
      })

      Vue.prototype.$connection.start()
    }

    Vue.prototype.$sendUpdatedBoardState = function (newBoardState, roomName) {
      return Vue.prototype.$connection.invoke('UpdateBoardStateAsync', newBoardState, roomName)
    }
  }
}
