import Vue from 'vue'
import Vuex from 'vuex'
import * as Tone from 'tone'
import { BoardState, Track } from '../classes'

Vue.use(Vuex)

let resumedAudioContext = false
const resumeAudioContext = () => {
  if (!resumedAudioContext) {
    Tone.context.resume()
    resumedAudioContext = true
  }
}

const soundNames = [
  'bass',
  'clap',
  'hat2',
  'hihat',
  'kick',
  'openhihat',
  'snare',
  'sub'
]

const store = new Vuex.Store({
  state: {
    signedIn: false,
    token: null,
    roomName: '',
    sounds: soundNames.map(name => ({
      name,
      buffer: null
    })),
    boardState: undefined,
    boardStateReady: false,
    // bpm: 65,
    on: false,
    currentStepIndex: 0
  },
  getters: {
    ready (state) {
      return state.boardState && (state.sounds
        .filter(({ buffer }) => buffer === null)
        .length) === 0
    }
  },
  mutations: {
    signedIn (state, value) {
      state.signedIn = value
    },
    token (state, value) {
      state.token = value
    },
    setRoomName (state, value) {
      state.roomName = value
    },
    setStep (state, newStepIndex) {
      if (newStepIndex > (state.boardState.numberOfSteps - 1)) {
        newStepIndex = 0
      }
      state.currentStepIndex = newStepIndex
    },
    setTrackStep (state, { track, step }) {
      const steps = state.boardState.tracks[track].steps.slice()
      steps[step] = !steps[step]
      state.boardState.tracks[track].steps = steps
    },
    setSound ({ sounds }, { name, buffer }) {
      const sound = sounds.find((s) => s.name === name)
      sound.buffer = buffer
    },
    setBPM (state, bpm) {
      state.boardState.bpm = bpm
    },
    toggleOn (state) {
      state.on = !state.on
    },
    setBoardState (state, boardState) {
      state.boardState = boardState
      state.boardStateReady = true
    }
  },
  actions: {
    fetchSounds ({ commit }) {
      soundNames.forEach(name => {
        const buffer = new Tone.Player(`sounds/${name}.wav`, () => {
          commit('setSound', {
            name,
            buffer
          })
        }).toDestination() // .toMaster()
      })
    },
    toggleOn ({ state, commit }) {
      resumeAudioContext()
      commit('toggleOn')
      if (state.on) {
        Tone.Transport.bpm.value = state.boardState.bpm
        Tone.Transport.start()
      } else {
        Tone.Transport.stop()
        commit('setStep', 0)
      }
    },
    setBPM ({ state, commit }, bpm) {
      resumeAudioContext()
      commit('setBPM', bpm)
      Tone.Transport.bpm.value = state.boardState.bpm
    }
  },
  modules: {
  }
})

store.dispatch('fetchSounds')

Tone.Transport.scheduleRepeat(function (time) {
  if (store.state.on) {
    store.state.boardState.tracks.forEach(({ steps, instrumentName }) => {
      const snd = store.state.sounds.find((s) => s.name === instrumentName)
      if (steps[store.state.currentStepIndex] === true) {
        // snd.buffer.volume.value = 50
        snd.buffer.start(time)
      }
    })
    store.commit('setStep', store.state.currentStepIndex + 1)
  }
}, '16n')

export default store
