import { Component, OnInit } from '@angular/core';
import { UsuarioDataService } from '../_data-services/usuario.data-service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

    usuarios: any[] = [];
    usuario: any = {};
    usuarioLogin: any = {};
    usuarioLogado: any = {};
    showList: boolean = true;
    isAuthenticate: boolean = false;

    constructor(private usuarioDataService: UsuarioDataService) { }

    ngOnInit() {
        
  }

    get() {
        this.usuarioDataService.get().subscribe((dados:any[]) => {
            this.usuarios = dados;
            this.showList = true;
        }, erro => {
            alert('erro interno do sistema');
        })
    }

    save() {
        if (this.usuario.id) {
            this.put();
        }
        else {
            this.post();
        }
    }

    openDetalhes(usuario) {
        this.showList = false;
        this.usuario = usuario;
    }

    post() {
        this.usuarioDataService.post(this.usuario).subscribe(d => {
            if (d == true) {
                //alert('Usuário cadastrado com sucesso');
                this.get();
                this.usuario = {};
            }
            else {
                alert('Erro ao cadastrar usuário');
            }
        }, erro => {
            console.log(erro);
            alert('erro interno do sistema');
        })
    }

    put() {
        this.usuarioDataService.put(this.usuario).subscribe(d => {
            if (d == true) {
                //alert('Usuário atualizado com sucesso');
                this.get();
                this.usuario = {};
            }
            else {
                alert('Erro ao atualizar usuário');
            }
        }, erro => {
            console.log(erro);
            alert('erro interno do sistema');
        })
    }

    delete(usuario) {
        this.usuarioDataService.delete().subscribe(d => {
            if (d == true) {
                //alert('Usuário excluido com sucesso');
                this.get();
                this.usuario = {};
            }
            else {
                alert('Erro ao excluir usuário');
            }
        }, erro => {
            console.log(erro);
            alert('erro interno do sistema');
        })
    }

    autenticar() {
        this.usuarioDataService.autenticar(this.usuarioLogin).subscribe((d: any) => {
            //debugger;
            if (d.usuario) {
                localStorage.setItem('token_usuario', JSON.stringify(d));
                this.get();
                this.getDadosUsuario();
            }
            else {
                alert('Usuário inválido.');
            }
        }, erro => {
            console.log(erro);
            alert('erro interno do sistema');
        })
    }

    getDadosUsuario() {
        this.usuarioLogado = JSON.parse(localStorage.getItem('token_usuario'))
        this.isAuthenticate = this.usuarioLogado != null;
    }
}
