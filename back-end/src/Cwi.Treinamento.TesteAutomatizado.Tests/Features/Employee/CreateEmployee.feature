Funcionalidade: Cadastro de funcionarios
	Sendo um usu�rio com os devidas permiss�es
	Quero poder cadastra um novo funcionario

Cenario: Cadastro de funcionario sem autentica��o
	Dado que o usu�rio n�o esteja autenticado
	E que seja solicitado a cria��o de um novo funcion�rio
	Ent�o o funcion�rio n�o ser� cadastrado
	E ser� retornado uma mensagem de falha de autentica��o.