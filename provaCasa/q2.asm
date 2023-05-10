.text
#Bráulio melhor professor da terra
main: 
	addi $8, $0, 1 
	 
for:   	
	addi $2, $0, 5		#Recebe o valor digitado
      	syscall
      	
      	srl $9, $2, 31		#Pega o bit mais significativo
      	bne $9, $0, sai  	#Verifica se o bit mais significativo é diferente de 0, se sim sai
      	
      	mult $8, $2
      	mflo $8
      	j for
      	    
sai:  
	add $4, $8, $0
      	addi $2, $0, 1
      	syscall
      	
fim:  
	addi $2, $0, 10
      	syscall