import { Component, ElementRef, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { VariacaoDataService } from '../_data-services/variacao.data-service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-variacoes',
  templateUrl: './variacoes.component.html',
  styleUrls: ['./variacoes.component.css']
})
export class VariacoesComponent implements OnInit, AfterViewInit  {

  variacoes: any[] = [];
  variacao: any = {};
  variacaoRequest: any = {};
  showList: boolean = true;
  identificacaoAtivo: string = "";
  intervalo: number = 1;
  range: string = "";
  possuiDados: boolean = false;

  constructor(
    private variacaoDataService: VariacaoDataService,
    private toastr: ToastrService
  ) { }

  //@ViewChild("ChartPercent", {static: false}) chartPercent: ElementRef
  //@ViewChild("ChartValues", {static: false}) chartValues: ElementRef

  ngOnInit() {
    this.get();
  }

  ngAfterViewInit() {
    //this.get();
    // console.log(this.possuiDados);
    // //this.possuiDados = true;
    // console.log(this.chartPercent);
    // console.log(this.chartValues);

    // if(this.possuiDados)
    //   this.displayCharts();
  }

  get() {
    this.variacaoDataService.get().subscribe((dados: any[]) => {
      this.variacoes = dados;
      this.showList = true;
      //this.displayCharts();

      if(this.variacoes.length > 0)
        this.possuiDados = true;
    }, erro => {
      this.toastr.error('erro interno do sistema');
    })
  }

  save() {  
    if (this.variacao.id) {
      this.put();
    }
    else {
      this.post();
    }
  }

  post() {
        this.variacaoDataService.post(this.variacaoRequest).subscribe(d => {
      if (d == true) {
        this.toastr.success('Variação cadastrada com sucesso');
        this.get();
        this.variacao = {};
      }
      else {
        this.toastr.error('Erro ao cadastrar');
      }
    }, erro => {
      try{
        this.toastr.error(erro.error.toString().split('\r\n')[0].replace('System.Exception: ', ''), 'Erro');
      }
      catch(error){
        this.toastr.error('erro interno do sistema');
      }
    })
  }

  put() {
    this.variacaoDataService.put(this.variacao).subscribe(d => {
      if (d == true) {
        this.toastr.success('Variação atualizada com sucesso');
        this.get();
        this.variacao = {};
      }
      else {
        this.toastr.error('Erro ao atualizar');
      }
    }, erro => {
      this.toastr.error('erro interno do sistema');
    })
  }

  delete() {
    this.variacaoDataService.delete().subscribe(d => {
      if (d == true) {
        this.toastr.success('Variação excluida com sucesso');
        this.get();
        this.variacao = {};
        this.possuiDados = false;
      }
      else {
        this.toastr.error('Erro ao excluir');
      }
    }, erro => {
      this.toastr.error('erro interno do sistema');
    })
  }

  displayCharts(){
    //debugger;
    //console.log(this.chartPercent);
    // new Chart(this.chartPercent.nativeElement, {
    //   type: 'line',
    //   data: {
    //     labels: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
    //     datasets: [
    //       {
    //         label: "valor 1",
    //         borderColor: "#88001b",
    //         fill: false,
    //         data: [52,46,75,39,85,67,49,52,74,25,12,54]
    //       },
    //       {
    //         label: "valor 2",
    //         borderColor: "#3f48cc",
    //         fill: false,
    //         data: [43,75,43,86,41,45,78,52,97,45,57,85]
    //       }
    //     ]
    //   },
    //   options: {
    //     responsive: true,
    //     plugins: {
    //       legend: {
    //         position: 'top',
    //       },
    //       title: {
    //         display: true,
    //         text: 'Chart.js Line Chart'
    //       }
    //     }
    //   }
    // });
    // new Chart(this.chartValues.nativeElement, {
    //   type: 'line',
    //   data: {
    //     labels: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
    //     datasets: [
    //       {
    //         label: "valor 1",
    //         borderColor: "#88001b",
    //         fill: false,
    //         data: [52,46,75,39,85,67,49,52,74,25,12,54]
    //       },
    //       {
    //         label: "valor 2",
    //         borderColor: "#3f48cc",
    //         fill: false,
    //         data: [43,75,43,86,41,45,78,52,97,45,57,85]
    //       }
    //     ]
    //   },
    //   options: {
    //     responsive: true,
    //     plugins: {
    //       legend: {
    //         position: 'top',
    //       },
    //       title: {
    //         display: true,
    //         text: 'Chart.js Line Chart'
    //       }
    //     }
    //   }
    // });
  }
}
