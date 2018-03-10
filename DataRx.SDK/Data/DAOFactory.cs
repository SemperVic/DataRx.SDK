using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Contracts;
using DataRx.SDK.Common;

namespace DataRx.SDK.Data
{
    /// <summary>
    /// Abstract Data Access Object (DAO) Factory
    /// </summary>
    public abstract class AbstractDataFactory
    {
        /// <summary>
        /// Abstract GetDAOFactory Method.
        /// </summary>
        /// <param name="daoFactoryProvider">DAO Factory Provider</param>
        /// <returns>IDAOFactory</returns>
        public abstract IDAOFactory GetDAOFactory(String daoFactoryProvider);
    }

    /// <summary>
    /// DataRx.SDK Concrete Data Access Object Factory
    /// </summary>
    public sealed class DAOFactory : AbstractDataFactory
    {
        /// <summary>
        /// Early Class Instantiation. No double lock required.
        /// </summary>
        private static DAOFactory instance = new DAOFactory();
        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static DAOFactory Instance
        {
            get { return instance; }        
        }

        public override IDAOFactory GetDAOFactory(String daoFactoryProvider)
        {
            switch (daoFactoryProvider)
            {
                case DAOFactoryProvider.SQLITE3:
                    return SQLite3Factory.Instance;
                case DAOFactoryProvider.MSSQL2012:
                    return MSSQLFactory.Instance;
                case DAOFactoryProvider.MYSQL:
                    return MySQLFactory.Instance;
                case DAOFactoryProvider.COUCH:
                    return CouchDBFactory.Instance;
                case DAOFactoryProvider.MONGO:
                    return MongoDBFactory.Instance;
                default:
                    throw new NotImplementedException("The '" + daoFactoryProvider + "' is not implemented in A2Z.SDK");
            }
        }
    }

    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public sealed class SQLite3Factory : IDAOFactory
    {
        private static SQLite3Factory instance = new SQLite3Factory();
        /// <summary>
        /// TODO: Code Commentary
        /// </summary>
        public static SQLite3Factory Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// TODO: Code Commentary
        /// </summary>
        /// <returns></returns>
        public ICompositeModelProvider GetCompositeModelProvider()
        {
            return SQLITE3.CompositeObjectDAOProvider.Instance;
        }
    }

    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public sealed class MSSQLFactory : IDAOFactory
    {
        private static MSSQLFactory instance = new MSSQLFactory();

        public static MSSQLFactory Instance
        {
            get { return instance; }
        }

        public ICompositeModelProvider GetCompositeModelProvider()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public sealed class MySQLFactory : IDAOFactory
    {
        private static MySQLFactory instance = new MySQLFactory();

        public static MySQLFactory Instance
        {
            get { return instance; }
        }

        public ICompositeModelProvider GetCompositeModelProvider()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public sealed class CouchDBFactory : IDAOFactory
    {
        private static CouchDBFactory instance = new CouchDBFactory();

        public static CouchDBFactory Instance
        {
            get { return instance; }
        }

        public ICompositeModelProvider GetCompositeModelProvider()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public sealed class MongoDBFactory : IDAOFactory
    {
        private static MongoDBFactory instance = new MongoDBFactory();

        public static MongoDBFactory Instance
        {
            get { return instance; }
        }

        public ICompositeModelProvider GetCompositeModelProvider()
        {
            throw new NotImplementedException();
        }
    }
}
