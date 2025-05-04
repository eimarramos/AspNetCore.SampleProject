import { useState } from 'react'
import { ListComponent } from './components/List/List'
import { SearchComponent } from './components/SearchBar/SearchBar'
import { LoadingItemComponent } from './components/LoadingItem/LoadingItem'
import { ErrorComponent } from './components/Error/Error'
import { EmptyComponent } from './components/Empty/Empty'
import { useGetPokedexFetch } from './hooks/useFetchPokedex'
import { PaginationComponent } from './components/Pagination/Pagination'

export const HomeComponent = () => {
  const [currentPage, setCurrentPage] = useState<number>(1)
  const { pagination, isLoading, error } = useGetPokedexFetch(currentPage)
  const [filterText, setfilterText] = useState<string>('')

  const filterPokemons = (e: React.FormEvent<HTMLInputElement>) => {
    setfilterText(e.currentTarget.value)
  }

  const filteredPokemons = pagination.items.filter(pokemon =>
    pokemon.name.toLowerCase().includes(filterText.toLowerCase()) ||
    pokemon.types.some((type) => {
      return type.toLowerCase().includes(filterText.toLowerCase())
    })
  )

  const changePage = (page: number) => {
    setCurrentPage(page)
  }

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

      <PaginationComponent
        onChangePage={changePage} // Pasa la función al componente hijo
        hasNextPage={pagination.hasNextPage}
        hasPreviousPage={pagination.hasPreviousPage}
        pageNumber={pagination.pageNumber}
        totalCount={pagination.totalCount}
        totalPages={pagination.totalPages}
      />
    </>
  )
}
