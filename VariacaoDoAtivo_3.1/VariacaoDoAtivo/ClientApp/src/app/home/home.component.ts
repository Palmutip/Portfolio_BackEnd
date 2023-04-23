import { Component } from '@angular/core';
import { faNewspaper, faChartLine, faMoneyBillAlt } from '@fortawesome/free-solid-svg-icons';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  faNewspaper = faNewspaper;
  faChartLine = faChartLine;
  faMoneyBillAlt = faMoneyBillAlt;
  logoPng: string = './assets/images/Logo.png';

  constructor(
    private toastr: ToastrService
  ) { }

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
