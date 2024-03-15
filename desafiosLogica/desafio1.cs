using System;

class Program
{
    static void Main()
    {
        int[] arrInicial = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
        int[] arrInvertido = InverteOrdem(arrInicial);
        Console.WriteLine(string.Join(", ", arrInvertido));
    }

    static int[] InverteOrdem(int[] arr)
    {
        int inicio = 0;
        int fim = arr.Length - 1;

        while (inicio < fim)
        {
           
            int temp = arr[inicio];
            arr[inicio] = arr[fim];
            arr[fim] = temp;

            
            inicio++;
            fim--;
        }

        return arr;
    }
}