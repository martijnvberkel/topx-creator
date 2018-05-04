using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOPX
{
    public class Import
    {
        public void ImportCSV()
        {
            string[] allLines = File.ReadAllLines(@"d:\temp\TOPX bestandsvoorbeeld XML.csv");

            using (var entities = new TOPXEntities())
            {
                for (int i = 1; i < allLines.Length; i++)
                {
                    var strbuilder = new StringBuilder();
                    string[] items = allLines[i].Split(";"[0]);

                    strbuilder.Append("INSERT INTO Source VALUES (");
                    foreach (var item in items)
                    {
                        strbuilder.Append("'" + item + "',");
                    }
                    strbuilder.Append(")");
                    strbuilder.Remove(strbuilder.Length - 2, 1);
                    entities.Database.ExecuteSqlCommand(strbuilder.ToString());
                }
            }
        }
    }
}
