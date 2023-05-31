using System;

namespace questao01
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //SE ISNTANCIA DESSA FORMA
            Pilha<String> x =  new Pilha<string>();

            x.Push("C#");
            Console.WriteLine(x.Peek());
            x.Push("Python");
            x.Push("C++");
            x.Push("Ramon");

            x.Clear();

            while(x.Count > 0){
                Console.WriteLine(x.Pop());
            }
        }
    }

    class Pilha<T>{
        // O T recebe o tipo quando é instanciado
        private T[] objs = new T[10];
        private int k;

        public int Count{
            get { return k; }
        }

        public T Peek(){
            if(k == 0){
                throw new InvalidOperationException();
            } 
            return objs[k-1];
        }

        public void Clear(){
            k = 0;
        }

        public T Pop(){
            if(k == 0){
                throw new InvalidOperationException();
            }
            k--;
            return objs[k];
        }

        public void Push(T obj){
            if(k == objs.Length){
                Array.Resize(ref objs, objs.Length + 1);
            }
            objs[k] = obj;
            k++;
        }
    }
}
