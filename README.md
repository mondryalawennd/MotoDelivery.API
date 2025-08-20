# 🏍️ MotoDelivery API

API para gerenciamento de motos, entregadores e entregas, construída com .NET e arquitetura DDD, seguindo boas práticas de Clean Code, SOLID e testes automatizados.

---

## 🚀 Tecnologias Utilizadas

| Tecnologia | Descrição |
|------------|-----------|
| ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white) | Linguagem principal da API |
| ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=flat&logo=dotnet&logoColor=white) | Framework para construção da API |
| ![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=flat&logo=dotnet&logoColor=white) | ORM para PostgreSQL |
| ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=flat&logo=postgresql&logoColor=white) | Banco de dados relacional |
| ![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=flat&logo=mongodb&logoColor=white) | Banco de dados NoSQL |
| ![AutoMapper](https://img.shields.io/badge/AutoMapper-007ACC?style=flat) | Mapeamento entre DTOs, Commands e Responses |
| ![MediatR](https://img.shields.io/badge/MediatR-FF9900?style=flat) | Implementação de CQRS e mensageria interna |
| ![Rebus](https://img.shields.io/badge/Rebus-FF6600?style=flat) | Sistema de mensageria para eventos de domínio |
| ![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white) | Contêinerização da aplicação e RabbitMQ |
| ![RabbitMQ](https://img.shields.io/badge/RabbitMQ-FF6600?style=flat&logo=rabbitmq&logoColor=white) | Mensageria distribuída |
| ![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat&logo=swagger&logoColor=white) | Documentação automática da API |
| ![xUnit](https://img.shields.io/badge/xUnit-FA7199?style=flat&logo=xunit&logoColor=white) | Testes unitários da API |

---

## 📦 Estrutura do Projeto

MotoDelivery
│
├─ Application/ # Casos de uso, Commands, Handlers, Profiles
├─ Domain/ # Entidades, agregados e regras de negócio
├─ Infrastructure/ # Repositórios, Configurações EF Core
├─ IoC/ # Injeção de dependências
├─ WebApi/ # Controllers e startup da aplicação
└─ Tests/ # Testes unitários e integração


---

## 📄 Casos de Uso

### Moto
- Cadastrar nova moto (Identificador, Ano, Modelo, Placa)  
- Garantir **placa única**  
- Gerar evento de **MotoCadastrada** via mensageria  
- Consumidor armazena motos 2024 no banco  
- Consultar motos e filtrar por placa  
- Modificar apenas a placa  
- Remover moto sem locações  

### Entregador
- Cadastrar entregador (Identificador, Nome, CNPJ, DataNascimento, NúmeroCNH, TipoCNH, ImagemCNH)  
- CNH válida: A, B ou A+B  
- CNPJ e CNH devem ser únicos  
- Enviar foto da CNH (png ou bmp) para storage (S3, MinIO ou disco local)  

### Locação
- Alugar motos por períodos (7, 15, 30, 45, 50 dias) com preços diferentes por dia  
- Data início obrigatória é **primeiro dia após criação**  
- Somente entregadores com CNH categoria A podem alugar  
- Calcular valor total e multas/dias adicionais:
  - Retorno antecipado → multa percentual das diárias não usadas  
  - Retorno tardio → cobrança diária adicional R$50  

---

## 📝 Como Rodar a Aplicação

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/MotoDelivery.git


 1. Configure variáveis de ambiente e connection strings (appsettings.json) para PostgreSQL e MongoDB.

2. Execute os contêineres com Docker (incluindo RabbitMQ):
   docker-compose up -d
3. Rode a aplicação:
   dotnet run --project MotoDelivery.WebApi
4. Acesse a documentação Swagger:
   http://localhost:5000/swagger
```

## 📄 Licença

MIT License © Mondrya Lawennd Mota

---

Se quiser, posso criar **uma versão ainda mais visual**, com **badges de status do build, cobertura de testes e versão do .NET**, para deixar o README pronto para **GitHub profissional**.  

Quer que eu faça essa versão completa?
