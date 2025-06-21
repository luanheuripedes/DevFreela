# DevFreela

Uma plataforma completa de gerenciamento de projetos freelancer desenvolvida com ASP.NET Core, criado para consolidar os aprendizados adquiridos na trilha do Luiz Dev.

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0-blue)
![C#](https://img.shields.io/badge/C%23-10.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)

## Sobre o Projeto

O **DevFreela** é uma API robusta para gerenciamento de projetos freelancer, permitindo que clientes publiquem projetos e freelancers possam se candidatar e executá-los. O sistema oferece funcionalidades completas para o ciclo de vida de projetos de freelance.

### Funcionalidades Principais

- **Gerenciamento de Usuários**
  - Cadastro e autenticação de clientes e freelancers
  - Perfis detalhados com habilidades e experiências
  - Sistema de avaliações e feedback

- **Gestão de Projetos**
  - Criação e publicação de projetos
  - Sistema de propostas e candidaturas
  - Acompanhamento do progresso do projeto
  - Marcos e entregas

- **Sistema de Pagamentos**
  - Integração com gateway de pagamento
  - Controle de valores e comissões
  - Histórico de transações

- **Comunicação**
  - Sistema de comentários nos projetos
  - Notificações em tempo real
  - Chat entre cliente e freelancer

## Tecnologias Utilizadas

### Backend
- **ASP.NET Core 6.0** - Framework web
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server** - Banco de dados principal
- **AutoMapper** - Mapeamento de objetos
- **FluentValidation** - Validação de dados
- **JWT** - Autenticação e autorização
- **Swagger/OpenAPI** - Documentação da API

### Arquitetura e Padrões
- **Clean Architecture** - Arquitetura limpa e desacoplada
- **CQRS** - Command Query Responsibility Segregation
- **Repository Pattern** - Padrão para acesso a dados
- **Dependency Injection** - Injeção de dependência
- **Unit of Work** - Padrão para controle transacional

## 📁 Estrutura do Projeto

```
DevFreela/
├── src/
│   ├── DevFreela.API/              # Camada de apresentação (Controllers, Middlewares)
│   ├── DevFreela.Application/      # Camada de aplicação (Services, DTOs, Commands, Queries)
│   ├── DevFreela.Core/            # Camada de domínio (Entities, Interfaces, Enums)
│   └── DevFreela.Infrastructure/   # Camada de infraestrutura (Data, External Services)
├── tests/
│   ├── DevFreela.UnitTests/       # Testes unitários
│   └── DevFreela.IntegrationTests/ # Testes de integração
└── docs/                          # Documentação adicional
```

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/sql-server) ou [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

## Instalação e Configuração

### 1. Clone o repositório
```bash
git clone https://github.com/luanheuripedes/DevFreela.git
cd DevFreela
```

### 2. Configuração do Banco de Dados
```bash
# Navegue até o projeto da API
cd src/DevFreela.API

# Execute as migrations
dotnet ef database update
```

### 3. Configuração do appsettings.json
```json
{
  "ConnectionStrings": {
    "DevFreelaCs": "Server=localhost;Database=DevFreela;Trusted_Connection=true;"
  },
  "Jwt": {
    "Key": "SUA_CHAVE_SECRETA_AQUI",
    "Issuer": "DevFreela",
    "Audience": "DevFreela-Users"
  }
}
```

### 4. Execute o projeto
```bash
dotnet run
```

A API estará disponível em `https://localhost:7000` ou `http://localhost:5000`

## Documentação da API

Após executar o projeto, acesse a documentação interativa do Swagger:
- **Swagger UI**: `https://localhost:7000/swagger`

### Principais Endpoints

#### Autenticação
- `POST /api/auth/login` - Login de usuário
- `POST /api/users` - Cadastro de usuário

#### Projetos
- `GET /api/projects` - Listar projetos
- `POST /api/projects` - Criar projeto
- `GET /api/projects/{id}` - Obter projeto por ID
- `PUT /api/projects/{id}` - Atualizar projeto
- `DELETE /api/projects/{id}` - Deletar projeto

#### Comentários
- `POST /api/projects/{id}/comments` - Adicionar comentário
- `GET /api/projects/{id}/comments` - Listar comentários do projeto

##  Testes

### Executar Testes Unitários
```bash
dotnet test tests/DevFreela.UnitTests/
```

### Executar Testes de Integração
```bash
dotnet test tests/DevFreela.IntegrationTests/
```

### Coverage de Testes
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Deploy

### Docker
```dockerfile
# Exemplo de Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DevFreela.API/DevFreela.API.csproj", "DevFreela.API/"]
RUN dotnet restore "DevFreela.API/DevFreela.API.csproj"
COPY . .
WORKDIR "/src/DevFreela.API"
RUN dotnet build "DevFreela.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevFreela.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevFreela.API.dll"]
```

## Projetos Relacionados

- **[DevFreelaAngular](https://github.com/luanheuripedes/DevFreelaAngular)** - Frontend em Angular
- **[DevFreelaMicrosservico](https://github.com/luanheuripedes/DevFreelaMicrosservico)** - Microsserviço de pagamentos

## Contribuição

Contribuições são sempre bem-vindas! Para contribuir:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Autor

**Luan Heuripedes**
- LinkedIn: [/in/luan-heuripedes](https://www.linkedin.com/in/luan-heuripedes/)
- GitHub: [@luanheuripedes](https://github.com/luanheuripedes)

## Suporte

Se você tiver alguma dúvida ou precisar de ajuda, sinta-se à vontade para:
- Abrir uma [issue](https://github.com/luanheuripedes/DevFreela/issues)
- Entrar em contato através do LinkedIn

---

Projeto desenvolvido durante a formação ASP.NET Core, aplicando conceitos modernos de desenvolvimento web e arquitetura de software.
