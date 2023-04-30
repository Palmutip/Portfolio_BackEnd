import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { VariacoesComponent } from './variacoes/variacoes.component';
import { UsuarioDataService } from './_data-services/usuario.data-service';
import { Interceptor } from './autenticacao/app-interceptor.module';
import { ToastrModule } from 'ngx-toastr';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { VariacaoDataService } from './_data-services/variacao.data-service';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuariosComponent,
    VariacoesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'usuarios', component: UsuariosComponent },
      { path: 'variacoes', component: VariacoesComponent },
    ]),
      Interceptor,
      FontAwesomeModule,
      ToastrModule.forRoot({
        progressBar: true
      })
    ],
    providers: [
      UsuarioDataService,
      VariacaoDataService,
      { provide: LOCALE_ID, useValue: 'pt-BR' }
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
