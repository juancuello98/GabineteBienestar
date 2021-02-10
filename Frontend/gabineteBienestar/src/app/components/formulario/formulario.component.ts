import { Component, OnInit } from '@angular/core';
import { CombosService } from 'src/app/services/combo.service';
import { AlumnoService } from 'src/app/services/alumno.service';
import { HorariosService } from 'src/app/services/horarios.service';
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



  constructor(private MotivosService : CombosService, private AlumnoService: AlumnoService,private HorarioService : HorariosService) {

  }



  ngOnInit(): void {
      this.obtenerAlumno();
      this.getComboMotivos();
      this.getHorarios();

  }

  public getComboMotivos() {
    this.MotivosService.getMotivos().subscribe((res) => {
      this.listaMotivos = res;
    })
  }

  public getHorarios(){
    this.HorarioService.getHorarios().subscribe((res) => {
      this.listaHorarios = res;
    })
  }

  public obtenerAlumno(){
    this.AlumnoService.getAlumno().subscribe((res) => {
      this._alumno.nombre = res.nombre;
      this._alumno.documento = res.documento;
    })
  }
}
