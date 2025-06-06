# Gestão Telecom - Backend

API REST desenvolvida com ASP.NET Core para gerenciar operadoras, contratos e faturas.

## ✅ Pré-requisitos

- .NET 9 SDK
- Banco de dados PostgreSQL

## ⚙️ Configuração

1. Clone o repositório:
   - git clone https://github.com/matheuslima19/telecom-api.git
   - cd telecom-api

2. Configure a string de conexão no appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=telecomdb;Username=postgres;Password=suasenha"
}

## 🛠️ Execução

1. Restaure as dependências:
   dotnet restore

2. Aplique as migrations:
   dotnet ef database update

3. Rode o projeto:
   dotnet run

A API estará disponível em:
https://localhost:5032

## 🚀 Funcionalidades

- CRUD de Operadoras
- CRUD de Contratos (com associação a operadora)
- CRUD de Faturas (com associação a contrato)
- Dashboard com métricas gerenciais

## 🧪 Tecnologias

- ASP.NET Core 9
- Entity Framework Core + PostgreSQL
- AutoMapper
- HostedService

## 📁 Estrutura principal

├── Controllers/
├── Domain/
├── Application/
├── Infrastructure/
├── Program.cs
└── appsettings.json
