using System;

namespace MyProject;

class Program
{
    public class Pessoa
    {
        private string nome;

        public override string ToString()
        {
            return $"Nome: {Nome}";
        }
    }

    static void Main(string[] args)
    {
        Pessoa ramon = new Pessoa();

        ramon.SetIdade(-2);
        Console.WriteLine(ramon.MaiorDeIdade());
    }
}
