import {Injectable} from "@angular/core";
import {HttpEvent, HttpHandler, HttpRequest, HttpClient, HttpUrlEncodingCodec, HttpHeaderResponse, HttpHeaders, HttpErrorResponse} from "@angular/common/http";
import {HttpInterceptor} from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

  constructor(private http : HttpClient) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = localStorage.getItem("token");

    const _headers = new HttpHeaders({
      "BZ-AUTH-TOKEN": "Basic "+ token
    })

    const reqClon = req.clone({
      headers:_headers
    });

    return next.handle(req).pipe(
      catchError(this.manejarError)
    );


    // if(token){
    //   req = req.clone({
    //     setHeaders: {
    //       'BZ-AUTH-TOKEN': 'Basic '+ token,
    //     }
    //   });
    // }

    // return next.handle(req).pipe(
    //   catchError(this.manejarError)
    // );


  }

  manejarError(error: HttpErrorResponse){
    console.log('Ocurrio un error');
    console.warn(console.error);
    return throwError('Error personalizado');
  }
}
