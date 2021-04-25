using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMAS.DataAccess.Seed;
using System.Linq;
using System.Data.Entity;
using System.Globalization;
using IMAS.Common.Globalization;
using IMAS.DataAccess;
using IMAS.Model.Domain.Core;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SeedDatabaseAtLevel1()
        {
            DatabaseInitializer_Level1.Initialize();
        }

        [TestMethod]
        public void MiscTest()
        {
            IMASModel context = new IMASModel();
            context.Media.ToList().ForEach(m => m.CreateDate = DateTime.Now);
            context.SaveChanges();
        }
    }
}
