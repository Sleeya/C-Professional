using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DatabaseTests
{
    public class ConstructorsTests
    {
        [Test]
        public void ThrowsExceptionIfConstructorTakesTooManyArguments()
        {
            Assert.That(() => new Database(new int[17]), Throws.InvalidOperationException.With.Message.EqualTo("Constructor cannot take more than 16 arguments."));
        }
    }
}
