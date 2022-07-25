using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace proiect1
{
    public class Programare
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public DateTime Data { get; set; }
        public string Serviciu { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Client 
        {
            get 
            {
                return Nume + " " + Prenume;
            }
        }

        public string data_proxy
        {
            get
            {
                return Data.ToString("dd.MM.yyyy");
            }
        }
    }
    public static class Programari
    {
        public static List<Programare> GetProgramari(DateTime Data)
        {
            List<Programare> programari = new List<Programare>();
            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();
                    string sql = @"SELECT c.Nume as Nume, c.Prenume as Prenume, p.Data as Data, p.Serviciu as Serviciu, c.Telefon as Telefon, c.Mail as Mail, p.Id as Id, c.Id as IdClient
                            FROM dbo.Programari AS p INNER JOIN 
                            dbo.Clienti as c ON p.IdClient = c.Id                            
                            WHERE p.Data = @data AND p.Sters=0";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.DateTime)).Value = Data.Date;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Programare pr = new Programare()
                            {
                                Prenume = reader["Prenume"].ToString(),
                                Nume = reader["Nume"].ToString(),
                                Serviciu = reader["Serviciu"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Mail = reader["Mail"].ToString(),
                                Data = Convert.ToDateTime(reader["Data"]),
                                Id = Convert.ToInt32(reader["Id"]),
                                IdClient = Convert.ToInt32(reader["IdClient"])
                            };
                            programari.Add(pr);

                        }
                    }
                }
                catch (Exception)
                {
                    // jurnalizare + afisare eroare        
                }
            }
            return programari;
        }

        public static bool ProgramareAM(int id, DateTime Data, string Serviciu, int idClient, string telefon, string mail, string nume, string prenume)
        {
            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd;
                    string sql="";
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
                                    )
                                    SELECT SCOPE_IDENTITY()";

                        SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                        cmd2.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                        cmd2.Parameters.Add(new SqlParameter("@nume", SqlDbType.NVarChar)).Value = nume;
                        cmd2.Parameters.Add(new SqlParameter("@prenume", SqlDbType.NVarChar)).Value = prenume;
                        cmd2.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar)).Value = mail;
                        cmd2.Parameters.Add(new SqlParameter("@telefon", SqlDbType.NVarChar)).Value = telefon;

                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idClient = reader[0] == DBNull.Value ? 0 : Convert.ToInt32(reader[0]);
                            }
                        }
                        sql = @"INSERT INtO dbo.Programari(
                                        Data, Serviciu, IdClient
                                        )
                                        VALUES
                                        (
                                        @data,
                                        @serviciu,
                                        @idClient
                                        )";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.DateTime)).Value = Data;
                        cmd.Parameters.Add(new SqlParameter("@serviciu", SqlDbType.NVarChar)).Value = Serviciu;
                        cmd.Parameters.Add(new SqlParameter("@idClient", SqlDbType.Int)).Value = idClient;
                        cmd.ExecuteNonQuery();
                        Clienti.ClientAM(idClient, nume, prenume, mail, telefon);


                    }
                    else
                    {
                        sql = @"UPDATE dbo.Programari
                                        SET Data=@data, Serviciu=@serviciu, IdClient = @idClient
                                        WHERE id=@id";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.DateTime)).Value = Data;
                        cmd.Parameters.Add(new SqlParameter("@serviciu", SqlDbType.NVarChar)).Value = Serviciu;
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                        cmd.Parameters.Add(new SqlParameter("@idClient", SqlDbType.Int)).Value = idClient;
                        cmd.ExecuteNonQuery();
                        Clienti.ClientAM(idClient, nume, prenume, mail, telefon);

                    }
                }
                catch (Exception)
                {
                    return false;
                    
                }
            }
            return true;
        }

        public static Programare GetProgramare(int id)
        {
            Programare pr = null;
            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();
                    string sql = @"SELECT c.Nume as Nume, c.Prenume as Prenume, p.Data as Data, p.Serviciu as Serviciu, c.Telefon as Telefon, c.Mail as Mail, p.Id as Id, c.Id as IdClient
                            FROM dbo.Programari AS p INNER JOIN 
                            dbo.Clienti as c ON p.IdClient = c.Id                            
                            WHERE p.Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                pr=new Programare{
                                Prenume = reader["Prenume"].ToString(),
                                Nume = reader["Nume"].ToString(),
                                Serviciu = reader["Serviciu"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Mail = reader["Mail"].ToString(),
                                Data = Convert.ToDateTime(reader["Data"]),
                                Id = Convert.ToInt32(reader["Id"]),
                                IdClient = Convert.ToInt32(reader["IdClient"])
                            };

                        }
                    }
                }
                catch (Exception)
                {
                    // jurnalizare + afisare eroare        
                }
            }
            return pr ;
        }

        public static bool DeleteProgramare(int id)
        {
            using (SqlConnection cnn = new SqlConnection(DBConnection.CnnString()))
            {
                try
                {
                    cnn.Open();
                    string sql = @"UPDATE dbo.Programari
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
                    
                }
            }
        }
    }
    }
