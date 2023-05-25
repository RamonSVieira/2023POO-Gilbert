using System;
using System.Collections;

namespace prova2
{
    class Jogador : IComparable{
        private string nome;
        private int camisa, numGols;

        public Jogador(string nome, int camisa, int numGols){
            this.nome= nome;
            this.camisa = camisa;
            this.numGols = numGols;
        }

        public string Nome{
            set {this.nome= value;}
            get{ return nome;}
        }

        public int Camisa{
            set{this.camisa = value;}
            get{return Camisa;}
        }

        public int NumGols{
            set{this.numGols = value;}
            get{return numGols;}
        }


        public override string ToString(){
            return $"{nome} - {camisa} - {numGols}";
        }

        public int CompareTo(object obj){
            Jogador x = obj as Jogador;
            return nome.CompareTo(x.nome);
        }
    }

    class CamisaComparator : IComparer{
        public int Compare(object obj1, object obj2){
            Jogador x = obj1 as Jogador;
            Jogador y = obj2 as Jogador;
            return x.Camisa.CompareTo(y.Camisa);
        }
    }

    class GolComparator : IComparer{
        public int Compare(object obj1, object obj2){
            Jogador x = obj1 as Jogador;
            Jogador y = obj2 as Jogador;
            return -x.NumGols.CompareTo(y.NumGols);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Jogador a = new Jogador("Zico", 10, 700);
            Jogador b = new Jogador("sócrates", 8, 200);
            Jogador c = new Jogador("Ronaldo", 1, 10);

            Jogador[] v = {a, b, c};
            Array.Sort(v, new GolComparator());
            foreach (var x in v){
                Console.WriteLine(x.ToString());
            }
        }
    }
}
