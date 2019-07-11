import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Servicios/auth.service';

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
  constructor(private Auth: AuthService) { }

  ngOnInit() {
  }

  registro(){
    this.Auth.registrar(this.model).subscribe(() => {
      console.log('Se registro de manera satisfactoria ');
    }, error =>{
      console.log(error);
    });
  }
}
