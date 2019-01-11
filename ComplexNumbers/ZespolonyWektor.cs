using AlgorytmyKwantowe;

namespace AlgorytmyKwantowe
{ }
    class ZespolonyWektor
    {
        public Zespolona[] ComplexVector;
        
        public ZespolonyWektor(Zespolona[] cv)
        {
        this.ComplexVector = cv;
        }

    public static ZespolonyWektor operator +(ZespolonyWektor c1, ZespolonyWektor c2) //dodawanie
    {
        Zespolona[] add = new Zespolona[c1.ComplexVector.Length];
        for (int i = 0; i < c1.ComplexVector.Length; i++)
        {
            // add[i] = new Complex(W.vector[i].R + V.vector[i].R, W.vector[i].I + V.vector[i].I);
            add[i] = c1.ComplexVector[i] + c2.ComplexVector[i];
        }

        return new ZespolonyWektor(add);
    }

    public static ZespolonyWektor operator -(ZespolonyWektor c1, ZespolonyWektor c2) //odejmowanie
    {
        Zespolona[] odd = new Zespolona[c1.ComplexVector.Length];
        for (int i = 0; i < c1.ComplexVector.Length; i++)
        {
            odd[i] = c1.ComplexVector[i] - c2.ComplexVector[i];
        }

        return new ZespolonyWektor(odd);
    }

    public static Zespolona IloczynSkalarny (ZespolonyWektor c1, ZespolonyWektor c2) //iloczyn
    {
        Zespolona temp = new Zespolona(0);
        for (int i = 0; i < c1.ComplexVector.Length; i++)
        {
            temp += c1.ComplexVector[i] * c2.ComplexVector[i];
        }

        return temp;
    }

    public static ZespolonyWektor Skalar(ZespolonyWektor c1, int skalar) //skalar
    {
        Zespolona[] skal = new Zespolona[c1.ComplexVector.Length];
        for (int i = 0; i < c1.ComplexVector.Length; i++)
        {
            skal[i] = c1.ComplexVector[i] * skalar;
        }

        return new ZespolonyWektor(skal);
    }


}

