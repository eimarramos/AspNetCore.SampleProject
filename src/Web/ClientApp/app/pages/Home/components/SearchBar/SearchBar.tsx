import style from './SearchBar.module.css'
import searchIcon from '../../../../assets/images/Search icon.png'

type StatProps = {
  filterPokemons: (event: React.FormEvent<HTMLInputElement>) => void
}

export const SearchComponent: React.FC<StatProps> = ({filterPokemons}) => {
  return (
      <label data-testid="searchLabel" className={style.search_bar}>
        <img
          src={searchIcon}
          alt="Search icon"
          className={style.search_bar__icon}
        />
        <input
          type="text"
          placeholder="Search a Pokémon"
          name="search"
          className={style.search_bar__input}
          onChange={filterPokemons}
        />
      </label>
  )
}
