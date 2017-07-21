using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ApiServer.Defines;
using System.Data;
using ApiServer.Exceptions;

namespace ApiServer.SQL
{
    //singleton
    public class SQLClient 
    {
        private static SQLClient instance = new SQLClient();
        public static SQLClient Instance
        {
            get
            {
                return instance;
            }
        }
        //attributes
        private string loginCNNString;
        private string dataCNNString;
        private SqlConnection loginCNN;
        private SqlConnection dataCNN;

        //methods

        //------------------------------------private----------------------
        //execute query using provided connections
        private DataTable query(string _query, SqlConnection _conn, List<String> keys, List<String> values)
        {
            try
            {
                DataTable data = new DataTable();

                // create data adapter
                SqlCommand cmd = new SqlCommand(_query, _conn);
                for (int i=0;i<keys.Count;i++)
                    cmd.Parameters.AddWithValue(keys[i], values[i]);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(data);
                return data;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Unable to execute query! " + ex.Message);
                throw new ExceptionDefines.InternalErrorEx();
            }
        }


        //------------------------------------public-------------------------
        //initialize sql connections
        //exceptions: unable to connect to login server or data servers
        public void init()
        {
            Console.WriteLine("Init sql server!");
            loginCNNString = Constants.LOGIN_CONNECTION_STRING;
            dataCNNString = Constants.DATA_CONNECTION_STRING;

            loginCNN = new SqlConnection(loginCNNString);
            dataCNN = new SqlConnection(dataCNNString);

            try
            {
                loginCNN.Open();
            } catch (SqlException ex)
            {
                Console.WriteLine("Unable to connect to login db server!");
                throw new ExceptionDefines.InternalErrorEx();
            }

            try
            {
                dataCNN.Open();
            } catch (SqlException ex)
            {
                Console.WriteLine("Unable to connect to data db server!");
                throw new ExceptionDefines.InternalErrorEx() ;
            }
        }

        //execute queries interacting with login server
        public DataTable loginQuery(string _query, List<string> keys, List<string> values)
        {
            try
            {
                return query(_query, loginCNN, keys, values);
            }
            catch (ExceptionDefines.InternalErrorEx ex)
            {
                throw ex;
            }
        }

        //execute queries interacting with data server>
        public DataTable dataQuery(string _query, List<string> keys, List<string> values)
        {
            try
            {
                return query(_query, dataCNN, keys, values);
            }
            catch (ExceptionDefines.InternalErrorEx ex){
                throw ex;
            }
        }

    }
}