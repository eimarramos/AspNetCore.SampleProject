import { formatNumber } from '../../../../utils/NumberFormater/NumberFormater'
import style from './Stat.module.css'

type StatProps = {
  name: string
  value: number
}

export const StatComponent: React.FC<StatProps> = ({ name, value }) => {
  return (
    <div className={style.stat_container}>
      <div className={style.stat_name_value_container}>
        <p className={style.stat_container__stat_name}>{name}</p>
        <p className={style.stat_container__stat_value}>
          {formatNumber(value)}
        </p>
      </div>
      <progress max="255" value={value} className={style.bar_progress} />
    </div>
  )
}
