using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    //Antônio Hideto Borges Kotsubo - 19162
    //Matheus Seiji Luna Noda       - 19190
    //Classe modificada armazenar o peso para o algoritimo de Dijkstra
    class PesoOriginal
    {
        //Guarda um peso (dist, tempo e preco)
        private Peso peso;
        //Guarda o vertice pao
        private int verticePai;
        public PesoOriginal(int vp, Peso p)
        {
            VerticePai = vp;
            Peso = p;
        }

        public int VerticePai { get => verticePai; set => verticePai = value; }
        public Peso Peso { get => peso; set => peso = value; }
    
        
    }
}
