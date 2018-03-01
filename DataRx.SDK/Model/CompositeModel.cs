/**
 *  Author(s):  SemperVic@GitHub
 *  Website:    //datarx.org
 *  Date:       02/28/2018
 *  Version:    1.0.0 (Alpha)
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Common;

namespace DataRx.SDK.Model
{
    /// <summary>
    /// AZ Composite Entity, Attribute Object Model.
    /// Composite Entity pattern is used in persistence mechanisms. A Composite entity is an entity object 
    /// model which represents a graph of objects. When a composite entity is updated, internally dependent
    /// objects get updated automatically as being managed by the composite object class. 
    /// </summary>
    [DataContract]
    public class CompositeModel
    {
        private String className = String.Empty;
        private String tns = String.Empty;
        private String daoFactory = String.Empty;

        /// <summary>
        /// Runtime class name with full class path
        /// </summary>
        public String ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }

        /// <summary>
        /// A2Z Taxonomy Namespace. Example: MDR
        /// Ref: A2Z DTO Model Namespaces
        /// </summary>
        public String TNS {
            get { return this.tns; }
            set { this.tns = value; } 
        }
        /// <summary>
        /// Data Access Object provider
        /// </summary>
        public String DAOFactory
        {
            get { return this.daoFactory; }
            set { this.daoFactory = value; }
        }
        /// <summary>
        /// Composite Model Entities
        /// </summary>
        public List<Entity> Entities = new List<Entity>();

        
    }
    /// <summary>
    /// The A2Z Entity Object is an independent container class used 
    /// to describe object taxonomy and hierarchy similar to a database 
    /// table, data transfer object or perhaps a serialized json document 
    /// stored in a no-sql document database.
    /// </summary>
    [DataContract]
    public class Entity : InDefinition
    {
        /// <summary>
        /// Lexicon used when documenting object taxonomy. Example: 'Metadata Prototype Object'
        /// </summary>
        public String EntityLexicon { get; set; }
        /// <summary>
        /// Short description describing the entity in 512 characters or less
        /// </summary>
        public String ShortDesc { get; set; }
        /// <summary>
        /// Entity Attributes Array
        /// </summary>
        public List<Attribute> Attributes = new List<Attribute>();
    }
    /// <summary>
    /// The A2Z Attribute defines information about the entity that needs to be stored.
    /// </summary>
    [DataContract]
    public class Attribute : InDefinition
    {
        /// <summary>
        /// Attribute lexicon used when documenting object taxonomy. 
        /// Example: 'Tax Key'
        /// </summary>
        public String AttributeLexicon { get; set; }
        /// <summary>
        /// Short description describing the entity in 512 characters or less.
        /// Example: 'Primary key constraint.'
        /// </summary>
        public String ShortDesc { get; set; }
        /// <summary>
        /// An Attribute's properties identify the physical characterstics and 
        /// constraints for of the attribute specified.
        /// </summary>
        public AttributeProperty Property = new AttributeProperty();
        /// <summary>
        /// Identifies the Entity/Attribute dependency hierarchy
        /// </summary>
        public List<ObjectDependency> Dependencies = new List<ObjectDependency>();
    }
    /// <summary>
    /// The ObjectDependency object identifies foreign key inheritance and entity hierarchy
    /// </summary>
    [DataContract]
    public class ObjectDependency
    {
        public String ConstraintName = String.Empty;
        public String PKTableName = String.Empty;
        public String PKColumnName = String.Empty;
        public String FKTableName = String.Empty;
        public String FKColumnName = String.Empty;
    }
    /// <summary>
    /// An Attribute's properties identify the physical characterstics and 
    /// constraints for of the attribute specified.
    /// </summary>
    [DataContract]
    public class AttributeProperty
    {
        public String Size = String.Empty;
        public String DBDataType = String.Empty;
        public String RTDataType = String.Empty;
        public Boolean IsNullable = true;
        public Boolean IsPrimaryKey = false;
        public Boolean IsForeignKey = false;
        public Boolean IsIndexed = false;
        public String ConstraintName = String.Empty;
    }

    /// <summary>
    /// Integration Definition Prototype Class
    /// This is not an interface/contract class.
    /// </summary>
    [DataContract]
    public partial class InDefinition
    {
        private Guid serialVersionUID = new Guid();
        private String idefName = String.Empty;
        private String publicName = String.Empty;
        private String privateName = String.Empty;
        
        /// <summary>
        /// The serial version UID associates an object with a class object container capable of 
        /// serialization/deserialization. If the class object cannot be found an 
        /// InvalidClassException will be thrown.
        /// </summary>
        public Guid SerialVersionUID
        {
            get { return this.serialVersionUID; }
            set { this.serialVersionUID = value; }
        }
        /// <summary>
        /// Integration Definition (ref: IDEF) is used to logically 
        /// identify the object's namespace taxonomy. No spaces are allowed 
        /// and string character data is converted to upper case in accordance 
        /// with A2Z IDEF1X modeling conventions. Example: TAX_KEY
        /// </summary>
        public String IDEFName 
        {
            get { return this.idefName; }
            set { 
                this.idefName = StringHelper.IDefinitionFormat(value);
                this.publicName = StringHelper.ToDromedaryCase(this.idefName);
                this.privateName = StringHelper.ToMedialCase(this.idefName);
            }         
        }
        /// <summary>
        /// Logical public object name. This is usually in sentence format 
        /// otherwise refered to as Pascal Casing. Pascal capitalizes the 
        /// first letter of each word w/o spaces between words. 
        /// Example: 'TaxKey'
        /// </summary>
        public String PublicName 
        {
            get { return this.publicName; }
            set { this.publicName = value; } 
        }
        /// <summary>
        /// Logcal private object name. This is usually in a camel case format 
        /// w/o any spaces between words. 
        /// Example: 'taxKey'
        /// </summary>
        public String PrivateName { get; set; }
    }
}
