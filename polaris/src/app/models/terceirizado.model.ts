import { Endereco } from './endereco.model';

export interface Terceirizado {
    cnpj: string;
    empresa: string;
    email: string;
    telefone: string;
    endereco: Endereco;
    listaServicos: string[];
}