//PROVA DE RAMON DE SOUSA VIEIRA
//20222014040012

using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace prova29_5
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            ContaReceber c1 = new ContaReceber("Ramon", new DateTime(1992, 12, 11), 200);
            ContaReceber c2 = new ContaReceber("Vinicius", new DateTime(2025, 12, 11), 200);
            ContaReceber c3 = new ContaReceber("Isis", new DateTime(2022, 12, 11), 200);
            ContaReceber c4 = new ContaReceber("Luana", new DateTime(2023, 6, 10), 200);
            ContaReceber c5 = new ContaReceber("Italo", new DateTime(2024, 12, 11), 200);

            Financeiro financas = new Financeiro();

            //INSERE
            financas.Inserir(c1);
            financas.Inserir(c2);
            financas.Inserir(c3);
            financas.Inserir(c4);
            financas.Inserir(c5);

            
            //LISTA
            Console.WriteLine("LISTOU:");
            foreach(ContaReceber c in financas.Listar()){
                Console.WriteLine(c);
            }

            Console.WriteLine();
            Console.WriteLine();

            //CONTAS RECEBIDAS
            Console.WriteLine("CONTAS RECEBIDAS:");
            foreach(ContaReceber c in financas.ContasRecebidas()){
                Console.WriteLine(c);
            }

            Console.WriteLine();
            Console.WriteLine();

            //CONTAS A RECEBER
            Console.WriteLine("CONTAS A RECEBER:");
            foreach(ContaReceber c in financas.ContasAReceber()){
                Console.WriteLine(c);
            }

            Console.WriteLine();
            Console.WriteLine();

            //CONTAS VENCIDAS
            Console.WriteLine("CONTAS VENCIDAS:");
            foreach(ContaReceber c in financas.ContasVencidas()){
                Console.WriteLine(c);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    class ContaReceber : IComparable{
        private string cliente;
        private DateTime dataVencimento;
        private double valor;
        private bool recebido = false;

        public ContaReceber(string c, DateTime d, double v){
            Cliente = c;
            DataVencimento = d;
            Valor = v;
        }

        //PROPS
        public string Cliente{
            set{
                if(value != "") this.cliente = value;
                else throw new ArgumentOutOfRangeException();
            }
            get{ return cliente;}
        }

        public DateTime DataVencimento{
            set{
                this.dataVencimento = value;
            }
            get{ return dataVencimento;}
        }

        public double Valor{
            set{
                if(value > 0) valor = value;
                else throw new ArgumentOutOfRangeException();
            }
            get{ return valor;}
        }

        public bool Recebido{
            get{ return recebido;}
        }

        public void Receber(){            
            this.recebido = true;
        }

        public override string ToString(){
            return $"{this.cliente} - {this.dataVencimento} - {this.valor} - {this.recebido}";
        }

        //Ordena por data
        public int CompareTo(object obj){
            ContaReceber conta = obj as ContaReceber;

            if(conta == null){
                throw new ArgumentOutOfRangeException();
            }

            return DataVencimento.CompareTo(conta.DataVencimento);
        }
    }

    class Financeiro{
        private ContaReceber[] contas = new ContaReceber[3];
        private int indice = 0;

        public void Inserir(ContaReceber c){
            if(indice == contas.Length){
                Array.Resize(ref contas, indice + 1);
            }
            contas[indice] = c;
            indice++;
        }

        public ContaReceber[] Listar(){
            ContaReceber[] vetorAux = new ContaReceber[indice];
            Array.Copy(contas, vetorAux, indice);
            Array.Sort(vetorAux);
            return vetorAux;
        }

        public ContaReceber[] ContasRecebidas(){
            ContaReceber[] vetorAux = new ContaReceber[indice];
            int n = 0;
            foreach(ContaReceber c in this.Listar()){
                if(c.Recebido == true){
                    vetorAux[n] = c;
                    n++;
                }
                else{
                    Array.Resize(ref vetorAux, indice-1); 
                }
            }
            Array.Sort(vetorAux);
            return vetorAux;
        }

        public ContaReceber[] ContasAReceber(){
            DateTime agora = new DateTime();
            agora = DateTime.Now;

            ContaReceber[] vetorAux = new ContaReceber[indice];
            int n = 0;
            foreach(ContaReceber c in this.Listar()){
                if(DateTime.Compare(c.DataVencimento, agora) == 1 && DateTime.Compare(agora.AddDays(15), c.DataVencimento) == 1){
                    vetorAux[n] = c;
                    n++;
                }
                else{
                    Array.Resize(ref vetorAux, indice--); 
                }
            }
            Array.Sort(vetorAux);
            return vetorAux;
        }

        public ContaReceber[] ContasVencidas(){
            DateTime agora = new DateTime();
            agora = DateTime.Now;

            ContaReceber[] vetorAux = new ContaReceber[indice];
            int n = 0;
            foreach(ContaReceber c in this.Listar()){
                if(DateTime.Compare(agora, c.DataVencimento) == 1){
                    vetorAux[n] = c;
                    n++;
                }
                else{
                    Array.Resize(ref vetorAux, indice--); 
                }
            }
            Array.Sort(vetorAux);
            return vetorAux;
        }

        public override string ToString(){
            return $"{this.contas.Length} - {this.ContasAReceber()}";
        }
    }
}
