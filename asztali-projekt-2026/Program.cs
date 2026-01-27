using asztali_projekt_2026.Model;

internal class Program
{
    public static readonly string connectionString = "Server=localhost;Database=foldrajz;User=root;";
    private static void Main(string[] args)
    {
        Dbcheck(connectionString);
    }

    private static void Dbcheck(string connectionString)
    {
         AdatbazisCsatlakozas.DbConnectionCheck(connectionString);
    }
}