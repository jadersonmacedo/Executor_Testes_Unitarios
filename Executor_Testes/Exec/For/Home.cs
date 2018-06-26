using Executor_Testes.Exec.Lis;
using Executor_Testes.Exec.Mod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Executor_Testes.Exec.For
{
    public partial class Home : Form
    {
        //00
        public Home()
        {
            InitializeComponent();
        }
        //01
        private void tspConfigurar_Click(object sender, EventArgs e)
        {
            Config configurar = new Config();
            configurar.ShowDialog();
        }
        //02
        private void tspRelatorioExecução_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }
        //03
        private void Home_Load(object sender, EventArgs e)
        {
            //Limpar arvore de execução
            trvCenarios.Nodes.Clear();

            //Carregar arquivo de configuração xml
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            //Limpar dados das pastas do sistema
            settings.Remove("SP_PathReport");
            settings.Remove("SP_Executor");
            settings.Remove("SP_WebDrivers");

            //Limpar dados de conexão da massa de dados
            settings.Remove("MD_Server");
            settings.Remove("MD_Catalogo");
            settings.Remove("MD_User");
            settings.Remove("MD_Pass");

            //Limpar dados de conexão como banco de dados
            settings.Remove("BD_Server");
            settings.Remove("BD_Catalogo");
            settings.Remove("BD_User");
            settings.Remove("BD_Pass");

            //Limpar dados do navegador
            settings.Remove("SA_Browser");
            settings.Remove("SA_Url");
            settings.Remove("SA_User");
            settings.Remove("SA_Pass");

            //Salvar arquivo de configuração xml
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            //Limpar arquivo de configuracao das Dll's
            var xmlExecutor = Directory.GetCurrentDirectory() + "\\Executor_Testes.exe.config";

            var listaProjetos = ConfigurationManager.AppSettings.GetValues("SP_Projetos")[0];
            var lista = new List<string>();

            String[] projetos = listaProjetos.Split(',');

            foreach (var item in lista)
            {
                string nomeProjeto = Directory.GetCurrentDirectory() + @"\" + item + ".dll.config";
                if (File.Exists(nomeProjeto))
                {
                    File.Delete(nomeProjeto);
                }
            }

            //Carregar os projetos para execucao
            foreach (var item in projetos)
            {
                cbxProjetos.Items.Add(item);
            }
        }
        //04
        private void btnCarregarCenarios_Click(object sender, EventArgs e)
        {
            //Limpar arvore de execucao de testes
            trvCenarios.Nodes.Clear();

            //Acessar banco de dados
            var entityAutomacao = Acessos.ObterEntityAutomacao();

            //Carregar lista de massa de dados
            List<TreeViewExecucaoAutomacao> lstExecucao = new List<TreeViewExecucaoAutomacao>();

            var listaProjetos = ConfigurationManager.AppSettings.GetValues("SP_Projetos")[0];
            String[] projetos = listaProjetos.Split(',');

            //Carrega cenarios com projetos individuais
            if (listaProjetos.Contains(cbxProjetos.Text))
            {
                //Manager >> Ikcadm
                switch (cbxProjetos.Text)
                {
                    case "EC_Manager":
                        //Executa stored procedure
                        entityAutomacao.sp_RetornaTreeViewAutomacaoManager();

                        //Carrega todas as linhas das tabelas dos banco de dados ( checked = true )
                        lstExecucao = entityAutomacao.TreeViewExecucaoAutomacao.Where(t => t.MassaDados == false).ToList();

                        //Adiciona Titulo a aplicação
                        var objAutomacaoEC_Manager = trvCenarios.Nodes.Add("Teste Automatizados EC Manager");

                        //Carrega os cenarios do banco de dados
                        var lstFuncionalidadesAutomacaoManager = lstExecucao.Select(f => new { Tabela = f.Tabela, Funcionalidade = f.Funcionalidade }).Distinct().ToList();

                        foreach (var item in lstFuncionalidadesAutomacaoManager)
                        {
                            var objNode = objAutomacaoEC_Manager.Nodes.Add(item.Funcionalidade);
                            foreach (var casoTeste in lstExecucao.Where(cs => cs.Tabela == item.Tabela).ToList())
                            {
                                var node = objNode.Nodes.Add(casoTeste.TestCaseID.ToString() + " - " + casoTeste.Descricao_CasoTeste);
                                node.Tag = casoTeste;
                            }
                        }

                        objAutomacaoEC_Manager.Expand();
                        trvCenarios.SelectedNode = trvCenarios.Nodes[0];
                        break;

                    case "EC_Ikcadm":
                        //Executa stored procedure
                        entityAutomacao.sp_RetornaTreeViewAutomacaoIkcadm();

                        //Carrega todas as linhas das tabelas dos banco de dados ( checked = true )
                        lstExecucao = entityAutomacao.TreeViewExecucaoAutomacao.Where(t => t.MassaDados == false).ToList();

                        //Adiciona Titulo a aplicação
                        var objAutomacaoEC_Ikcadm = trvCenarios.Nodes.Add("Testes Automatizados EC Ikcadm");

                        //Carrega os cenarios do banco de dados
                        var lstFuncionalidadesAutomacaoIkcadm = lstExecucao.Select(f => new { Tabela = f.Tabela, Funcionalidade = f.Funcionalidade }).Distinct().ToList();

                        foreach (var item in lstFuncionalidadesAutomacaoIkcadm)
                        {
                            var objNode = objAutomacaoEC_Ikcadm.Nodes.Add(item.Funcionalidade);
                            foreach (var casoTeste in lstExecucao.Where(cs => cs.Tabela == item.Tabela).ToList())
                            {
                                var node = objNode.Nodes.Add(casoTeste.TestCaseID.ToString() + " - " + casoTeste.Descricao_CasoTeste);
                                node.Tag = casoTeste;
                            }
                        }

                        objAutomacaoEC_Ikcadm.Expand();
                        trvCenarios.SelectedNode = trvCenarios.Nodes[0];
                        break;

                }
            }
        }
        //05
        private void trvExecucao_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode item in e.Node.Nodes)
            {
                item.Checked = e.Node.Checked;
            }
        }
        //06
        private void tspCriarMassaDados_Click(object sender, EventArgs e)
        {
            //Pegar past do projeto
            var diretorio = AppDomain.CurrentDomain.BaseDirectory + "MassaDados\\";
            var extensao = ".xml";
            string nomeArquivo = string.Empty;

            var entityAutomacao_Automacao = Acessos.ObterEntityAutomacao();
            StringBuilder comando_Automacao = new StringBuilder();

            var lstTesteAutomacao = new List<CasoTesteClasse>();

            var selecionadosAutomacao = trvCenarios.Nodes[0].Nodes.Cast<TreeNode>().SelectMany(grupo => grupo.Nodes.Cast<TreeNode>().Where(a => a.Checked).Select(item => (TreeViewExecucaoAutomacao)item.Tag)).ToList();

            var agrupadosAutomacao = (from a in selecionadosAutomacao
                                      group a by a.Tabela into x
                                      select new { Tabela = x.Key, Teste = x }).ToList();

            DataSet _testesAutomacao = new DataSet();
            _testesAutomacao.DataSetName = "Execucao";

            foreach (var item in agrupadosAutomacao)
            {
                string _select = string.Format("select * from {0} where id_teste in({1})", item.Tabela, string.Join(",", item.Teste.Select(a => a.ID_Teste.ToString())));

                DataTable _dt = Acessos.ObterDados(_select).Tables[0];
                _dt.TableName = item.Tabela;
                _testesAutomacao.Tables.Add(_dt.Copy());
            }

            if (!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);

            nomeArquivo = diretorio + "MassaDados";

            if (File.Exists(nomeArquivo + extensao))
            {
                var _arquivo = new FileInfo(nomeArquivo + extensao);
                File.Move(nomeArquivo + extensao, nomeArquivo + "_" + _arquivo.LastWriteTime.ToString("dd_MM_yyyy_HH_mm_ss") + extensao);
                _arquivo.Delete();
            }
            _testesAutomacao.WriteXml(nomeArquivo + extensao, XmlWriteMode.WriteSchema);
#if DEBUG
            var diretorioTestesAutomacao = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Executor_Testes\\Data\\MassaDados\\";

            if (!Directory.Exists(diretorioTestesAutomacao))
                Directory.CreateDirectory(diretorioTestesAutomacao);
            File.Copy(nomeArquivo + extensao, diretorioTestesAutomacao + "MassaDados.xml", true);
#endif
            MessageBox.Show("Massa de Dados Gerada com sucesso: " + diretorio + "MassaDados.xml", "", MessageBoxButtons.OK);
        }
        //07
        private void btnExecutar_Click(object sender, EventArgs e)
        {
            //Sistema verifica se o usuario selecionou os cenarios desejado
            if (cbxProjetos.Text == "")
            {
                MessageBox.Show("Por favor reabrir o executor e não esquecer de selecionar um projeto! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }

            //Sistema captura a pasta atual do projeto
            string folder = Directory.GetCurrentDirectory();

            //O sistema executa a dll selecionada de acordo o projeto
            var diretorio = folder + "\\MassaDados\\";
            var extensao = ".xml";
            string nomeArquivo = string.Empty;

            var entityAutomacao_Automacao = Acessos.ObterEntityAutomacao();
            StringBuilder comando_Automacao = new StringBuilder();

            var lstTesteAutomacao = new List<CasoTesteClasse>();

            var selecionadosAutomacao = trvCenarios.Nodes[0].Nodes.Cast<TreeNode>().SelectMany(grupo => grupo.Nodes.Cast<TreeNode>().Where(a => a.Checked).Select(item => (TreeViewExecucaoAutomacao)item.Tag)).ToList();

            var agrupadosAutomacao = (from a in selecionadosAutomacao
                                      group a by a.Tabela into x
                                      select new { Tabela = x.Key, Teste = x }).ToList();

            DataSet _testesAutomacao = new DataSet();
            _testesAutomacao.DataSetName = "Execucao";

            foreach (var item in agrupadosAutomacao)
            {
                string _select = string.Format("select * from {0} where id_teste in({1})", item.Tabela, string.Join(",", item.Teste.Select(a => a.ID_Teste.ToString())));

                DataTable _dt = Acessos.ObterDados(_select).Tables[0];
                _dt.TableName = item.Tabela;
                _testesAutomacao.Tables.Add(_dt.Copy());
            }

            if (!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);

            nomeArquivo = diretorio + "MassaDados";

            if (File.Exists(nomeArquivo + extensao))
            {
                var _arquivo = new FileInfo(nomeArquivo + extensao);
                File.Move(nomeArquivo + extensao, nomeArquivo + "_" + _arquivo.LastWriteTime.ToString("dd_MM_yyyy_HH_mm_ss") + extensao);
                _arquivo.Delete();
            }
            _testesAutomacao.WriteXml(nomeArquivo + extensao, XmlWriteMode.WriteSchema);
#if DEBUG
            var diretorioTestesAutomacao = folder + "\\MassaDados\\";
            if (!Directory.Exists(diretorioTestesAutomacao))
                Directory.CreateDirectory(diretorioTestesAutomacao);
#endif
            foreach (TreeNode item in trvCenarios.Nodes[0].Nodes)
            {
                foreach (TreeNode item2 in item.Nodes)
                {
                    var trvItem = (TreeViewExecucaoAutomacao)item2.Tag;
                    if (item2.Checked)
                    {
                        var teste = new CasoTesteClasse();
                        teste.ID_Teste = trvItem.ID_Teste;
                        teste.ID_TestCase = trvItem.TestCaseID;
                        teste.Funcionalidade = trvItem.Funcionalidade;
                        teste.Executar = item2.Checked;
                        teste.ID_Config = trvItem.ID_Config;
                        teste.ID_Suite = trvItem.ID_Suite;
                        teste.OrdemExecucao = trvItem.OrdemExecucao;
                        teste.Nome_Teste = trvItem.Nome_Teste;
                        teste.Descricao = trvItem.Descricao_CasoTeste;
                        lstTesteAutomacao.Add(teste);
                    }
                }
            }
            string folderData = folder + "\\Report\\";

            diretorio = folderData + DateTime.Now.ToString("dd-MM-yyyy") + "\\";

            Directory.CreateDirectory(diretorio);

            string error = string.Empty;
            string trx = string.Empty;
            ProcessStartInfo psi;
            Process reg;
            string report = String.Empty;
            string output = "";

            if (lstTesteAutomacao.Where(lst => lst.Executar == true).Count() > 0)
            {
                DirectoryInfo di = new DirectoryInfo(diretorio);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                if (File.Exists(diretorio + DateTime.Now.ToString("dd-MM-yyyy") + "_Automacao.txt"))
                    File.Delete(diretorio + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + "_Automacao.txt");

                var lstArvoreExecucao = selecionadosAutomacao.Where(t => t.Executar == true).Select(t => new { Funcionalidade = t.Funcionalidade, ID = t.OrdemExecucao, Nome = t.Nome_Teste, Descricao = t.Descricao_CasoTeste }).Distinct().OrderBy(n => n.ID).ToList();

                string pathProject = AppDomain.CurrentDomain.BaseDirectory;
                string dll = pathProject + cbxProjetos.Text + ".dll";

                string container = "/testcontainer:\"";
                string vNamespace = " /test:\"CenariosDeTestes.";

                pgbStatus.Value = 0;

                foreach (var item in lstArvoreExecucao)
                {
                    lblFuncionalidade.Text = "Funcionalidade: " + item.Funcionalidade;
                    lblCenario.Text = "Cenario de Teste: "+item.Descricao;

                    int totalTeste = lstArvoreExecucao.Count;

                    pgbStatus.Maximum = totalTeste;
                    pgbStatus.Step = 1;
                    pgbStatus.PerformStep();

                    string cmd = container + dll + "\"" + vNamespace + item.Nome + "\"";
                    string exe = ConfigurationManager.AppSettings["SP_Executor"];

                    psi = new ProcessStartInfo(exe, cmd);

                    try
                    {
                        psi.RedirectStandardOutput = true;
                        psi.RedirectStandardError = true;
                        psi.CreateNoWindow = true;
                        psi.UseShellExecute = false;
                        reg = Process.Start(psi);
                        reg.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    using (StreamReader myOutput = reg.StandardOutput)
                    {
                        output = myOutput.ReadToEnd();

                        if (output.Contains("not found"))
                            throw new Exception(output);
                    }
                    using (StreamReader myError = reg.StandardError)
                    {
                        error = myError.ReadToEnd();
                        if (error != string.Empty)
                            MessageBox.Show("Verificar Erro");
                    }

                    Thread.Sleep(500);
                }
                MessageBox.Show("Execução Finalizada");
            }
        }
    }
}