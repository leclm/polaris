import { Endereco } from "./endereco.model";

export interface ClienteEdicao {
    clienteUuid?: string;
    nome: string;
    sobrenome: string;
    dataNascimento: string;
    email: string;
    telefone: string;
    endereco: Endereco
}