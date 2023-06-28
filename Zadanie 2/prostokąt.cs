using System;
using System.Collections.Generic;


public class Prostokąt{
    private decimal bokA;
    private decimal bokB;

    public decimal BokA{
        get { return bokA; }
        set{
            if (!IsValidSideLength(value))
                throw new ArgumentException("Długość boku musi być skończona i nie ujemna.");
            bokA = value;
        }
    }

    public decimal BokB{
        get { return bokB; }
        set{
            if (!IsValidSideLength(value))
                throw new ArgumentException("Długość boku musi być skończona i nie ujemna.");
            bokB = value;
        }
    }

    private static readonly Dictionary<char, decimal> wysokośćArkusza0 = new Dictionary<char, decimal>{
        ['A'] = 1189m,
        ['B'] = 1414m,
        ['C'] = 1297m
    };

    public static Prostokąt ArkuszPapieru(string format){
        if (format.Length < 2) 
            throw new ArgumentException("Niepoprawny format arkusza.");

        char klucz = format[0];
        byte indeks;
    
        if (!byte.TryParse(format.Substring(1), out indeks))
            throw new ArgumentException("Niepoprawny format arkusza.");

        if (!wysokośćArkusza0.ContainsKey(klucz))
            throw new ArgumentException("Niepoprawny format arkusza.");


        decimal wysokośćBazowa = wysokośćArkusza0[klucz];
        if (indeks > 10)
            throw new ArgumentException("Niepoprawny format arkusza.");
        decimal pierwiastekZDwóch = (decimal)Math.Sqrt(2);
        decimal bokA = wysokośćBazowa / (decimal)Math.Pow((double)pierwiastekZDwóch, indeks);
        decimal bokB = bokA / pierwiastekZDwóch;

        return new Prostokąt(bokA, bokB);
    }

    public Prostokąt(decimal bokA, decimal bokB){
        BokA = bokA;
        BokB = bokB;
    }

    private bool IsValidSideLength(decimal length){
        return length >= 0;
    }
}
