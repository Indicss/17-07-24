using System;
using System.Collections.Generic;

public class Angajat
{
    public string Nume { get; set; }
    public int Vechime { get; set; }

    public Angajat(string nume, int vechime)
    {
        Nume = nume;
        Vechime = vechime;
    }

    public virtual decimal CalculeazaSalariu()
    {
        return 10000;
    }
}

public class Manager : Angajat
{
    public Manager(string nume, int vechime) : base(nume, vechime)
    {
    }

    public override decimal CalculeazaSalariu()
    {
        return 10000 + 0.3m * 10000 * Vechime;
    }
}

public class Programator : Angajat
{
    public List<string> Limbaje { get; set; }

    public Programator(string nume, int vechime, List<string> limbaje) : base(nume, vechime)
    {
        Limbaje = limbaje;
    }

    public override decimal CalculeazaSalariu()
    {
        decimal salariu = 10000;
        foreach (string limbaj in Limbaje)
        {
            if (limbaj == "C#")
            {
                salariu += 4 * 10000;
            }
            else
            {
                salariu += 0.5m * 10000;
            }
        }
        return salariu;
    }
}

public class Contabil : Angajat
{
    public Contabil(string nume, int vechime) : base(nume, vechime)
    {
    }

    public override decimal CalculeazaSalariu()
    {
        return 10000 + 0.2m * 10000 * Vechime;
    }
}

class Program
{
    static void Main()
    {
        List<Angajat> angajati = new List<Angajat>
        {
            new Manager("Oleg Jalba", 5),
            new Programator("Maria Ionescu", 3, new List<string> { "C#", "Java" }),
            new Contabil("Nicolae Ursu", 10)
        };

        foreach (var angajat in angajati)
        {
            Console.WriteLine($"Angajat: {angajat.Nume}, Salariu: {angajat.CalculeazaSalariu()}");
        }
    }
}
