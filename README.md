<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, sans-serif;
            line-height: 1.6;
            color: #24292e;
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
        }
        h1, h2, h3 {
            color: #0366d6;
            margin-top: 24px;
            margin-bottom: 16px;
        }
        code {
            background-color: #f6f8fa;
            padding: 2px 4px;
            border-radius: 4px;
            font-family: SFMono-Regular, Consolas, 'Liberation Mono', Menlo, monospace;
        }
        pre {
            background-color: #f6f8fa;
            padding: 16px;
            border-radius: 6px;
            overflow: auto;
        }
        a {
            color: #0366d6;
            text-decoration: none;
        }
        a:hover {
            text-decoration: underline;
        }
        .badge {
            display: inline-block;
            padding: 3px 6px;
            border-radius: 3px;
            font-size: 12px;
            font-weight: 600;
            margin-right: 4px;
        }
        .badge-blue {
            background-color: #0366d6;
            color: white;
        }
        .badge-green {
            background-color: #28a745;
            color: white;
        }
    </style>
</head>
<body>

<h1>Cooperativa API</h1>
<p>Sistema de gerenciamento de cooperados e contatos favoritos para cooperativas de crédito</p>

<span class="badge badge-blue">.NET 8</span>
<span class="badge badge-green">PostgreSQL</span>
<span class="badge">Entity Framework</span>
<span class="badge">Swagger</span>

<h2>📋 Visão Geral</h2>
<p>API RESTful desenvolvida para gerenciar cooperativas, cooperados e seus contatos favoritos, com suporte a cadastro de chaves PIX.</p>

<h2>✨ Funcionalidades</h2>
<ul>
    <li>Cadastro de cooperativas e cooperados</li>
    <li>Gerenciamento de contatos favoritos</li>
    <li>Validação de chaves PIX (CPF, CNPJ, Email, Telefone ou Aleatória)</li>
    <li>Documentação automática com Swagger UI</li>
    <li>Arquitetura seguindo princípios SOLID</li>
</ul>

<h2>🚀 Começando</h2>

<h3>Pré-requisitos</h3>
<ul>
    <li><a href="https://dotnet.microsoft.com/download/dotnet/8.0">.NET 8 SDK</a></li>
    <li><a href="https://www.postgresql.org/download/">PostgreSQL 15+</a></li>
    <li><a href="https://git-scm.com/">Git</a> (opcional)</li>
</ul>

<h3>Instalação</h3>
<ol>
    <li>Clone o repositório:
        <pre><code>git clone https://github.com/seu-usuario/cooperativa-api.git
cd cooperativa-api</code></pre>
    </li>
    <li>Configure o banco de dados:
        <pre><code>CREATE DATABASE cooperativa;</code></pre>
    </li>
    <li>Atualize a connection string em <code>appsettings.json</code>:
        <pre><code>{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=cooperativa;Username=postgres;Password=sua_senha;"
  }
}</code></pre>
    </li>
    <li>Aplique as migrations:
        <pre><code>dotnet ef database update</code></pre>
    </li>
</ol>

<h2>🛠️ Executando</h2>
<pre><code>dotnet run</code></pre>

<p>Acesse a documentação da API:</p>
<ul>
    <li>Swagger UI: <a href="https://localhost:5001/swagger">https://localhost:5001/swagger</a></li>
    <li>Endpoint alternativo: <a href="http://localhost:5000/swagger">http://localhost:5000/swagger</a></li>
</ul>

<h2>🐳 Docker (Opcional)</h2>
<pre><code>docker-compose up --build</code></pre>

<h2>📚 Documentação da API</h2>

<h3>Cooperativas</h3>
<table>
    <tr>
        <th>Endpoint</th>
        <th>Método</th>
        <th>Descrição</th>
    </tr>
    <tr>
        <td><code>/api/Cooperativas</code></td>
        <td>GET</td>
        <td>Lista todas as cooperativas</td>
    </tr>
    <tr>
        <td><code>/api/Cooperativas</code></td>
        <td>POST</td>
        <td>Cria nova cooperativa</td>
    </tr>
</table>

<h3>Cooperados</h3>
<table>
    <tr>
        <th>Endpoint</th>
        <th>Método</th>
        <th>Descrição</th>
    </tr>
    <tr>
        <td><code>/api/Cooperados</code></td>
        <td>GET</td>
        <td>Lista todos os cooperados</td>
    </tr>
    <tr>
        <td><code>/api/Cooperados/por-conta/{conta}</code></td>
        <td>GET</td>
        <td>Busca cooperado por conta corrente</td>
    </tr>
</table>

<h2>🧪 Testes</h2>
<pre><code>dotnet test</code></pre>

<h2>🤝 Como Contribuir</h2>
<ol>
    <li>Faça um fork do projeto</li>
    <li>Crie sua branch (<code>git checkout -b feature/nova-feature</code>)</li>
    <li>Commit suas alterações (<code>git commit -m 'Adiciona nova feature'</code>)</li>
    <li>Push para a branch (<code>git push origin feature/nova-feature</code>)</li>
    <li>Abra um Pull Request</li>
</ol>

<h2>📄 Licença</h2>
<p>Distribuído sob a licença MIT. Veja <code>LICENSE</code> para mais informações.</p>

<h2>🛠 Troubleshooting</h2>
<p><strong>Problema:</strong> Erro de certificado SSL no Swagger</p>
<p><strong>Solução:</strong></p>
<ol>
    <li>Regenere o certificado:
        <pre><code>dotnet dev-certs https --clean
dotnet dev-certs https --trust</code></pre>
    </li>
    <li>Ou acesse via HTTP:
        <pre><code>http://localhost:5000/swagger</code></pre>
    </li>
</ol>

</body>
</html>
