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
      .get("http://apibuscadores.somee.com/api/hoteis")
      .then((response) => {
        setClients(response.data);
      })
      .catch((error) => {
        console.error("Erro ao buscar a lista de hoteis:", error);
      });
  }, []);

  return (
    <div>
      <h1 className={style.h1}>Lista de Hoteis</h1>
      <p>
        <Link href="categoria/add-hoteis" style={{ backgroundColor: "green" , color:'white', textDecoration:'none'}}>
          Cadastrar novo Hotel
        </Link>
      </p>
      <table className="table container tabela">
        <thead>
          <tr>
            <th>Id_Hotel</th>
            <th>PrecoPorNoite</th>
            <th>Categorias</th>
            <th>Nome_Hotel</th>
            <th>Cep</th>
            <th>Rua</th>
            <th>Bairro</th>
            <th>Telefone</th>
            <th>Ações</th>{" "}
          </tr>
        </thead>
        {clients.map((element) => (
          <tbody key={element.id_Hotel}>
            <tr className={style.tabela}>
              <td>{element.idHotel}</td>
              <td>{element.precoPorNoite}</td>
              <td>{element.categorias}</td>
              <td>{element.nomeHotel}</td>
              <td>{element.cep}</td>
              <td>{element.rua}</td>
              <td>{element.bairro}</td>
              <td>{element.telefone}</td>
              <td>
                <Link
                  href={`categoria/update-hotel/${element.id_Hotel}`}
                  className="btn btn-warning"
                >
                  Editar
                </Link>
                <Link
                  href={`categoria/delete-hotel/${element.id_Hotel}`}
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
