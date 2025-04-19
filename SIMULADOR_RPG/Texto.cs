public static class Texto
{
    public static void Digitar(string texto, int velocidade = 20)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(velocidade);
        }
        Console.WriteLine();
    }
}

