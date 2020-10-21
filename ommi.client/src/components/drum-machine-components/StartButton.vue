<template>
  <v-btn large :class="buttonStyle" @click="togglePlay">
    <v-icon>
      {{ on ? 'mdi-stop' : 'mdi-play' }}
    </v-icon>
    {{ on ? 'Stop' : 'Play' }}
  </v-btn>
</template>

<script>
import { mapState } from 'vuex'
export default {
  computed: {
    ...mapState(['on']),
    buttonStyle () {
      return this.on ? 'error' : 'primary'
    }
  },
  methods: {
    togglePlay () {
      this.$store.dispatch('toggleOn')
    }
  }
}
</script>
