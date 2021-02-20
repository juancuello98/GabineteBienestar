import { Component, OnInit } from '@angular/core';
import { SendDataRequest } from 'src/app/modelos/SendDataRequest';
import { SolicitudService } from 'src/app/services/solicitud.service';
import { Parameters } from '../../modelos/Parameters';
import { FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss'],
})
export class FormularioComponent implements OnInit {

  documento = new FormControl(undefined, [Validators.required]);
  observaciones = new FormControl(undefined, [Validators.required]);
  motivos = new FormControl(undefined, [Validators.required]);
  prefHorarios = new FormControl(undefined, [Validators.required]);

  Solicitud: SendDataRequest = new SendDataRequest();
  listaMotivos: Array<Parameters> = [];
  listaHorarios: Array<Parameters> = [];

  constructor(
     private ToastService: ToastrService, private SolicitudServices: SolicitudService
  ) {}

  ngOnInit(): void {
    this.getToken();
  }

  public getToken() {
    this.SolicitudServices.getToken().subscribe((res) => {
      console.log(res);
      localStorage.setItem('token', res.token);
      this.getComboMotivos();
      this.getHorarios();
    });
  }
  public getComboMotivos() {
    this.SolicitudServices.getMotivos().subscribe(
      (res) => {
        this.listaMotivos = res.data;
      },
      (err) => {
        console.log(err);
        this.showToastrError(err, 'Ups! Algo salio mal');
      }
    );
  }

  public getHorarios() {
    this.SolicitudServices.getHorarios().subscribe(
      (res) => {
        this.listaHorarios = res.data;
      },
      (err) => {
        console.log(err);
        this.showToastrError(err, 'Ups! Algo salio mal');
      }
    );
  }

  public SendSolicitud() {
    if (this.VerificarDatos()) {
      this.Solicitud.Documento = parseInt(this.documento.value);
      this.Solicitud.ReasonId = this.motivos.value;
      this.Solicitud.Observaciones = this.observaciones.value;
      this.Solicitud.TimePreferencesId = this.prefHorarios.value.toString();
      this.SolicitudServices.sendData(this.Solicitud).subscribe((res) => res);
      localStorage.removeItem('token');
      this.showToastrSucces('Operacion exitosa','La solicitud ha sido enviada')
    }
    else{
      this.showToastrError('Complete los campos obligatorios','Solicitud Incompleta')
    }

  }

  public VerificarDatos() {
    if (
      this.documento.value == null ||
      this.documento.value == 0 ||
      this.documento.value == '' ||
      this.observaciones.value == '' ||
      this.observaciones.value == null ||
      this.motivos.value == 0 ||
      this.motivos.value == null ||
      this.prefHorarios.value == '' ||
      this.prefHorarios.value == null
    ) {
      return false;
    }
    return true;
  }

  getErrorMessage() {
    var mensaje = '';
    if (
      this.documento.hasError('required') ||
      this.observaciones.hasError('required') ||
      this.motivos.hasError('required') ||
      this.prefHorarios.hasError('required')
    ) {
      mensaje += 'Campo obligatorio.';
    }
    return mensaje;
  }

  public showToastrSucces(mensajeAlert: string, tituloAlert: string) {
    this.ToastService.success(mensajeAlert, tituloAlert);
  }

  public showToastrError(mensajeAlert: string, tituloAlert: string) {
    this.ToastService.error(mensajeAlert, tituloAlert);
  }
}
