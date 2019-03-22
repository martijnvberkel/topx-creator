using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionstring = LocalDbHelper.GetConnectionString();
            using (var con = new SqlConnection(connectionstring))
            {
                con.Open();
                var sqlCommandText = @"USE master 
                         DECLARE @kill varchar(8000) = ''; 
                         SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), spid) + ';' 
                         FROM master..sysprocesses  
                         WHERE dbid = db_id('ModelTopX') 
                         EXEC(@kill); 
                         ALTER DATABASE ModelTopX  SET SINGLE_USER WITH ROLLBACK IMMEDIATE; 
                         drop database ModelTopX";
                var sqlCommand = new SqlCommand(sqlCommandText, con);
                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
