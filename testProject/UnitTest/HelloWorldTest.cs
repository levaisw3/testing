using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace testProject.UnitTest
{
    [TestFixture]
    class HelloWorldTest
    {
        [Test]//Here is the test case for the Hello World.
        public void Hello()
        {
            //I am sending "something" to Hello method.
            //I am expecting to receive "Hello something"
            string name = HelloWorld.Hello("something");
            Assert.That(name.Equals("Hello something"));
        }
    }
}
