import { Endereco } from "./endereco.model";

export interface Cliente {
    clienteUuid?: string;
    nome: string;
    sobrenome: string;
    cpf: string;
    dataNascimento: string;
    email: string;
    telefone: string;
    endereco: Endereco
}