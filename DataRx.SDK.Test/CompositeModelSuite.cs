using DataRx.SDK.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataRx.SDK.Test
{
    /// <summary>
    /// Composite Object Model Test Class Suite
    /// </summary>
    [TestClass]
    public class CompositeModelSuite
    {
        private CompositeModel cmo = new CompositeModel();

        /// <summary>
        /// Instantiates a new CompositeModel object and evaluates it's machanics
        /// </summary>
        [TestMethod]
        [Owner("DataRx")]
        public void TestCompositeModelClassInstance()
        {      
            Console.WriteLine("DataRx.SDK.Model.CompositeModel");
            Console.WriteLine(" - Testing CompositeModel Instantiation");            
            Assert.IsNotNull(cmo, "After calling new CompositeModel(), object should not be null");            
            // Test for ClassName property
            Assert.AreEqual(String.Empty, cmo.ClassName);
            // Test For Taxonomy Namespace property
            Assert.AreEqual(String.Empty, cmo.TNS);
            // Test For DAOFactory property
            Assert.AreEqual(String.Empty, cmo.DAOFactory);
            Console.WriteLine(" - Testing for empty Entity array.");
            // Test for Entity Array
            Assert.AreEqual(0, cmo.Entities.Count);
        }

        [TestMethod]
        [Owner("DataRx")]
        public void TestEntityClassInstance()
        {
            Console.WriteLine("DataRx.SDK.Model.Entity");
            Console.WriteLine(" - Testing Entity Instantiation");
            Entity eob = new Entity();
            Assert.IsNotNull(eob, "After calling new Entity(), object should not be null");
            Console.WriteLine(" - Testing Integration Definition inheritance");
            // Test for SerialVersionUID
            Assert.AreEqual(new Guid(), eob.SerialVersionUID);
            // Test for IDEFName
            Assert.AreEqual(String.Empty, eob.IDEFName);
            Assert.AreEqual(String.Empty, eob.PublicName);
            Assert.AreEqual(String.Empty, eob.PrivateName);
            Console.WriteLine(" - Testing for Entity properties");
            Assert.AreEqual(String.Empty, eob.EntityLexicon);
            Assert.AreEqual(String.Empty, eob.ShortDesc);
            Console.WriteLine(" - Testing for empty Attribute array.");
            // Test for Entity Array
            Assert.AreEqual(0, eob.Attributes.Count);
            Console.WriteLine(" - Test populating Entity object.");
            // Populate Entity and add to Composite Model
            Guid newGuid = Guid.NewGuid();
            String myDesc = "You only get one chance to design your software but you will have thousands of opportunities to sustain it. Make your design count!";
            eob.SerialVersionUID = newGuid;
            eob.IDEFName = "TEST_ENTITY";
            eob.PublicName = "TestEntity";
            eob.PrivateName = "testEntity";
            eob.EntityLexicon = "Test Entity";
            eob.ShortDesc = myDesc;
            Assert.AreEqual(newGuid, eob.SerialVersionUID);
            Assert.AreEqual("TEST_ENTITY", eob.IDEFName);
            Assert.AreEqual("TestEntity", eob.PublicName);
            Assert.AreEqual("testEntity", eob.PrivateName);
            Assert.AreEqual("Test Entity", eob.EntityLexicon);
            Assert.AreEqual(myDesc, eob.ShortDesc);
            Console.WriteLine(" - Test adding Entity to Composite Model.");
            cmo.Entities.Add(eob);
            Assert.AreEqual(1, cmo.Entities.Count);
        }

        [TestMethod]
        [Owner("DataRx")]
        public void TestEntityAttributeClassInstance()
        {
            Console.WriteLine("DataRx.SDK.Model.EntityAttribute");
            Console.WriteLine(" - Testing Attribute Instantiation");
            EntityAttribute attrib = new EntityAttribute();
            Assert.IsNotNull(attrib, "After calling new EntityAttribute(), object should not be null");
            Console.WriteLine(" - Testing Integration Definition inheritance");
            // Test for SerialVersionUID
            Assert.AreEqual(new Guid(), attrib.SerialVersionUID);
            // Test for IDEFName
            Assert.AreEqual(String.Empty, attrib.IDEFName);
            Assert.AreEqual(String.Empty, attrib.PublicName);
            Assert.AreEqual(String.Empty, attrib.PrivateName);
            Assert.AreEqual(String.Empty, attrib.AttributeLexicon);
            Assert.AreEqual(String.Empty, attrib.ShortDesc);
            Console.WriteLine(" - Testing for default Attribute property object");
            // Test for ConstraintName property
            Assert.AreEqual(String.Empty, attrib.Property.ConstraintName);
            Assert.AreEqual(String.Empty, attrib.Property.Size);
            Assert.AreEqual(String.Empty, attrib.Property.DBDataType);
            Assert.AreEqual(String.Empty, attrib.Property.RTDataType);
            Assert.AreEqual(true, attrib.Property.IsNullable);
            Assert.AreEqual(false, attrib.Property.IsPrimaryKey);
            Assert.AreEqual(false, attrib.Property.IsForeignKey);
            Assert.AreEqual(false, attrib.Property.IsIndexed);
            Console.WriteLine(" - Test populating EntityAttribute object.");
            Guid newGuid = Guid.NewGuid();
            String myDesc = "You only get one chance to design your software but you will have thousands of opportunities to sustain it. Make your design count!";
            attrib.SerialVersionUID = newGuid;
            attrib.IDEFName = "TEST_ATTRIB1";
            attrib.PublicName = "TestAttrib1";
            attrib.PrivateName = "testAttrib1";
            attrib.AttributeLexicon = "Test Attrib 1";
            attrib.ShortDesc = myDesc;
            Assert.AreEqual("TEST_ATTRIB1", attrib.IDEFName);
            Assert.AreEqual("TestAttrib1", attrib.PublicName);
            Assert.AreEqual("testAttrib1", attrib.PrivateName);
            Assert.AreEqual("Test Attrib 1", attrib.AttributeLexicon);
            Assert.AreEqual(myDesc, attrib.ShortDesc);
            Console.WriteLine(" - Test adding EntityAttribute to Entity.");
            cmo.Entities = addTestEntityObjects(1);
            cmo.Entities[0].Attributes.Add(attrib);
            Assert.AreEqual(1, cmo.Entities.Count);
        }



        private List<Entity> addTestEntityObjects(Int32 number)
        {
            List<Entity> entityArray = new List<Entity>();

            for (Int32 i = 0; i < number; i++)
            {
                Entity eob = new Entity();
                eob.SerialVersionUID = Guid.NewGuid();
                eob.IDEFName = "TEST_ENTITY_" + i;
                eob.PublicName = "TestEntity" + i;
                eob.PrivateName = "testEntity" + i;
                eob.EntityLexicon = "Test Entity " + i;
                eob.ShortDesc = "Test description " + i;
                entityArray.Add(eob);
            }

            return entityArray;
        }
    }
}
