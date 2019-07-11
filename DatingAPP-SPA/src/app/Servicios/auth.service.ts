import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  URL = 'http://localhost:5000/api/AuthRepositorio/';

  constructor(private http: HttpClient) { }

  Login(model: any) {
     return this.http.post(this.URL + 'Login' , model).pipe(map((respuesta: any) => {
        const usuario = respuesta;
        if(usuario){
          localStorage.setItem('token' , usuario.token);
        }
     }));
  }

  registrar(model: any) {
    return this.http.post( this.URL + 'Registro' , model);
  }
}
