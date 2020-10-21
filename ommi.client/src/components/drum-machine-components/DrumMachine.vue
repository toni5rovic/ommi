<template>
  <v-container class="mb-0 pb-0">
    <v-row :align="center">
      <div class="col-5" :align-self="align">
        <h3>Current room is: {{ this.$store.state.roomName }}</h3>
      </div>
      <v-col cols="4" :align-self="center">
        <BPM />
      </v-col>
      <v-col cols="4" class="ma-1 ml-5 pl-5" :align-self="center">
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
