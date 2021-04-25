using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMAS.Common.Messaging;

namespace IMAS.Test
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmailHelper.SendMailAsync("reg@tahacnc.com", "mehrta.misc@live.com", "Yes Babe", "Body").Wait();
        }
    }
}
