import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpParams } from '@angular/common/http';
//import { serializeNodes } from '@angular/compiler/src/i18n/digest';
import { Injectable } from '@angular/core';
//import { Data } from '@angular/router';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { DataRequest } from '../modelos/dataRequest';
import { LoginResponse } from '../modelos/LoginResponse';
import { SendDataRequest } from '../modelos/sendDataRequest';

@Injectable({
  providedIn: 'root',
})
export class SolicitudService {


  private urlApi = 'https://localhost:44307/api/Solicitud/';


  constructor(private http: HttpClient) {

  }

  public getToken():Observable<LoginResponse> {


    return this.http.get<any>(this.urlApi+'login').pipe(
      catchError((err) => {
        console.log(err);
        throw err.error;
      }),
      map((data) => {

        return data;
      })
    );

  }



// servicio para llenar el combobox horarios
  public getHorarios(): Observable<DataRequest>  {
    return this.http.get<DataRequest>(this.urlApi + 'GabineteBienestar/parameters/GetTimePreferences')
      .pipe(
        catchError(err => {
          throw err.error;

        }),
        map(data => {
          return data;
        })
      )
  }

  // LLENAR EL COMBO DE MOTIVOS
  public getMotivos(): Observable<DataRequest> {
    // const _header = new HttpHeaders(
    //   {
    //     "bizuitToken" : 'ZMdufWTdCsSYUXj7%2fBEC3GVmCT6V5aUjt%2by0BKxV5ST1KPVbv0gnUExKVqX9eCOhE7nm5vX8hPCLnuV5mn1jFncZY5GshrqwvI%2fca9DDdU81u3vpdHcTui8Yqnh2CZv7aO0ik%2bvUAU%2f25JQpOxwfTeEU0mL%2fWBdJ1P%2bCVeH%2fM3jUJMNx94IY1L5uJhWf8zvICkQMw5dXK74%3d'
    //   }
    // );
    return this.http.get<DataRequest>(this.urlApi + 'GabineteBienestar/parameters/GetReasons')
      .pipe(
        catchError(err => {
          console.log(err)
          throw err.error;

        }),
        map(data => {
          return data;
        })
      )
  }

  public sendData (sendData : SendDataRequest): Observable<any>{
    return this.http.post<SendDataRequest>(this.urlApi , sendData)
    .pipe(
      catchError(err => {
        console.log(err)
        throw err.error;

      }),
      map(data => {
        return data;
      })
    )
  }
}
