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
      <h2
        :key="track.instrumentName"
        :style="`grid-column: 1; grid-row: ${index+1};`"
        class="st-name"
      >
        {{ track.instrumentName }}
      </h2>
      <step
        v-for="(step, stepIndex) in track.steps"
        :key="`${track.instrumentName}-${stepIndex}`"
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
  grid-template-columns: 155px repeat(16, auto);
  border: 1px solid #555;
  margin: 0px 20px 20px;
}
.st-name {
  background: linear-gradient(#292929, #111);
  border: 1px solid #555;
  color: white;
  font-size: 14px;
  margin: 0px;
  vertical-align: middle;
  padding: 0px 10px;
  line-height: 50px;
}
</style>
