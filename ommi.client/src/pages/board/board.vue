<template>
  <drum-machine />
</template>

<script>
import DrumMachine from '../../components/drum-machine-components/DrumMachine.vue'
import { GET } from '../../store/fetch.ts'
export default {
  name: 'Board',
  components: {
    DrumMachine
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
