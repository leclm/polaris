import { Endereco } from "./endereco.model";
import { LoginEdicaoCadastro } from "./loginEdicaoCadastro.model";

export interface ClienteLogin {
    clienteUuid?: string;
    nome: string;
    sobrenome: string;
    cpf: string;
    dataNascimento: string;
    email: string;
    telefone: string;
    endereco: Endereco;
    login: LoginEdicaoCadastro;
}