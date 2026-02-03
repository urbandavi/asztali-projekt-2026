using asztali_projekt_2026.Model;
using System.ComponentModel.Design;
using System.Data;
using System.Runtime.CompilerServices;

internal class Program
{
    public static FileIO.ReadFromFile reader = new FileIO.ReadFromFile();
    public static readonly string connectionString = "Server=localhost;Database=asztalifocik;User=root;";
    public static DataTable adatok = new DataTable();
    public static List<Class_Object> focistak = new List<Class_Object>();
    public static List<List<string>> adatokcsv = new List<List<string>>();
    private static void Main(string[] args)
    {
        Dbcheck(connectionString);
        SelectFromTable("focistak", connectionString);
        AdatBetoltes(adatok);
        Beolvasas(ref adatokcsv);
        Feltoltes(adatokcsv);

        foreach (var f in focistak)
        {
            f.ToString();
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Figyelem: Üdvözlünk felhasználó! Ez a projekt focisták adatait hivatott tárolni és lekérdezhetővé tenni. A program 6 lekérdezésen fog végig menni. Kezdjük is el:");
        Console.ForegroundColor= ConsoleColor.White;
        //MenuCommand();

        //funkciók

        //folyamatban



        //kész
        osszesJatekosKilistazasa(focistak);
        Console.WriteLine("-----------------------------------------------------------------");
        jatekosSpecifikusSzures(focistak);
        Console.WriteLine("-----------------------------------------------------------------");
        oregek(focistak);
        Console.WriteLine("-----------------------------------------------------------------");
        kinekVanTooobbGolja(focistak);
        Console.WriteLine("-----------------------------------------------------------------");
        golokAtlagaMeccsekreLebontva(focistak);
        Console.WriteLine("-----------------------------------------------------------------");
        megadottSzazalekMegnyerve(focistak);


        //test commit
    }




    private static void MenuCommand()
    {
        Console.WriteLine("Válassz funkciót:");
        Console.WriteLine("[1] ");
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
            Console.WriteLine($"Írj A betűt ha legfeljebb {age} éves vagy írj F betűt ha legalább {age} éves focistákra vagy kíváncsi.");
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
        Console.WriteLine("A program most kiszortírozza a focistákat a góljaik és meccseik átlaga alapján.");
        Console.WriteLine("Adj meg egy átlagot. Ez az átlag lesz a lekérdezés minimuma. Ez alatti átlagú játékosok nem lesznek kilistázva.");
        double felhasznaloAtlag = Convert.ToDouble( Console.ReadLine());
        foreach (var a in atlaglista)
        {
            if (a>felhasznaloAtlag)
            {
                Console.WriteLine(focistak[atlaglista.IndexOf(a)].ToString());
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
        Console.WriteLine("Adj meg egy számot 1 és 100 között. A program ki fogja listázni azokat a játékosokat akik a megadott számmmal (százalékban értelmezve) egyenlő vagy több alkalommal nyerték meg a meccseiket.");
        double szazalek = Convert.ToDouble(Console.ReadLine());

        if (szazalek < 0 || szazalek > 100)
        {
            Console.WriteLine("Hibás százalék érték!");
        }
        else
        {
            foreach (var f in focistak)
            {
                double nyeresegSzazalek = (double)f.Wins / f.Matches * 100;
                if (nyeresegSzazalek >= szazalek)
                {
                    Console.WriteLine($"{f.Firstname} {f.Lastname} Gólok: {f.Goals}");
                }
            }
        }


    }

    private static void kinekVanTooobbGolja(List<Class_Object> focistak)
    {

        Console.WriteLine("Adj meg egy bizonyos gólmennyiséget: ");
        int megadottGolok = Convert.ToInt32(Console.ReadLine());
       

        for (int i = 0;  i < focistak.Count; i++)
        {

            if (focistak[i].Goals > megadottGolok)
            {
                Console.WriteLine($"{focistak[i].Firstname} {focistak[i].Lastname}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Ezek az emberek rúgtak ugyan annyi vagy több gólt mint amit megadtál.");
        





    }

    private static void jatekosSpecifikusSzures(List<Class_Object> focistak)
    {
        bool joanev = false;
        Console.WriteLine("Add meg először a játékos vezetéknevét majd a keresztnevét a szűréshez:");
        Console.Write("Vezetéknév: ");
        string megadottCSnev = Console.ReadLine();
        Console.Write("Keresztnév: ");
        string megadottKnev = Console.ReadLine();

        foreach (var f in focistak)
        {
            if (f.Firstname.ToLower() == megadottKnev.ToLower().Trim() && f.Lastname.ToLower() == megadottCSnev.ToLower().Trim())
            {
                joanev = true;
                Console.WriteLine(f.ToString());
            }
            
            
        }
        if (joanev == false)
        {
            Console.WriteLine("A név nem szerepel az adatbázisban.");
        }
    }

    private static void osszesJatekosKilistazasa(List<Class_Object> focistak)
    {
        Console.WriteLine("Az első hány sort listázza ki a program. (Adj meg egy számot 0-2000 között)");
        int mennyitlistazzonKi = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < mennyitlistazzonKi; i++)
        {
            Console.WriteLine(focistak[i].ToString());
            
        }
        

    }

    private static void Dbcheck(string connectionString)
    {
    }


    private static void SelectFromTable(string tableName, string connectionString)
    {
        adatok = AdatbazisCsatlakozas.GetAllData(tableName, connectionString);
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


    private static void Beolvasas(ref List<List<string>> adatokcsv)
    {
        adatokcsv = reader.FileRead("../../../focistak.txt", 7, ';', true);
    }

    private static void Feltoltes(List<List<string>> adatokcsv)
    {
        List<List<string>> focistakLista = adatokcsv;
        focistak = new List<Class_Object>();

        foreach (var sor in focistakLista)
        {
            Class_Object focisok = new Class_Object();
            focisok.Id = Convert.ToInt32(sor[0]);
            focisok.Firstname = sor[1];
            focisok.Lastname = sor[2];
            focisok.Matches = Convert.ToInt32(sor[3]);
            focisok.Goals = Convert.ToInt32(sor[4]);
            focisok.Wins = Convert.ToInt32(sor[5]);
            focisok.Age = Convert.ToInt32(sor[6]);

            focistak.Add(focisok);
        }



    }
}
