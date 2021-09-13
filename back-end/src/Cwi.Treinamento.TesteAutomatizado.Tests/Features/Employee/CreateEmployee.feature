Funcionalidade: Cadastro de funcionarios
	Sendo um usuário com os devidas permissões
	Quero poder cadastra um novo funcionario

Cenario: Cadastro de funcionario sem autenticação
	Dado que o usuário não esteja autenticado
	E que seja solicitado a criação de um novo funcionário
	Então o funcionário não será cadastrado
	E será retornado uma mensagem de falha de autenticação.