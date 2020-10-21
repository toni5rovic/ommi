<template>
  <div class="container">
    <span class="bpm-text">
      Set current bpm
    </span>
  <input
    v-model="bpm"
    min="60"
    max="180"
    type="number"
    class="bpm"
  />
  </div>
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

<style scoped>
.bpm {
  color: #25ccf7;
  border: 2px solid #25ccf7;
  font-size: 18px;
  background: none;
  padding: 10px;
  border-radius: 2px;
  margin: 2px 4px;
  margin-right: 20px;
  align-self: center;
}
.bpm-text{
  font-size: 20px;
}
.container{
  flex: 100%;
}
</style>
