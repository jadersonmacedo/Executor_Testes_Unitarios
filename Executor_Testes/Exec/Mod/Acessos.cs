using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor_Testes.Exec.Mod
{
    public static class Acessos
    {
        //00
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }
        //01
        public static DataTable CarregarConfigInicial()
        {
            var DtConfigInicial = new DataTable();

            DtConfigInicial = ConvertCSVtoDataTable("C:\\Data\\Config.csv");

            return DtConfigInicial;
        }
        //02
        public static Qualidade ObterEntityAutomacao()
        {
            string dataSource = ConfigurationManager.AppSettings.GetValues("MD_Server")[0];
            string dataCatalogo = ConfigurationManager.AppSettings.GetValues("MD_Catalogo")[0];
            string dataUser = ConfigurationManager.AppSettings.GetValues("MD_User")[0];
            string dataPass = ConfigurationManager.AppSettings.GetValues("MD_Pass")[0];

            var dbEntity = new Qualidade();
            dbEntity.ChangeDatabase(dataCatalogo, dataSource, dataUser, dataPass);

            return dbEntity;
        }
        //03
        public static void ChangeDatabase(this DbContext source, string initialCatalog = "", string dataSource = "", string userId = "", string password = "", bool integratedSecuity = false, string configConnectionStringName = "")
        {
            try
            {
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder
                    (ConfigurationManager
                        .ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (entityCnxStringBuilder.ProviderConnectionString);

                // only populate parameters with values if added
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;

                // set the integrated security status
                sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

                // now flip the properties that were changed
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //04
        public static DataSet ObterDados(string comando)
        {
            using (SqlConnection conn = new SqlConnection(ObterEntityAutomacao().Database.Connection.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        conn.Close();
                        return ds;
                    }
                }
            }
        }
    }
}