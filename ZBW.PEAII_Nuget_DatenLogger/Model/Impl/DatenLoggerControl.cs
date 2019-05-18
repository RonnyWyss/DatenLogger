using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ZBW.PEAII_Nuget_DatenLogger.Properties;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    internal class DatenLoggerControl
    {
        public void ConnectionState()
        {
            // private string Connectionstring => $"Servername={this.txtServer.Text};Database={this.txtDatabase.Text};Uid={this.txtUid.Text};Pwd={this.txtPwd.Text}";
            //var connStr = "Server="+servername +";Database="+ database + ";Uid=" + username + ";Pwd=" + passwort;//"Server=localhost;Database=sqlteacherdb;Uid=root;Pwd=";

            using (IDbConnection conn = new MySqlConnection(Settings.Default.Connectionstring)) //In diesem Befehl kann die Datenbankanbidnung gewählt werden.
            {
                try
                {
                    conn.Open();

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT mitarbeiternr, name, vorname, gehalt FROM mitarbeiter";
                    // cmd.CommandText = "SELECT id, pod, location, hostname, severity, timestamp, text FROM v_logentries";
                    using (var reader = cmd.ExecuteReader())

                    {
                        var values = new object[reader.FieldCount]; //Variante 1
                        while (reader.Read())
                        {
                            //Datenauslesen Variante 1 Werte einzeln auslesen
                            var cols = reader.GetValues(values);
                            for (var i = 0; i < cols; i++) Console.Write($"|{values[i]}");
                            Console.WriteLine();

                            ////Datenauslesen Variante 2 Alle Werte lesen
                            //var mitarbeiternr = reader.GetString(0);
                            //var name = reader.GetString(1);
                            //var vorname = reader.GetString(2);
                            ////  var gehalt2 = reader.GetValue(3); // Wenn NULL in Datenbank
                            ////  DBNull.Value;
                            //var gehalt = reader.GetDecimal(3);
                            //Console.WriteLine($"{mitarbeiternr} | {name} | {vorname} | {gehalt}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    MessageBox.Show(e.Message);
                    //throw;
                }
            }

            Console.ReadLine();
        }
    }
}