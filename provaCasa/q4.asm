.text
#Bráulio melhor professor da terra
main:
	addi $2, $0, 5
	syscall
	add $8, $0, $2		#input 1
	
	addi $2, $0, 5
	syscall
	add $9, $0, $2		#input 2
	
	addi $24, $0, 1		#Valor 1 para comparação
	addi $10, $0, 1		#Inicializar incremento
	addi $11, $0, 1		#Quantidade de divisores
	addi $19, $0, 2		#teste
	
for:
	slt $20, $19, $11	#Se $19(2) < $11(divisores) entao $20 = 1
	beq $20, 1, printN	#Ja temos que a quantidade de divisores comum é maior que 2, logo nao sao primos
	beq $10, $9, printS	#Ja chegamos nos nosso valores e a quantidade de divisores nao ultrapaddou2, logo são primos
	
	div $8, $10		#divide e pega o resto
	mfhi $12
	
	div $9, $10		#divide e pega o resto
	mfhi $13

verificaResto:
	slt $14, $12, $24	# Resto igual a 0
	slt $15, $13, $24	# Resto igual a 0
	and $16, $14, $15	#Se em ambos tivermos o valor 1, sao divisiveis por este valor
	beq $16, 1, adiciona
	addi $10, $10, 1
	j for

adiciona:
	addi $11, $11, 1
	addi $10, $10, 1
	j for
	
printN:
	add $4, $0, 'N'
	addi $2, $0, 11
	syscall
	j fim

printS:
	add $4, $0, 'P'
	addi $2, $0, 11
	syscall
	j fim
	
fim:
	addi $2, $0, 10
	syscall
