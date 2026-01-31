using asztali_projekt_2026.Model;
using System.Data;
using System.Runtime.CompilerServices;


internal class Program
{

    public static readonly string connectionString = "Server=localhost;Database=asztalifocik;User=root;";
    public static DataTable adatok = new DataTable();
    public static List<Class_Object> focistak = new List<Class_Object>();
    private static void Main(string[] args)
    {
        Dbcheck(connectionString);
        SelectFromTable("focistak", connectionString);
        AdatBetoltes(adatok);
      

        //funkciók

        //folyamatban

        osszesJatekosKilistazasa(focistak);
        jatekosSpecifikusSzures(focistak);
        kinekVanTooobbGolja(focistak);
        megadottSzazalekMegnyerve(focistak);
        golokAtlagaMeccsekreLebontva(focistak);


        //kész
        //oregek(focistak);


        //test commit
    }

    private static void oregek(List<Class_Object> focistak)
    {
        //egy bizonyos kor felettieket vagy alattiakat kiadja a program





        Console.WriteLine("Adj meg egy kort 16 és 40 között:");
        
        int age = Convert.ToInt32(Console.ReadLine());

        if (age>40 || age<16)
        {
            Console.WriteLine($"Az {age} szám nem tartozik bele a megadható intervallumba.");
        }
        else
        {
            Console.WriteLine($"A(z) {age} éves vagy az alatti kórú, vagy {age} korú és feletti játékosokat szeretnéd lekérdezni? Ha felette írj F betüt ha alatta írj A betüt!");
            string valasz = Console.ReadLine();

            
            foreach (var focisok in focistak)
            {
                if (valasz.ToLower()=="f")
                {
                    if (focisok.Age >= age)
                    {
                        Console.WriteLine(focisok.ToString());
                    }
                }
                else
                {
                    if (focisok.Age <= age)
                    {
                        Console.WriteLine(focisok.ToString());
                    }
                }
            }




          
        }
        
        
        


    }

    private static void golokAtlagaMeccsekreLebontva(List<Class_Object> focistak)
    {


        List<double> atlaglista = new List<double>();
        atlaglistaFeltoltes(focistak, ref atlaglista);
        Console.WriteLine("Adj meg egy átlagot. Ez az átlag lessz a lekérdezés minimuma.");
        double felhasznaloAtlag = Convert.ToDouble( Console.ReadLine());
        foreach (var a in atlaglista)
        {
            if (a>felhasznaloAtlag)
            {
                Console.WriteLine(focistak[atlaglista.IndexOf(a)].ToString());
                Console.WriteLine(a);
            }
            
        }

        






    }

    private static void atlaglistaFeltoltes(List<Class_Object> focistak, ref List<double> atlaglista)
    {
        foreach (var f in focistak)
        {
            double golatlag = f.Goals / f.Matches;
            atlaglista.Add(golatlag);
        }

    }

    private static void megadottSzazalekMegnyerve(List<Class_Object> focistak)
    {
    }

    private static void kinekVanTooobbGolja(List<Class_Object> focistak)
    {
    }

    private static void jatekosSpecifikusSzures(List<Class_Object> focistak)
    {
    }

    private static void osszesJatekosKilistazasa(List<Class_Object> focistak)
    {
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
            focisok.Firstname = f.Field<string>("first_name");
            focisok.Lastname = f.Field<string>("last_name");
            focisok.Matches = f.Field<int>("matches");
            focisok.Goals = f.Field<int>("goals");
            focisok.Wins = f.Field<int>("wins");
            focisok.Age = f.Field<int>("age");


            focistak.Add(focisok);

        }
    }
}