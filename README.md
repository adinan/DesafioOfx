# MundiPagg - Desafio Ofx. 

O Desafio consiste de desenvolver uma API RESTful com o intuito de importar arquivos OFX e disponibilizar as informações de maneira ótima e eficiente


<details open="open">
  <summary><b>Mostrar como executar o projeto</b></summary>

1. Tenho o Docker instalado. 
2. Baixar ou clonar este repositório
3. Entre na pasta raiz do projeto, onde se encontra o arquivo docker-compose.yml
4. Abra um terminal nesta pasta e rode o comando
```
docker-compose up -d
```
5. Aguarde os downloads e configurações Docker serem finalizadas e depois as seguintes interfaces estarão disponíveis:
- Sql Server: localhost,1433 
- Aplicação (através do swagger): http://localhost:5001/swagger/index.html

6. Após tudo pronto acesse a API Auth e crie um usuário para poder usar as outras APIs que precisão de autorização. Utilizar no Header da requisição Authorization: bearer {accessToken}
7. A aplicação já vem com uma carga inicial nas tabelas Bancos, Agencias e Contas. Assim sendo possível já subir os 3 arquivos OFXs disponibilizados. 

</details>




### Notas
Para arquivos OFXs com novos agencias e contas é necessário cadastrar as informações via sql visto que o foco e a importação de arquivos OFXs partindo da premissa que já existiram contas agenicas e bancos pre cadastrados



### Tecnologia e Padrões Utilizada BackEnd
- [DDD (Domain Driven Design)](https://en.wikipedia.org/wiki/Domain-driven_design)
- [CQRS](https://docs.microsoft.com/pt-br/azure/architecture/patterns/cqrs)
- [Web API]( https://docs.microsoft.com/pt-br/aspnet/core/web-api/?view=aspnetcore-5.0) (usando conceito RESTful);
- [XUnit](https://xunit.net/) (Para testes de unidade. Utilizado tmb MOQ e Bogus)
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

## APIs
- Conta com os métodos de get por id e pelas códigos co Banco, Agencia e Conta. Post de um lancamento financeiro e pacth de um lancamento financeiro
- Importacao com o método de post de um arquivo OFX
- Relatorio com o método que retorna extrato financeiro de uma Conta.
