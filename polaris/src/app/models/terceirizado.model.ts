import { Servico } from './servico.model';
import { Endereco } from './endereco.model';

export interface Terceirizado {
    id: string;
    cnpj: string;
    empresa: string;
    email: string;
    telefone: string;
    endereco: Endereco;
    servicos: Servico[];
}