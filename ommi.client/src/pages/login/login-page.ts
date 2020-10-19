import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import { POST } from '../../store/fetch'

@Component
export default class LoginPage extends Vue {
  registerRequest = {
    username: '',
    password: ''
  }

  loginFailure = false

  onSubmit () {
    POST('/auth/login', this.registerRequest, false, '')
      .then(response => response.json())
      .then(data => {
        this.$store.commit('token', data.token)
        this.$store.commit('signedIn', true)
        this.$connectSignalR()
        this.$router.push('/rooms')
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
