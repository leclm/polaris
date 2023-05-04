import { Categoria } from "./categoria.model";
import { Tipo } from "./tipo.model";

export interface ConteinerEstado {
    categoria: Categoria;
    codigo: number;
    conteinerUuid: string;
    cor: string;
    estado: number;
    fabricacao: string;
    fabricante: string;
    material: string;
    status: boolean;
    tipo: Tipo;
}