import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cadastro-clientes',
  templateUrl: './cadastro-clientes.component.html',
  styleUrls: ['./cadastro-clientes.component.css']
})
export class CadastroClientesComponent {
  nome: string = '';
  email: string = '';
  cpf: string = '';
  dataNascimento: string = '';
  cadastroSucesso: boolean = false;

  constructor(private http: HttpClient) {}



  cadastrarCliente() {
    const url = 'https://localhost:7015/api/Clientes/cadastro';

    const model = {
      Nome: this.nome,
      Email: this.email,
      Cpf: this.cpf,
      DataNasicmento: this.dataNascimento
    };

    this.http.post(url, model).subscribe(
      (response: any) => {
        console.log(response.mensagem);
        this.cadastroSucesso = true;
        this.nome = '';
        this.email = '';
        this.cpf = '';
        this.dataNascimento = '';
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
