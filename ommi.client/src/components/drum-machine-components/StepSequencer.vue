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
      <v-chip close label :key="track.soundName" class="ma-2 mr-1 pl-2 white--text" color="#705754" @click:close="remove(track)">
        {{ track.instrumentName }}
      </v-chip>
      <!-- <v-btn
        :key="track.soundName"
        :style="`grid-column: 1; grid-row: ${index+1};`"
        class="primary text-button ma-0 pt-1 pb-1"
      >
        {{ track.instrumentName }}
      </v-btn> -->
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
