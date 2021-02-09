import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HorariosService {

  private urlApi = 'https://localhost:44307/api/Solicitud/horarios';

  constructor(private http: HttpClient) {}

  public getHorarios(): Observable<any> {
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
