using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataRx.SDK.Model;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;

namespace DataRx.SDK.Common
{
    /// <summary>
    /// DTOEvent delegate signature that is called when a DTOEvent is triggered.
    /// </summary>
    /// <remarks>The standard Arizona call stack does not natively listen for 
    /// change events. The reason for this is because all of the interface 
    /// points of entry exist in stateless environments. Accordingly, call 
    /// stack ADO/ORM mappings rely on the object's property named "ObjectState". 
    /// Should you ever use these libraries for desktop or command line 
    /// processes you can tie your event listener to this handler in-lieu of 
    /// relying on DTOState methods and use the standard Set method.</remarks>
    /// <param name="sender">The source of the event.</param>
    /// <param name="dtoEventArgs">An object that contains the event data.</param>
    public delegate void DTOEventHandler(object sender, DTOEventArgs dtoEventArgs);
    
    /// <summary>
    /// Data Transfer Object Event Arguments
    /// </summary>
    public class DTOEventArgs : EventArgs
    {
        private String info = String.Empty;
        /// <summary>
        /// DTOEventArgs Information Only
        /// </summary>
        /// <param name="info">Defined in API implementation</param>
        public DTOEventArgs(String info)
        {
            this.info = info;
        }
        /// <summary>
        /// Gets Event Information
        /// </summary>
        /// <returns>Information defined in implementation</returns>
        public string GetInfo() { return info; }
    }

    /// <summary>
    /// A DTO is a simple container for a set of aggregated data that needs to 
    /// be transferred across a process or network boundary. It should contain 
    /// no business logic and limit its behavior to activities such as internal 
    /// consistency checking and basic validation.
    /// </summary>
    [DataContract]
    public partial class DataTransferObject
    {
        /// <summary>
        /// PropertyChangedEvent is raised when a property in the DTO object is changed
        /// </summary>
        public event DTOEventHandler PropertyChangedEvent;

        /// <summary>
        /// Method to be called when a property is changed
        /// </summary>
        /// <param name="info">Information about the Event</param>
        /// <event cref="DTOEventHandler">Raises DTOEventHandler Event</event>
        private void OnPropertyChange(String info)
        {
            if (PropertyChangedEvent != null)
            {
                PropertyChangedEvent(this, new DTOEventArgs(info));
            }
        }

        /// <summary>
        /// The serial version UID associates an object with a class object container capable of 
        /// serialization/deserialization. If the class object cannot be found an 
        /// InvalidClassException will be thrown.
        /// </summary>
        [DataMember]
        public Guid SerialVersionUID { get; set; }
        /// <summary>
        /// Gets the runtime Type of this current instance 
        /// </summary>
        [DataMember]
        public String GetType { get; set; }
        /// <summary>
        /// Identifies the DTO Object State
        /// </summary>
        [DataMember]
        public String ObjectState { get; set; }
        /// <summary>
        /// Identifies the current Universal Coordinated Time. 
        /// </summary>
        [DataMember]
        public DateTime CurrentUTC;
        /// <summary>
        /// Identifies the current Unix Timestamp
        /// </summary>
        [DataMember]
        public Int64 CurrentUTS;
        /// <summary>
        /// Identifies the current DateID
        /// </summary>
        [DataMember]
        public Int64 CurrentDateID;

        /// <summary>
        /// Default Constructor
        /// </summary>
        [DataMember]
        public DataTransferObject()
        {
            SerialVersionUID = new Guid();
            ObjectState = DTOState.New;
            GetType = this.GetType().ToString();
            CurrentUTC = DateTime.UtcNow;
            CurrentUTS = UTS.UtsNow;
            CurrentDateID = UTS.UtcToDateId(CurrentUTC);            
        }
    }
    
