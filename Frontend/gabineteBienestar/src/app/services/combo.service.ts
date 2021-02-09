import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class CombosService {

  private urlApi = 'https://localhost:44307/api/Solicitud/motivos';

  constructor(private http: HttpClient) {}

  public getMotivos(): Observable<any> {
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
