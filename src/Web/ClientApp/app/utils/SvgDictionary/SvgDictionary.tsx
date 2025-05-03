import type { ReactNode } from 'react'
import { BugIcon } from '../../assets/svg/BugIcon'
import { DarkIcon } from '../../assets/svg/DarkIcon'
import { DragonIcon } from '../../assets/svg/DragonIcon'
import { ElectricIcon } from '../../assets/svg/ElectricIcon'
import { FairyIcon } from '../../assets/svg/FairyIcon'
import { FightingIcon } from '../../assets/svg/FightingIcon'
import { FireIcon } from '../../assets/svg/FireIcon'
import { FlyingIcon } from '../../assets/svg/FlyingIcon'
import { GhostIcon } from '../../assets/svg/GhostIcon'
import { GrassIcon } from '../../assets/svg/GrassIcon'
import { GroundIcon } from '../../assets/svg/Ground'
import { NormalIcon } from '../../assets/svg/NormalIcon'
import { PoisonIcon } from '../../assets/svg/Poison'
import { PyschiclonIcon } from '../../assets/svg/PsychicIcon'
import { RockIcon } from '../../assets/svg/RockIcon'
import { SteelIcon } from '../../assets/svg/SteelIcon'
import { WaterIcon } from '../../assets/svg/WaterIcon'
import { IceIcon } from '../../assets/svg/IceIcon'

export const svgDictionary = (key: string) => {
  const dictionary: Record<string, ReactNode> = {
    bug: <BugIcon />,
    dark: <DarkIcon />,
    dragon: <DragonIcon />,
    electric: <ElectricIcon />,
    fairy: <FairyIcon />,
    fighting: <FightingIcon />,
    fire: <FireIcon />,
    flying: <FlyingIcon />,
    ghost: <GhostIcon />,
    grass: <GrassIcon />,
    ground: <GroundIcon />,
    normal: <NormalIcon />,
    poison: <PoisonIcon />,
    psychic: <PyschiclonIcon />,
    rock: <RockIcon />,
    steel: <SteelIcon />,
    water: <WaterIcon />,
    ice: <IceIcon />,
  }

  return dictionary[key]
}
