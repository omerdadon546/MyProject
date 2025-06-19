using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Web;


namespace omerWCF.App_Code
{
    /// <summary>
    /// This is a class Name "Connection_Class" to perform Insert, Update Delete Seשrch options
    /// Show Data in DataGridView and also Perform SqlDataReader Options.
    /// </summary>
    public class Connection
    {
            const string FILE_NAME = "omeracces.accdb";
            static string location = "../../App_Data/" + FILE_NAME;
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + location;
            public OleDbConnection con;

        public OleDbCommand Command(string Query_)
        {
            OleDbCommand myCmd = new OleDbCommand(Query_, con); ;

            return myCmd;

        }
                public void OpenConnection()
        {
            con = new OleDbConnection(ConnectionString);
            con.Open();
        }


        public void CloseConnection()
        {
            con.Close();

        }


        public void ExecuteQueries(string Query_)
        {
            OleDbCommand cmd = new OleDbCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }


        public OleDbDataReader DataReader(string Query_)
        {
            OleDbCommand cmd = new OleDbCommand(Query_, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public object ShowDataInGridView(string Query_)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

    }
}