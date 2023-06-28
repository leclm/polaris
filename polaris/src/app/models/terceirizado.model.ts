import { Endereco } from './endereco.model';

export interface Terceirizado {
    terceirizadoUuid?: string;
    cnpj: string;
    empresa: string;
    email: string;
    telefone: string;
    endereco: Endereco;
    listaServicos?: string[];
}