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
   git clone https://github.com/cleytonbsc/sctec-projeto-final.git

2. Acesse a pasta do projeto:
   cd sctec-projeto-final/DeskFlow.API

3. Configure a Connection String no arquivo `appsettings.json`:
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=DeskFlowDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }

4. Execute as Migrations para criar a estrutura no banco de dados:
```
dotnet ef database update
```
5. Execute a API:
```
dotnet run
```

6. Acesse a documentação do Swagger para testar os endpoints:
   A URL exibida no terminal (por exemplo, `http://localhost:5051/swagger`).

### Criar uma migration
Quando houver alterações nas entidades, crie uma nova migration a partir da pasta `DeskFlow.API`:
```
dotnet ef migrations add NomeDaMigration
dotnet ef database update
```

## 👤 Registrar Usuário e Definir Administrador

### Registrar um usuário
Com a API em execução, envie uma requisição `POST` para `/auth/register` ou usar o endpoint **POST /auth/register** no Swagger. 
A senha deve atender às regras padrão de complexidade do ASP.NET Identity.

### Dar o papel `Admin`
Depois de registrar o usuário, execute o script abaixo no banco configurado em `DefaultConnection`. Ele cria o papel, caso ainda não exista, e associa o usuário pelo e-mail:
```
IF NOT EXISTS (SELECT 1 FROM AspNetRoles WHERE NormalizedName = 'ADMIN')
BEGIN
      INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
      VALUES (NEWID(), 'Admin', 'ADMIN', NEWID());
END;

INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM AspNetUsers u
CROSS JOIN AspNetRoles r
WHERE u.NormalizedEmail = 'ADMIN@DESKFLOW.COM'
   AND r.NormalizedName = 'ADMIN'
   AND NOT EXISTS (
      SELECT 1
      FROM AspNetUserRoles ur
      WHERE ur.UserId = u.Id AND ur.RoleId = r.Id
   );
```
Após essa associação, faça login em `POST /auth/login` e use o `accessToken` retornado no botão **Authorize** do Swagger. Os endpoints administrativos exigem o papel `Admin`.

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
