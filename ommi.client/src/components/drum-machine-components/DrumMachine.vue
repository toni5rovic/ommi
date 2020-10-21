<template>
  <v-container class="mb-0 pb-0">
    <v-row>
      <v-col cols="5" class="mt-3">
        <p class="text-button">Current room is: <br />{{ this.$store.state.roomName }}</p>
      </v-col>
      <v-col cols="4" class="">
        <BPM />
      </v-col>
      <v-col cols="3" class="mt-1">
        <start-button />
      </v-col>
    </v-row>
    <div v-if="ready">
      <StepSequencer />
    </div>
  </v-container>
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
  },
  methods: {
    updateBoardState (newBoardState) {
      this.$store.commit('setBoardState', newBoardState)
    }
  },
  mounted () {
    // Listen to score changes coming from SignalR events
    this.$ommiHub.$on('updateBoardState', this.updateBoardState)
  }
}
</script>
