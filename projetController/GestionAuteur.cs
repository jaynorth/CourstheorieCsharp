using projetModel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetController
{
    public class GestionAuteur
    {
        public List<Auteur> GetListeAuteurs(string chemin)
        {
            List<Auteur> auteurListe = new List<Auteur>();
            string connectionString = "";
            OleDbConnection con = null;
            OleDbCommand cmd = null;
            string sql = "";
            OleDbDataReader reader = null;
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + chemin;
            con = new OleDbConnection(connectionString);
            try
            {
                con.Open();
                sql = "select CodeAuteur, Nom, Prenom, DateNaissance from Auteur";
                cmd = new OleDbCommand(sql, con);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                while (reader.Read())
                {
                    Auteur a = new Auteur();
                    a.CodeAuteur = int.Parse(reader[0].ToString());
                    a.Nom = reader["Nom"].ToString();
                    a.Prenom = reader[2].ToString();
                    a.DateNaissance = Convert.ToDateTime(reader["DateNaissance"]);
                    auteurListe.Add(a);
                }
            } catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la connexion : " + e);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (cmd != null)
                    cmd.Dispose();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return auteurListe;
        }

        public void InsertAuteur(string chemin, Auteur auteur)
        {
            string connectionString = "";
            OleDbConnection con = null;
            OleDbCommand cmd = null;
            string sql = "";
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + chemin;
            con = new OleDbConnection(connectionString);
            try
            {
                con.Open();
                sql = "insert into Auteur (Nom, Prenom, DateNaissance) values (@nom, @prenom, @datenaissance)";
                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("@nom", auteur.Nom);
                cmd.Parameters.AddWithValue("@prenom", auteur.Prenom);
                cmd.Parameters.AddWithValue("@datenaissance", auteur.DateNaissance);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la connexion : " + e);
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void UpdateAuteur(string chemin)
        {
            string connectionString = "";
            OleDbConnection con = null;
            OleDbCommand cmd = null;
            string sql = "";
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + chemin;
            con = new OleDbConnection(connectionString);
            try
            {
                con.Open();
                sql = "update Auteur set Nom = @nom, Prenom = @prenom where Nom = @nom1";
                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("@nom", "Marcel");
                cmd.Parameters.AddWithValue("@prenom", "Bob");
                cmd.Parameters.AddWithValue("@nom1", "Ginier");
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la connexion : " + e);
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void DeleteAuteur(string chemin)
        {
            string connectionString = "";
            OleDbConnection con = null;
            OleDbCommand cmd = null;
            string sql = "";
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + chemin;
            con = new OleDbConnection(connectionString);
            try
            {
                con.Open();
                sql = "delete from Auteur where CodeAuteur = @num";
                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("@num", 4);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la connexion : " + e);
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
