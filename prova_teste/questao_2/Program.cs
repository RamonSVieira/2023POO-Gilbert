using Internal;
using System;
namespace MyProject;
class Program
{

  class pecaDomino{
    private int lado1;
    private int lado2;

    public pecaDomino(int lado1, int lado2){
      if (lado1 >= 0 && lado1 <= 6) this.lado1 = lado1;
      else throw new ArgumentOutOfRangeException();

      if (lado2 >= 0 && lado2 <= 6) this.lado2 = lado2;
      else throw new ArgumentOutOfRangeException();
    }

    public void SetLado1(int lado1){
      if (lado1 >= 0 && lado1 <= 6) this.lado1 = lado1;
      else throw new ArgumentOutOfRangeException();
    }

    public void SetLado2(int lado2){
      if (lado2 >= 0 && lado2 <= 6) this.lado2 = lado2;
      else throw new ArgumentOutOfRangeException();
    }

    public int GetLado1(){
      return lado1;
    }

    public int GetLado2(){
      return lado2;
    }

    public double Combinar(pecaDomino novaPeca){
      if (this.lado1 == novaPeca.lado1 || this.lado2 == novaPeca.lado2 || this.lado1 == novaPeca.lado2 || this.lado2 == novaPeca.lado1) return true;
      else false;
    }

    public override string ToString()
    {
      return $"Lado 1: {lado1} Lado 2: {lado2}";
    }
  }

    static void Main(string[] args)
    {
      Console.WriteLine("Informe o Lado 1 da primeira peça");
      int peca1lado1 = int.Parse(Console.ReadLine());
      Console.WriteLine("Informe o Lado 2 da primeira peça");
      int peca1lado2 = int.Parse(Console.ReadLine());
      pecaDomino peca1 = new pecaDomino(peca1lado1, peca1lado2);

      Console.WriteLine("Informe o Lado 1 da segunda peça");
      int peca2lado1 = int.Parse(Console.ReadLine());
      Console.WriteLine("Informe o Lado 2 da segunda peça");
      int peca2lado2 = int.Parse(Console.ReadLine());
      pecaDomino peca2 = new pecaDomino(peca2lado1, peca2lado2);


      if (peca1.Combinar(peca2))
      {
        Console.WriteLine("As peças combinam");
      }else{
        Console.WriteLine("As peças não combinam");
      }
    }
}