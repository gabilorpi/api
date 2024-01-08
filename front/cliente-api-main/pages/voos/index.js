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
      .get("http://apibuscadores.somee.com/api/voos")
      .then((response) => {
        setClients(response.data);
      })
      .catch((error) => {
        console.error("Erro ao buscar a lista de voos:", error);
      });
  }, []);

  return (
    <div>
      <h1 className={style.h1}>Lista de Voos</h1>
      <p>
        <Link href="categoria/add-voos" style={{ backgroundColor: "green" , color:'white', textDecoration:'none'}}>
          Cadastrar novo Voo
        </Link>
      </p>
      <table className="table container tabela">
        <thead>
          <tr>
            <th>Id_Voo</th>
            <th>Hora_Decolagem</th>
            <th>Data_Decolagem</th>
            <th>Hora_Aterrissagem</th>
            <th>Data_Aterrissagem</th>
            <th>Origem</th>
            <th>Destino</th>
            <th>Preco</th>
            <th>Ações</th>{" "}
          </tr>
        </thead>
        {clients.map((element) => (
          <tbody key={element.id_Voo}>
            <tr className={style.tabela}>
              <td>{element.idVoo}</td>
              <td>{element.horaDecolagem}</td>
              <td>{element.dataDecolagem}</td>
              <td>{element.horaAterrissagem}</td>
              <td>{element.dataAterrissagem}</td>
              <td>{element.origem}</td>
              <td>{element.destino}</td>
              <td>{element.preco}</td>
              <td>
                <Link
                  href={`categoria/update-voo/${element.id_Voo}`}
                  className="btn btn-warning"
                >
                  Editar
                </Link>
                <Link
                  href={`categoria/delete-voo/${element.id_Voo}`}
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
