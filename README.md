# MundiPagg - Desafio Ofx. 

O Desafio consiste de desenvolver uma API RESTful com o intuito de importar arquivos OFX e disponibilizar as informações de maneira ótima e eficiente

#### Como executar
Necessário Docker estar instalado na máquina.
Executando o projeto:
- Baixar ou clonar este repositório.
- Entre na pasta raiz do projeto, onde se encontra o arquivo docker-compose.yml 
- Abra um terminal nesta pasta e rode o comando:

```
docker-compose up -d
```

Aguarde os downloads e configurações Docker serem finalizadas e depois as seguintes interfaces estarão disponíveis:
- Mongo (através do Mongo express): http://localhost:8081/
- Sql Server: 
- Aplicação (através do swagger): http://localhost:32770/swagger/index.html

 
### Tecnologia e Padrões Utilizada BackEnd
- [DDD (Domain Driven Design)](https://en.wikipedia.org/wiki/Domain-driven_design)
- [CQRS](https://docs.microsoft.com/pt-br/azure/architecture/patterns/cqrs)
- [Web API]( https://docs.microsoft.com/pt-br/aspnet/core/web-api/?view=aspnetcore-5.0) (usando conceito RESTful);
- [XUnit](https://xunit.net/) (Para testes de unidade)
- [C# ](https://msdn.microsoft.com/en-us/library/kx37x362.aspx) 
- [.Net 5](https://docs.microsoft.com/pt-br/dotnet/core/dotnet-five) 
- [Entity Framework Core 5.0]( https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/whatsnew) (ORM – Banco Relacional)
- [Identity Core com JWT]( https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-5.0) (autenticação e segurança da API)
- Elmah - Para log de Eventos Web
- Autommaper 
- Swagger
- MediatR
- FluentValidation
- [OfxNet](https://github.com/jim-dale/BankingTools) – Projeto para conversão do arquivo OFX para o contexto da aplicação. Fizemos algumas pequenas modificações no projeto.
