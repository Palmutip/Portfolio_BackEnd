import { Component, OnInit } from '@angular/core';
import { UsuarioDataService } from '../_data-services/usuario.data-service';
import { ToastrModule, ToastrService } from 'ngx-toastr';

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

    constructor(
        private usuarioDataService: UsuarioDataService,
        private toastr: ToastrService
    ) { }

    ngOnInit() {

    }

    get() {
        this.usuarioDataService.get().subscribe((dados: any[]) => {
            this.usuarios = dados;
            this.showList = true;
        }, erro => {
            this.toastr.warning('erro interno do sistema');
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
                this.toastr.success('Usuário cadastrado com sucesso');
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
                this.toastr.success('Usuário atualizado com sucesso');
                this.get();
                this.usuario = {};
            }
            else {
                this.toastr.warning('Erro ao atualizar usuário');
            }
        }, erro => {
            console.log(erro);
            this.toastr.warning('erro interno do sistema');
        })
    }

    delete() {
        this.usuarioDataService.delete().subscribe(d => {
            if (d == true) {
                this.toastr.success('Usuário excluido com sucesso');
                this.get();
                this.usuario = {};
            }
            else {
                this.toastr.warning('Erro ao excluir usuário');
            }
        }, erro => {
            console.log(erro);
            this.toastr.warning('erro interno do sistema');
        })
    }

    autenticar() {
        this.usuarioDataService.autenticar(this.usuarioLogin).subscribe((d: any) => {
            if (d.usuario) {
                this.toastr.success('Usuário autenticado com sucesso!', 'Sucesso');
                localStorage.setItem('token_usuario', JSON.stringify(d));
                this.get();
                this.getDadosUsuario();
            }
            else {
                this.toastr.warning('Usuário inválido.');
            }
        }, erro => {
            console.log(erro);
            this.toastr.warning('erro interno do sistema');
        })
    }

    getDadosUsuario() {
        this.usuarioLogado = JSON.parse(localStorage.getItem('token_usuario'))
        this.isAuthenticate = this.usuarioLogado != null;
    }
}
