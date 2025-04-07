Cooperativa API - Sistema de Gerenciamento de Cooperados e Contatos Favoritos
📝 Descrição
API REST desenvolvida em .NET 8 para gerenciamento de cooperativas, cooperados e seus contatos favoritos, com integração a banco de dados PostgreSQL. O projeto inclui:

Cadastro de cooperativas e cooperados

Gerenciamento de contatos favoritos com chaves PIX

Documentação via Swagger

Arquitetura seguindo princípios SOLID

🛠️ Tecnologias
Backend: .NET 8, Entity Framework Core

Banco de Dados: PostgreSQL

Documentação: Swagger/OpenAPI

Containerização: Docker (opcional)

⚙️ Configuração do Ambiente
Pré-requisitos
.NET 8 SDK

PostgreSQL ou Docker

Git

Instalação
Clone o repositório:

bash
Copy
git clone https://github.com/seu-usuario/cooperativa-api.git
cd cooperativa-api
Configure o banco de dados:

Crie um banco chamado cooperativa no PostgreSQL

Atualize a connection string no appsettings.json:

json
Copy
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=cooperativa;Username=seu_usuario;Password=sua_senha;"
}
Execute as migrations:

bash
Copy
dotnet ef database update
Instale o certificado de desenvolvimento:

bash
Copy
dotnet dev-certs https --trust
🚀 Executando o Projeto
bash
Copy
dotnet run
A API estará disponível em:

Swagger UI: https://localhost:5001/swagger

Endpoint HTTP alternativo: http://localhost:5000/swagger

🐳 Execução com Docker (Opcional)
bash
Copy
docker-compose up --build
📚 Endpoints Principais
Cooperativas
GET /api/Cooperativas - Lista todas as cooperativas

POST /api/Cooperativas - Cria nova cooperativa

Cooperados
GET /api/Cooperados - Lista cooperados

GET /api/Cooperados/por-conta/{conta} - Busca por conta corrente

Contatos Favoritos
GET /api/cooperados/{id}/contatosfavoritos - Lista contatos de um cooperado

POST /api/cooperados/{id}/contatosfavoritos - Adiciona novo contato

🧪 Testes
Para executar os testes unitários:

bash
Copy
dotnet test
🤝 Contribuição
Faça um fork do projeto

Crie uma branch (git checkout -b feature/nova-feature)

Commit suas alterações (git commit -m 'Adiciona nova feature')

Push para a branch (git push origin feature/nova-feature)

Abra um Pull Request

📄 Licença
Este projeto está licenciado sob a licença MIT - veja o arquivo LICENSE para detalhes.
