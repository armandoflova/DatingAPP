import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/Servicios/auth.service';
import { AlertasService } from 'src/app/Servicios/alertas.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
   model = {
     Nombre: '',
     password: ''
   };

  constructor(public authservicio: AuthService,
              private alerta: AlertasService) { }

  ngOnInit() {
  }
  Login(form: NgForm){
      this.authservicio.Login(this.model).subscribe(next =>{
      this.alerta.exito('Inicio sesión de manera exitosa'); 
      }, error=>{
       this.alerta.error(error.statusText);
       console.log(error);
       
       
      });
    
  }

  // Loggint(){
  //   const token = localStorage.getItem('token');
  //   return !!token;
  // }

  Logout(){
    localStorage.removeItem('token');
    this.alerta.info('Se cerro su sesión');
    }
}
