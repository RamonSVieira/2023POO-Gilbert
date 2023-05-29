using System;
using System.Collections.Generic;
using System.Collections;

namespace MyProject;

class Program
{
    static void Main(string[] args)
    {
        Equipe brasil = new Equipe("Brasil");
        Jogador j1 = new Jogador("Ramon", 10, 7);
        Jogador j2 = new Jogador("Vini", 2, 0);
        Jogador j3 = new Jogador("Italo", 3, 0);
        Jogador j4 = new Jogador("Daniel", 5, 1);
        Jogador j5 = new Jogador("Lama", 9, 11);
        Jogador j6 = new Jogador("Luan", 7, 5);
        Jogador j7 = new Jogador("Darlan", 1, 0);

        brasil.Inserir(j1);
        brasil.Inserir(j2);
        brasil.Inserir(j3);
        brasil.Inserir(j4);
        brasil.Inserir(j5);
        brasil.Inserir(j6);
        brasil.Inserir(j7);

        Console.WriteLine("LISTAR:");
        foreach (Jogador j in brasil.Listar())
        {
            Console.WriteLine(j);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("ARTILHEIROS:");
        foreach (Jogador j in brasil.Artilheiros())
        {
            Console.WriteLine(j);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("CAMISAS:");
        foreach (Jogador j in brasil.Camisas())
        {
            Console.WriteLine(j);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(brasil);

        //EXCLUIR
        Console.WriteLine("EXCLUIR:");
        int n = 0;
        foreach (Jogador j in brasil.Listar())
        {
            Console.WriteLine($"{n++} - {j}");
        }
        Console.Write("Informe o número do compromisso para remover: ");
        n = int.Parse(Console.ReadLine());

        Jogador x = brasil.Listar()[n];
        brasil.Excluir(x);
        Console.Write("Excluído com sucesso\n");
        foreach (Jogador j in brasil.Listar())
        {
            Console.WriteLine($"{n++} - {j}");
        }



        // Jogador[] jogadores = new Jogador[3];
        // jogadores[0] = new Jogador("Ramon", 10, 25);
        // jogadores[1] = new Jogador("Lama", 9, 7);
        // jogadores[2] = new Jogador("Daniel", 8, 3);

        // Console.WriteLine("Alfabética");
        // //Ordena por nome
        // Array.Sort(jogadores);

        // foreach (Jogador jogador in jogadores)
        // {
        //     Console.WriteLine(jogador);
        // }

        // Console.WriteLine("\nOrdena por gols");
        // //Ordena por quantGols
        // Array.Sort(jogadores, new GolComparer());

        // foreach (Jogador jogador in jogadores)
        // {
        //     Console.WriteLine(jogador);
        // }

        // Console.WriteLine("\nOrdena por número camisa");
        // //Ordena por Número camisa crescente
        // Array.Sort(jogadores, new CamisaComparer());

        // foreach (Jogador jogador in jogadores)
        // {
        //     Console.WriteLine(jogador);
        // }
    }
}

class Jogador : IComparable
{
    private string nome;
    private int camisa;
    private int numGols;

    public Jogador(string nome, int camisa, int numGols)
    {
        //O QUE ESTÁ ACONTECENDO AQUI?
        //A propriedade no bloco de baixo, recebe o parametro passado pelo Construtor
        Nome = nome;
        Camisa = camisa;
        NumGols = numGols;
    }

    //PROPRIEDADES
    public string Nome
    {
        set
        {
            if (value != "")
                this.nome = value;
            else
                throw new ArgumentOutOfRangeException();
        }
        get { return nome; }
    }

    public int Camisa
    {
        set
        {
            if (value > 0)
                this.camisa = value;
            else
                throw new ArgumentOutOfRangeException();
        }
        get { return camisa; }
    }

    public int NumGols
    {
        set
        {
            if (value >= 0)
                this.numGols = value;
            else
                throw new ArgumentOutOfRangeException();
        }

        get { return numGols; }
    }

    public override string ToString()
    {
        return $"{nome} - {camisa} - {numGols}";
    }

    //Função criada para podermos usar o Array.Sort e ordenar alfabéticamente
    public int CompareTo(object obj)
    {
        Jogador jogador = obj as Jogador;
        if (jogador == null)
            throw new ArgumentException();

        return nome.CompareTo(jogador.nome);
    }
}

//Classe responsável por comparar os jogadores a partir dos gols
class GolComparer : IComparer
{
    public int Compare(object obj, object obj2)
    {
        Jogador a = obj as Jogador;
        Jogador b = obj2 as Jogador;

        if (a == null || b == null)
        {
            throw new ArgumentException("Os objetos comparados devem ser instâncias da classe Jogador.");
        }

        //Acessamos a propriedade pois o atributo é private
        return b.NumGols.CompareTo(a.NumGols);
    }
}

//Classe responsável por comparar os jogadores a partir das camisas

class CamisaComparer : IComparer
{
    public int Compare(object obj, object obj2)
    {
        Jogador a = obj as Jogador;
        Jogador b = obj2 as Jogador;

        if (a == null || b == null)
        {
            throw new ArgumentException("Os objetos comparados devem ser instâncias da classe Jogador.");
        }

        return a.Camisa.CompareTo(b.Camisa);
    }
}

class Equipe
{
    private string pais;
    private Jogador[] jogadors = new Jogador[20];
    private int indice = 0;

    public Equipe(string pais)
    {
        if (pais != "")
            this.pais = pais;
        else
            throw new ArgumentOutOfRangeException();
    }


    //PASSO A PASSO PARA INSERIR
    //1° - Verifica se o indice é igual a jogadors.Length, (True ? Soma 2 ao jogadors.Length : empty)
    //2° - Atribui o VALUE a jogadors[indice]
    //3° - Soma 1 ao INDICE
    public void Inserir(Jogador value)
    {
        if (indice == jogadors.Length)
        {
            Array.Resize(ref jogadors, 1 + jogadors.Length);
        }
        jogadors[indice] = value;
        indice++;
    }

    //PASSO A PASSO PARA LISTAR
    //1° - Cria uma vetor com numero de posições igual ao nosso indice
    //2° - Faz uma cópia do vetor JOGADORS EM VETORAUX, passando JOGADORS, VETORAUX E INDICE
    //3° - Retorna o VETOR AUX
    //Caso voce queira retorna ordenada basta usar os seguintes códigos antes de retornar:
    //Array.Sort(vetorAux, new GolComparer()); Ou demais de ornação implementados na classe Jogador
    public Jogador[] Listar()
    {
        Jogador[] vetorAux = new Jogador[indice];
        Array.Copy(jogadors, vetorAux, indice);
        return vetorAux;
    }

    //PASSO A PASSO PARA DELETES(não era necessário mas faremos por aprendizado)
    public void Excluir(Jogador j)
    {
        Jogador[] vetorAux = new Jogador[indice - 1];
        int n = 0;
        foreach (Jogador jg in this.Listar())
        {
            if (jg != j)
            {
                vetorAux[n] = jg;
                n++;
            }
        }
        indice--;
        jogadors = vetorAux;
    }

    public Jogador[] Artilheiros()
    {
        Jogador[] vetorAux = new Jogador[indice];
        Array.Copy(jogadors, vetorAux, indice);
        Array.Sort(vetorAux, new GolComparer());
        return vetorAux;
    }

    public Jogador[] Camisas()
    {
        Jogador[] vetorAux = new Jogador[indice];
        Array.Copy(jogadors, vetorAux, indice);
        Array.Sort(vetorAux, new CamisaComparer());
        return vetorAux;
    }

    public override string ToString()
    {
        return $"{pais} - {indice}";
    }
}
