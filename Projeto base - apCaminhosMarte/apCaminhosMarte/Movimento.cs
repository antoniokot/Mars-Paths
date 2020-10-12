using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Antônio Hideto Borges Kotsubo - 19162 e Matheus Seiji Luna Noda - 19190
class Movimento : IComparable<Movimento>    // Classe alterada para auxilio no projeto
{
    private int linha, coluna, distancia;     // Coordenadas da matriz
    public Movimento(int lin, int col, int dist)
    {
        linha = lin;
        coluna = col;
        distancia = dist;
    }
    public Movimento(int lin, int col)
    {
        linha = lin;
        coluna = col;
        distancia = 0;
    }

    public int Linha
    {
        get => linha;
        set => linha = value;
    }
    public int Coluna
    {
        get => coluna;
        set => coluna = value;
    }
    public int Distancia
    {
        get => distancia;
        set => distancia = value;
    }

    public override String ToString()
    {
        return linha + ", " + coluna;
    }

    public int CompareTo(Movimento outro)   // para compatibilizar com ListaSimples e NoLista
    {
        return 0;
    }
}

