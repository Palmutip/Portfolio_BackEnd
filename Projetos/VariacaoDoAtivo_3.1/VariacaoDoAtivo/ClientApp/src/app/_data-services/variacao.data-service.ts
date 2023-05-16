import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class VariacaoDataService {
    module: string = '/api/variacao';

    constructor(private http: HttpClient) { }

    get() {
        return this.http.get(this.module);
    }

    post(variacaoRequest) {
        return this.http.post(this.module, variacaoRequest);
    }

    put(dados) {
        return this.http.put(this.module, dados);
    }

    delete() {
        return this.http.delete(this.module);
    }
}