import { Cliente } from "./cliente.model";
import { Conteiner } from "./conteiner.model";
import { Endereco } from "./endereco.model";

export interface AluguelEstado {
    aluguelUuid: string;
    estadoAluguel: number;    
    dataInicio: string;
    dataDevolucao: string;
    tipoLocacao: number;
    desconto: number;
    valorTotalAluguel: number;
    latitude: number;
    longitude: number;
    status: boolean;
    cliente: Cliente;
    endereco: Endereco;
    conteineres: Conteiner[];    
}