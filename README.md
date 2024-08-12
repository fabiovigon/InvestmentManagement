# InvestmentManagement

Portfólio Financeiro
Descrição
O projeto de Portfólio Financeiro é uma aplicação desenvolvida em .NET 8 com Entity Framework, com a finalidade de gerenciar um portfólio de investimentos. A aplicação é estruturada em três camadas principais:

Presentation: Camada responsável pela interface do usuário e exposição dos endpoints da API.
Domain: Camada de regras de negócio e lógica da aplicação.
Infra: Camada de acesso a dados e configurações do banco de dados.
Funcionalidades
Gestão de Usuários: Criação e vinculação de usuários a sistemas financeiros específicos.
Gestão de Produtos: Criação de produtos financeiros com categorias associadas.
Trades: Realização de operações de compra e venda de investimentos.

Requisitos
.NET 8 SDK
SQL Server
Configuração do Projeto
Passo a Passo para Rodar o Projeto
Clonar o Repositório

Clone o repositório para sua máquina local usando o comando:

-git clone https://github.com/fabiovigon/InvestmentManagement.git

Abra o projeto e restaure as dependencias com o comando CTRL+B ou clicando na Solution com o botão direito e Build Solution

Navegue até a raiz do projeto e execute o comando para restaurar as dependências:

-dotnet restore

Configurar a Conexão com o Banco de Dados

Edite o arquivo appsettings.json na camada Presentation para configurar a conexão com o banco de dados:

- Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu-servidor;Database=seu-banco-de-dados;User Id=seu-usuario;Password=sua-senha;"
  }
}


Aplicar Migrations

Abra a aba Tools e navegue até a opção NuGet Pakcage manager e clique em Package Manager console.
após isso em Default project selelcione o projeto Infra. feito isso rode os comando abaixo

Add-migration Criando-database

2.Update-Database.

Criado o Database no sql server va na pasta Presentation, clique na WebAPI com o botão direito do mouse e clique em Set as Startup Project para podermos inicializar por ele

feito isso irá abrir o Swagger e aplicação estará pronta para ser consumida

Obs: a aplicação até o momento realiza algumas das operações de forma parcial, como autenticação via jwt e a parte de trade da compra do produto e o cliente
