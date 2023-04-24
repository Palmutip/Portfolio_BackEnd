import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class VariacaoDataService {
    module: string = '/api/variacao';

    constructor(private http: HttpClient) { }

    get() {
        return this.http.get(this.module);
    }

    post(ativo, intervalo, range) {
        return this.http.post(this.module + '?identificacaoAtivo=' + ativo + '&intervalo=' + intervalo + '&range=' + range, ativo);
    }

    put(dados) {
        return this.http.put(this.module, dados);
    }

    delete() {
        return this.http.delete(this.module);
    }
}