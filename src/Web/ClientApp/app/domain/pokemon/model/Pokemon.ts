export type Pokemon = {
  id: number
  name: string
  image: string
  weight: number
  height: number
  types: string[]
  stats: Stat[]
}

export type Stat = {
  name: string;
  value: number;
}
