using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OdontoClinicaP1.individuo;

namespace OdontoClinicaP1.infra
{
    class AtendimentosHandler
    {
        private List<Atendimento> listAtendimentos;

        public AtendimentosHandler(List<Atendimento> atendimentos)
        {
            listAtendimentos = atendimentos;
        }

        public void imprimirRelatorio()
        {
            string saida = "";
            double total = 0.0;

            saida += "-------------------------------------------------------------------------------------------\n";
            saida += "Data do atendimento | Código | Nome | Preço\n";

            foreach(Atendimento atend in listAtendimentos)
            {
                saida += atend.ToString();
                total += atend.calculaTotal();
            }

            saida += "\nTotal: ";
            saida += total.ToString() + "\n";
            // Total: Código de cálculo de Total

            saida += "-------------------------------------------------------------------------------------------\n";

        }
    }
}
