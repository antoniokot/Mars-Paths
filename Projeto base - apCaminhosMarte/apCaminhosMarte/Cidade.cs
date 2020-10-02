using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Cidade : IComparable<Cidade>
    {
        int codCidade, x, y;
        string nomeCidade;

        public Cidade(int codCidade, int x, int y, string nomeCidade) 
        {
            CodCidade = codCidade;
            X = x;
            Y = y;
            NomeCidade = nomeCidade;
        }

        public int CodCidade { get => codCidade; set => codCidade = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string NomeCidade { get => nomeCidade; set => nomeCidade = value; }

        public int CompareTo(Cidade outra)
        {
            return this.codCidade.CompareTo(outra.codCidade);
        }
    }
}
