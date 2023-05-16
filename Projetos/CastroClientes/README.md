# Exemplo de aplicação web em 3 camadas

Este é um projeto de Cadastro de Clientes desenvolvido no Visual Studio usando o modelo de arquitetura de 3 camadas (3 layer architecture). O objetivo desta aplicação é permitir o cadastro e gerenciamento de clientes, utilizando diferentes projetos para acesso aos dados e duas opções de interface: uma construída com MVC e outra com Web Forms.

## Projetos

A solução é composta por vários projetos, cada um com uma responsabilidade específica:

1. **CadastroClientes.Objetos**: Este projeto contém as classes '**ClienteDTO**' e '**UsuarioDTO**', que são utilizadas para transferência de dados entre as camadas.

2. **CadastroClientes.Regras**: Neste projeto, estão localizadas as classes '**ClienteBLL**' e '**UsuarioBLL**', responsáveis por implementar as regras de negócio relacionadas aos clientes e usuários, respectivamente. Essas classes fazem chamadas às funções dos projetos de acesso a dados.

3. **DataAccess**: Este projeto é responsável pela conexão com o banco de dados utilizando o ADO .NET Entity Data Model. Ele possui as classes '**ClientesDAL**' e '**UsuariosDAL**', onde são realizadas operações de CRUD utilizando o Entity Framework.

4. **DataAccessADO**: Este projeto utiliza a classe '**System.Data.SqlClient**' para a conexão com o banco de dados e possui as classes '**ClientesDAL**' e '**UsuariosDAL**' para as operações de CRUD utilizando SQL padrão.

5. **Comuns**: Este projeto compartilhado contém duas classes úteis: uma classe de extensão de string e outra para criptografia. Essas classes podem ser utilizadas por outros projetos dentro da solução.

6. **WebApp**: Este projeto de aplicação web foi construído em MVC e utiliza o projeto DataAccess para realizar a manipulação dos dados. A interface é composta por uma tela de login para autenticação e uma opção para criar cadastro. Após a autenticação, o menu de cabeçalho é preenchido com as opções "Usuários", "Clientes" e "Logout", permitindo o CRUD conforme as tabelas correspondentes.

7. **WebFormsApp**: Este projeto de aplicação web foi construído utilizando Web Forms e utiliza o projeto DataAccessADO para realizar a manipulação dos dados. Assim como o projeto WebApp, ele possui uma tela de login, um formulário de cadastro e um menu de cabeçalho com as opções "Usuários", "Clientes" e "Logout".

## Banco de Dados

A pasta ScriptsBD possui um script para criar um novo Banco de Dados no SQL Server com as tabelas necessárias para funcionamento do processo. Para executar o script, pode ser usado o SQL Server Management Studio (SSMS). Com ele aberto siga os seguintes passos:

1. Abra uma nova janela de consulta no SSMS e cole o conteúdo do script SQL 'CadastroClientes.sql' no editor.
2. Execute o script SQL selecionado clicando no botão "Execute" (ou pressionando a tecla F5). O SSMS executará o script e criará o banco de dados especificado.

Após a conclusão do script, você terá um novo banco de dados criado no servidor SQL Server.

## Instalação e Configuração

1. Clone o repositório para sua máquina local.
2. Abra a solução no Visual Studio.
3. Verifique se todas as dependências estão corretamente instaladas e configuradas.
4. Compile a solução para garantir que não ocorram erros de compilação.

## Executando a Aplicação

1. Selecione o projeto desejado (WebApp ou WebFormsApp) e defina-o como projeto de inicialização. 
 - Se escolher WebFormsApp, certifique-se de ajustar a classe '**Conexão**' no projeto '**DataAccessADO**' para ajustar a connection string no construtor da classe conforme as credenciais do seu banco de dados local.
 - Se escolher WebApp, será necessário atualizar o arquivo de conexão ADO .NET Entity Data Model conforme sua instancia do banco de dados.
2. Inicie a depuração da aplicação.
3. Na pagina de login, crie o primeiro cadastro e terá acesso as paginas da aplicação.
4. Explore as opções disponíveis no menu de cabeçalho para realizar as operações de CRUD.