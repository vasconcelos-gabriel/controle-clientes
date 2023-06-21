import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-edicao-cliente',
  templateUrl: './edicao-cliente.component.html',
  styleUrls: ['./edicao-cliente.component.css']
})
export class EdicaoClienteComponent implements OnInit {
  cliente: any = {};
  clienteEdicao: any = {}; 
  errorMessage: string = '';
  edicaoSucesso: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.obterCliente(id);
    }
  }

  obterCliente(idCliente: string): void {
    this.http.get<any>(`https://localhost:7015/api/clientes/${idCliente}`)
      .subscribe(
        response => {
          this.cliente = response;
          this.clienteEdicao = { ...this.cliente };
          this.clienteEdicao.dataNascimento = new Date(this.clienteEdicao.dataNascimento).toISOString().slice(0, 10);
        },
        error => {
          this.errorMessage = 'Erro ao obter os dados do cliente.';
        }
      );
  }

  atualizarCliente(): void {
    this.http.put<any>('https://localhost:7015/api/Clientes/api/clientes/atualizacao', this.clienteEdicao)
      .subscribe(
        response => {
          console.log(response);
          this.edicaoSucesso = true;
          this.router.navigate(['/consulta-clientes']);
        },
        error => {
          this.errorMessage = 'Erro ao atualizar o cliente.';
        }
      );
  }
}
