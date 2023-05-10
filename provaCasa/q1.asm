.text
#Bráulio melhor professor da terra
main:
	addi $2, $0, 5
	syscall
	add $8, $0, $2		#input 1
	
	addi $2, $0, 5
	syscall
	add $9, $0, $2		#input 2
	
	#Verifica maior
	slt $20, $8, $9		#Se $8 < $9 $20 = 1 else 0
	beq $20, 1, menor8
	addi $8, $8, 1		# Se chegou aqui é porque o $9 é maior	

for9:
	beq $9, $8, fim		#Se o menor valor se equipar ao maior, FIM
	andi $24, $9, 1		#Verifica se o ultimo bit é 1
	bne $24, $0 passa9	#Se for 1 passa pois o numero é impar
	
	add $4, $0, $9		#Printa pois pelo visto é par
      	addi $2, $0, 1
      	syscall
      	addi $4, $0, '\n'
      	addi $2, $0, 11
      	syscall
      	
passa9:
	addi $9, $9, 1
	j for9
	
menor8:
	addi $9, $9, 1		#Soma 1 ao maior valor
for8:
	beq $8, $9, fim		#Se o menor valor se equipar ao maior, FIM
	andi $24, $8, 1		#Verifica se o ultimo bit é 1
	bne $24, $0 passa8	#Se for 1 passa pois o numero é impar
	
	add $4, $0, $8		#Printa pois pelo visto é par
      	addi $2, $0, 1
      	syscall
      	addi $4, $0, '\n'
      	addi $2, $0, 11
      	syscall
	
passa8:
	addi $8, $8, 1
	j for8

fim:
	addi $2, $0, 10
	syscall
