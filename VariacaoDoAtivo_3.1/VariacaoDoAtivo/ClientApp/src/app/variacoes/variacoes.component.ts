import { Component, OnInit } from '@angular/core';
import { VariacaoDataService } from '../_data-services/variacao.data-service';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-variacoes',
  templateUrl: './variacoes.component.html',
  styleUrls: ['./variacoes.component.css']
})
export class VariacoesComponent implements OnInit {

  variacoes: any[] = [];
  variacao: any = {};
  showList: boolean = true;
  identificacaoAtivo: string = "";
  intervalo: number = 1;
  range: string = "";
  possuiDados: boolean = false;

  constructor(
    private variacaoDataService: VariacaoDataService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.variacaoDataService.get().subscribe((dados: any[]) => {
      this.variacoes = dados;
      this.showList = true;

      if(this.variacoes.length > 0)
        this.possuiDados = true;
    }, erro => {
      this.toastr.warning('erro interno do sistema');
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
        this.variacaoDataService.post(this.identificacaoAtivo, this.intervalo, this.range).subscribe(d => {
      if (d == true) {
        this.toastr.success('Variação cadastrada com sucesso');
        this.get();
        this.variacao = {};
      }
      else {
        alert('Erro ao cadastrar');
      }
    }, erro => {
      console.log(erro);
      alert('erro interno do sistema');
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
        this.toastr.warning('Erro ao atualizar');
      }
    }, erro => {
      console.log(erro);
      this.toastr.warning('erro interno do sistema');
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
        this.toastr.warning('Erro ao excluir');
      }
    }, erro => {
      console.log(erro);
      this.toastr.warning('erro interno do sistema');
    })
  }

}
