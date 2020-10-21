<template>
<v-container>
  <v-row align="center" justify="center">
    <v-col cols="12" sm="6">
      <v-layout align-center column justify-center>
        <v-card class>
          <v-card-text>
            <v-text-field label="Email" v-model="registerRequest.email" />
            <v-text-field label="Username" v-model="registerRequest.username" />
            <v-text-field label="Password" type="password" v-model="registerRequest.password" />
            <v-text-field label="Confirm password" type="password" v-model="registerRequest.confirmPassword" />
            <v-alert type="error" v-if="confirmPasswordError">Passwords don't match.</v-alert>
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn @click="onSubmit">Sign up</v-btn>
          </v-card-actions>
          <v-alert type="error" v-if="registrationError">Registration failed, try again</v-alert>
        </v-card>
        <p class="message">
          Already registered? <router-link to="login">Login</router-link>
        </p>
      </v-layout>
    </v-col>
  </v-row>
</v-container>
</template>

<script>
import { POST } from '../store/fetch'

export default {
  name: 'Register',
  data () {
    return {
      registerRequest: {
        email: '',
        username: '',
        password: '',
        confirmPassword: ''
      },
      registrationError: false,
      confirmPasswordError: false
    }
  },
  methods: {
    onSubmit () {
      if (this.registerRequest.password !== this.registerRequest.confirmPassword) {
        this.showPasswordNotMatchingError()
        return
      }

      POST('/auth/register', this.registerRequest, false, '')
        .then(response => response.json())
        .then(_ => {
          this.$router.push('/login')
        })
        .catch(() => {
          this.showRegistrationError()
        })
    },

    showRegistrationError () {
      this.registrationError = true

      setTimeout(() => {
        this.registrationError = false
      }, 3000)
    },

    showPasswordNotMatchingError () {
      this.confirmPasswordError = true

      setTimeout(() => {
        this.confirmPasswordError = false
      }, 3000)
    }
  }
}
</script>
