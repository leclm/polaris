import { Endereco } from "./endereco.model";
export interface Aluguel {
    dataInicio: string;
    dataDevolucao: string;
    tipoLocacao: number;
    desconto: number;
    valorTotalAluguel: number;
    clienteUuid?: string;
    endereco: Endereco;
    conteineresUuid: string[];    
}