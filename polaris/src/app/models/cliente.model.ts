import { Endereco } from "./endereco.model";

export interface Cliente {
    nome: string;
    sobrenome: string;
    cpf: string;
    dataNascimento: string;
    email: string;
    telefone: string;
    endereco: Endereco
}