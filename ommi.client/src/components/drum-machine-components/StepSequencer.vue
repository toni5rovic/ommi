<template>
  <div class="steps">
    <div
      v-if="on"
      :style="`grid-column: ${currentStepIndex + 2}; grid-row: 1 / span 9;`"
      class="step-indicator"
    />
    <template
      v-for="(track, index) in boardState.tracks"
    >
      <v-chip close label :key="track.soundName" class="ma-2 mr-1 pl-2 white--text" color="#545C60" @click:close="remove(track)">
        {{ track.instrumentName }}
      </v-chip>
      <step
        v-for="(step, stepIndex) in track.steps"
        :key="`${track.soundName}-${stepIndex}`"
        :track="index"
        :on="step"
        :doubled="step === true"
        :index="stepIndex"
        :style="`grid-column: ${stepIndex + 2}; grid-row: ${index+1};`"
      />
    </template>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import Step from './Step.vue'
export default {
  components: {
    Step
  },
  methods: {
    remove (track) {
      console.log(track.instrumentName)
    }
  },
  computed: {
    ...mapState(['on', 'currentStepIndex', 'boardState'])
  }
}
</script>

<style scoped>
.step-indicator {
  background: #00ff0020;
}
.steps {
  display: grid;
  grid-template-columns: 120px repeat(16, auto);
  margin: 0px 20px 20px;
}
</style>
