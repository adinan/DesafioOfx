# MundiPagg - Desafio Ofx. 

O Desafio consiste de desenvolver uma API RESTful com o intuito de importar arquivos OFX e disponibilizar as informações de maneira ótima e eficiente


<details>
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
- Para arquivos OFXs com novas agências e contas é necessário cadastrar as informações via sql visto que o foco é a importação de arquivos OFXs partindo da premissa que já existiram contas agências e bancos pré cadastrados
- Não tive tempo para aprender como utilizar um serviço de CI. Logo não foi utilizado essa ferramenta.

#### Prova sobre a solução ser performática
Pegamos várias bibliotecas do Nuget que fazem a conversão de arquivo .ofx para uma classe c#. Criamos um arquivo com cerca de 1kk de transações e usamos essas bibliotecas para avaliar o tempo de conversão. Dentre as testadas, a mais performática foi a OfxNet e esta foi utilizada neste projeto. Utilizamos CQRS com o intuito de obter uma melhor performance, nossa aplicação iria fazer consultas em um banco de leitura MongoDB e escrita em SQL Server, porem não tive tempo de implementar e utilizar o banco NOSQL.



### Tecnologia e Padrões Utilizada BackEnd
- [DDD (Domain Driven Design)](https://en.wikipedia.org/wiki/Domain-driven_design)
- [CQRS](https://docs.microsoft.com/pt-br/azure/architecture/patterns/cqrs)
- [Web API](https://docs.microsoft.com/pt-br/aspnet/core/web-api/?view=aspnetcore-5.0) (usando conceito RESTful);
- [XUnit](https://xunit.net/) (Para testes de unidade. Utilizado tmb MOQ e Bogus)
- [C# ](https://msdn.microsoft.com/en-us/library/kx37x362.aspx) 
- [.Net 5](https://docs.microsoft.com/pt-br/dotnet/core/dotnet-five) 
- [Entity Framework Core 5.0](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/whatsnew) (ORM – Banco Relacional)
- [Identity Core com JWT](https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-5.0) (autenticação e segurança da API)
- [Elmah](https://elmah.io/) (Para log de Eventos Web)
- [Autommaper](https://docs.automapper.org/en/stable/)
- [Swagger](https://swagger.io/docs/)
- [MediatR](https://github.com/jbogard/MediatR/wiki)
- [AutoMocker](https://github.com/moq/Moq.AutoMocker)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [OfxNet](https://github.com/jim-dale/BankingTools) – Projeto para conversão do arquivo OFX para o contexto da aplicação. Fizemos algumas pequenas modificações no projeto.

## APIs
1. Conta <br />
 - Get por id<br />
 - Get por códigos do Banco, Agencia e Conta<br />
 - Post de um lançamento financeiro<br />
 - Pacth de um lançamento financeiro<br />
2. Importacao<br />
 - Importação com o método de post de um arquivo OFX<br />
3. Relatorio<br />
 - Relatório com o método que retorna extrato financeiro de uma Conta<br />
  
  
