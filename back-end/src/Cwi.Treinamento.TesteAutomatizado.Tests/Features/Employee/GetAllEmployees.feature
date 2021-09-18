Funcionalidade: Obter todos os funcionários

Cenario: Obter os funcionários sem registros na base
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E que seja feita uma chamada do tipo 'GET' para o endpoint 'v1/employees'
	Entao o código de retorno será '204'