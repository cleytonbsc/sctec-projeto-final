# 🎧 DeskFlow API — Gestão de Chamados e Helpdesk de TI

## 🎯 Sobre o Projeto
A **DeskFlow API** é uma Web API RESTful construída em .NET Core 10 utilizando Entity Framework Core e SQL Server. O sistema automatiza o gerenciamento de chamados de suporte técnico, histórico de interações e acompanhamento de status do atendimento.

## 🛠️ Tecnologias Utilizadas
- .NET Core 10 / Web API
- Entity Framework Core 10
- SQL Server
- Swagger / OpenAPI

## 🚀 Como Executar a Aplicação

### Pré-requisitos
- .NET SDK 10 (ou superior)
- SQL Server em execução (LocalDB, SQL Server Express ou Docker)

### Passo a Passo
1. Clone este repositório:
   git clone https://github.com/seu-usuario/deskflow-api.git

2. Acesse a pasta do projeto:
   cd deskflow-api/src/DeskFlow.API

3. Configure a Connection String no arquivo `appsettings.json`:
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=DeskFlowDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }

4. Execute as Migrations para criar a estrutura no banco de dados:
   dotnet ef database update

5. Execute a API:
   dotnet run

6. Acesse a documentação do Swagger para testar os endpoints:
   https://localhost:7000/swagger

## 🧠 Ciclo de Vida do Chamado
- **Aberto**: Chamado registrado pelo solicitante.
- **EmAndamento**: Suporte em atendimento ao chamado.
- **Fechado**: Chamado encerrado com texto de solução e data de conclusão.

## 🧱 Arquitetura em Camadas
- **Controllers**: Recebem as requisições HTTP e definem os Status Codes.
- **Services**: Contêm as regras de negócio e validação dos status.
- **Repositories**: Executam comandos e consultas de banco via EF Core.
- **Middlewares**: Tratamento e padronização de erros globais da API.

## 🎥 Vídeo de Apresentação
[Clique aqui para assistir ao vídeo de demonstração do projeto](https://link-do-seu-video.com)
