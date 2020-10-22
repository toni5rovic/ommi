<template>
  <v-dialog v-model="show" max-width="500px">
    <v-card raised>
      <v-card-title class="headline blue darken-2 white--text" primary-title>
        Add new track to the board
      </v-card-title>

      <v-divider></v-divider>

      <v-card-text class="mt-2">
        <v-list shaped dense>
          <v-subheader>Instruments</v-subheader>
          <v-list-item-group
            v-model="selectedItem"
            color="primary"
          >
            <v-list-item
              v-for="(item, itemIndex) in instruments"
              :key="itemIndex"
            >
              <v-list-item-avatar size="40">
                <!-- <v-img max-height="80%" contain :src="item.icon"></v-img> -->
                <!-- <v-img :src="item.icon" max-height="25px" /> -->
                <img v-bind:src="getImgUrl(item.icon)" >
                <!-- <img src="../assets/bass-guitar.svg" > -->
              </v-list-item-avatar>
              <v-list-item-content>
                <v-list-item-title v-text="item.instrumentName"></v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-card-text>

      <v-divider></v-divider>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="addSelectedTrack">OK</v-btn>
        <v-btn color="primary" @click="show=false">Close</v-btn>
      </v-card-actions>
      <v-alert type="error" v-if="trackAlreadyExistsError">Selected track already exists. Please choose another one.</v-alert>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: 'AddTrackModal',
  props: {
    value: Boolean,
    addTrackCallback: Function
  },
  data: () => ({
    trackAlreadyExistsError: false,
    selectedItem: 1,
    instruments: [
      { instrumentName: 'Bass', soundName: 'bass', icon: 'bass-guitar.svg' },
      { instrumentName: 'Clap', soundName: 'clap', icon: 'clapping.svg' },
      { instrumentName: 'HiHat 1', soundName: 'hihat', icon: 'hi-hat.svg' },
      { instrumentName: 'HiHat 2', soundName: 'hat2', icon: 'hi-hat.svg' },
      { instrumentName: 'Kick', soundName: 'kick', icon: 'karate.svg' },
      { instrumentName: 'Open HiHat', soundName: 'openhihat', icon: 'open-hi-hat.svg' },
      { instrumentName: 'Snare', soundName: 'snare', icon: 'snare.svg' },
      { instrumentName: 'Sub', soundName: 'sub', icon: 'tom.svg' }
    ]
  }),
  computed: {
    show: {
      get () {
        return this.value
      },
      set (value) {
        this.$emit('input', value)
      }
    }
  },
  methods: {
    getImgUrl (imgName) {
      return require('../assets/' + imgName)
    },
    addSelectedTrack () {
      const selectedTrack = this.instruments[this.selectedItem]
      if (this.trackAlreadyExists(selectedTrack.soundName)) {
        this.showTrackAlreadyExistsError()
        return
      }

      this.addTrackCallback(selectedTrack.soundName, selectedTrack.instrumentName)
      this.show = false
    },

    trackAlreadyExists (soundName) {
      for (let i = 0; i < this.$store.state.boardState.tracks.length; i++) {
        const track = this.$store.state.boardState.tracks[i]
        if (track.soundName === soundName) {
          return true
        }
      }

      return false
    },

    showTrackAlreadyExistsError () {
      this.trackAlreadyExistsError = true

      setTimeout(() => {
        this.trackAlreadyExistsError = false
      }, 3000)
    }
  }
}
</script>
