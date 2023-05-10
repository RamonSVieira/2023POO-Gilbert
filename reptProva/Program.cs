class Program
{
    static void Main(string[] args)
    {
        Pais[] paises = new Pais[5];

        for (int i = 0; i < paises.Length; i++)
        {
            Console.WriteLine("Digite nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite População:");
            int populacao = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite area:");
            double area = double.Parse(Console.ReadLine());

            paises[i] = new Pais(nome, populacao, area);
        }

        int maior = 0;

        for (int i = 1; i < paises.Length; i++)
        {
            if (paises[maior].Densidade() < paises[i].Densidade())
            {
                maior = i;
            }
        }

        Console.WriteLine($"Maior densidade: {paises[maior]}");
    }
}

class Pais
{
    private string nome;
    private int populacao;
    private double area;

    public Pais(string nome, int populacao, double area)
    {
        if (nome != "")
        {
            this.nome = nome;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
        if (area > 0)
        {
            this.area = area;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
        if (populacao > 0)
        {
            this.populacao = populacao;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void setNome(string nome)
    {
        if (nome != "")
        {
            this.nome = nome;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void setPopulacao(int populacao)
    {
        if (populacao > 0)
        {
            this.populacao = populacao;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void setArea(double area)
    {
        if (area > 0)
        {
            this.area = area;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public string getNome()
    {
        return nome;
    }

    public int getPopulacao()
    {
        return populacao;
    }

    public double getArea()
    {
        return area;
    }

    public double Densidade()
    {
        return populacao / area;
    }

    public override string ToString()
    {
        return $"Pais: {nome}, Densidade: {Densidade():0.00} Hab/km²";
    }
}
