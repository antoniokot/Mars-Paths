using apCaminhosMarte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Antônio Hideto Borges Kotsubo - 19162 e Matheus Seiji Luna Noda - 19190
class Movimento : IComparable<Movimento>    // Classe alterada para auxilio no projeto
{
    private int origem, destino;     // Coordenadas da matriz de proximidade de cidades
    private Peso peso; 
    public Movimento(int ori, int des, Peso peso)
    {
        origem = ori;
        destino = des;
        this.peso = peso;
    }
    public Movimento(int ori, int des)
    {
        origem = ori;
        destino = des;
        peso = null;
    }


    public Peso Peso
    {
        get => peso;
        set => peso = value;
    }
    public int Origem 
    { 
        get => origem; 
        set => origem = value; 
    }

    public int Destino 
    { 
        get => destino; 
        set => destino = value; 
    }

    public override String ToString()
    {
        return origem + ", " + destino;
    }

    public int CompareTo(Movimento outro)   // para compatibilizar com ListaSimples e NoLista
    {
        return 0;
    }
}

