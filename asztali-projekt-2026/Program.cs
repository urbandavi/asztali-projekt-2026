using asztali_projekt_2026.Model;
using System.Data;


internal class Program
{

    public static readonly string connectionString = "Server=localhost;Database=asztalifocik;User=root;";
    public static DataTable adatok = new DataTable();
    public static List<Class_Object> focistak = new List<Class_Object>();
    private static void Main(string[] args)
    {
        SelectFromTable("focistak", connectionString);
        Dbcheck(connectionString);
        AdatBetoltes(adatok);
    }

    private static void Dbcheck(string connectionString)
    {
         AdatbazisCsatlakozas.DbConnectionCheck(connectionString);
    }


    private static void SelectFromTable(string tableName, string connectionString)
    {
        adatok = AdatbazisCsatlakozas.GetAllData(tableName, connectionString);
        Console.WriteLine("Adatok sikeresen szinkronizálva az adatbázisból, átmeneti tárolóba");
    }


    private static void AdatBetoltes(DataTable adatok)
    {
        //Itt hagytuk abba előző órán 12A - péntek
        foreach (DataRow f in adatok.Rows)
        {
            Class_Object focisok = new Class_Object();

            focisok.Id = f.Field<int>("id");
            focisok.Firstname = f.Field<string>("firstname");
            focisok.Lastname = f.Field<string>("lastname");
            focisok.Matches = f.Field<int>("matches");
            focisok.Goals = f.Field<int>("goals");
            focisok.Wins = f.Field<int>("wins");
            focisok.Age = f.Field<int>("age");


            focistak.Add(focisok);

        }
    }
}