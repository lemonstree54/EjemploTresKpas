using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EjemploTresKpasDAL
{
    public class clsParametros
    {
        //Parametros
        public String  Nombre { get; set; }
        public Object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public Int32 Tamano { get; set; }
        public ParameterDirection Direccion { get; set; }


        //Constructor parametros entrada
        public clsParametros(String _nombre, Object _valor)
        {
            Nombre = _nombre;
            Valor = _valor;
            Direccion = ParameterDirection.Input;
        }

        //Constructor parametros salida
        public clsParametros(String _nombre, SqlDbType _tipoDato, Int32 _tamano)
        {
            Nombre = _nombre;
            TipoDato = _tipoDato;
            Tamano = _tamano;
            Direccion = ParameterDirection.Output;
        }

    }
}
