Funcionalidade: Obter todos os funcionários

Cenario: Obter os funcionários sem registros na base
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E que seja feita uma chamada do tipo 'GET' para o endpoint 'v1/employees'
	Entao o código de retorno será '204'

Cenario: Obter os funcionários com registros na base
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E que os registros sejam inseridos na tabela 'Employee' da base de dados
		| Id | Name            | Email             | Active |
		| 1  | 'Funcionario 1' | 'func1@email.com' | True   |
		| 2  | 'Funcionario 2' | 'func2@email.com' | True   |
	E que seja feita uma chamada do tipo 'GET' para o endpoint 'v1/employees'
	Entao o código de retorno será '200'
	E o conteúdo retornado será
		"""
		[
			{
				"id": 1,
				"name": "Funcionario 1",
				"email": "func1@email.com",
				"active": true
			},
			{
				"id": 2,
				"name": "Funcionario 2",
				"email": "func2@email.com",
				"active": true
			}
		]
		"""