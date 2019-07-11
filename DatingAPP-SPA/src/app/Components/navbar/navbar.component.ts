import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/Servicios/auth.service';

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

  constructor(private authservicio: AuthService) { }

  ngOnInit() {
  }
  Login(form: NgForm){
      this.authservicio.Login(this.model).subscribe(next=>{
        console.log('Autenticacion Satisfactoria');
       
        
      }, error=>{
       console.log('error con la autenticación');
       
      });
    
  }

  Loggint(){
    const token = localStorage.getItem('token');
    return !!token;
  }

  Logout(){
    localStorage.removeItem('token');
    }
}
