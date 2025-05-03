import { EmptyIcon } from '~/assets/svg/EmptyIcon'
import style from './Empty.module.css'

export const EmptyComponent = () => (
  <article data-testid="componenteVacio" className={style.empty_container}>
    <EmptyIcon />
    <p>
      There is no results for "nonexistent"
    </p>
  </article>
)
