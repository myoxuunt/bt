namespace Utilities.Database
{
    
    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Threading;

    #region Client Factory Classes

    /// <summary> Abstract factory for obtaining provider-appropriate ADO.NET data objects. </summary>
    public interface IClientFactory
    {
        IDbConnection   GetConnection   (string connectString);
        IDbDataAdapter  GetDataAdapter  (string query, IDbConnection connection);

        // 2007.01.17 Added 
        //
        IDbCommand      GetCommand      (string query, IDbConnection connection);
    }

    // Concrete Client Factory implementations.  Each implementation  creates ADO.NET objects
    // appropriate to a particular provider, such as SQL Server.  To enable native  support for another
    // provider's ADO.NET classes, define another client factory class below, and instatiate it in
    // ConnectForm.  DbClient itself can also be subclassed if any special behaviour is required.

    /// <summary> SQL Server Client </summary>
    public class SqlFactory: IClientFactory
    {
        public IDbConnection GetConnection (string connectString)
        {
            return new SqlConnection (connectString);
        }

        public IDbDataAdapter GetDataAdapter (string query, IDbConnection connection)
        {
            return new SqlDataAdapter (query, (SqlConnection) connection);
        }

        // 2007.01.17 Added
        //
        public IDbCommand GetCommand( string query, IDbConnection connection )
        {
            return new SqlCommand( query, (SqlConnection) connection );
        }
    }

    /// <summary> OLE-DB Client </summary>
    public class OleDbFactory: IClientFactory
    {
        public IDbConnection GetConnection (string connectString)
        {
            return new OleDbConnection (connectString);
        }
        public IDbDataAdapter GetDataAdapter (string query, IDbConnection connection)
        {
            return new OleDbDataAdapter (query, (OleDbConnection) connection);
        }

        // 2007.01.17 Added
        //
        public IDbCommand GetCommand( string query, IDbConnection connection )
        {
            return new OleDbCommand( query, (OleDbConnection) connection );
        }
            
    }

    #endregion // IClientFactory
}
