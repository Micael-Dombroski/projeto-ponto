using System;
using System.Collections.Generic;
using Ponto.Classes;

namespace Ponto.ConsoleApp
{
    class Program
    {
        static string menuOption;
        static UserConsole userConsole = new();
        static ConsoleUtils _utils = new();

        static string ler;
        static int Opt;
        static int OptMenu;
        static Empresa empresa;
        //Inventando Dados para um Adm inicial...---------------------------------------------------------------
        static Administrador administrador = new Administrador("12345678900", "Galo", "Cinza");
        //------------------------------------------------------------------------------------------------------
        static CrudFuncionario funcionarios = new CrudFuncionario();//Tive que colocar esses dados só pra poder usar o Crud
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                _utils.ShowHeader("Menu");
                ShowMainMenu();
                ReadMenuOption();
                HandleMenu();
            }
            administrador.ChaveAdministrador = "root";
            //Funcionario Teste-----------------------------------------------------------------------------------
            Funcionario funcionarioC = new Funcionario("12345678901", "lucas", "almeida");
            funcionarios.Cadastrar(funcionarioC);
            //----------------------------------------------------------------------------------------------------
            Console.WriteLine("Informe o Nome da Empresa: ");
            string empresaNome = Console.ReadLine();
            do
            {
                Console.Write("Informe o CNPJ da Empresa: ");
                ler = Console.ReadLine();
            } while (ValCNPJ(ler) == false);
            string cnpj = ler;
            Console.Write("Informe o UF onde a Empresa está localizada: ");
            string uf = Console.ReadLine();
            Console.Write("Informe a Cidade onde a Empresa está localizada: ");
            string cidade = Console.ReadLine();
            Console.Write("Informe o Complemento da Empresa: ");
            string complemento = Console.ReadLine();
            Console.Write("Informe o Bairro onde a Empresa está localizada: ");
            string bairro = Console.ReadLine();
            Console.Write("Informe a Rua onde a Empresa está localizada: ");
            string rua = Console.ReadLine();
            do
            {
                Console.Write("Informe o Número do Complemento da Empresa: ");
                ler = Console.ReadLine();
            } while (ENumero(ler) == false);
            int numero = Convert.ToInt32(ler);
            empresa = new Empresa(empresaNome, cnpj);
            do
            {
                do
                {
                    ler = Console.ReadLine();
                } while (ENumero(ler) == false);
                Opt = Convert.ToInt32(ler);
                switch (Opt)
                {
                    case 1:
                        cnpj = empresa.CNPJ;
                        Console.WriteLine("-----------Dados da Empresa-----------");
                        Console.WriteLine($"CNPJ: {cnpj[0]}{cnpj[1]}.{cnpj[2]}{cnpj[3]}{cnpj[4]}.{cnpj[5]}{cnpj[6]}{cnpj[7]}/{cnpj[8]}{cnpj[9]}{cnpj[10]}{cnpj[11]}-{cnpj[12]}{cnpj[13]}");
                        Console.WriteLine($"Nome: {empresa.Nome}");
                        Console.WriteLine("---------------------------------------");
                        break;
                    case 2:
                        do
                        {
                            do
                            {
                                ler = Console.ReadLine();
                            } while (ENumero(ler) == false);
                            OptMenu = Convert.ToInt32(ler);
                            switch (OptMenu)
                            {
                                case 1:
                                    do
                                    {
                                        Console.Write("Informe o CPF do Funcionário que deseja Consultar: ");
                                        ler = Console.ReadLine();
                                    } while (ValCPF(ler) == false);
                                    if (funcionarios.ConsultarCPF(ler) == null)
                                    {
                                        Console.WriteLine("Funcionário Não Encontrado");
                                    }
                                    else
                                    {
                                        Funcionario funcionario = funcionarios.ConsultarCPF(ler);
                                        string cpf = funcionario.Cpf;
                                        Console.WriteLine("-----------Dados do Funcionário-----------");
                                        Console.WriteLine($"CPF: {cpf[0]}{cpf[1]}{cpf[2]}.{cpf[3]}{cpf[4]}{cpf[5]}.{cpf[6]}{cpf[7]}{cpf[8]}-{cpf[9]}{cpf[10]}");
                                        Console.WriteLine($"Nome: {funcionario.Name} {funcionario}");
                                        Console.WriteLine($"UF: {funcionario}");
                                        Console.WriteLine($"Cidade: {funcionario}");
                                        Console.WriteLine($"Bairro: {funcionario}");
                                        Console.WriteLine($"Rua: {funcionario}");
                                        Console.WriteLine($"Complemento: {funcionario}");
                                        Console.WriteLine($"Número do Complemento: {funcionario}");
                                        Console.WriteLine($"Nome de Usuário: {funcionario.Usuario}");
                                        Console.WriteLine($"Senha: {funcionario.Senha}");
                                        Console.WriteLine("------------------------------------------");
                                    }
                                    break;
                                case 2:
                                    bool registrarPonto = false;
                                    bool usuarioExistente = false;
                                    bool senhaCerta = false;
                                    do
                                    {
                                        registrarPonto = false;
                                        usuarioExistente = false;
                                        senhaCerta = false;
                                        Console.Write("Informe o Nome do Usuário: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Usuario == ler)
                                            {
                                                usuarioExistente = true;
                                                Console.Write("Informe a Senha do Usuário: ");
                                                ler = Console.ReadLine();
                                                if (funcionario.Senha == ler)
                                                {
                                                    senhaCerta = true;
                                                    registrarPonto = true;
                                                    funcionario.MarcarPonto();
                                                }
                                            }
                                        }
                                        if (usuarioExistente == false)
                                        {
                                            Console.WriteLine("Usuário Não Encontrado");
                                        }
                                        else if (senhaCerta == false)
                                        {
                                            Console.WriteLine("Senha Incorreta");
                                        }
                                    } while (registrarPonto == false);
                                    break;
                                case 3:
                                    Console.WriteLine("Voltando...");
                                    break;
                                default:
                                    Console.WriteLine("Opção Inválida");
                                    break;
                            }
                        } while (OptMenu != 4);
                        break;
                    case 3:
                        bool AdmCadastrado = false;
                        do
                        {
                            do
                            {
                                Console.WriteLine("-----------Menu Administrador-----------");
                                Console.WriteLine("[1] Cadastrar");
                                Console.WriteLine("[2] Editar");
                                Console.WriteLine("[3] Excluir");
                                Console.WriteLine("[4] Exibir todos os Funcionários");
                                Console.WriteLine("[5] Voltar");
                                Console.WriteLine("----------------------------------------");
                                Console.Write("Informe o Número da Opção desejada: ");
                                ler = Console.ReadLine();
                            } while (ENumero(ler) == false);
                            OptMenu = Convert.ToInt32(ler);
                            Console.WriteLine("Caso Não Tenha um Administrador Cadastrado use essa chave de administrador: root");
                            switch (OptMenu)
                            {
                                case 1:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                                {
                                                    AdmCadastrado = true;
                                                }
                                            }
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                    //Falta Escrever Aqui o Código pra Cadastrar
                                    break;
                                case 2:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                                {
                                                    AdmCadastrado = true;
                                                }
                                            }
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                    //Falta Escrever Aqui o Código para Editar
                                    break;
                                case 3:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                                {
                                                    AdmCadastrado = true;
                                                }
                                            }
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                    //Excluindo Funcionário...
                                    bool FuncionarioExistente = false;
                                    string CpfFuncionario = "";
                                    do
                                    {
                                        Console.Write("Informe o CPF do Funcionário que deseja excluir: ");
                                        ler = Console.ReadLine();
                                    } while (ValCPF(ler) == false);
                                    foreach (KeyValuePair<string, Funcionario> par1 in funcionarios.ConsultarTodos())
                                    {
                                        if (par1.Key == ler)
                                        {
                                            FuncionarioExistente = true;
                                            CpfFuncionario = par1.Key;
                                        }
                                    }
                                    if (FuncionarioExistente == true)
                                    {
                                        Console.WriteLine("Tem certeza que deseja Excluir esse Funcionário? S/N");
                                        ler = Console.ReadLine();
                                        if (ler.ToLower() == "s")
                                        {
                                            funcionarios.Excluir(CpfFuncionario);
                                            Console.WriteLine("Funcionário Excluído");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Funcionário Não Encontrado");
                                    }
                                    break;
                                case 4:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                                {
                                                    AdmCadastrado = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                    Console.WriteLine("Exibindo Todos os Funcionários...");
                                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("CPF             | Nome Completo             | Endereço");
                                    foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                    {
                                        Funcionario funcionario = par.Value;
                                        string cpf = funcionario.Cpf;
                                        Console.Write($"{cpf[0]}{cpf[1]}{cpf[2]}.{cpf[3]}{cpf[4]}{cpf[5]}.{cpf[6]}{cpf[7]}{cpf[8]}-{cpf[9]}{cpf[10]} | ");
                                        Console.Write($"{funcionario.Name} {funcionario}  | ");
                                        Console.Write($"{funcionario} - ");
                                        Console.Write($"{funcionario} - ");
                                        Console.Write($"{funcionario} - ");
                                        Console.Write($"{funcionario} - ");
                                        Console.Write($"{funcionario} - ");
                                        Console.WriteLine($"{funcionario}");
                                    }
                                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                                    break;
                                case 5:
                                    Console.WriteLine("Voltando...");
                                    break;
                                default:
                                    Console.WriteLine("Opção Inválida");
                                    break;
                            }
                        } while (OptMenu != 4);
                        break;
                    case 4:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            } while (Opt != 4);
        }

        private static void HandleMenu()
        {
            switch (menuOption)
            {
                case "0":
                    Exit();
                    break;
                case "2":
                    userConsole.Execute();
                    break;
                default:
                    break;
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Saindo do sistema...");
            Environment.Exit(1);
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("[1] Exibir Informações da Empresa");
            Console.WriteLine("[2] Menu Funcionário");
            Console.WriteLine("[3] Menu Administrador");
            Console.WriteLine("[0] Sair");
        }

        static void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        static bool ENumero(string palavra)
        {
            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] > 57 || palavra[i] < 48)
                {
                    Console.WriteLine("Use apenas números nesse campo");
                    return false;
                }
            }
            return true;
        }
        static bool ValCNPJ(string Cnpj)
        {
            try
            {
                if (Cnpj.Length < 14 || Cnpj.Length > 14)
                {
                    throw new ArgumentException("O número de caracteres inseridos não bate com a quantidade que essa informação exige"); ;
                }
                for (int i = 0; i < Cnpj.Length; i++)
                {
                    if (Cnpj[i] < 48 || Cnpj[i] > 57)
                    {
                        throw new ArgumentException("Use apenas números nessa informação");
                    }
                }
                Console.WriteLine("CNPJ válido");
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        static bool ValCPF(string Cpf)
        {
            try
            {
                if (Cpf.Length < 11 || Cpf.Length > 11)
                {
                    throw new ArgumentException("O número de caracteres inseridos não bate com a quantidade que essa informação exige"); ;
                }
                for (int i = 0; i < Cpf.Length; i++)
                {
                    if (Cpf[i] < 48 || Cpf[i] > 57)
                    {
                        throw new ArgumentException("Use apenas números nessa informação");
                    }
                }
                Console.WriteLine("CPF válido");
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
