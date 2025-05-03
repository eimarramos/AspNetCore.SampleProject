import { getColor } from '~/utils/Colors/ColorsMapper'
import { FormatString } from '~/utils/StringFormater/StringFormater'
import { svgDictionary } from '~/utils/SvgDictionary/SvgDictionary'
import style from './Type.module.css'

type TypeProps = {
  name: string
}

export const TypeComponent: React.FC<TypeProps> = ({ name }) => {
  return (
    <div data-testid="pill" className={`${style.card_body_pills} ${getColor(name)}`}>
      {svgDictionary(name)}
      <p>{FormatString(name)}</p>
    </div>
  )
}
