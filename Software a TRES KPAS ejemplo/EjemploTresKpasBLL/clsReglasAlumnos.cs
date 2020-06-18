using System;
using System.Collections.Generic;
using System.Data;
using EjemploTresKpasBO;
using EjemploTresKpasDAL;



namespace EjemploTresKpas
{
    public class clsReglasAlumnos
    {

        clsAlumnos alumnos = new clsAlumnos();
        clsManejador Manager = new clsManejador();

        public string IngresarAlumno(List<clsAlumnos> alumnos)
        {
            var mensaje = string.Empty;
            //var alumno = new clsAlumnos();
            List<clsParametros> Ltparametros = new List<clsParametros>();
            
            try
            {
                foreach (var alumno in alumnos)
                {
                    //Se pasan los parametros de entrada.
                    Ltparametros.Add(new clsParametros("@documento", alumno._Documento));
                    Ltparametros.Add(new clsParametros("@Nombre", alumno._Nombre));
                    Ltparametros.Add(new clsParametros("@Apellidos", alumno._Apellidos));
                    Ltparametros.Add(new clsParametros("@Sexo", alumno._Sexo));
                    Ltparametros.Add(new clsParametros("@Direccion", alumno._Direccion));
                    Ltparametros.Add(new clsParametros("@FechaNacimiento", alumno._FechaNacimiento));
                }
               
                //Se pasan los parametros de salida.
                Ltparametros.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 200));

                Manager.EjecutarSP("AlumnosInsertar", Ltparametros);

                mensaje = Ltparametros[6].Valor.ToString();

            }
            catch (Exception)
            {

                throw;
            }


            return mensaje;
        }

        public DataTable AlumnosListar()
        {
            return Manager.Listado("AlumnosConsultar", null);
        }

    }
}
