<template>
  <button
    class="step"
    :style="style"
    @click="onClick"
  />
</template>

<script>
export default {
  props: {
    on: {
      type: Boolean
    },
    index: {
      type: Number
    },
    doubled: {
      type: Boolean
    },
    track: {
      type: Number
    }
  },
  computed: {
    style () {
      // const offsetColor = (this.index > 3 && this.index < 8) || (this.index > 11 && this.index < 16)
      const offsetColor = (this.index % 8 >= 4)
      return {
        background: offsetColor ? '#545C60' : '#705754',
        opacity: this.on ? 1 : 0.35
      }
    }
  },
  methods: {
    onClick () {
      this.$store.commit('setTrackStep', {
        track: this.track,
        step: this.index
      })

      // Send updated board state to hub
      this.$sendUpdatedBoardState(this.$store.state.boardState, this.$store.state.roomName)
    }
  }
}
</script>

<style>
@keyframes flash {
  0% {
    opacity: 0.5;
  }
  50% {
    opacity: 1;
  }
  100% {
    opacity: 0.5
  }
}
.step {
  border-radius: 2px;
  margin: 2px;
}
</style>
