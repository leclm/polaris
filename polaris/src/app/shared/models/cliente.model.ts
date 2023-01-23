export class Cliente {
  constructor(
    public nome?: string,
    public sobrenome?: string,
    public dataNascimento?: string,
    public cpf?: number,
    public email?: string,
    public cep?: number,
    public estado?: string,
    public cidade?: string,
    public endereco?: string,
    public numero?: number,
    public complemento?: string,
    public isActive?: boolean,
    public nomeEmpresa?: string ) {    
  }
}
