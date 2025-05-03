import { useState } from 'react'
import { ListComponent } from './components/List/List'
import { SearchComponent } from './components/SearchBar/SearchBar'
import { LoadingItemComponent } from './components/LoadingItem/LoadingItem'
import { ErrorComponent } from './components/Error/Error'
import { EmptyComponent } from './components/Empty/Empty'
import { useGetPokemons } from './hooks/useFetchPokemons'

export const HomeComponent = () => {
  const { pokemons, isLoading, error } = useGetPokemons()
  const [filterText, setfilterText] = useState<string>('')

  const filterPokemons = (e: React.FormEvent<HTMLInputElement>) => {
    setfilterText(e.currentTarget.value)
  }

  const filteredPokemons = pokemons.filter(pokemon =>
    pokemon.name.toLowerCase().includes(filterText.toLowerCase()) || 
    pokemon.types.some((type) => {
      return type.toLowerCase().includes(filterText.toLowerCase())
    })
    ,
  )

  return (
    <>
      <SearchComponent filterPokemons={filterPokemons}></SearchComponent>

      {error && <ErrorComponent></ErrorComponent>}

      {!error && !isLoading && filteredPokemons.length === 0 && (
        <EmptyComponent />
      )}

      <ListComponent pokemons={filteredPokemons}>
        {isLoading &&
          Array.from({ length: 20 }, (_, index) => (
            <LoadingItemComponent key={index} />
          ))}
      </ListComponent>
    </>
  )
}
