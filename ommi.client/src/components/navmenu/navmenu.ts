import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class NavMenuScript extends Vue {
  get isVisible () {
    return this.$store.state.showAppbar
  }

  signedin () {
    return this.$store.state.signedIn
  }

  goToLogin () {
    this.$router.push('/login')
  }

  root () {
    console.log(this.$router.currentRoute.path)
    if (this.$router.currentRoute.path !== '/') {
      this.$router.push('/')
      return
    }
    if (this.$store.state.signedIn) {
      this.$router.push('/')
    }
  }

  logout () {
    this.$store.commit('signedIn', false)
    this.$store.commit('token', null)
    this.root()
  }

  showMenu = false
}
