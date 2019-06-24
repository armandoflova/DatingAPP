import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-valores',
  templateUrl: './valores.component.html',
  styles: []
})
export class ValoresComponent implements OnInit {
  valores: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValores();
  }
  getValores(){
    this.http.get("http://localhost:5000/api/Values").subscribe(resultado =>{
      this.valores = resultado;
      console.log(this.valores);
      
    }, error => {
      console.log(error);
    }
    );
  }
}
