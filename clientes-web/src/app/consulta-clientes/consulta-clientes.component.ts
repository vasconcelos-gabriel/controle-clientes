import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

interface Cliente {
  idCliente: string;
  nome: string;
  email: string;
  cpf: string;
  dataNascimento: string;
}

@Component({
  selector: 'app-consulta-clientes',
  templateUrl: './consulta-clientes.component.html',
  styleUrls: ['./consulta-clientes.component.css']
})
export class ConsultaClientesComponent implements OnInit {
  clientes: Cliente[] = [];

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.consultarClientes();
  }

  consultarClientes(): void {
    this.http.get<Cliente[]>('https://localhost:7015/api/clientes/consultar')
      .subscribe(
        response => {
          this.clientes = response;
        },
        error => {
          console.error(error);
        }
      );
  }

  editarCliente(idCliente: string): void {
    this.router.navigate(['/edicao-cliente', idCliente]);
  }

  excluirCliente(idCliente: string): void {
    this.http.delete(`https://localhost:7015/api/clientes/exclusao/${idCliente}`)
      .subscribe(
        () => {
          console.log('Cliente excluído com sucesso!');
          this.consultarClientes(); 
        },
        error => {
          console.error(error);
        }
      );
  }
}
