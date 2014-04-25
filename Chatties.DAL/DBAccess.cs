using System;
using System.Xml;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Chatties.DAL
{
    public class DBAccess<T> : SqlDatabase, IDisposable
    {
        private bool _disposed;
        private CadenaConexion stringConnection;

        /// <summary>
        /// Constructor que especifíca una cadena de conexión
        /// </summary>
        /// <param name="stringConnection"></param>
        public DBAccess(CadenaConexion stringConnection)
            :base(getStringConnection(stringConnection))
        {
            this.stringConnection = stringConnection;
        }

        /// <summary>
        /// Constructor que especifíca la cadena de conexión Enlasys por default
        /// </summary>
        public DBAccess()
            : this(CadenaConexion.Enlasys) { }

        /// <summary>
        /// Almacena la cadena de conexión actual
        /// </summary>
        public CadenaConexion StringConnection
        {
            get { return StringConnection; }
            set { this.StringConnection = value; }
        }

        /// <summary>
        /// Devuelve la cadena de conexión correspondiente al archivo de configuración
        /// </summary>
        /// <param name="stringConnection">El id de la cadena de conexión</param>
        /// <returns>La información de la cadena de conexión deseada</returns>
        private static string getStringConnection(CadenaConexion stringConnection)
        {
            return ConfigurationManager.ConnectionStrings[stringConnection.ToString()].ConnectionString;
        }

        /// <summary>
        /// Obtiene la instancia de una clase desde la base de datos a través de la ejecucón de una consulta
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns></returns>
        public T GetObject(string query)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(this.ExecuteXmlReader(this.GetSqlStringCommand(query)));
        }

        /// <summary>
        /// Obtiene la instancia de una clase desde la base de datos a través de la ejecución de un stored procedure
        /// </summary>
        /// <param name="spName">Nombre del Stored Procedure</param>
        /// <param name="spParams">Parámetros del Stored Procedure</param>
        /// <returns></returns>
        public T GetObject(string spName, params object[] spParams)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(this.ExecuteXmlReader(this.GetStoredProcCommand(spName, spParams)));
        }

        /// <summary>
        /// Obtiene un dataset desde la base de datos a través de la ejecución de un stored procedure
        /// </summary>
        /// <param name="spName">Nombre del Stored Procedure</param>
        /// <param name="spParams">Parámetros del Stored Procedure</param>
        /// <returns></returns>
        public DataSet GetDataSet(string spName, params object[] spParams)
        {
            return this.ExecuteDataSet(spName, spParams);
        }

        /// <summary>
        /// Utiliza el Garbage Collector para eliminar instancias propias
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~DBAccess()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
