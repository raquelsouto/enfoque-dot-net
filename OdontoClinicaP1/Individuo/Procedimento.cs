namespace OdontoClinicaP1.individuo
{
    class Procedimento
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public string ToString()
        {
            return "Código: " + Codigo + " | Nome: " + Nome + " | Preço: " + Preco;
        }

    }

}
