.text
#Bráulio melhor professor da terra
main: 
	addi $2, $0, 5
      	syscall
      	add $8, $0, $2		#usuário digita
      	
      	addi $8, $8, 1		#Usuário digita + 1
      	addi $9, $0, 1		#Incremento
      	
      	addi $15, $0, 1		#Somador
      	addi $16, $0, 0		#Referencia
      	addi $17, $0, 0		#Referencia
      	
for:
	slt $20, $9, $8		#Se $9 < $8 então $20 = 1 else = 0
	beq $20, $0, sai	#Se $20 = 0  então ja fizemos todas as linhas requeridas
	
	add $10, $9, $0		#Cópia do incremento
	addi $9, $9, 1		#Incremento
for2:
	slt $20, $0, $10	#Se $0 < $10, então $20 = 1 else = 0
	beq $20, $0, voltaFor
	
	add $4, $0, $15		#Printa o valor
	addi $2, $0, 1
	syscall
	
	add $4, $0, ' '		#Printa espaço
	addi $2, $0, 11
	syscall
	
	add $17, $16, $15	#Recebe a soma do atual com o anterior
	addi $16, $15, 0	#Recebe o anterior
	addi $15, $17, 0	#Recebe o atual
	
	subi $10, $10, 1	#subtrai 1
	j for2
	
voltaFor:
	add $4, $0, '\n'
	addi $2, $0, 11
	syscall
	j for

sai:
	addi $2, $0, 10
	syscall
