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
      .get("http://apibuscadores.somee.com/api/agencias")
      .then((response) => {
        setClients(response.data);
      })
      .catch((error) => {
        console.error("Erro ao buscar a lista de agencia:", error);
      });
  }, []);

  return (
    <div>
      <h1 className={style.h1}>Lista de Agências</h1>
      <p>
        <Link href="categoria/add-agencia" style={{ backgroundColor: "green" , color:'white', textDecoration:'none'}}>
          Cadastrar nova Agência
        </Link>
      </p>
      <table className="table container tabela">
        <thead>
          <tr>
            <th>Id_Agencia</th>
            <th>Nome_Agencia</th>
            <th>Cep</th>
            <th>Rua</th>
            <th>Bairro</th>
            <th>Telefone</th>
            <th>Ações</th>{" "}
          </tr>
        </thead>
        {clients.map((element) => (
          <tbody key={element.id_Agencia_Agencia}>
            <tr className={style.tabela}>
              <td>{element.idAgencia}</td>
              <td>{element.nomeAgencia}</td>
              <td>{element.cep}</td>
              <td>{element.rua}</td>
              <td>{element.bairro}</td>
              <td>{element.telefone}</td>
              <td>
                <Link
                  href={`categoria/update-agencia/${element.id_Agencia}`}
                  className="btn btn-warning"
                >
                  Editar
                </Link>
                <Link
                  href={`categoria/delete-agencia/${element.id_Agencia}`}
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
