<template>
  <v-container>
    <v-text-field label="BPM" type="number" outlined v-model="bpm"></v-text-field>
  </v-container>
</template>

<script>
export default {
  name: 'BPM',
  computed: {
    bpm: {
      get () {
        if (this.$store.state.boardState === undefined) {
          return 90
        } else {
          return this.$store.state.boardState.tempoBPM
        }
      },
      set (val) {
        this.$store.dispatch('setBPM', val)

        // Send updated board state to hub
        this.$sendUpdatedBoardState(this.$store.state.boardState, this.$store.state.roomName)
      }
    }
  }
}
</script>
