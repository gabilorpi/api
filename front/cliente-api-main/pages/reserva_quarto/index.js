import "bootstrap/dist/css/bootstrap.css";
import { useEffect, useState } from "react";
import axios from "axios";
import style from "../../styles/Home.module.css";
import Link from "next/link"; // Importe o Link para criar links de navegação

const Home = () => {
  const [clients, setClients] = useState([]);

  useEffect(() => {
    // Faça uma chamada GET para a API Spring Boot
    axios
      .get("http://apibuscadores.somee.com/api/reserva_quarto")
      .then((response) => {
        setClients(response.data);
      })
      .catch((error) => {
        console.error("Erro ao buscar a lista de quartos:", error);
      });
  }, []);

  return (
    <div>
      <h1 className={style.h1}>Lista de Reserva_Quarto</h1>
      <p>
        <Link href="categoria/add-voos" style={{ backgroundColor: "green" , color:'white', textDecoration:'none'}}>
          Cadastrar nova Reserva_Quarto
        </Link>
      </p>
      <table className="table container tabela">
        <thead>
          <tr>
            <th>Id_Reserva</th>
            <th>quartos</th>
            <th>Data_Checkout</th>
            <th>Data_Checkin</th>
            <th>Ações</th>{" "}
          </tr>
        </thead>
        {clients.map((element) => (
          <tbody key={element.id_Reserva}>
            <tr className={style.tabela}>
              <td>{element.idReserva}</td>
              <td>{element.quarto}</td>
              <td>{element.dataCheckOut}</td>
              <td>{element.dataCheckIn}</td>
              <td>
                <Link
                  href={`categoria/update-reserva/${element.id_Reserva}`}
                  className="btn btn-warning"
                >
                  Editar
                </Link>
                <Link
                  href={`categoria/delete-reserva/${element.id_Reserva}`}
                  className="btn btn btn-danger"
                >
                  Excluir
                </Link>
              </td>
            </tr>
          </tbody>
        ))}
      </table>
    </div>
  );
};

export default Home;
