<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <v-btn @click="TryAuth">
          Try Auth
          <v-icon>mdi-house</v-icon>
        </v-btn>
        <div>{{ authSuccess }}</div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({
  name: 'HelloWorld',
  data: () => ({
    authSuccess: ''
  }),
  methods: {
    TryAuth () {
      const requestOptions: RequestInit = {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + this.$store.state.token
        }
      }

      const baseUrl = process.env.VUE_APP_API_BASEURL
      return fetch(baseUrl + '/authtest', requestOptions)
        .then(response => response.json())
        .then(data => {
          this.authSuccess = 'Success'
        })
        .catch(() => {
          this.authSuccess = 'Error. Not authorized.'
        })
    }
  }
})
</script>
