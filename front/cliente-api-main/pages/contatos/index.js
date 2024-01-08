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
      .get("http://apibuscadores.somee.com/api/contatos")
      .then((response) => {
        setClients(response.data);
      })
      .catch((error) => {
        console.error("Erro ao buscar a lista de contatos:", error);
      });
  }, []);

  return (
    <div>
      <h1 className={style.h1}>Lista de Contatos</h1>
      <p>
        <Link href="categoria/add-contatos" style={{ backgroundColor: "green" , color:'white', textDecoration:'none'}}>
          Cadastrar novo Contato
        </Link>
      </p>
      <table className="table container tabela">
        <thead>
          <tr>
            <th>Id_Contato</th>
            <th>Nome</th>
            <th>Email</th>
            <th>Telefone</th>
            <th>Mensagen</th>
            <th>Ações</th>{" "}
          </tr>
        </thead>
        {clients.map((element) => (
          <tbody key={element.id_Contato}>
            <tr className={style.tabela}>
              <td>{element.idContato}</td>
              <td>{element.nome}</td>
              <td>{element.email}</td>
              <td>{element.telefone}</td>
              <td>{element.mensagen}</td>
              <td>
                <Link
                  href={`categoria/update-contato/${element.id_Contato}`}
                  className="btn btn-warning"
                >
                  Editar
                </Link>
                <Link
                  href={`categoria/delete-contato/${element.id_Contato}`}
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
