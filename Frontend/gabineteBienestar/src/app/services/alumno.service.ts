import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { Alumno } from '../modelos/alumno';

@Injectable({
  providedIn: 'root'
})
export class AlumnoService {

  private urlApi = 'https://localhost:44307/api/Solicitud/datosAlumno';

  constructor(private http: HttpClient) {}

  public getAlumno(): Observable<Alumno> {
    return this.http.get<any>(this.urlApi)
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
