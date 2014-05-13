﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public partial class DAL
    {

        class UcenikDAO : IDaoCrud<Ucenik>
        {
            protected MySqlCommand c;

            public long create(Ucenik entity)
            {
                try
                {
                    c = new MySqlCommand("insert into ucenik values ('" + entity.Ime + "," + entity.Prezime + ","
                        + entity.Datum_rodjenja + "," + entity.Username + ", " + entity.Password + ", " + entity.Godina_studija + "," + entity.Id_kuca 
                    + "," + entity.Prefekt +"')", con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            public Ucenik read(Ucenik entity)
            {
                c = new MySqlCommand("select * from ucenik where ucenik_id=" + entity.Id_ucenik+ "and ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and dat_rodj=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username + " and pass=" + entity.Password + "and gd_studija=" + entity.Godina_studija +
                    "and id_kuca =" + entity.Id_kuca + " and prefekt =" +entity.Prefekt + ";");
                MySqlDataReader mr = c.ExecuteReader();
                KucaDAO  kd = new KucaDAO();
                if (mr.Read())
                    return new Ucenik(mr.GetInt32("id_ucenik"),mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"),mr.GetInt32("gd_studija"), mr.GetInt32("kuca") ,mr.GetBoolean("prefekt"));
                else
                    return null;
            }
            public Ucenik update(Ucenik entity)
            {
                c = new MySqlCommand("update ucenik set ucenik_id=" + entity.Id_ucenik + ", ime=" + entity.Ime + " , prezime=" + entity.Prezime + " , dat_rodj=" + entity.Datum_rodjenja
                     + " , pass=" + entity.Password + ", gd_studija=" + entity.Godina_studija +
                    ", id_kuca =" + entity.Id_kuca + " , prefekt =" + entity.Prefekt + "where username=" + entity.Username + ";");
                c.ExecuteNonQuery();
                return read(entity);
            }

            public void delete(Ucenik entity)
            {
                c = new MySqlCommand("delete ucenik where ucenik_id=" + entity.Id_ucenik + "and ime=" + entity.Ime + " and prezime=" + entity.Prezime + " and dat_rodj=" + entity.Datum_rodjenja
                    + " and username=" + entity.Username  + "and gd_studija=" + entity.Godina_studija +
                    "and id_kuca =" + entity.Id_kuca + " and prefekt =" + entity.Prefekt + ";");
                c.ExecuteNonQuery();
            }

            public Ucenik getById(int id)
            {
                KucaDAO kd = new KucaDAO();
                c = new MySqlCommand("select * from ucenik where id_ucenik=" + Convert.ToString(id) + ";");
                MySqlDataReader mr = c.ExecuteReader();
                if (mr.Read())
                    return new Ucenik(mr.GetInt32("id_ucenik"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"), mr.GetInt32("gd_studija"), mr.GetInt32("kuca"), mr.GetBoolean("prefekt"));
                else
                    return null;

            }

            public List<Ucenik> getAll()
            {
                try
                {
                    KucaDAO kd = new KucaDAO();
                    c = new MySqlCommand("select * from ucenik", con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Ucenik> ucenici = new List<Ucenik>();
                    while (mr.Read())
                        ucenici.Add(new Ucenik(mr.GetInt32("id_ucenik"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"), mr.GetInt32("gd_studija"), mr.GetInt32("kuca"), mr.GetBoolean("prefekt")));
                    return ucenici;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Ucenik> getByExample(string ime, string prezime)
            {
                try
                {
                    KucaDAO kd = new KucaDAO();
                    c = new MySqlCommand("select * from ucenik where ime=" + ime + " and prezime=" + prezime, con);
                    MySqlDataReader mr = c.ExecuteReader();
                    List<Ucenik> ucenici = new List<Ucenik>();
                    while (mr.Read())
                        ucenici.Add(new Ucenik(mr.GetInt32("id_ucenik"), mr.GetString("ime"), mr.GetString("prezime"), mr.GetDateTime("dat_rodj"), mr.GetString("username"), mr.GetString("pass"), mr.GetInt32("gd_studija"), mr.GetInt32("kuca"), mr.GetBoolean("prefekt")));
                    return ucenici;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            

        }
    }
}
