export class Track {
  steps: boolean[]
  volume: Number
  instrumentName: string
}

export class BoardState {
  volume: Number
  tempoBPM: Number
  numberOfSteps: Number
  tracks: Track[]
}
