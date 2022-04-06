using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoClinicaP1.individuo;

namespace OdontoClinicaP1.infra
{
    public class Window
    {
        // Atualmente essas listas abaixo fazem o papel do nosso Banco de Dados.
        private List<Atendimento> listAtendimentos = new List<Atendimento>();
        private List<Procedimento> listProcedimentos = new List<Procedimento>();
        private List<Paciente> listPacientes = new List<Paciente>();

        public void Start()
        {
            int option = 0;
            bool continua = true;
            do
            {
                VerMenu();
                bool sucesso = int.TryParse(Console.ReadLine(), out option);

                if (sucesso && option <= 6)
                {
                    if (option == 0)
                    {
                        continua = false;
                        break;
                    }

                    FazerEscolha(option);
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("OPÇÃO INVÁLIDA!!!");
                }
                
            }
            while (continua);
        }

        private void FazerEscolha(int option)
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                    {
                        GravarPaciente();
                    }
                    break;
                case 2:
                    {
                        GravarProcedimento();
                    }
                    break;
                case 3:
                    {
                        RegistrarAtendimento();
                    }
                    break;
                case 4:
                    {
                        VerRelatorios();
                    }
                    break;
                case 5:
                    {
                        VerPacientesCadastrados();
                    }
                    break;
                case 6:
                    {
                        VerProcedimentosCadastrados();
                    }
                    break;
            }
        }

        private void GravarProcedimento()
        {
            int codProcedure = 0;

            Procedimento proc = new Procedimento();

            Console.WriteLine("----- Cadastro de procedimentos -----");

            Console.WriteLine("Código: ");
            int codProcedimento = int.Parse(Console.ReadLine());

            if (!listProcedimentos.Any())
            {
                proc.Codigo = codProcedimento;
                Console.WriteLine("\nDigite o nome do procedimento: ");
                var nome = Console.ReadLine();
                Console.WriteLine("\nDigite o preço do procedimento: ");
                var preco = Console.ReadLine();

                double precoDouble = 0;
                bool sucesso = double.TryParse(preco, out precoDouble);

                while (!sucesso)
                {
                    Console.WriteLine("\nPreço inválido. Digite o preço do procedimento novamente: ");
                    preco = Console.ReadLine();
                    sucesso = double.TryParse(preco, out precoDouble);
                }

                proc.Nome = nome;
                proc.Preco = double.Parse(preco);

                listProcedimentos.Add(proc);
                Console.WriteLine("\nProcedimento registrado com sucesso!");
            }
            else
            {
                for (int i = 0; i < listProcedimentos.Count(); i++)
                {
                    if (listProcedimentos[i].Codigo.Equals(codProcedimento))
                    {
                        Console.WriteLine("Já existe um procedimento cadastrado com este código!");
                    }
                    else
                    {
                        proc.Codigo = codProcedimento;
                        Console.WriteLine("\nDigite o nome do procedimento: ");
                        var nome = Console.ReadLine();
                        Console.WriteLine("\nDigite o preço do procedimento: ");
                        var preco = Console.ReadLine();

                        double precoDouble = 0;
                        bool sucesso = double.TryParse(preco, out precoDouble);

                        while (!sucesso)
                        {
                            Console.WriteLine("\nPreço inválido. Digite o preço do procedimento novamente: ");
                            preco = Console.ReadLine();
                            sucesso = double.TryParse(preco, out precoDouble);
                        }

                        proc.Nome = nome;
                        proc.Preco = double.Parse(preco);

                        listProcedimentos.Add(proc);
                        Console.WriteLine("\nProcedimento registrado com sucesso!");

                        break;
                    }
                }
            }
            Console.WriteLine("\nPressione ENTER para voltar ao menu!");
        }

        private void GravarPaciente()
        {
            Paciente paciente = new Paciente();

            Console.WriteLine("----- Cadastro de Paciente -----");
            Console.WriteLine("\nDigite o nome: ");
            var name = Console.ReadLine();
            Console.WriteLine("\nDigite o CPF (apenas números): ");
            var cpf = Console.ReadLine();
            Boolean sucesso = false;
            while (!sucesso)
            {
                if (cpf.Length == 11 && !(cpf.Where(c => char.IsLetter(c)).Count() > 0))
                {
                    sucesso = true;
                }
                else
                {
                    Console.WriteLine("CPF inválido! Digite novamente o número do CPF: ");
                    cpf = Console.ReadLine();
                }
            }
            Console.WriteLine("\nDigite o telefone: ");
            var phone = Console.ReadLine();

            paciente.Nome = name;
            paciente.Cpf = cpf;
            paciente.Telefone = phone;
            int count = 0;

            if(listPacientes.Count > 0)
            {
                for(int i = 0; i < listPacientes.Count; i++)
                {
                    if (listPacientes[i].Cpf.Equals(cpf))
                    {
                        count++;
                        break;
                    }
                }

                if(count > 0)
                {
                    Console.WriteLine("\nCPF já cadastrado!");
                }
                else
                {
                    listPacientes.Add(paciente);
                    Console.WriteLine("\nPaciente registrado com sucesso!");
                }                
            }
            else
            {
                listPacientes.Add(paciente);
                Console.WriteLine("\nPaciente registrado com sucesso!");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu!");
        }

        private void RegistrarAtendimento()
        {
            Atendimento atendimento = new Atendimento();
            Paciente paciente = new Paciente();
            Procedimento procedimento = new Procedimento();
            int countPaciente = 0;
            int countProcedimento = 0;

            Console.WriteLine("----- Cadastro de Atendimento -----");
            Console.WriteLine("\nDigite o CPF do Paciente: ");
            var cpf = Console.ReadLine();
            Console.WriteLine(cpf);

            if (listPacientes.Count() > 0 && listProcedimentos.Count > 0)
            {
                for (int i = 0; i < listPacientes.Count; i++)
                {
                    if (listPacientes[i].Cpf.Equals(cpf))
                    {
                        countPaciente = 1;
                        paciente = listPacientes[i];
                        break;
                    }
                }

                if(countPaciente == 1)
                {
                    atendimento.cadastrarPaciente(paciente);

                    var cadastro = true;

                    while (cadastro)
                    {
                        Console.WriteLine("----- Digite o código do Procedimento ou SAIR para encerrar o registro -----");
                        var cod = Console.ReadLine();

                        if (cod.ToLower().Equals("sair") || cod == null)
                        {
                            cadastro = false;
                        }
                        else
                        {
                            for (var j = 0; j < listProcedimentos.Count(); j++)
                            {
                                if (listProcedimentos[j].Codigo.Equals(int.Parse(cod)))
                                {
                                    countProcedimento = 1;
                                    procedimento = listProcedimentos[j];
                                    break;
                                }
                            }

                            if(countProcedimento == 1)
                            {
                                atendimento.adicionarProcedimento(procedimento);
                                countProcedimento = 0;
                            }
                            else
                            {
                                Console.WriteLine("Procedimento não cadastrado!");
                            }


                        }
                    }

                    if(atendimento != null)
                    {
                        atendimento.DataAtendimento = DateTime.Now.ToString("dd-MM-yyy/HH:ss");
                        listAtendimentos.Add(atendimento);
                    }                    
                }
                else
                {
                    Console.WriteLine("Paciente não cadastrado. Realize o cadastro do paciente primeiro!");
                    Console.WriteLine("Pressione ENTER para voltar ao menu!");
                }
            }
            else
            {
                Console.WriteLine("Lista de Pacientes ou Procedimentos está vazia!");
                Console.WriteLine("Pressione ENTER para voltar ao menu!");
            }
        }

        private void VerRelatorios()
        {
            List<Atendimento> atendimentosCPF = new List<Atendimento>();

            Console.WriteLine("----- Digite o CPF que deseja pesquisar -----");
            var cpf = Console.ReadLine();

            if (listAtendimentos != null)
            {
                Console.WriteLine("\n\n-------------------------------------------------------------------------------------------");
                Console.WriteLine("Data do atendimento | Código | Nome | Preço\n");

                for (int i = 0; i < listAtendimentos.Count; i++)
                {
                    if (listAtendimentos[i].getCPFPaciente().Equals(cpf))
                    {
                        listAtendimentos[i].mostraProcedimentos();
                        Console.WriteLine("\nTOTAL: R$" + listAtendimentos[i].calculaTotal() + "\n");
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------");
            }

            else
            {
                Console.WriteLine("Não tem nenhum atendimento cadastrado para o CPF digitado");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu!");
        }

        private void VerPacientesCadastrados()
        {
            if (listPacientes.Count == 0)
            {
                Console.WriteLine("A lista de pacientes está vazia");
            }
            else
            {
                for (int i = 0; i < listPacientes.Count; i++)
                {
                    Console.WriteLine(listPacientes[i].ToString());
                }
            }
        }

        private void VerProcedimentosCadastrados()
        {
            if (listProcedimentos.Count == 0)
            {
                Console.WriteLine("A lista de procedimentos está vazia");
            }
            else
            {
                for (int i = 0; i < listProcedimentos.Count; i++)
                {
                    Console.WriteLine(listProcedimentos[i].ToString());
                }
            }
        }

        private void VerMenu()
        {
            Console.Clear();
            Console.WriteLine(
                @"-----# Gerenciamento de Clínica Odontológica #-----
1. Cadastrar paciente
2. Cadastrar procedimento
3. Registrar atendimento
4. Visualizar relatório de atendimentos
5. Visualizar a lista de pacientes cadastrados
6. Visualizar a lista de procedimentos cadastrados
0. Sair
");
        }

    }
}
