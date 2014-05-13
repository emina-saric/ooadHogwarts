using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class DAL
    {
        class PredmetDAO : IDaoCrud<Predmet>
        {
            protected MySqlCommand c;
            public long create(Predmet entity)
            {
                try
                {
                    c = new MySqlCommand("insert into predmet values ('" + entity.Naziv + "','" + entity.Broj_casova + ","
                        + entity.Id_profesor +"')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public Predmet read(Predmet entity)
            {
                c = new MySqlCommand("select * from predmet where id_predmet=" + entity.Id_predmet + "and ime=" + entity.Naziv + " and br_cas=" + entity.Broj_casova + " and id_prof=" + entity.Id_profesor + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Predmet(mr.GetInt32("id_predmet"), mr.GetString("ime"), mr.GetInt32("br_cas"), mr.GetInt32("id_prof"));
                else
                    return null;
            }

            public Predmet update(Predmet entity)
            {
                c = new MySqlCommand("update predmet set id_predmet=" + entity.Id_predmet + "and ime=" + entity.Naziv + " and br_cas=" + entity.Broj_casova + " and id_prof=" + entity.Id_profesor + ";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(Predmet entity)
            {
                c = new MySqlCommand("delete predmet where id_predmet=" + entity.Id_predmet + "and ime=" + entity.Naziv + " and br_cas=" + entity.Broj_casova + " and id_prof=" + entity.Id_profesor + ";");
                c.ExecuteNonQuery();
            }

            public Predmet getById(int id)
            {
                c = new MySqlCommand("select * from predmet where id=" + Convert.ToString(id) + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Predmet(mr.GetInt32("id_predmet"),mr.GetString("ime"), mr.GetInt32("br_cas"), mr.GetInt32("id_prof"));
                else
                    return null;
            }

            public List<Predmet> getAll()
            {
                try
                {
                    c = new MySqlCommand("select * from predmet", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Predmet> _predmeti = new List<Predmet>();
                    while (mr.Read())
                        _predmeti.Add(new Predmet(mr.GetInt32("id_predmet"), mr.GetString("ime"), mr.GetInt32("br_cas"), mr.GetInt32("id_prof")));
                    return _predmeti;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Predmet> getByExample(string name, string value)
            {
                try
                {
                    c = new MySqlCommand("select * from predmet where ime=" + name  , con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Predmet> _predmeti = new List<Predmet>();
                    while (mr.Read())
                        _predmeti.Add(new Predmet(mr.GetInt32("id_predmet"), mr.GetString("ime"), mr.GetInt32("br_cas"), mr.GetInt32("id_prof")));
                    return _predmeti;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
