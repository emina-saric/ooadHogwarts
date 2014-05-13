using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public partial class DAL
    {
        public class ProfesorDAO : IDaoCrud<Profesor>
        {
            protected MySqlCommand c;

            public long create(Profesor entity)
            {
                try
                {
                    c = new MySqlCommand("insert into profesor values ('" + entity.Ime + "," + entity.Prezime + ","
                        + entity.Datum_rodjenja + "," + entity.Username + ", " + entity.Password + "," + entity.Id_predmet + "," + entity.Predstavnik_kuce +"')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public Profesor read(Profesor entity)
            {
                c = new MySqlCommand("select * from profesor where id_profesor ="+ entity.Id_profesor + "and ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and dat_rodj=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username + " and pass=" + entity.Password + "and id_predmet =" + entity.Id_predmet+ "and pred_k =" + entity.Predstavnik_kuce +";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Profesor(mr.GetInt32("id_profesor"),mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"),mr.GetInt32("id_predmet"),mr.GetBoolean("pred_k"));
                else
                    return null;
            }

            
            public Profesor update(Profesor entity)
            {
                c = new MySqlCommand("update profesor set id_profesor=" + entity.Id_profesor + ", ime=" + entity.Ime + ", prezime=" + entity.Prezime + ", datum_rodjenja=" + entity.Datum_rodjenja
                    + ", password=" + entity.Password + ", id_predmet=" + entity.Id_predmet + ", pred_k=" + entity.Predstavnik_kuce + "where username=" + entity.Username + ";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(Profesor entity)
            {
                c = new MySqlCommand("delete profesor where id_profesor=" + entity.Id_profesor + ", ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and datum_rodjenja=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username + " and password=" + entity.Password + "and id_predmet=" + entity.Id_predmet + "and pred_k=" + entity.Predstavnik_kuce +";");
                c.ExecuteNonQuery();
            }

            public Profesor getById(int id)
            {
                c = new MySqlCommand("select * from profesor where id_profesor=" + Convert.ToString(id) + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Profesor(mr.GetInt32("id_profesor"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"), mr.GetInt32("id_predmet"), mr.GetBoolean("pred_k"));
                else
                    return null;

            }

            public List<Profesor> getAll()
            {
                try
                {
                    c = new MySqlCommand("select * from profesor", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Profesor> _profesori = new List<Profesor>();
                    while (mr.Read())
                        _profesori.Add(new Profesor(mr.GetInt32("id_profesor"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"), mr.GetInt32("id_predmet"), mr.GetBoolean("pred_k")));
                    return _profesori;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Profesor> getByExample(string ime, string prezime)
            {
                try
                {
                    c = new MySqlCommand("select * from osobe where ime=" + ime + " and prezime=" + prezime, con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Profesor> _profesori = new List<Profesor>();
                    while (mr.Read())
                        _profesori.Add(new Profesor(mr.GetInt32("id_profesor"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"), mr.GetInt32("id_predmet"), mr.GetBoolean("pred_k")));
                    return _profesori;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
