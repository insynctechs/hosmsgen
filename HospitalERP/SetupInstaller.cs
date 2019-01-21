using System;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace HospitalERP
{
   [RunInstaller(true)]
    public partial class SetupInstaller : System.Configuration.Install.Installer
    {
        SqlConnection masterConnection = new SqlConnection();
        //private string logFilePath = "C:\\SetupLog.txt";
        public SetupInstaller() : base()
        {
            InitializeComponent();
        }

        private string GetSql(string Name)
        {
            try
            {
                // Gets the current assembly.
                Assembly Asm = Assembly.GetExecutingAssembly();

                // Resources are named using a fully qualified name.
                Stream strm = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name);

                // Reads the contents of the embedded file.
                StreamReader reader = new StreamReader(strm);
                return reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("In GetSQL: " + ex.Message);
                throw ex;
            }
        }

        private void ExecuteSql(string DatabaseName, string Sql)
        {
            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(Sql, masterConnection);

            // Initialize the connection, open it, and set it to the "master" database
            masterConnection.ConnectionString = Properties.Settings.Default.connstr;
            Command.Connection.Open();
            Command.Connection.ChangeDatabase(DatabaseName);
            try
            {
                Command.ExecuteNonQuery();
            }
            finally
            {
                // Closing the connection should be done in a Finally block
                Command.Connection.Close();
            }
        }


        private  void installProc()
        {
            
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connstr);
            ServerConnection svrConnection = new ServerConnection(sqlConnection);
            Server server = new Server(svrConnection);
            server.ConnectionContext.ExecuteNonQuery(GetSql("procedures.txt"));

        }

        protected void AddDBTable(string strDBName)
        {
            try
            {
                // Creates the database.
                ExecuteSql("master", "CREATE DATABASE " + strDBName);

                // Creates the tables.
                ExecuteSql(strDBName, GetSql("tables.txt"));

                // Creates the stored procedure.
                //ExecuteSql(strDBName, GetSql("procedures.txt"));
                //installProc();

            }
            catch (Exception ex)
            {
                // Reports any errors and abort.
                //MessageBox.Show("In exception handler: " + ex.Message);
                throw ex;
            }
        }


        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            AddDBTable("ERP_db");
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            ExecuteSql("master", "DROP DATABASE ERP_db");
        }
    }
}
