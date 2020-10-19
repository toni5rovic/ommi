import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    signedIn: false,
    token: null
  },
  mutations: {
    signedIn (state, value) {
      state.signedIn = value
    },
    token (state, value) {
      state.token = value
    }
  },
  actions: {
  },
  modules: {
  }
})
