using System.Timers;
public static class Reloj
{
    const int SEGUNDOS_MAX = 15;
    private static System.Timers.Timer reloj;
    private static int segundosFaltantes = 0;

    public static int ObtenerSegundosFaltantes()
    {
        return segundosFaltantes;
    }

    public static void ComenzarContador()
    {
        reloj = new System.Timers.Timer(1000); // 1 segundo
        segundosFaltantes = SEGUNDOS_MAX;

        reloj.Elapsed += Tick;
        reloj.Enabled = true;   
    }
    public static void FinalizarContador()
    {
        reloj.Stop();
        reloj.Dispose();
    }
    private static void Tick(Object source, ElapsedEventArgs e)
    {
        segundosFaltantes--;
        Console.WriteLine(segundosFaltantes);
        if (segundosFaltantes < 0)
            FinalizarContador();
    }
}