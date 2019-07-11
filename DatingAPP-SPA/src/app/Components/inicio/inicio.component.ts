import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  registrar = false;
  constructor() { }

  ngOnInit() {
  }
  mostrarResgitro(){
    this.registrar = !this.registrar;
  }
}
