import Vue from 'vue'
import App from './components/app/App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import SignalRPlugin from './plugins/signalr'

Vue.config.productionTip = false

Vue.use(SignalRPlugin)

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
