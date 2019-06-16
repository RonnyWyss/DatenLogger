using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    internal class DataAccess
    {
        private readonly string connStr;

        public DataAccess(string connStr)
        {
            this.connStr = connStr;
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    IsValid = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Datenbankverbindung nicht möglich.\n\n{0}", e.Message));
            }
        }

        public bool IsValid { get; }

        public DataTable GetArticleData(string where, int recordCount, out string stmt)
        {
            stmt = "select ARTIKELNR, BEZEICHNUNG, NETTOPREIS, HERSTELLER from ARTIKEL where " + where + " limit " + recordCount;
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = stmt;
                        using (var dataAdapter = new MySqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Artikelabfrage nicht möglich.\n\n{0}", e.Message));
            }

            return dt;
        }

        public DataTable GetArticleDataSafe(string where, string whereValue, int recordCount, out string stmt)
        {
            stmt = "select ARTIKELNR, BEZEICHNUNG, NETTOPREIS, HERSTELLER from ARTIKEL where " + where + " @whereVal limit @recordCnt";
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = stmt;
                        cmd.Parameters.AddWithValue("@whereVal", whereValue);
                        cmd.Parameters.AddWithValue("@recordCnt", recordCount);
                        using (var dataAdapter = new MySqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Artikelabfrage nicht möglich.\n\n{0}", e.Message));
            }

            return dt;
        }
    }
}