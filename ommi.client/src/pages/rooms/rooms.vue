<template>
  <v-container>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="6">
        <v-layout align-center column justify-center>
          <v-btn @click="createRoom">
            Create Room
            <v-icon>mdi-plus</v-icon>
          </v-btn>
          <v-row v-if="loading == true" justify="center" class="pa-0 ma-0 text-center">
            <v-col cols="6" sm="7">
              <div>
                <v-progress-circular indeterminate color="primary">
                </v-progress-circular>
              </div>
            </v-col>
          </v-row>
          <v-row v-if="listOfRooms.length > 0 && loading == false" justify="center">
            <v-col v-for="room in this.listOfRooms" :key="room.id" cols="12" sm="12">
              <v-card class="mb-2" target="_blank">
                <v-container class="pa-0 ma-0">
                  <v-row class="pa-0 ma-0" justify="space-between">
                    <v-col class="pa-0 ma-0" col="11">
                      <v-list-item col="12" three-line dense>
                        <v-list-item-content class="pa-0">
                          <v-list-item-title class="mb-1">{{ room.name }}</v-list-item-title>
                        </v-list-item-content>
                      </v-list-item>
                    </v-col>
                    <v-col class="pa-0" cols="auto">
                      <div class="mt-5 mr-2">
                        <v-btn icon @click="joinRoom(room.name)">
                          <v-icon>mdi-location-enter</v-icon>
                        </v-btn>
                      </div>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card>
            </v-col>
          </v-row>
        </v-layout>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { GET } from '../../store/fetch'

export default {
  name: 'Rooms',

  data () {
    return {
      listOfRooms: Array,
      loading: false
    }
  },

  methods: {
    createRoom () {
      this.$router.push('/create-room')
    },
    joinRoom (roomName) {
      this.$store.commit('setRoomName', roomName)
      this.$connection.invoke('JoinGroupAsync', roomName)
    },
    joinedToTheRoom () {
      this.$router.push('/board')
    }
  },

  mounted () {
    // Listen to score changes coming from SignalR events
    this.$ommiHub.$on('joinedToTheRoom', this.joinedToTheRoom)

    this.loading = true
    GET('/rooms', true, this.$store.state.token)
      .then(response => response.json())
      .then(responseData => {
        this.loading = false
        this.listOfRooms = responseData
      })
      .catch(() => {
        this.listOfRooms = []
      })
  }
}
</script>
