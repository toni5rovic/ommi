<template>
  <v-container>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="6">
        <v-layout align-center column justify-center>
          <v-card class>
            <v-card-text>
              <v-text-field label="Room name" v-model="roomName" />
            </v-card-text>
            <v-card-actions>
              <v-spacer />
              <v-btn @click="onSubmit">Create Room</v-btn>
            </v-card-actions>
            <v-alert type="error" v-if="roomNameExistsError"
            >
            Room with given name already exists. Please pick another name.
            </v-alert>
            <v-row v-if="roomBeingCreated == true" justify="center" class="pa-0 ma-0 text-center">
              <v-col cols="6" sm="7">
                <div>
                  <v-progress-circular indeterminate color="primary">
                  </v-progress-circular>
                </div>
              </v-col>
            </v-row>
          </v-card>
        </v-layout>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { GET } from '../../store/fetch'

export default {
  name: 'CreateRoom',
  data () {
    return {
      roomName: '',
      roomNameExistsError: false,
      roomBeingCreated: false
    }
  },

  mounted () {
    // Listen to score changes coming from SignalR events
    this.$ommiHub.$on('roomCreated', this.roomCreated)
  },

  methods: {
    onSubmit () {
      this.checkIfRoomExists(this.roomName)
    },

    checkIfRoomExists (roomName: string) {
      const url = '/rooms/' + roomName
      this.roomBeingCreated = true
      GET(url, true, this.$store.state.token)
        .then(response => response.json())
        .then(data => {
          if (data != null) {
            this.roomBeingCreated = false
            this.showRoomExistsError()
          }
        })
        .catch(() => {
          // Room doesn't exist. It will be created.
          // After creation, user is redirected to the board page
          this.roomBeingCreated = false
          this.$connection.invoke('CreateAndJoinGroupAsync', this.roomName)
        })
    },

    roomCreated (roomName: string) {
      this.roomBeingCreated = false
      this.$store.commit('setRoomName', roomName)
      this.$router.push('/board')
    },

    showRoomExistsError () {
      this.roomNameExistsError = true

      setTimeout(() => {
        this.roomNameExistsError = false
      }, 3000)
    }
  }
}

</script>
