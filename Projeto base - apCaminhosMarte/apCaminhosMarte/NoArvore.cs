using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NoArvore<Tipo> : IComparable<NoArvore<Tipo>> where Tipo : IComparable<Tipo>
{
    Tipo info;  // informação armazenada
    NoArvore<Tipo> esq, dir;
    int altura;

    public NoArvore(Tipo dado, NoArvore<Tipo> esquerda, NoArvore<Tipo> direita, int altura)
    {
        Info = dado;
        Esq = esquerda;
        Dir = direita;
        Altura = altura;
    }

    public NoArvore(Tipo dado) : this(dado, null, null, 0)
    {
    }

    public NoArvore() : this(default(Tipo), null, null, 0)
    {
    }

    public int Altura { get => altura; set => altura = value; }
    public Tipo Info { get => info; set => info = value; }
    internal NoArvore<Tipo> Esq { get => esq; set => esq = value; }
    internal NoArvore<Tipo> Dir { get => dir; set => dir = value; }

    public int CompareTo(NoArvore<Tipo> outro)
    {
        return this.CompareTo(outro);
    }

    public string ParaArquivo()
    {
        throw new NotImplementedException();
    }
}
