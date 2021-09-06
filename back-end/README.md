# Treinamento de Automação de Testes Backend

Este documento tem por objetivo guiá-lo no processo de configuração e instalação das ferramentas que serão usadas durante o treinamento de automação de testes backend usando c#, bem como a inicialização e uso do sistema que iremos automatizar.

## Estrutura do projeto

Para o treinamento de automação de testes, usaremos uma Web Api desenvolvida em .Net5 com o banco de dados Postgres conteinerizados em um ambiente docker.

Para mais detalhes sobre como configurar o projeto, siga o passo-a-passo abaixo ou consulte os [documentos de apoio](#documentos-de-apoio).

**Estrutura de pastas**

`./`<br />
`└─ ci` -> _configurações referentes a integração contínua_<br />
`└─ src` -> _código gerado no desenvolvimento do projeto a ser automatizado._<br />
`└─ tools` -> _ferramentas de uso comum e auxiliares_ <br />
`└─ .gitignore` -> _configurações de ignore do git_<br />
`└─ README.md` -> _conteúdo deste documento_

## Configurando a aplicação

**IDE (Ambiente de Desenvolvimento Integrador)**

Nos próximos passos você encontrará instruções para instalação e configuração de duas opções
de IDE, **você não precisa instalar as duas**, basta escolher a de sua preferência e seguir
com o treinamento.

Obs.:
Para a gravação do treinamento foi utilizado o Visual Studio 2019 Enterprise (requer
licença).

**Visual Studio - Setup**

Faça o [download](https://visualstudio.microsoft.com/pt-br/downloads/) do Visual Studio 2019 ou superior, durante a instalação selecione o pacote
para desenvolvimento de aplicações “ASP<i></i>.NET e Desenvolvimento Web”.

Na aba “Componentes Individuais”, verifique se as opções SDK do .NET e Runtime do .NET
5.0 estão selecionadas, caso não estejam selecione-as.

O idioma padrão da IDE utilizado durante o treinamento é o inglês, para evitar dificuldades
em encontrar menus por causa da diferença entre linguagens, sugerimos que você
selecione e instale o idioma “Inglês” na aba “Pacote de idiomas”.

Em caso de dúvida em alguma etapa do processo de instalação, consulte o [guia completo
de instalação](https://docs.microsoft.com/pt-br/visualstudio/install/install-visual-studio?view=vs-2019) do Visual Studio.

Após concluir a instalação, faça o [download](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio) e instale a extensão do SpecFlow que facilitará a criação e escrita dos cenários de teste.

**Visual Studio Code - Setup**

Faça o [download](https://dotnet.microsoft.com/download/dotnet/5.0) do Dotnet 5.0 SDK e prossiga com a instalação, este recurso é necessário para o desenvolvimento e execução do projeto de teste.

Faça o [download](https://code.visualstudio.com/Download) e instale o Visual Studio Code.

Extensões úteis para o desenvolvimento do projeto de teste:
* [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Cucumber Language Support](https://marketplace.visualstudio.com/items?itemName=alexkrechik.cucumberautocomplete)


**Docker - Setup**

Faça o [download](https://www.docker.com/get-started) do docker para o sistema operacional de sua preferência e prossiga com a instalação, em caso de dúvidas consulte o [guia de instalação](https://docs.docker.com/engine/install/).

Caso seja necessário a atualização do kernel, consulte as etapas 4 e 5 presentes [neste guia](https://docs.microsoft.com/pt-br/windows/wsl/install-win10#step-4---download-the-linux-kernel-update-package).

**Iniciando as aplicações**

Mapeie o repositório em uma pasta de sua preferência.

Abra o PowerShell ou prompt de comando na pasta `./ci` e execute o comando abaixo para gerar as imagens necessárias das aplicações que serão utilizadas:

```
docker-compose build
```

Após a conclusão do build, execute o comando abaixo para iniciar os containers.

```
docker-compose up -d
```

Se todos os passos forem executados com sucesso, a aplicação estará pronta para ser utilizada.

**Encerrando as aplicações**

Abra o PowerShell ou prompt de comando na pasta `./ci` e execute o comando abaixo para encerrar os containers das aplicações:

```
docker-compose down
```

O comando acima irá parar os containers usados, mas manterá as images e os volumes das aplicações para reuso no futuro, caso queira remover por completo os recursos usados pelas aplicações, execute o comando abaixo:

```
docker-compose down -v --rmi all
```

**Acessando as aplicações**

*WebApi:*<br/>
&nbsp;&nbsp;&nbsp;Url: http://localhost:8080/swagger<br/>

*Autenticação WebApi:*<br/>
&nbsp;&nbsp;&nbsp;Url: http://localhost:8080/v1/public/auth<br/>
&nbsp;&nbsp;&nbsp;Username: teste.automatizado<br/>
&nbsp;&nbsp;&nbsp;Password: treinamento123

*Postgres:*<br/>
&nbsp;&nbsp;&nbsp;Host: localhost:5432 / postgresdb<br/>
&nbsp;&nbsp;&nbsp;Database: employee<br/>
&nbsp;&nbsp;&nbsp;Username: teste.automatizado<br/>
&nbsp;&nbsp;&nbsp;Password: treinamento123

*PgAdmin:*<br/>
&nbsp;&nbsp;&nbsp;Url: http://localhost:16543/<br/>
&nbsp;&nbsp;&nbsp;Username: teste.automatizado@cwi.com.br<br/>
&nbsp;&nbsp;&nbsp;Password: treinamento123

## Documentos de apoio

Documento auxiliar para configuração/inicialização da aplicação:

[`./tools/docs/Configuração Api - Treinamento de Automação de Testes.pdf`](https://git.cwi.com.br/prytula-daniel/quadrante-qualidade/csharp-test-automation-workshop/blob/master/tools/docs/Configura%C3%A7%C3%A3o%20Api%20-%20Treinamento%20de%20Automa%C3%A7%C3%A3o%20de%20Testes.pdf)

Documento auxiliar para uso da aplicação:

[`./tools/docs/Documentação Api - Treinamento de Automação de Testes.pdf`](https://git.cwi.com.br/prytula-daniel/quadrante-qualidade/csharp-test-automation-workshop/blob/master/tools/docs/Documenta%C3%A7%C3%A3o%20Api%20-%20Treinamento%20de%20Automa%C3%A7%C3%A3o%20de%20Testes.pdf)

Diagrama da base de dados:

[`./tools/docs/Treinamento-DatabaseSchema.jpg`](https://git.cwi.com.br/prytula-daniel/quadrante-qualidade/csharp-test-automation-workshop/blob/master/tools/docs/Treinamento-DatabaseSchema.jpg)

## Referências
- [.NET](https://docs.microsoft.com/pt-br/dotnet/core/introduction)
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [SpecFlow](https://docs.specflow.org/en/latest/)
- [Docker](https://docs.docker.com/get-started/)
- [PowerShell](https://docs.microsoft.com/pt-br/powershell/scripting/overview?view=powershell-7.1)
- [Prompt de Comando](https://docs.microsoft.com/pt-br/windows-server/administration/windows-commands/cmd)
- [Postgres](https://www.postgresql.org/)
- [PgAdmin](https://www.pgadmin.org/)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [Visual Studio Code](https://code.visualstudio.com/docs)