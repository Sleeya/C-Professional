using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DatabaseTests
{
    public class FetchTests
    {
        [Test]
        public void ReturnsElementsAsArrayStructure()
        {
            Database db = new Database(1,2,3);

            Assert.That(()=>db.Fetch(),Is.EquivalentTo(new int[]{1,2,3}));
        }
    }
}
