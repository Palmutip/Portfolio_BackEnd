import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { Injectable, NgModule } from '@angular/core';
import { Observable } from 'rxjs';
import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
} from '@angular/common/http';

@Injectable()
export class HttpsRequestInterceptor implements HttpInterceptor {
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler,
    ): Observable<HttpEvent<any>> {
        var _user = JSON.parse(localStorage.getItem('token_usuario'));

        const dupReq = req.clone({
            headers: req.headers.set('authorization', (_user && _user.token) ? 'Bearer ' + _user.token : ''),
        });
        return next.handle(dupReq);

    }
}
@NgModule({
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: HttpsRequestInterceptor,
            multi: true,
        },
    ],
})

export class Interceptor { }