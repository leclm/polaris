import { ConteinerEstado } from "./conteinerEstado.model";
import { Servico } from "./servico.model";
import { Terceirizado } from "./terceirizado.model";

export interface PrestacaoServicoEstado {
    comentario: string;
    conteiner: ConteinerEstado;
    dataProcedimento: string;
    estadoPrestacaoServico: number;
    prestacaoDeServicoUuid: string;
    servico: Servico;
    terceirizado: Terceirizado;
}
   