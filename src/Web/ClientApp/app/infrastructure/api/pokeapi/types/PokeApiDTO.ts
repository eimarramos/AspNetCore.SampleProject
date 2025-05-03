export type PokeApiDTO = {
  id: number
  pokedexNumber: number
  name: string
  weight: number
  height: number
  image: string,
  types: string[],
  stats: [{ value: number; name: string }]
}