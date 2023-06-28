import { Categoria } from "./categoria.model";
import { Tipo } from "./tipo.model";

export interface ConteinerEstado {
    conteinerUuid: string;
    codigo: number;
    fabricacao: string;
    fabricante: string;
    material: string;
    cor: string;
    categoriaConteiner: Categoria;
    tipoConteiner: Tipo;
    
    estado: number;
    status: boolean;
}