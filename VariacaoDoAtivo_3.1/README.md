# Teste Prático - Variação do ativo

Este documento detalha a solução de um desafio que consiste em consultar a variação do preço de um ativo escolhido nos últimos 30 pregões. A solução apresentada neste documento utiliza a API do Yahoo Finance para consultar os preços do ativo escolhido. Foi implementada uma solução de backend com em .NET Core e utilizada a arquitetura DDD (Domain Driven Design).

O objetivo principal é apresentar o percentual de variação de preço de um dia para o outro e o percentual desde o primeiro pregão apresentado. Para isso, a solução busca os dados na API da Yahoo Finance e armazena as informações consultadas em uma base de dados SQL Server local. A solução também implementa uma API que consulta essas informações na base de dados, retornando o valor do ativo nos últimos 30 pregões e apresentando a variação do preço no período, considerando o valor de abertura.

## Requisitos

1. Solução desenvolvida utilizando .NET 6.0 e Entity Framework Core. Sendo assim se faz necessário o download do ".NET SDK", conforme o ambiente em que a solução estiver operando. O download pode ser realizado através do link: https://dotnet.microsoft.com/en-us/download

2. Para armazenar os dados, utiliza-se o Banco de Dados SQL Server.
Caso o usuário deseje acessar os dados diretamente, pode-se fazer um download de algum SGBD como o "SQL Server Management Studio". 
Link para o download da ferramenta: https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms

3. Caso deseje publicar o projeto, certifique-se de instalar o ASP.NET Core Runtime 6.0. Para Windows é necessário o download e instalação do 'Hosting Bundle' e 'x64/x86 Runtime' presentes no link: https://dotnet.microsoft.com/en-us/download/dotnet/6.0 

## Execução do Projeto

É de escolha do usuário executar o projeto diretamente pelo Visual Studio 2022 (que será um processo mais rápido) ou publicar a solução em um site no IIS local. Abaixo segue o passo a passo para a execução do projeto diretamente pelo VS22:

1. O usuário deve clonar ou mesmo baixar o código fonte pelo botão '<>code' disponível nessa página!
2. Abra a solução do projeto com o VS22. Esta é a versão suportada pelo .NET 6.0
3. Uma vez aberta a solução, o usuário já pode executá-la. Caso o Visual Studio solicite a aprovação de confiança do certificado SSL, o usuário deve confirmar o aceite para a execução do swagger.

## Publicar o Projeto

A seguir um passo a passo para publicação da solução utilizando o Visual Studio 2022 no idioma pt-br.

1. Crie um novo site no IIS. Certifique-se de conceder as permissões necessárias ao pool e ao usuário do Windows para não obter erros de permissão de acesso.
2. Para criar um perfil de publicação o usuário pode clicar com o botão direito no projeto 'VariacaoDoAtivo' e escolher a opção 'Publicar'. Irá abrir uma janela com as opções de publicação. Escolha o Destino como 'Pasta' e clique em próximo. Por padrão, o visual studio preenche o 'Local da pasta', então já podemos clicar em Concluir.
3. Após concluir irá aparecer a janela de progresso e logo irá mostrar um aviso de Perfil de publicação criado. Clique em fechar. A janela que estará aberta no fundo é o perfil de publicação que criamos. Agora basta clicar no botão 'Publicar '
4. Clique na opção 'Mostrar todas as configurações'. Aguarde enquanto o Visual Studio carrega o Contexto de Dados. Serão mostradas as opções 'Banco de Dados' e 'Migrações do Entity Framework'. Expanda ambas as opções e marque suas caixas de seleção que representa o valor da ConnectionString do SQL Server. Clique em Salvar. **OBS:** caso seja apresentado algum erro de dotnet tool, certifique-se de que o dotnet tool está instalado executando o seguinte comando no Console de Gerenciador de pacotes: 'dotnet tool install --global dotnet-ef'
5. Agora o perfil está preparado para publicação. O usuári pode clicar no botão 'Publicar' que está na janela atual. 
6. Após publicar, o usuário deverá copiar o conteúdo que se encontra dentro do diretório que foi definido no etapa 2 deste passo-a-passo e colar no diretório onde foi criado o Site do IIS (na etapa 1).
7. Para acesso às rotas configuradas no projeto, o usuário deve acessar o endereço que foi configurado no IIS + o sufixo '/swagger/index.html'. Exemplo de acesso: http://localhost:7530/swagger/index.html

## Funcionamento do projeto

- Foram criadas rotas de GET, POST, PATCH e DELETE para a manipulação do BD.
- Para popular o banco de dados, o usuário deve fazer um POST e informar o NOME do ativo que deseja obter o resultado no parametro 'IdentificacaoAtivo'. Exemplos: **NUBR33.SA** / **PETR4.SA**
- Não é possivel popular o BD com dados de dois ativos simultaneamente, uma vez que essa API foi construida para listar os ultimos 30 pregões de um unico ativo. Caso o usuário deseje consultar um ativo diferente, ele deverá utilizar a rota de DELETE para limpar os dados da tabela e em seguida executar um novo POST com o nome do ativo desejado.
- O método de PATCH está sem validação de conteúdo pois a intenção era somente demonstrar a aplicação dos verbos Http.

## Anotações importantes sobre o dotnet ef

O projeto está sendo criado com .NET 6.0, por esse motivo deixarei aqui registrado algumas anotações para executar corretamente os comandos do dotnet ef no Console do Gerenciador de pacotes

1. É importante que a pasta atual onde o console inicializa seja a pasta da Solução do projeto. para isso rode o comando:
`dir`
E você verá a estrutura de pastas atual da instancia do seu console. Caso ainda nao esteja na pasta da Solução do projeto, use o comando:
`cd C:\Pasta\PastaSolucao\`
Para redirecionar o console para o local correto.

2. Para realizar os comandos do dotnet ef tools, você precisará utilizar de algumas "options" para referenciar o projeto de Data e o projeto Startup. Exemplos:
```
dotnet ef migrations add Initial --project VariacaoDoAtivo.Data -c VariacaoDbContext --startup-project VariacaoDoAtivo
```
e tambem:
```
dotnet ef database update --project VariacaoDoAtivo.Data -c VariacaoDbContext --startup-project VariacaoDoAtivo
```

## Informações Adicionais

- Este projeto foi criado para validação de conhecimento e serve de Teste Prático para uma oferta de trabalho.
- O usuário deve ficar atento com o caminho fisico da pasta deste projeto, pois existe a chance de erro de execução do projeto por falta de permissão de execução dependendo do diretório em que se encontra.
- Em caso de dúvidas ou sugestões, entre em contato comigo pelo meu e-mail: palmutip@hotmail.com