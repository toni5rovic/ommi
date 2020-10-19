<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <v-btn @click="TryAuth">
          Try Auth
          <v-icon>mdi-house</v-icon>
        </v-btn>
        <div>{{ authSuccess }}</div>

        <v-btn @click="callSignalR">
          Call Signal R
          <v-icon>mdi-tree</v-icon>
        </v-btn>
        <div> {{message}} </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { GET } from '../store/fetch'

export default Vue.extend({
  name: 'HelloWorld',
  data: () => ({
    authSuccess: '',
    message: ''
  }),
  mounted () {
    // Listen to score changes coming from SignalR events
    this.$ommiHub.$on('receiveMessage', this.receiveMessage)
  },
  methods: {
    TryAuth () {
      GET('/authtest', true, this.$store.state.token)
        .then(response => response.json())
        .then(() => {
          this.authSuccess = 'Success'
        })
        .catch(() => {
          this.authSuccess = 'Error. Not authorized.'
        })
    },

    callSignalR () {
      this.$activateSignalR()
    },

    receiveMessage (message: string) {
      this.message = message
    }
  }
})
</script>
