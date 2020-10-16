using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    //Antônio Hideto Borges Kotsubo - 19162
    //Matheus Seiji Luna Noda       - 19190
    class Cidade : IComparable<Cidade>
    {
        //Atributos da classe, codigo da cidade, coordenada x, coordenada y
        int codCidade, x, y;
        //Nome da cidade
        string nomeCidade;

        //Construtor recebe os atributos e os coloca nas propriedades
        public Cidade(int codCidade, int x, int y, string nomeCidade) 
        {
            CodCidade = codCidade;
            X = x;
            Y = y;
            NomeCidade = nomeCidade;
        }

        //Propriedades
        public int CodCidade { get => codCidade; set => codCidade = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string NomeCidade { get => nomeCidade; set => nomeCidade = value; }

        //CompareTo de codigo da cidade
        public int CompareTo(Cidade outra)
        {
            return this.codCidade.CompareTo(outra.codCidade);
        }
    }
}
