Funcionalidade: Criar funcionário com steps genéricos

Cenario: Criação de funcionário com sucesso
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E que seja feita uma chamada do tipo 'POST' para o endpoint 'v1/employees' com o corpo da requisição
		"""
			{
				"name": "Funcionário 1",
				"email": "funcionário1@empresa.com"
			}
		"""
	Entao o código de retorno será '201'
	E o registro estará disponível na tabela 'Employee' da base de dados
		| Id | Name            | Email                      | Active |
		| 1  | 'Funcionário 1' | 'funcionário1@empresa.com' | True   |