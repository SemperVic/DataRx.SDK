﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataRx.SDK.Common
{
    /// <summary>
    /// Represents a Database Connection Object
    /// </summary>
    [DataContract]
    public class DataSource
    {
        /// <summary>
        /// Data Source Name
        /// </summary>
        [DataMember]
        public String DSN { get; set; }
        /// <summary>
        /// Database Host
        /// </summary>
        [DataMember]
        public String DBHost { get; set; }
        /// <summary>
        /// Database / Catalog
        /// </summary>
        [DataMember]
        public String DBCatalog { get; set; }
        /// <summary>
        /// User Name w/DB Admin rights
        /// </summary>
        [DataMember]
        public String DBUser { get; set; }
        /// <summary>
        /// Password - this value will be encrypted
        /// </summary>
        [DataMember]
        public String DBPassword { get; set; }
        /// <summary>
        /// Database Factory implementation. ref: DataRx.SDK.Common.DAOFactoryProvider
        /// </summary>
        [DataMember]
        public String DBFactory { get; set; }
        /// <summary>
<<<<<<< HEAD
        /// Does a database trust exist
        /// </summary>
        [DataMember]
        public Boolean DBTrust { get; set; }
        /// <summary>
        /// Database Connection String
        /// </summary>
        [DataMember]
        public String CNString { get; set; }

=======
        /// Connection String
        /// </summary>
        [DataMember]
        public String CNString { get; set; }
>>>>>>> adc3091fc4677be0f24b5018d9af9a23bd49cd56
    }
}
