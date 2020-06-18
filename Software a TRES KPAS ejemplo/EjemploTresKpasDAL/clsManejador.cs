using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace EjemploTresKpasDAL

{
    public class clsManejador
    {
        SqlConnection connection = new SqlConnection("Server=.; DataBase = dbEjemploTresKpas; Integrated Security= true");

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        //Metodos para Insertar, Actualizar o Eliminar
        public void EjecutarSP(String NombreSp, List<clsParametros> Ltparametros)
        {
            SqlCommand cmd;
            try
            {
                OpenConnection();
                cmd = new SqlCommand(NombreSp, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if(Ltparametros != null)
                {
                    for (int i = 0; i < Ltparametros.Count; i++)
                    {
                        if(Ltparametros[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(Ltparametros[i].Nombre, Ltparametros[i].Valor);
                        }

                        if(Ltparametros[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(Ltparametros[i].Nombre, Ltparametros[i].TipoDato, Ltparametros[i].Tamano).Direction = ParameterDirection.Output;

                        }

                    }
                    cmd.ExecuteNonQuery();

                    //Se recupera el parametro de salida.
                    for(int i = 0; i < Ltparametros.Count; i ++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            Ltparametros[i].Valor = cmd.Parameters[i].Value.ToString();
                    }

                }

            }
            catch (System.Exception ex)
            {

                throw ex;

            }
            CloseConnection();
        }

        //Metodo para consultas.
        public DataTable Listado(String Nombresp, List<clsParametros> Ltparametros)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;

            try
            {
                da = new SqlDataAdapter(Nombresp, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if(Ltparametros != null)
                {
                    for(int i =0; i < Ltparametros.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(Ltparametros[i].Nombre, Ltparametros[i].Valor);

                    }
                }
                da.Fill(dt);

            }
            catch (System.Exception)
            {

                throw;
            }
            return dt;
        }

    }
}
