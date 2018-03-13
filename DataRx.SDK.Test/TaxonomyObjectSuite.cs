using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite.Generic;
using DataRx.SDK.Data;
using DataRx.SDK.Model;
using DataRx.SDK.Service;


namespace DataRx.SDK.Test
{
    [TestClass]
    public class TaxonomyObjectSuite
    {
        [TestMethod]
        public void TestDBConnection()
        {
            List<TaxonomyObject> tax = TaxonomyObjectServiceProvider.Instance.GetCompositeModelByTNS("A2Z");


        }
    }
}
