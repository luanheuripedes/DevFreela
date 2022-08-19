# DevFreela
Projeto construído no módulo Formação ASP NET CORE, utilizando .NET6

## É uma API para implementar funcionalidades necessárias para um sistema de freelance. Onde o cliente loga e cria um projeto, o programador vê aquele projeto, combina com o cliente e então começa a desenvolve-lo.

### Swagger
  Simplifica o desenvolvimento de APIs, documentado e ajudando nos teste das APIs. O Swagger gera uma interface contendo os EndPoints, assim podendo realizar as requisições de sua interface.
  
### Arquitetura Limpa
  Arquitetura que tem como foco o dominio do sistema, arquitetura que é dividida em 4 camadas CORE, APPLICATION, INFRASTRUCTURE e API.
  
### Entity Framework Core
  É a ORM mais utilizada no desenvolvimento .NET, facilitando muito o CRUD e a criação do banco de dados.
  
### Dapper
  ORM mais performática e simples que o Entity Framework Core, de fácil adoção em um projeto que já utiliza o EF Core ou outros métodos de acessos de dados.
  
### CQRS
  Padrão que separa consultas(Queries) das ações que alteram o estado do sistema(Commands).
  
### MediatR
  Responsavel por fazer a delegação do que cada Command e Queries vai realizar.
  
### JWT -> Json Web Token
 É uma cadeia de caracteres com dados da aplicação e usuário em base64, além de uma chave gerada com um algoritmo de hashing como o SHA256. Essa chave é gerada através de uma chave secreta definida na aplicação e que é validada ao receber a requisição. O JWT é enviado via cabeçalho Authorization.
 
### xUnit -> Para testes unitários
  Ferramenta gratuita e open-source para testes unitários, sendo a principal opção atualmente junto com o NUnit. Funciona com o .NET Core, .NET Framework, Universal Windows Apps e Xamarin. Tem um template prório para o .NET Core, tanto via linha de comando quanto pelo Visual Studio 2019. Em um projeto de testes do xUnit, basta criar uma classe e inserir o método com a anotação [Fact].
  
### Microsserviços e Mensageria
  É uma abordagem do desenvolvimento de software na qual consiste em pequenos serviços independentes que se comunicam usando APIs bem definidas. Nesse projeto foi implementado um microsserviço de pagamento, foi utilizando o RabbitMQ para lidar com o trafego de mensagens entre a API Monólito com o microsserviço
