using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace proiect1
{
    public class Client
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public bool Sters { get; set; }
    }
    public static class Clienti
    {

        public static List<Client> GetClienti()
        {
            List<Client> clienti = new List<Client>();
            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();
                    string sql = @"SELECT c.Nume as Nume, c.Prenume as Prenume, c.Mail as Mail, c.Id as IdClient, c.Telefon as Telefon
                            FROM dbo.Clienti AS c WHERE c.Sters=0   ";
                    SqlCommand cmd = new SqlCommand(sql, cnn);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Client pr = new Client()
                            {
                                Prenume = reader["Nume"].ToString(),
                                Nume = reader["Prenume"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Mail = reader["Mail"].ToString(),
                                Id = Convert.ToInt32(reader["IdClient"])
                            };
                            clienti.Add(pr);

                        }
                    }
                }
                catch (Exception)
                {
                    // jurnalizare + afisare eroare        
                }
            }
            return clienti;
        }

        public static bool ClientAM(int id, string nume, string prenume, string mail, string telefon)
        {
            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();

                    if (id == 0)
                    {

                        string sql2 = @"INSERT INTO dbo.Clienti(
                                    Nume,
                                    Prenume,
                                    Mail,
                                    Telefon
                                    )
                                    VALUES(
                                    @nume,
                                    @prenume,
                                    @mail,
                                    @telefon
                                    )";

                        SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                        cmd2.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                        cmd2.Parameters.Add(new SqlParameter("@nume", SqlDbType.NVarChar)).Value = nume;
                        cmd2.Parameters.Add(new SqlParameter("@prenume", SqlDbType.NVarChar)).Value = prenume;
                        cmd2.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar)).Value = mail;
                        cmd2.Parameters.Add(new SqlParameter("@telefon", SqlDbType.NVarChar)).Value = telefon;
                        cmd2.ExecuteNonQuery();

                    }
                    else
                    {


                        string sql = @"UPDATE dbo.Clienti
                                    SET Nume= @nume, Prenume = @prenume, Mail = @mail, Telefon= @telefon
                                    WHERE Id=@id";
                        SqlCommand cmd = new SqlCommand(sql, cnn);
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                        cmd.Parameters.Add(new SqlParameter("@nume", SqlDbType.NVarChar)).Value = nume;
                        cmd.Parameters.Add(new SqlParameter("@prenume", SqlDbType.NVarChar)).Value = prenume;
                        cmd.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar)).Value = mail;
                        cmd.Parameters.Add(new SqlParameter("@telefon", SqlDbType.NVarChar)).Value = telefon;
                        cmd.ExecuteNonQuery();
                    }
                    return true;

                }
                catch (Exception)
                {
                    return false;
                    
                }
            }


        }

        public static Client GetClient(int Id)
        {
            Client pr=null;

            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();
                    string sql = @"SELECT c.Nume as Nume, c.Prenume as Prenume, c.Mail as Mail, c.Id as IdClient, c.Telefon as Telefon, c.Sters as Sters
                            FROM dbo.Clienti AS c WHERE c.Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = Id;
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pr = new Client()
                            {
                                Prenume = reader["Nume"].ToString(),
                                Nume = reader["Prenume"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Mail = reader["Mail"].ToString(),
                                Id = Convert.ToInt32(reader["IdClient"])
                            };

                        }
                    }
                }
                catch (Exception)
                {
                    // jurnalizare + afisare eroare        
                }
            }
            return pr;
        }

        public static bool DeleteClient(int id)
        {
            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();
                    string sql = @"UPDATE dbo.Clienti
                                    SET Sters=1
                                    WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }

        }
    }
}
