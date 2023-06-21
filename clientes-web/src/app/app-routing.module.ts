import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroClientesComponent } from './cadastro-clientes/cadastro-clientes.component';
import { ConsultaClientesComponent } from './consulta-clientes/consulta-clientes.component';
import { EdicaoClienteComponent } from './edicao-cliente/edicao-cliente.component';


const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'consulta-clientes'},
  { path: 'cadastro-clientes', component: CadastroClientesComponent },
  { path: 'consulta-clientes', component: ConsultaClientesComponent },
  { path: 'edicao-cliente/:id', component: EdicaoClienteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
