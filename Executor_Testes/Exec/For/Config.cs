using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Executor_Testes.Exec.For
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Adicionar linhas de configuracao de massa de dados
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            //Adicionar Ultima configuracao
            string browser = string.Empty;
            if (browserGoogleChrome.Checked)
            {
                settings.Add("SA_Browser", "Chrome");
            }
            if (browserMozzilaFirefox.Checked)
            {
                settings.Add("SA_Browser", "Firefox");
            }
            if (browserInertnetExlorer.Checked)
            {
                settings.Add("SA_Browser", "Internet Explorer");
            }
            if (browserInertnetExlorer.Checked)
            {
                settings.Add("SA_Browser", "Internet Edge");
            }

            settings.Add("SA_Url", txtUrlWeb.Text);
            settings.Add("SA_User", txtUsuarioWeb.Text);
            settings.Add("SA_Pass", txtSenhaWeb.Text);

            settings.Add("BD_Server", txtServidorBD.Text);
            settings.Add("BD_Catalogo", txtCatalogoBD.Text);
            settings.Add("BD_User", txtUsuarioBD.Text);
            settings.Add("BD_Pass", txtSenhaBD.Text);

            settings.Add("MD_Server", txtServidorMD.Text);
            settings.Add("MD_Catalogo", txtCatologoMD.Text);
            settings.Add("MD_User", txtUsuarioMD.Text);
            settings.Add("MD_Pass", txtSenhaMD.Text);

            settings.Add("SP_Executor", txtExecutor.Text);
            settings.Add("SP_WebDrivers", txtWebDriver.Text);
          //  settings.Add("SP_PathReport", txtReport.Text);

          //  settings.Add("AP_Endpoint", txtEndPoint.Text);
         //   settings.Add("AP_User", txtUserAPI.Text);
          //  settings.Add("AP_Pass", txtPassAPI.Text);

            //Salvar arquivo de configuração
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            //Replicar informações dentro da dll
            var xmlExecutor = Directory.GetCurrentDirectory() + "\\Executor_Testes.exe.Config";
            var xml = Directory.GetCurrentDirectory();

            var listaProjetos = ConfigurationManager.AppSettings.GetValues("SP_Projetos")[0];
            String[] projetos = listaProjetos.Split(',');

            foreach (var item in projetos)
            {
                string nomeProjeto = Directory.GetCurrentDirectory() + @"\" + item + ".dll.config";
                if (File.Exists(nomeProjeto))
                {
                    File.Delete(nomeProjeto);
                    File.Copy(xmlExecutor, xmlExecutor + 1);
                    File.Move(xmlExecutor + 1, nomeProjeto);
                }
                else
                {
                    File.Copy(xmlExecutor, xmlExecutor + 1);
                    File.Move(xmlExecutor + 1, nomeProjeto);
                }
            }

            MessageBox.Show("Dados Gravados com Sucesso! ");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Adicionar linhas de configuracao de massa de dados
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            //Adicionar Ultima configuracao
            settings.Remove("SA_Browser");
            settings.Remove("SA_Url");
            settings.Remove("SA_User");
            settings.Remove("SA_Pass");
            settings.Remove("BD_Server");
            settings.Remove("BD_Catalogo");
            settings.Remove("BD_User");
            settings.Remove("BD_Pass");
            settings.Remove("MD_Server");
            settings.Remove("MD_Catalogo");
            settings.Remove("MD_User");
            settings.Remove("MD_Pass");
            settings.Remove("SP_Executor");
            settings.Remove("SP_WebDrivers");
            settings.Remove("SP_PathReport");
            settings.Remove("AP_Endpoint");
            settings.Remove("AP_User");
            settings.Remove("AP_Pass");

            //Salvar arquivo de configuração
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            MessageBox.Show("Dados Removidos com Sucesso! ");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}