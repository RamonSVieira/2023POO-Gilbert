namespace MyProject;

class Program
{
    class Pais
    {
        private string nome;
        private int populacao;
        private double area;

        public Pais(string nome, int populacao, double area)
        {
            if (nome != "")
                this.nome = nome;
            else
                throw new ArgumentOutOfRangeException();

            if (populacao > 0)
                this.populacao = populacao;
            else
                throw new ArgumentOutOfRangeException();

            if (area > 0)
                this.area = area;
            else
                throw new ArgumentOutOfRangeException();
        }

        public void SetNome(string nome)
        {
            if (nome != "")
                this.nome = nome;
            else
                throw new ArgumentOutOfRangeException();
        }

        public void SetPopulacao(int populacao)
        {
            if (populacao > 0)
                this.populacao = populacao;
            else
                throw new ArgumentOutOfRangeException();
        }

        public void SetArea(double area)
        {
            if (area > 0)
                this.area = area;
            else
                throw new ArgumentOutOfRangeException();
        }

        public string GetNome()
        {
            return nome;
        }

        public int GetPopulacao()
        {
            return populacao;
        }

        public double GetArea()
        {
            return area;
        }

        public double Densidade()
        {
            return populacao / area;
        }

        public override string ToString()
        {
            return $"A Densidade demográfica do {nome} é: {Densidade():0.00} hab/km²";
        }
    }

    static void Main(string[] args)
    {
        Pais[] paises = new Pais[3];

        for (int i = 0; i < paises.Length; i++)
        {
            Console.WriteLine("Digite o nome do país: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de habitantes: ");
            int populacao = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a área do pais: ");
            double area = double.Parse(Console.ReadLine());

            paises[i] = new Pais(nome, populacao, area);
            Console.WriteLine();
        }

        int maiorPadrao = 0;
        for (int i = 1; i < paises.Length; i++)
        {
            if (paises[maiorPadrao].Densidade() < paises[i].Densidade())
            {
                maiorPadrao = i;
            }
        }

        Console.WriteLine($"Maior Densidade = {paises[maiorPadrao]}");
    }
}
