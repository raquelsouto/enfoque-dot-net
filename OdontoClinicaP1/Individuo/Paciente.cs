namespace OdontoClinicaP1.individuo
{
    public class Paciente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string ToString()
        {
            return "Nome: " + Nome + " | CPF: " + Cpf + " | telefone: " + Telefone;
        }

    }

}
