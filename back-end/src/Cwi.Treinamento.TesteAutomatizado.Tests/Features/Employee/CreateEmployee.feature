Funcionalidade: Cadastro de funcionário
	Sendo um usuário com as devidas permissão
	Quero poder cadastrar um novo funcionário

@Employee @CreateEmployee
Cenario: Cadastro de um funcionário sem autenticação
	Dado que o usuário não esteja autenticado
	E que seja solicitado a criação de um novo usuário
	Então o funcionário não será cadastrado
	E será retornado uma mensagem de erro de autenticação

@Employee @CreateEmployee
Cenario: Cadastro de um funcionário com sucesso
	Dado que a base de dados esteja limpa
	Dado que o usuário esteja autenticado
	E que seja solicitado a criação de um novo usuário
	Então o funcionário será cadastrado
	E o registro estará disponível na tabela 'Employee' da base de dados
	| Id | Name                | Email                    | Active |
	| 1  | 'Funcionario Teste' | 'funcionario1@email.com' | True   |