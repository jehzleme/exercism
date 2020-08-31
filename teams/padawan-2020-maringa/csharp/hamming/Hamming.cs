using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        var contador = 0;

        if (firstStrand == secondStrand) return 0;
        if (firstStrand.Length != secondStrand.Length)
            //|| firstStrand != null && secondStrand == null
            //|| firstStrand == null && secondStrand != null)
            throw new ArgumentException();
        else
        {
            for (int i=0; i<firstStrand.Length; i++)
            {
                if (firstStrand[i] != secondStrand[i])
                    contador++;
            }
            return contador;
        }
    }
}