import { Cliente } from "./cliente.model";
import { Conteiner } from "./conteiner.model";
import { Endereco } from "./endereco.model";

export interface Aluguel {
    dataInicio: string;
    dataDevolucao: string;
    tipoLocacao: number;
    endereco: Endereco;
    clienteUuid?: string;
    conteineresUuid: string[];
    valorTotalAluguel: number;
    desconto: number;
}