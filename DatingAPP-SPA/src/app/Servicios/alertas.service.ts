import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertasService {

  constructor() { }

  // tslint:disable-next-line: no-unused-expression
  confirmar( mensaje: string, okcallback:() => any){
    alertify.confirm(mensaje , function(e){
      if(e){
        okcallback();
      }else{}
    });
  }

  exito(mensaje: string){
    alertify.success(mensaje);
  }
  
  error(mensaje: string){
    alertify.error(mensaje);
  }

  cuidado(mensaje: string){
    alertify.warning(mensaje);
  }

  info(mensaje: string){
    alertify.message(mensaje);
  }




}
