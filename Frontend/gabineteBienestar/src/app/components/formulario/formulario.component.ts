import { Component, OnInit } from '@angular/core';
import { CombosService } from 'src/app/services/combo.service';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit {

  lista = [];

  constructor(private ComboService : CombosService) { }

  ngOnInit(): void {
    this.getComboMotivos();
  }

  public getComboMotivos() {
    this.ComboService.getMotivos().subscribe((res) => {
      this.lista = res;
    })
  }
}
