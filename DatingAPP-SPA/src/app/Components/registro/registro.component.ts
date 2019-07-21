import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Servicios/auth.service';
import { AlertasService } from 'src/app/Servicios/alertas.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  model = {
    nombre: '',
    password: ''
  };
  constructor(private Auth: AuthService,
              private alertas: AlertasService) { }

  ngOnInit() {
  }

  registro(){
    this.Auth.registrar(this.model).subscribe(() => {
      this.alertas.exito('Se registro usuario de manera correcta');
    }, error =>{
      this.alertas.error(error);
    });
  }
}
