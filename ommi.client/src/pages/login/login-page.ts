import Vue from 'vue'
import { Component } from 'vue-property-decorator'

@Component
export default class LoginPage extends Vue {
  registerRequest = {
    username: '',
    password: ''
  }

  loginFailure = false

  onSubmit () {
    const requestOptions: RequestInit = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(this.registerRequest)
    }

    const baseUrl = process.env.VUE_APP_API_BASEURL
    return fetch(baseUrl + '/auth/login', requestOptions)
      .then(response => response.json())
      .then(data => {
        console.log(data.token)
        this.$store.commit('token', data.token)
        this.$router.push('/')
        this.$store.commit('signedIn', true)
      })
      .catch(() => {
        this.$store.commit('signedIn', false)
        this.showLoginError()
      })
  }

  showLoginError () {
    this.loginFailure = true

    setTimeout(() => {
      this.loginFailure = false
    }, 3000)
  }
}
