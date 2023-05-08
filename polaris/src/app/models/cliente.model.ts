import { Endereco } from "./endereco.model";
import { Login } from "./login.model";

export interface Cliente {
    nome: string;
    sobrenome: string;
    cpf: string;
    dataNascimento: string;
    email: string;
    telefone: string;
    endereco: Endereco,
    login: Login
}