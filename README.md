# Desafio Simplificado

O que é o desafio?

O projeto consiste em uma Web Api Rest a fim de gerenciar os patrimonios de uma empresa.

# Tecnologias Utilizadas

- ASP.NET Core 2.2 (with .NET Core 2.2)
- ASP.NET WebApi Core
- Entity Framework Core 2.2

# Arquitetura

- Infra contem o context do Entity para acesso ao banco
- Classes DAO (Data Access Object) onde ficam os comando do banco de dados SQL
- A pasta Models onde ficam as Entidades/Classes (MArca e Patrimonio)
- Controllers possuem os metodos abaixo

# Lista dos metodos da Api

- api/Marca => Busca todas as marcas cadastradas no banco
- api/Marca/{id} => Busca as marcas pelo Id
- api/Marca/{id}/Patrimonio => Busca todos os patrimonios de uma marca
- (post) api/Marca => Insere uma nova marca se essa não existir, se existir retorna a mensagem
- (put) api/Marca/{id} => Altera determinada marca
- (delete) api/Marca/{id} => Deleta a marca

- api/Patrimonio => Busca todos os patrimonios
- api/Patrimonio/{id} => Busca os patrimonios por id
- (post) api/Patrimonio => Insere um novo patrimonio
- (put) api/Patrimonio => Altera os dados de um patrimonio
- (delete) api/Patrimonio/{id} => Deleta o patrimonio

# Injeção de Dependecia

Os controllers implementam injeção de dependência do classe DAO e Context para realizarem as operações no banco de dados.

# Chamando métodos POST e PUT

Para chamar os métodos POST e PUT utilize no Fiddler ou Postman o seguinte:

Para testar o POST é necessário passar no BODY Nome, MarcaId e Descrição. 
EX:

  {
    "nome": "Fulano",
    "marcaId": 1,
    "descricao": "descrição 1"
  }
  
  Para testar o PUT apenas o Nome passando o id na url
EX:

  {
    "nome": "Fulano"
  }
