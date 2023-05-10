.text
#Bráulio melhor professor da terra
main: 
	addi $2, $0, 5		#input
      	syscall
      	
	beq $2, $0, fim		#Se o valor digitado for 0, para
	#Caso nosso usuário digite apenas um valor, o mesmo será maior e ao mesmo tempo menor
	
      	add $9, $0, $2  	#Menor
      	add $10, $0, $2  	#Maior
      	addi $11, $0, 1		#Quantidades de valores digitados
      	add $12, $0, $2		#Soma de todos os valores digitados para média
      	
for:   	
	addi $2, $0, 5		#Recebe o valor digitado
      	syscall
      	
      	beq $2, $0, sai  	#Se o valor digitado for 0, para
      	
      	addi $11, $11, 1	#Cada vez que passa no for aumenta 1 para sabermos a quantidade de valores digitados
      	add $12, $12, $2	#Soma de todos os números digitados
      	
      	slt $20, $2, $9		#Se o $2 < $9, $11 = 1 else = 0
      	beq $20, $0, testMaior	#Se $20, contiver 0 nao é o menor, logo testaremos se é o maior
      	add $9, $0, $2		#Se chegou aqui, $2 menor que $9, logo, vamos atualizar
      	j fimTestes
      	
testMaior:
	slt $20, $10, $2	#Se $2 > $10, $20 = 1 else = 0
	beq $20, $0, fimTestes	#Se em $20 tivermos 0, nao é maior
	add $10, $0, $2		#Se chegou aqui, é maior

fimTestes:
	j for
      	    
sai:	
	div $14, $12, $11
	
	add $13, $9, $10	#Somando o menor valor e o maior valor
	div $15, $13, 2
	 
	add $4, $9, $0
      	addi $2, $0, 1
      	syscall
      	
      	addi $4, $0, '\n'
      	addi $2, $0, 11
      	syscall
      	
      	add $4, $10, $0
      	addi $2, $0, 1
      	syscall
      	
      	addi $4, $0, '\n'
      	addi $2, $0, 11
      	syscall
      	
      	add $4, $14, $0
      	addi $2, $0, 1
      	syscall
      	
      	addi $4, $0, '\n'
      	addi $2, $0, 11
      	syscall
      	
      	add $4, $15, $0
      	addi $2, $0, 1
      	syscall
fim:  
	addi $2, $0, 10
      	syscall