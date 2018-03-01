/**
 *  Author(s):  SemperVic@GitHub
 *  Website:    //datarx.org
 *  Date:       02/28/2018
 *  Version:    1.0.1 (Alpha)
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
        /** Class Properties **/
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
        /** Class Properties **/
        private String entityLexicon = String.Empty;
        private String shortDesc = String.Empty;
        /// <summary>
        /// Lexicon used when documenting object taxonomy. Example: 'Metadata Prototype Object'
        /// </summary>
        [DataMember]
        public String EntityLexicon
        {
            get { return this.entityLexicon; } 
            set { this.entityLexicon = value; }
        }
        /// <summary>
        /// Short description describing the entity in 512 characters or less
        /// </summary>
        [DataMember]
        public String ShortDesc
        {
            get { return this.shortDesc; }
            set { this.shortDesc = value; }
        }
        /// <summary>
        /// Entity Attributes Array
        /// </summary>
        public List<Attribute> Attributes = new List<Attribute>();
        /// <summary>
        /// Identifies the Entity/Attribute dependency hierarchy
        /// </summary>
        public List<ObjectDependency> Dependencies = new List<ObjectDependency>();
    }
    /// <summary>
    /// The A2Z Attribute defines information about the entity that needs to be stored.
    /// </summary>
    [DataContract]
    public class Attribute : InDefinition
    {
        /** Class Properties **/
        private String attributeLexicon = String.Empty;
        private String shortDesc = String.Empty;
        /// <summary>
        /// Attribute lexicon used when documenting object taxonomy. 
        /// Example: 'Tax Key'
        /// </summary>
        [DataMember]
        public String AttributeLexicon
        {
            get { return this.attributeLexicon; }
            set { this.attributeLexicon = value; }
        }
        /// <summary>
        /// Short description describing the entity in 512 characters or less.
        /// Example: 'Primary key constraint.'
        /// </summary>
        [DataMember]
        public String ShortDesc
        {
            get { return this.shortDesc; }
            set { this.shortDesc = value; }

        }
        /// <summary>
        /// An Attribute's properties identify the physical characterstics and 
        /// constraints for of the attribute specified.
        /// </summary>
        public AttributeProperty Property = new AttributeProperty();
    }
    /// <summary>
    /// The ObjectDependency object identifies foreign key inheritance and entity hierarchy
    /// </summary>
    [DataContract]
    public class ObjectDependency
    {
        /** Class Properties **/
        private String constraintName = String.Empty;
        private String pkEntityIDefName = String.Empty;
        private String pkAttributeIDefName = String.Empty;
        private String fkEntityIDefName = String.Empty;
        private String fkAttributeIDefName = String.Empty;

        /// <summary>
        /// Dependency constraint name uses an IDefinitionFormatted string to identify 
        /// named constraints within the super entity.
        /// </summary>
        [DataMember]
        public String ConstraintName
        {
            get { return this.constraintName; }
            set { this.constraintName = value; }
        }
        /// <summary>
        /// Parent entity
        /// </summary>
        [DataMember]
        public String PKEntityName
        {
            get { return this.pkEntityIDefName; }
            set { this.pkEntityIDefName = value; }
        }
        /// <summary>
        /// Primary key constraint
        /// </summary>
        [DataMember]
        public String PKAttributeName
        {
            get { return this.pkAttributeIDefName; }
            set { this.pkAttributeIDefName = value; }
        }
        /// <summary>
        /// Child entity
        /// </summary>
        [DataMember]
        public String FKEntityName
        {
            get { return this.fkEntityIDefName; }
            set { this.fkEntityIDefName = value; }
        }
        /// <summary>
        /// Inherited foreign key
        /// </summary>
        [DataMember]
        public String FKAttributeName
        {
            get { return this.fkAttributeIDefName; }
            set { this.fkAttributeIDefName = value; }
        }
    }
    /// <summary>
    /// An Attribute's properties identify the physical characterstics and 
    /// constraints for of the attribute specified.
    /// </summary>
    [DataContract]
    public class AttributeProperty
    {
        /** Class Properties **/
        private String constraintName = String.Empty;
        private String size = String.Empty;
        private String dbDataType = String.Empty;
        private String rtDataType = String.Empty;
        private Boolean isNullable = true;
        private Boolean isPrimaryKey = false;
        private Boolean isForeignKey = false;
        private Boolean isIndexed = false;

        /// <summary>
        /// Dependency constraint name uses an IDefinitionFormatted string to identify 
        /// named constraints within the super entity.
        /// </summary>
        [DataMember]
        public String ConstraintName
        {
            get { return this.constraintName; }
            set { this.constraintName = value; }
        }
        /// <summary>
        /// Size of attribute data type
        /// </summary>
        [DataMember]
        public String Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        /// <summary>
        /// Database Data Type
        /// </summary>
        public String DBDataType
        {
            get { return this.dbDataType; }
            set { this.dbDataType = value; }
        }
        /// <summary>
        /// Runtime Data Type
        /// </summary>
        [DataMember]
        public String RTDataType
        {
            get { return this.rtDataType; }
            set { this.rtDataType = value; }
        }
        /// <summary>
        /// Allow null values when saving to disk.
        /// </summary>
        [DataMember]
        public Boolean IsNullable
        {
            get { return this.isNullable; }
            set { this.isNullable = value; }
        }
        /// <summary>
        /// Identifies if attribute is a primary key constraint
        /// </summary>
        [DataMember]
        public Boolean IsPrimaryKey
        {
            get { return this.isPrimaryKey; }
            set { this.isPrimaryKey = value; }
        }
        /// <summary>
        /// Identifies if attribute inherits a primary key from another entity
        /// </summary>
        [DataMember]
        public Boolean IsForeignKey
        {
            get { return this.isForeignKey; }
            set { this.isForeignKey = value; }
        }
        /// <summary>
        /// Identifies if attribute is indexed
        /// </summary>
        [DataMember]
        public Boolean IsIndexed
        {
            get { return this.isIndexed; }
            set { this.isIndexed = value; }
        }        
    }

    /// <summary>
    /// Integration Definition Prototype Class
    /// This is not an interface/contract class.
    /// </summary>
    [DataContract]
    public partial class InDefinition
    {
        /** Class Properties **/
        private Guid serialVersionUID = new Guid();
        private String idefName = String.Empty;
        private String publicName = String.Empty;
        private String privateName = String.Empty;

        /// <summary>
        /// The serial version UID associates an object with a class object container capable of 
        /// serialization/deserialization. If the class object cannot be found an 
        /// InvalidClassException will be thrown.
        /// </summary>
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public String PrivateName 
        { 
            get { return this.privateName; }
            set {this.privateName = value; }
        }
    }
}
