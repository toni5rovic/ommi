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
              <v-list-item-icon>
                <v-icon v-text="item.icon"></v-icon>
              </v-list-item-icon>
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
    selectedItem: 1,
    instruments: [
      { instrumentName: 'Bass', soundName: 'bass', icon: 'mdi-guitar-acoustic' },
      { instrumentName: 'Clap', soundName: 'clap', icon: 'mdi-guitar-acoustic' },
      { instrumentName: 'HiHat 1', soundName: 'hihat', icon: 'mdi-guitar-acoustic' },
      { instrumentName: 'HiHat 2', soundName: 'hat2', icon: 'mdi-guitar-acoustic' },
      { instrumentName: 'Kick', soundName: 'kick', icon: 'mdi-guitar-acoustic' },
      { instrumentName: 'Open HiHat', soundName: 'openhihat', icon: 'mdi-guitar-acoustic' },
      { instrumentName: 'Snare', soundName: 'snare', icon: 'mdi-guitar-acoustic' },
      { instrumentName: 'Sub', soundName: 'sub', icon: 'mdi-guitar-acoustic' }
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
    addSelectedTrack () {
      const selectedTrack = this.instruments[this.selectedItem]
      this.addTrackCallback(selectedTrack.soundName, selectedTrack.instrumentName)
      this.show = false
    }
  }
}
</script>
