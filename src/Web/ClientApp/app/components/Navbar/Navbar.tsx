import style from './Navbar.module.css'
import nav_icon from '~/assets/images/Pokeball.png'

export const NavbarComponent = () => (
  <header className={style.navbar}>
    <nav className={style.nav}>
      <ul>
        <li >
          <a href="#" className={style.nav__link} >
            <img src={nav_icon} alt="" className={style.nav__icon} />
            <h1 className={style.nav__title}>Pokédex</h1>
          </a>
        </li>
      </ul>
    </nav>
  </header>
)
