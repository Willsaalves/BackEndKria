### README - Backend (ASP.NET Core)

Bem-vindo ao Repositório de Favoritos do GitHub - Backend!

Este é o repositório contendo o código-fonte do backend da aplicação, desenvolvido em ASP.NET Core. Aqui estão algumas instruções para começar:

## Iniciando o Projeto

1. **Clonar o Repositório:**
```bash
git clone <URL_do_repositório>
```

2. **Configurar o Ambiente de Desenvolvimento:**
- Certifique-se de ter o ambiente de desenvolvimento do ASP.NET Core configurado em sua máquina.

3. **Executar o Projeto:**
- Abra a solução (`KriaBackEnd.sln`) no Visual Studio.
- Pressione F5 para compilar e executar o backend.

4. **Acessar a Aplicação:**
A API estará disponível em [`http://localhost:5093/`](http://localhost:5093/swagger/index.html).

## Funcionalidades

1. **Marcação de Favoritos:**
- Utilize o endpoint `POST /api/Favorite/CreateFavorite` para marcar repositórios como favoritos.

## Tecnologias Utilizadas

- ASP.NET Core para o backend da aplicação.
- Entity Framework Core para interagir com o banco de dados.
