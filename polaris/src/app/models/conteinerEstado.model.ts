import { Categoria } from "./categoria.model";
import { Tipo } from "./tipo.model";

export interface ConteinerEstado {
    categoriaConteiner: Categoria;
    codigo: number;
    conteinerUuid: string;
    cor: string;
    estado: number;
    fabricacao: string;
    fabricante: string;
    material: string;
    status: boolean;
    tipoConteiner: Tipo;
}