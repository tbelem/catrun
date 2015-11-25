using System.Collections;
using System.Data.SqlClient;
using System;

public class DatabaseControl {

    public string Login(string login, string password)
    {
        SqlConnection myConnection = new SqlConnection("user id=votacao;" +
                                       "password=votacao;server=TIAGO-NOTE\\DESENV;" +
                                       "Trusted_Connection=false;" +
                                       "database=votacao; " +
                                       "connection timeout=3000");

        try
        {
            myConnection.Open();

            //SqlCommand myCommand = new SqlCommand("INSERT INTO Departamentos VALUES ('7','TESTE 2',NULL,NULL);", myConnection);

            //myCommand.ExecuteNonQuery();

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
