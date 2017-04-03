# Infnet.Aspnet.Tp3
Tp3 da matéria de ASP.NET

## Enunciado

O aluno deve criar uma aplicação web com o ASP .NET MVC para criar, ler, atualizar e deletar entradas do SQL Server Express LocalDB. Essas entradas serão livros com os seguintes campos: título, autor, editora, ano.

Essa aplicação consiste em:

- Uma página de cadastro de livros.
- Uma página de edição de um livro.
- Uma página de detalhes de um livro.
- Uma página de deleção de um livro.
- Uma página que exibe a lista de livros.

É importante destacar que o aluno deverá criar o banco de dados, a tabela Livro no banco de dados, o modelo na aplicação, as visões fortemente tipadas, e os controladores.

O aluno pode se inspirar nesse artigo: [Implementing Basic CRUD Functionality with the Entity Framework in ASP.NET MVC Application](https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application)

Mas vale ressaltar que o trabalho a ser implementado deve utilizar o ADO .NET e não o Entity Framework.

O trabalho deve ser entregue, no Moodle, como uma solução, ou projeto, do Visual Studio 2015, em um arquivo zipado (.zip.)

## Assessment

O aluno deve criar uma aplicação web com o ASP .NET MVC que permita que um usuário gerencie sua coleção de livros e os empréstimos dos mesmos. Os livros podem conter apenas os campos titulo, autor, editora e ano, e cada empréstimo contém os campos data de empréstimo, data de devolução e livro.

Essa aplicação consiste em:

- Uma página de cadastro de livros.
- Uma página de edição de um livro.
- Uma página de detalhes de um livro.
- Uma página de deleção de um livro.
- Uma página que exibe a lista de livros.
- Uma página de cadastro de empréstimo.
- Uma página de edição de empréstimo.
- Uma página que exibe a lista de empréstimos.

A listagem de livros pode diferenciar os livros com empréstimos em aberto dos livros disponíveis.

A listagem de empréstimos pode ser exibida na página de detalhes de um livro. O cadastro e edição de um empréstimo podem ser exibidos a partir da página de detalhes de um livro.

É importante destacar que o aluno deverá criar o banco de dados, as tabelas Livro e Emprestimo, seus relacionamentos, os modelos na aplicação, as visões fortemente tipadas, os controladores, as validações necessárias e alguns testes unitários de controladores.

O trabalho deve ser implementado utilizando o ADO .NET.

O trabalho deve ser entregue, no Moodle, como uma solução, ou projeto, do Visual Studio 2015, em um arquivo zipado (.zip.).
