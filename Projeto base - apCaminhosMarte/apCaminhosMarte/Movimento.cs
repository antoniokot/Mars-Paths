using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Antônio Hideto Borges Kotsubo - 19162 e Matheus Seiji Luna Noda - 19190
class Movimento : IComparable<Movimento>    // Classe alterada para auxilio no projeto
{
    private int origem, destino, distancia;     // Coordenadas da matriz de proximidade de cidades
    public Movimento(int ori, int des, int dist)
    {
        origem = ori;
        destino = des;
        distancia = dist;
    }
    public Movimento(int ori, int des)
    {
        origem = ori;
        destino = des;
        distancia = 0;
    }


    public int Distancia
    {
        get => distancia;
        set => distancia = value;
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

