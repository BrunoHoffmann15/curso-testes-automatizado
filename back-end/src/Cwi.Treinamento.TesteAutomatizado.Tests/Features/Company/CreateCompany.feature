Funcionalidade: Criar empresa

Cenario: Criação de empresa com sucesso
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E que seja feita uma chamada do tipo 'POST' para o endpoint 'v1/companies' com o corpo da requisição
		"""
			{
			  "name": "<Name>",
			  "code": "<Code>",
			  "maxEmployeesNumber": <MaxEmployeesNumber>
			}
		"""
	Entao o código de retorno será '201'
	E o registro estará disponível na tabela 'Company' da base de dados
		| Id | Name     | Code     | MaxEmployeesNumber   | Active |
		| 1  | '<Name>' | '<Code>' | <MaxEmployeesNumber> | True   |
	Exemplos: 
		| Name      | Code | MaxEmployeesNumber |
		| Empresa 1 | 123  | 300                |