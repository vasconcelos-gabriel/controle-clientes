# Controle de Clientes 
Este projeto consiste em um sistema de controle de clientes, desenvolvido utilizando tecnologias modernas e práticas de desenvolvimento. O objetivo é fornecer uma solução eficiente e escalável para o gerenciamento de clientes.

## Tecnologias Utilizadas
ASP.NET API: Framework de desenvolvimento web utilizado para construir a API do sistema.

Dapper: Micro ORM (Object Relational Mapping) usado para a camada de acesso a dados.

Swagger: Ferramenta para documentação e teste de APIs RESTful.

Entity Framework: Framework de mapeamento objeto-relacional utilizado para interagir com o banco de dados.

xUnit: Framework de testes unitários para a realização de testes automatizados.

Angular: Framework de desenvolvimento de aplicativos web front-end.

Bootstrap: Biblioteca de código aberto para desenvolvimento responsivo de sites e aplicativos.

# Configuração do Projeto
## Para executar o projeto em seu ambiente local, siga as etapas abaixo:

Crie um banco de dados no SQL Server.

Colete a Connection String do banco de dados recém-criado.

Abra o arquivo "SqlServerContext.cs" no diretório do projeto e localize a linha 17. Substitua "ConnectionStringAqui" pela sua Connection String, dentro das aspas.

Execute o comando "update database" no pacote do Entity Framework para aplicar as migrações pendentes e atualizar o banco de dados.

## Executando o Projeto

Após configurar o projeto, você pode executá-lo seguindo as etapas abaixo:

Certifique-se de ter as dependências e as ferramentas necessárias instaladas em seu ambiente de desenvolvimento.

Abra a solução do projeto em seu IDE favorito.

Execute o projeto da API ASP.NET.

O projeto Angular será automaticamente compilado e iniciado quando a API for executada.

## Testes
O projeto possui testes unitários implementados utilizando o framework xUnit. Para executar os testes, siga as etapas abaixo:

Certifique-se de ter as dependências e as ferramentas necessárias instaladas em seu ambiente de desenvolvimento.

Abra a solução do projeto em seu IDE favorito.

Execute os testes unitários.
