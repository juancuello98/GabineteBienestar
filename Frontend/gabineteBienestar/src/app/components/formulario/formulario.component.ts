import { Component, OnInit } from '@angular/core';
import { SendDataRequest } from 'src/app/modelos/SendDataRequest';
import { SolicitudService } from 'src/app/services/solicitud.service';
import { Parameters } from '../../modelos/Parameters';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit {



  Solicitud :SendDataRequest = new SendDataRequest();


  listaMotivos : Array<Parameters> = [];
  listaHorarios : Array<Parameters> = [];
  numeroDocumento ?: number;
  observaciones : string = "";
  Horarios : string = "";



  constructor(private SolicitudServices: SolicitudService) {

  }



  ngOnInit(): void {


      this.getToken();
      this.getComboMotivos();
      this.getHorarios();


  }

  public getToken(){
    this.SolicitudServices.getToken().subscribe( (res) => {
      localStorage.setItem("token",res);
    });
  }
  public getComboMotivos() {
    this.SolicitudServices.getMotivos().subscribe((res) => {
        this.listaMotivos = res.data;

    })
  }

  public getHorarios(){
    this.SolicitudServices.getHorarios().subscribe((res) => {
      this.listaHorarios = res.data;
    })
  }

  public SendSolicitud(){
    // this.Solicitud.Documento = 2;
    // this.Solicitud.ReasonId = 21;
    // this.Solicitud.TimePreferencesId = "";
    // this.Solicitud.Observaciones = "";
    this.SolicitudServices.sendData(this.Solicitud);
  }
}
