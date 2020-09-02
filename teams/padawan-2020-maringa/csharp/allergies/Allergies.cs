using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,           //00000001
    Peanuts = 2,        //00000010
    Shellfish = 4,      //00000100
    Strawberries = 8,   //00001000
    Tomatoes = 16,      //00010000
    Chocolate = 32,     //00100000
    Pollen = 64,        //01000000
    Cats = 128          //10000000
}

public class Allergies
{
    private readonly int Mask;
    public Allergies(int mask)
    {
        Mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return List().Contains(allergen);
    }

    public Allergen[] List()
    {
        List<Allergen> allergens = new List<Allergen>();
        foreach (var item in Enum.GetValues(typeof(Allergen)))
        {
            if ((Mask & (int)item)>0)
            {
                allergens.Add((Allergen)item);
            }
        }
        return allergens.ToArray();
    }
}