using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EF6CodeFirstSamples
{
    [TestFixture]
   public class TestDefaultCodeFirst
    {
        [Test]
        public void Test_Set_Database()
        {
            var entities = new BlogsEntities();
            Assert.AreEqual(entities.Departments.Count(),1);
        }
    }
}
