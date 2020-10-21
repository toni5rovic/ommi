<template>
  <v-container>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8">
        <drum-machine />
      </v-col>
      <v-col cols="12" sm="12">
        <v-spacer />
        <v-btn @click="showModalComponent()" color="primary">
          <v-icon>mdi-plus</v-icon>
          Add new track
        </v-btn>
        <AddTrackModal v-model="showModal" :addTrackCallback="addTrack"/>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import DrumMachine from '../../components/drum-machine-components/DrumMachine.vue'
import AddTrackModal from '../../components/add-track-modal.vue'
import { GET, POST } from '../../store/fetch.ts'
export default {
  name: 'Board',
  components: {
    DrumMachine,
    AddTrackModal
  },
  data () {
    return {
      showModal: false
    }
  },
  methods: {
    showModalComponent () {
      this.showModal = true
    },
    addTrack (soundName, instrumentName) {
      const trackToAdd = {
        boardStateId: this.$store.state.boardState.id,
        soundName: soundName,
        instrumentName: instrumentName,
        steps: [false, false, false, false,
          false, false, false, false,
          false, false, false, false,
          false, false, false, false],
        volume: 40
      }

      POST('/tracks', JSON.stringify(trackToAdd), true, this.$store.state.token)
        .then(response => response.json())
        .then(data => {
          this.$store.state.boardState.tracks.push(data)

          // Send updated board state to hub
          this.$sendUpdatedBoardState(this.$store.state.boardState, this.$store.state.roomName)
        })
    }
  },
  mounted () {
    GET('/boardstate/' + this.$store.state.roomName, true, this.$store.state.token)
      .then(response => response.json())
      .then(data => {
        this.$store.commit('setBoardState', data)
      })
      .catch(() => {
        console.log('Error! Room doesn\'t have a board state!')
      })
  }
}
</script>
