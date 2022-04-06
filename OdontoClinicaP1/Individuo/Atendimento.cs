namespace OdontoClinicaP1.individuo
{
    class Atendimento
    {
        public string DataAtendimento { get; set; } = "";
        private List<Procedimento> listProcedimentos = new List<Procedimento>();
        private Paciente Paciente = new Paciente();

        public void cadastrarPaciente(Paciente paciente)
        {
            Paciente = paciente;
        }

        public void adicionarProcedimento(Procedimento procedimento)
        {
            listProcedimentos.Add(procedimento);
        }

        public String getCPFPaciente()
        {
            return Paciente.Cpf;
        }

        public override string ToString()
        {
            string saida = "";

            foreach (Procedimento procedimento in listProcedimentos)
            {
                saida = DataAtendimento + " | " + procedimento.Codigo + " | " + procedimento.Nome + " | R$ " + procedimento.Preco + "\n";
                Console.WriteLine(saida);
            }

            return saida;
        }

        public void mostraProcedimentos()
        {
            string saida = "";

            foreach (Procedimento procedimento in listProcedimentos)
            {
                saida = DataAtendimento + " | " + procedimento.Codigo + " | " + procedimento.Nome + " | " + procedimento.Preco + "\n";
                Console.WriteLine(saida);
            }
        }

        public double calculaTotal()
        {
            double total = 0.0;

            foreach (Procedimento proc in listProcedimentos)
            {
                total += proc.Preco;
            }

            return total;
        }
    }
}

