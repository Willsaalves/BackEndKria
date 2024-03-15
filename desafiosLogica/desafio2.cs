using System;

class PrintNumbers
{
   
    static void printNos(int n)
    {
        if(n > 0)
        {
            printNos(n - 1);
            Console.Write(n + " ");
        }
        return;
    }


    static void Main()
    {
        printNos(100);
    }
}