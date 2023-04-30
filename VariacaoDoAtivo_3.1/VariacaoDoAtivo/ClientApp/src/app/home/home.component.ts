import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { faNewspaper, faChartLine, faMoneyBillAlt } from '@fortawesome/free-solid-svg-icons';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  faNewspaper = faNewspaper;
  faChartLine = faChartLine;
  faMoneyBillAlt = faMoneyBillAlt;
  logoPng: string = './assets/images/Logo.png';

  constructor(
    private toastr: ToastrService
  ) { }
  
  @ViewChild("MyCanvas", {static: true}) grafico: ElementRef

  ngOnInit(): void {
    console.log(this.grafico);
    new Chart(this.grafico.nativeElement, {
      type: 'line',
      data: {
        labels: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
        datasets: [
          {
            label: "valor 1",
            borderColor: "#88001b",
            fill: false,
            data: [52,46,75,39,85,67,49,52,74,25,12,54]
          },
          {
            label: "valor 2",
            borderColor: "#3f48cc",
            fill: false,
            data: [43,75,43,86,41,45,78,52,97,45,57,85]
          }
        ]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: 'Chart.js Line Chart'
          }
        }
      }
    });
  }

  ShowSuccess(){
    this.toastr.success('Este é um Toast para informar sucesso na operação', 'Sucesso');
  }
  ShowError(){
    this.toastr.error('Este é um Toast para informar erro na operação', 'Erro');
  }
  ShowWarning(){
    this.toastr.warning('Este é um Toast para informar um aviso referente à operação', 'Aviso');
  }
  ShowInformation(){
    this.toastr.info('Este é um Toast para informar uma mensagem referente à operação', 'Informação');
  }
}
