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
    let token = "ZMdufWTdCsSYUXj7%2fBEC3GVmCT6V5aUjt%2by0BKxV5ST1KPVbv0gnUExKVqX9eCOhE7nm5vX8hPCLnuV5mn1jFncZY5GshrqwvI%2fca9DDdU81u3vpdHcTui8Yqnh2CZv7aO0ik%2bvUAU%2f25JQpOxwfTeEU0mL%2fWBdJ1P%2bCVeH%2fM3jUJMNx94IY1L5uJhWf8zvICkQMw5dXK74%3d";

    const _headers = new HttpHeaders({
      "bizuitToken": token
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
