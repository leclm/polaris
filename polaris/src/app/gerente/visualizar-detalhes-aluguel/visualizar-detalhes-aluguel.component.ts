import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from '../services';
declare let pdfMake: any ;

@Component({
  selector: 'app-visualizar-detalhes-aluguel',
  templateUrl: './visualizar-detalhes-aluguel.component.html',
  styleUrls: ['./visualizar-detalhes-aluguel.component.scss']
})
export class VisualizarDetalhesAluguelComponent implements OnInit {
  public aluguelUuid: any;
  public aluguelData: any;
  public totalDays!: number;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute, private location: Location ) { }

  ngOnInit(): void {
    this.aluguelUuid = this.activatedRoute.snapshot.params['id'];
    this.getAllAlugueis();
    this.getAluguelById();
  }
  
  getAllAlugueis() {
    this.gerenteService.getAllAlugueis()
      .subscribe( (res: any) => {
        this.aluguelData = res;
      }
    );
  }
  
  convertStringToDate(dateString: string) {
    const dateParts = dateString.split(/[-/\.]/); // Split by "-" or "/" or "."
    const year = parseInt(dateParts[0]);
    const month = parseInt(dateParts[1]) - 1; // Subtract 1 as month index is zero-based
    const day = parseInt(dateParts[2]);
    const date = new Date(year, month, day);
    return date;
  }  

  calculateDaysBetweenDates(startDate: Date, endDate: Date): number {
    const oneDay = 24 * 60 * 60 * 1000; // Number of milliseconds in a day
    const start = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate());
    const end = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate());
    const diffInDays = Math.round(Math.abs((start.getTime() - end.getTime()) / oneDay));
    return diffInDays;
  }

  getAluguelById() {
    this.gerenteService.getAluguelById(this.aluguelUuid)
      .subscribe( (res: any) => {
        console.log(res)
        let dataInicioString = this.convertStringToDate(res.dataInicio);
        let dataDevolucaoString = this.convertStringToDate(res.dataDevolucao);    
        this.totalDays = this.calculateDaysBetweenDates(dataInicioString, dataDevolucaoString);
      }
    );
  }
   
  generatePdf(){
      this.gerenteService.getAluguelById(this.aluguelUuid).subscribe( (res: any) => {
          let dataInicioString = this.convertStringToDate(res.dataInicio);
          let dataDevolucaoString = this.convertStringToDate(res.dataDevolucao);    
          this.totalDays = this.calculateDaysBetweenDates(dataInicioString, dataDevolucaoString);

      const documentDefinition = { 


      content: [
        { text: "Contrato de Locação de Equipamento", style: "title" },
       
        `${res.cliente.nome} ${res.cliente.sobrenome}, CPF nº ${res.cliente.cpf}, com Endereço ${res.cliente.endereco.logradouro}, nº ${res.cliente.endereco.numero} na cidade de ${res.cliente.endereco.cidade} - ${res.cliente.endereco.estado}, doravante denominado LOCADOR e Contêineres SA, com sede na cidade de Curitiba - PR, estabelecida à Rua Dr. Alcides Vieira Arcoverde, 1225, bairro Jardim das Américas inscrita no CNPJ/MF sob o nº 52.634.977/0001-64, doravante denominada LOCATÁRIA, ambas as partes aqui representadas por quem de direito, têm justo e contratado entre si a locação do(s) equipamento(s) abaixo discriminado(s), mediante as cláusulas e condições estipuladas a seguir, salvo nos casos em que haja Convenção Coletiva que favoreça o LOCADOR. Neste caso, deve ser adotada a cláusula mais favorável ao LOCADOR. `,
        
        { text: "1. OBJETO E VALOR", style: "subtitle" },
        `Pelo presente instrumento o locador aluga à locatária o(s) equipamento(s) abaixo discriminado(s), e se obriga a locá-lo(s) nas condições estabelecidas neste contrato:`,

        {  
          table: {  
              headerRows: 1,  
              widths: ['*', 'auto', 'auto', 'auto','auto', 'auto', 'auto', 'auto'],  
              body: [  
                  ['Categoria', 'Cor', 'Material', 'Fabricação', 'Fabricante', 'Tipo', 'Volume', 'Valor Diária'], 
                  ...res.conteineres.map((c: { categoriaConteiner: { nome: any; }; cor: any; fabricacao: any; fabricante: any;material: any; tipoConteiner: { nome: any; volume: any; valorDiaria: any; }; }) => 
                  ([c.categoriaConteiner.nome, c.cor, c.material, c.fabricacao, c.fabricante, c.tipoConteiner.nome, c.tipoConteiner.volume+'m³', 'R$ '+c.tipoConteiner.valorDiaria])) 
  
              ]  
          }  
      } , 

        `1.1 O(s) equipamento(s) ora locado(S), será(ão) utilizado(s) pelo próprio Locador para exercer suas funções.`,

        { text: "2. ALUGUÉIS MENSAIS E VALOR TOTAL", style: "subtitle" },
        `2.1 A locatária pagará ao locador a quantia total de R$ ${res.valorTotalAluguel}. O aluguel constitui o pagamento pelo uso do(s) equipamento(s) e
        será devido a partir do dia da assinatura do presente.`,

        { text: "3. MANUTENÇÃO, ASSISTÊNCIA TÉCNICA E SEGURO", style: "subtitle" },
        `3.1 A manutenção do(s) equipamento(s), objeto(s) do presente contrato é de total responsabilidade da locatária durante o seu uso;
        3.2 A locatária deve manter o(s) o(s) equipamento(s) no seguro;
        3.3 Ao LOCADOR cabe manter o(s) equipamento(s) em perfeitas condições de uso e avisar imediatamente à LOCATÁRIA sobre eventuais problemas que impeçam o seu adequado funcionamento, para que esta tome as providências cabíveis.`,

        { text: "4. PRAZO DE VIGÊNCIA DO CONTRATO", style: "subtitle" },
        `4.1 O presente contrato tem duração de ${this.totalDays} dias, sendo vigente desde a data de início do aluguel em ${dataInicioString} até a data de devolução dos produtos alugados em ${dataDevolucaoString}`,
        
        { text: "5. RESCISÃO ", style: "subtitle" },
        `5.1 Qualquer uma das partes poderá rescindir o presente contrato a qualquer época, desde que comunique à outra, por escrito, com antecedência mínima de 30 (trinta) dias. `,        

        `Fica eleito o Foro da cidade de Curitiba, Estado de PR, como único competente, com renúncia a qualquer outro, por mais privilegiado que seja, para dirimir as questões que surgirem na execução do presente
        contrato. E por estarem justos e contratados assinam o presente contrato em 2 (duas) vias de igual teor e forma, para os mesmos efeitos, com as testemunhas a seguir: `,       

        `Local e data: _____________________________, ________ de ________________ de ________.`,        


        `1. Locador: __________________________________________________`,

        `2. Locatário: __________________________________________________`,     

        `Testemunhas: `,

        `1. __________________________________________________`, 

        `2. __________________________________________________`,   


      ],    styles: {  
        sectionHeader: {  
            bold: true,  
            decoration: 'underline',  
            fontSize: 14,  
            margin: [0, 15, 0, 15] ,
            color: 'blue'
        }  
    } 


     };
    pdfMake.createPdf(documentDefinition).open();



        }
      )


  }

  goBack(): void {
    this.location.back();
  }
}
