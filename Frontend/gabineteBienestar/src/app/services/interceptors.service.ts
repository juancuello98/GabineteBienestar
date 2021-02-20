import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpRequest,
  HttpClient,
  HttpUrlEncodingCodec,
  HttpHeaderResponse,
  HttpHeaders,
  HttpErrorResponse,
} from '@angular/common/http';
import { HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { tokenName } from '@angular/compiler';
import { LoginResponse } from '../modelos/LoginResponse';

@Injectable({
  providedIn: 'root',
})
export class AuthInterceptor implements HttpInterceptor {
  constructor(private http: HttpClient) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler) {

    console.log('Paso por el interceptor');

    const authToken = localStorage.getItem('token');

    if (authToken && authToken.length > 0) {

       const authReq = req.clone({
        headers: req.headers.set('bizuitToken', authToken)
      });
       return next.handle(authReq);
    }



    return next.handle(req).pipe(catchError(this.manejarError));


  }

  manejarError(error: HttpErrorResponse) {
    console.log('Ocurrio un error');
    console.warn(console.error);
    return throwError('Error personalizado');
  }
}
