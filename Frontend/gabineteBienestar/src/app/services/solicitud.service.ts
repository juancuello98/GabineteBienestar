import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { serializeNodes } from '@angular/compiler/src/i18n/digest';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { Alumno } from '../modelos/alumno';

@Injectable({
  providedIn: 'root',
})
export class SolicitudService {


  private urlApi = 'https://localhost:44307/api/Solicitud/';

  constructor(private http: HttpClient) {

  }

  public getToken():Observable<string> {


    return this.http.get<any>(this.urlApi+'loguear').pipe(
      catchError((err) => {
        throw err.error;
      }),
      map((data) => {
        localStorage.setItem("token",data)
        return data;
      })
    );

  }

  public getAlumno(): Observable<Alumno> {

    var _token = localStorage.getItem('token') ;
    return this.http.post<any>(
      this.urlApi + 'datosAlumno' ,{_token}
      ).pipe(
      catchError((err) => {
        throw err.error;
      }),
      map((data) => {
        return data;
      })
    );
  }

  public getHorarios(): Observable<any> {
    return this.http.get<any>(this.urlApi + 'horarios')
      .pipe(
        catchError(err => {
          throw err.error;

        }),
        map(data => {
          return data;
        })
      )
  }

  public getMotivos(): Observable<any> {
    return this.http.get<any>(this.urlApi + 'motivos')
      .pipe(
        catchError(err => {
          throw err.error;

        }),
        map(data => {
          return data;
        })
      )
  }
}
