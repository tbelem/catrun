using System.Collections;
using System.Data.SqlClient;
using System;
using UnityEngine;

public class DatabaseControl {

    SqlConnection myConnection;

    public DatabaseControl()
    {
        //CRIA A VARIAVEL DE CONEXAO
        myConnection = new SqlConnection("user id=catrun;" +
                                            "password=catrun;server=TIAGO-NOTE\\DESENV;" +
                                            "Trusted_Connection=false;" +
                                            "database=CATRUN; " +
                                            "connection timeout=3000");

    }

    private int qtdObstaculo()
    {
        int retorno;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("SELECT COUNT(1) as RES FROM OBSTACLE;", myConnection);

            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                retorno = (int)myReader["RES"];
                myConnection.Close();
            }
            else
            {
                retorno = 0;
                myConnection.Close();
            }

            return retorno;

        }
        catch (Exception e)
        {
            Debug.Log("ERRO qtdObstaculo: " + e.ToString());
            return 0;
        }
    }

    public void getObstaculo(ref string pfb, ref float posy, ref float posz)
    {
        System.Random rdn = new System.Random();
        int cod = rdn.Next(1, qtdObstaculo()+1); // de 1 a 2
        
        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("SELECT obstacle_prefab,obstacle_ctg FROM OBSTACLE where obstacle_cod =" + cod+" ;", myConnection);

            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                pfb = myReader["obstacle_prefab"].ToString();
                int ctg = (int)myReader["obstacle_ctg"];

                int lane = 0; // 1-BOT  2-MID  3-TOP

                if (ctg == 1) //qualquer lane
                {
                    lane = rdn.Next(1,4);
                }
                if (ctg == 2) //bot e mid
                {
                    lane = rdn.Next(1, 3);
                }

                string campo = "";
                if (lane == 1)
                {
                    campo = "obstacle_ybot";
                    posz = -1;
                }
                if (lane == 2)
                {
                    campo = "obstacle_ymid";
                    posz = 0;
                }
                if (lane == 3)
                {
                    campo = "obstacle_ytop";
                    posz = 1;
                }


                myReader.Close();

                myCommand = new SqlCommand("SELECT "+campo+" FROM OBSTACLE where obstacle_cod =" + cod + " ;", myConnection);
                SqlDataReader myReader2 = myCommand.ExecuteReader();
                if (myReader2.Read())
                {
                    posy = float.Parse(myReader2[campo].ToString());
                }

            }

            myConnection.Close();

        }
        catch (Exception e){ Debug.Log("ERRO getObstaculo: " + e.ToString()); }
    }

    public string Login(string login, string password)
    {


        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("select USU_NOM from USUARIO WHERE USU_RA='"+login+ "' AND USU_SNH='"+password+ "';", myConnection);

            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                return myReader["USU_NOM"].ToString();
            }
            else
            {
                return "FALSE";
            }
        }
        catch (Exception e)
        {
            return e.ToString();
        }
    }

}
