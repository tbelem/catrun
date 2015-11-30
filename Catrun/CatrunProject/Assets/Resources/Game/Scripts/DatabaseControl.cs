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
                if (ctg == 3) //bot e mid
                {
                    lane = 3;
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
        catch (Exception e)
        {
            Debug.Log("ERRO getObstaculo: " + e.ToString());
        }
    }

    public int Login(string login, string password)
    {


        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("select player_cod from PLAYER WHERE player_lgn='"+login+ "' AND player_psw='"+password+ "';", myConnection);

            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                myConnection.Close();
                return (int)myReader["player_cod"];
            }
            else
            {
                myConnection.Close();
                return 0;
            }

        }
        catch (Exception e)
        {
            Debug.Log("Erro Login: "+e.ToString());
            myConnection.Close();
            return 0;
        }
    }

    public int verificaHiscore(int player, int score)
    {
        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("select 1 from player_currency where pc_player_cod = "+player+" AND pc_hgh_sco < "+score+";", myConnection);

            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                myConnection.Close();
                return 1;
            }
            else
            {
                myConnection.Close();
                return 0;
            }

        }
        catch (Exception e)
        {
            Debug.Log("Erro verificaHiscore: " + e.ToString());
            myConnection.Close();
            return 0;
        }
    }

    public void gravaPartida(int player, int highscore, int money, int score, int obstacles, int powerups, int missions)
    {
        try
        {
            myConnection.Open();

            string comando = "UPDATE PLAYER_CURRENCY SET ";
            if (highscore == 1)
            {
                comando += "PC_HGH_SCO = " +score + ",";
            }            
            comando += "PC_CUR_MNY = PC_CUR_MNY + " + money;
            comando += ", PC_TOT_MNY = PC_TOT_MNY + " + money;
            comando += ", PC_TOT_SCO = PC_TOT_SCO + " + score;
            comando += ", PC_TOT_OBS = PC_TOT_OBS + " + obstacles;
            comando += ", PC_TOT_PUP = PC_TOT_PUP + " + powerups;
            comando += ", PC_TOT_MTC = PC_TOT_MTC + " + 1;
            comando += ", PC_TOT_MSS = PC_TOT_MSS + " + missions;
            comando += " WHERE pc_player_cod = "+ player + " ;";

            SqlCommand myCommand = new SqlCommand(comando, myConnection);

            myCommand.ExecuteNonQuery();

            comando = "INSERT INTO MATCH VALUES ("+player+",SYSDATETIME(),"+score+","+money+","+obstacles+","+powerups+");";

            myCommand = new SqlCommand(comando, myConnection);

            myCommand.ExecuteNonQuery();

            myConnection.Close();
        }
        catch (Exception e)
        {
            Debug.Log("ERRO gravaPartida: " + e.ToString());
        }
    }

}