    /// <summary>
    /// Static Reference to DTO ObjectStates
    /// </summary>
    [DataContract]
    public class DTOState
    {
        /// <summary>
        /// Indicates the DTO is New and will be inserted into the database when set.
        /// </summary>
        [DataMember]
        public const String New = "NEW";
        /// <summary>
        /// Indicates the DTO is Clean and unchanged and does not require a set
        /// </summary>
        [DataMember]
        public const String Clean = "CLEAN";
        /// <summary>
        /// Indicates the DTO is Dirty and will be updated in the database when set.
        /// </summary>
        [DataMember]
        public const String Dirty = "DIRTY";
    }
    
    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public class ObjectTransformation
    {
        /// <summary>
        /// Serializes a TaxonomyObject object to a Json string.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <param name="format">(*optional) [None|Indent]</param>
        /// <returns>Returns JavaScript Object Notation string</returns>
        public String SerializeTaxonomyObjectToJson(TaxonomyObject dto, String format = "None")
        {
            if(format.Equals("None"))
            {
                return JsonConvert.SerializeObject(dto, Formatting.None, JsonSettings);
            }
            else
            {
                return JsonConvert.SerializeObject(dto, Formatting.Indented, JsonSettings);
            }        
        }

        /// <summary>
        /// Converts a C# List<TaxonomyObject> class to a JSON string.
        /// </summary>
        /// <param name="dtoArray">List<TaxonomyObject></param>
        /// <returns>Returns JavaScript Object Notation string</returns>
        public String SerializeTaxonomyObjectCollectionToJson(List<TaxonomyObject> dtoArray, String format = "None")
        {
            if(format.Equals("None"))
            {
                return JsonConvert.SerializeObject(dtoArray, Formatting.None, JsonSettings);
            }
            else
            {
                return JsonConvert.SerializeObject(dtoArray, Formatting.Indented, JsonSettings);
            }
        }

        /// <summary>
        /// Deserializes a TaxonomyObject from an xml or json string
        /// </summary>
        /// <param name="stringType"></param>
        /// <param name="serializedObj"></param>
        /// <returns></returns>
        public TaxonomyObject DeserializeTaxonomyObject(String stringType, String serializedObj)
        {
            return new TaxonomyObject();
        }

        /// <summary>
        /// Converts a Data Transfer Object to a XML string.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public String SerializeTaxonomyObjectToXml(TaxonomyObject dto)
        {
            try
            {
                using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
                using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(stringWriter))
                {
                    var serializer = new XmlSerializer(dto.GetType());
                    serializer.Serialize(writer, dto);
                    writer.Flush();
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Populates a Data Transfer Object from a JSON string.
        /// </summary>
        /// <param name="jsonString"></param>
        public void LoadFromJson(String jsonString)
        {

        }

        /// <summary>
        /// Populates a Data Transfer Object from a XML string
        /// </summary>
        /// <param name="xmlString"></param>
        public void LoadFromXml(String xmlString)
        {

        }

        /// <summary>
        /// JSON Settings
        /// </summary>
        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            StringEscapeHandling = StringEscapeHandling.EscapeHtml
        };
    }

    /// <summary>
    /// Unix Timestamp Helper Class
    /// </summary>
    public static class UTS
    {
        /// <summary>
        /// UnixEpoch Time (1970/01/01 00:00)
        /// </summary>
        public static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        /// Returns Unix timestamp of now 
        /// </summary>
        public static Int64 UtsNow = (Int64)(DateTime.UtcNow.Subtract(UnixEpoch)).TotalSeconds;

        /// <summary>
        /// Converts UTC DateTime to a Unix timestamp
        /// </summary>
        /// <param name="value">UTC DateTime</param>
        /// <returns>The provided DateTime in Unix timestamp format</returns>
        public static Int64 UtcDateToUTS(DateTime value)
        {
            return (Int64)Math.Truncate((value.Subtract(UnixEpoch)).TotalSeconds);
        }

        /// <summary>
        /// Converts Localized DateTime to a (UTC) Unix timestamp
        /// </summary>
        /// <param name="value">Localized DateTime</param>
        /// <returns>The provided DateTime in Unix timestamp format</returns>
        public static Int64 LocalDateToUTS(DateTime value)
        {
            return (Int64)Math.Truncate((value.ToUniversalTime().Subtract(UnixEpoch)).TotalSeconds);
        }

        /// <summary>
        /// Converts a Unix timestamp to DateTime
        /// </summary>
        /// <param name="value">UTS</param>
        /// <returns></returns>
        public static DateTime UtsToDateTime(Int64 value)
        {
            return UnixEpoch.AddSeconds(value);
        }

        /// <summary>
        /// Converts Unix Time Stamp to DateID
        /// </summary>
        /// <param name="value">Unix Time Stamp</param>
        /// <returns>Int64 (DateID)</returns>
        public static Int64 UtsToDateId(Int64 value)
        {
            DateTime utc = UTS.UtsToDateTime(value);
            return UTS.UtcDateToUTS(new DateTime(utc.Year, utc.Month, utc.Day));
        }

        /// <summary>
        /// Converts UTC to DateID
        /// </summary>
        /// <param name="value">Univeral Time Cordinated</param>
        /// <returns>Int64 (Date Demension DateID)</returns>
        public static Int64 UtcToDateId(DateTime value)
        {
            return UTS.UtcDateToUTS(new DateTime(value.Year, value.Month, value.Day));
        }
    }
}
