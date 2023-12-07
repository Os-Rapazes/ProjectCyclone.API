# ProjectCyclone Back-End

Para desenvolver o back-end da aplicação utilizamos .NET 6 com C#
Como banco de dados utilizamos MySQL

## Como rodar o projeto

É necessário que você tenha o .NET 6 instalado em sua maquina

Além disso também é preciso instalar o MySQL

Após isso clone o repositório, vá no arquivo `appsettings.json` e altera a string de conexão com o banco e coloque os seus dados `"DefaultConnection": "Server=localhost; Database=project_cyclone; Uid=YOUR_USER; Pwd=YOUR_PASSWORD;"`

Para criar o banco de dados usaremos a ORM EntityFramework

Se ele ja estiver instalado apenas rode o comando `dotnet ef database update` e o banco de dados será criado

Após isso abra um terminal na pasta do projeto e digite o comando `dotnet run`

