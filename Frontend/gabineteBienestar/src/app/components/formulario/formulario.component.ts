import { Component, OnInit } from '@angular/core';
import { SolicitudService } from 'src/app/services/solicitud.service';
import { Alumno } from 'src/app/modelos/alumno';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit {

  listaMotivos = [];
  listaHorarios = [];
  _alumno : Alumno = new Alumno();



  constructor(private SolicitudServices: SolicitudService) {

  }



  ngOnInit(): void {
      // this.obtenerAlumno();
      // this.getComboMotivos();
      // this.getHorarios();

  }

  public getComboMotivos() {
    this.SolicitudServices.getMotivos().subscribe((res) => {
      this.listaMotivos = res;
    })
  }

  public getHorarios(){
    this.SolicitudServices.getHorarios().subscribe((res) => {
      this.listaHorarios = res;
    })
  }

  public obtenerAlumno(){
    this.SolicitudServices.getAlumno().subscribe((res) => {
      this._alumno.nombre = res.nombre;
      this._alumno.documento = res.documento;
    })
  }
}
