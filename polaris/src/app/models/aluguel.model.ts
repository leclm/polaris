import { Cliente } from "./cliente.model";
import { Conteiner } from "./conteiner.model";
import { Endereco } from "./endereco.model";

export interface Aluguel {
    dataInicio: string;
    dataDevolucao: string;
    tipoLocacao: string;
    endereco: Endereco;
    cliente: Cliente;
    conteiner: Conteiner;
    valorTotal: string;
    desconto: string;
}