import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { JwtHelperService } from "@auth0/angular-jwt";



@Injectable({
  providedIn: 'root'
})
export class AuthService {

  URL = 'http://localhost:5000/api/AuthRepositorio/';
   helper = new JwtHelperService();
  decoradorToken: any;
  constructor(private http: HttpClient) { }

  Login(model: any) {
     return this.http.post(this.URL + 'Login' , model).pipe(map((respuesta: any) => {
        const usuario = respuesta;
        if(usuario){
          localStorage.setItem('token' , usuario.token);
          this.decoradorToken = this.helper.decodeToken(usuario.token);
          console.log(this.decoradorToken);
          
        }
     }));
  }

  registrar(model: any) {
    return this.http.post( this.URL + 'Registro' , model);
  }

  logueado(){
    const token = localStorage.getItem('token');
    return !this.helper.isTokenExpired(token);
  }
}
