import Link from 'next/link';
import styles from '../styles/Navbar.module.css';

const Navbar = () => {
  return (
    <nav className={styles.navbar}>
      <Link href="/agencia">Agencia</Link>
      <Link href="/cliente">Cliente</Link>
      <Link href="/contatos">Contatos</Link>
      <Link href="/hoteis">Hoteis</Link>
      <Link href="/passagem">Passagem</Link>
      <Link href="/reserva_quarto">Reserva_Quarto</Link>
      <Link href="/voos">Voos</Link>
    </nav>
  );
};

export default Navbar;
