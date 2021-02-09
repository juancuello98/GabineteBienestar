import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CATCH_ERROR_VAR } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';




export class CombosService {

  private urlApi = 'https://localhost:44386/api/Solicitud/';

  constructor(private http: HttpClient) {

  }

  public getMotivos(): Observable<any> {
    return this.http.get(this.urlApi + 'motivos')
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
