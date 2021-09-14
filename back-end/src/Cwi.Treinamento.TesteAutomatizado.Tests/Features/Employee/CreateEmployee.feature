Funcionalidade: Cadastro de funcionário
	Sendo um usuário com as devidas permissão
	Quero poder cadastrar um novo funcionário

Cenario: Cadastro de um funcionário sem autenticação
	Dado que o usuário não esteja autenticado
	E que seja solicitado a criação de um novo usuário
	Então o funcionário não será cadastrado
	E será retornado uma mensagem de erro de autenticação