import style from './ListItem.module.css'
import { StatComponent } from '../Stat/Stat'
import type { Pokemon } from '~/domain/pokemon/model/Pokemon'
import { Weight } from '~/assets/svg/Weight'
import { Ruler } from '~/assets/svg/Ruler'
import { getColor } from '~/utils/Colors/ColorsMapper'
import { TypeComponent } from '../Type/Type'
import { formatNumber } from '~/utils/NumberFormater/NumberFormater'
import { FormatString } from '~/utils/StringFormater/StringFormater'

type ListItemProps = {
  pokemon: Pokemon
}

export const ListItemComponent: React.FC<ListItemProps> = ({ pokemon }) => {
  return (
    <article
      data-testid="pokemonCard"
      className={`${style.pokemon_card} ${getColor(pokemon.types[0])}`}
    >
      <header className={style.card_header}>
        <h3 className={style.card_header__name}>
          {pokemon.name}
        </h3>
        <p className={style.card_header_id}>#{formatNumber(pokemon.id)}</p>
      </header>
      <section className={style.card_body}>
        <div className={style.card_body__image_container}>
          <img className={style.card_body__image} src={pokemon.image} alt="" />
        </div>
        <div className={style.card_body__types}>
          {pokemon.types.map((type, index) => {
            return <TypeComponent key={index} name={type} />
          })}
        </div>
        <div className={style.card_body__measures_container}>
          <div className={style.card_body_measures}>
            <Weight />
            <p>{pokemon.weight} kg</p>
          </div>
          <hr className={style.card_body_measures__separator} />
          <div className={style.card_body_measures}>
            <Ruler />
            <p>{pokemon.height} m</p>
          </div>
        </div>
        <div className={style.card_body__stats}>
          {pokemon.stats.map((stat, index) => {
            return (
              <StatComponent key={index} name={stat.name} value={stat.value} />
            )
          })}
        </div>
      </section>
    </article>
  )
}
