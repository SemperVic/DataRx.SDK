using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DataRx.SDK.Data.SQLITE3
{
    public class SQL3DBase
    {
        public Boolean TestDatabase()
        {
            Boolean isDatabaseDefined = false;
            SQL3DBase dbase = new SQL3DBase();
            SQLiteConnection dbConn = dbase.DBConnection();
            try
            {
                dbConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(dbConn);
                cmd.CommandText = "SELECT * FROM CORE_VERSION_INFO";
                cmd.ExecuteReader();
                isDatabaseDefined = true;
            }
            catch (Exception e)
            {
                //Message noDbMsg = new Message();
                //noDbMsg.Type = MsgType.Warning;
                //noDbMsg.Title = "Database Not Defined";
                //noDbMsg.Detail = "The Arizona database file does not exist.";
                //// Attempting to Create Database
                //try
                //{
                //    Message dbMsg = dbase.CreateDatabase();
                //    List<Message> tableMsgs = dbase.CreateTables();
                //    isDatabaseDefined = true;
                //}
                //catch (Exception ex)
                //{
                //    Message errorMsg = new Message();
                //    errorMsg.Type = MsgType.Warning;
                //    errorMsg.Title = "SQLite Error";
                //    errorMsg.Detail = "The Arizona database could not be created. " + ex.Message;
                //}
            }
            finally
            {
                dbConn.Close();
            }

            return isDatabaseDefined;
        }

        public SQLiteConnection DBConnection()
        {
            String connectString = @"data source=C:\Users\Sean\Development\Projects\Arizona\Arizona.Portal\App_Data\ARIZONA.db3";
            SQLiteConnection dbConn = new SQLiteConnection(connectString);
            return dbConn;
        }

        //public Message CreateDatabase()
        //{
        //    Message msg = new Message();
        //    try
        //    {
        //        // Create Database File
        //        SQLiteConnection.CreateFile("ARIZONA.db3");
        //        // Create Message
        //        msg.Type = MsgType.Success;
        //        msg.Title = "Database Created";
        //        msg.Detail = "Sucessfully created the 'ARIZONA.db3' database";
        //    }
        //    catch (Exception e)
        //    {
        //        // Create Message
        //        msg.Type = MsgType.Error;
        //        msg.Title = "Database Error";
        //        msg.Detail = "Problem encountered creating the database. " + e.Message;
        //    }

        //    return msg;
        //}

        //public List<Message> CreateTables()
        //{
        //    List<Message> messages = new List<Message>();
        //    // Create VERSION
        //    VersionInfoDDL version = new VersionInfoDDL();
        //    messages.Add(version.CreateTable());

        //    // Create CORE_METADATA
        //    MetadataDDL metadata = new MetadataDDL();
        //    messages.Add(metadata.CreateTable());

        //    return messages;
        //}
    }
}
