<template>
  <div class="container">
    <div class="transport">
      <div>{{ this.$store.state.roomName }}</div>
      <BPM />
      <start-button />
    </div>
    <div v-if="ready">
      <StepSequencer />
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import StartButton from './StartButton.vue'
import BPM from './BPM.vue'
import StepSequencer from './StepSequencer.vue'

export default {
  components: {
    StartButton,
    BPM,
    StepSequencer
  },
  computed: {
    ...mapGetters(['ready'])
  }
}
</script>

<style>
/* .container {
  max-width: 800px;
  margin: auto;
  background: linear-gradient(to bottom right, #222, #0a0a0a);
  border: 2px solid black;
  border-radius: 4px;
  margin-top: 20px;
} */
.transport {
  display: grid;
  grid-template-columns: 50% 25% 25%;
}
.button-container {
  display: grid;
  grid-template-columns: 25% 25% 25% 25%;
  padding: 0px 20px 10px;
}
</style>
