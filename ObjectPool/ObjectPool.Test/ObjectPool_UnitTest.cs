using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool.Test
{
    [TestFixture]
    public class ObjectPool_UnitTest
    {
        [Test]
        public void Store_Adds_Object_If_Pool_Not_Full_Or_Max_Is_Zero()
        {
            var pool = new ObjectPool<object>()
            {
                MaxPoolSize = 0,
            };

            Assert.IsTrue(pool.Store(new object()));
            Assert.AreEqual(1, pool.Count);
            Assert.IsTrue(pool.Store(new object()));
            Assert.AreEqual(2, pool.Count);

            pool.MaxPoolSize = 3;

            Assert.IsTrue(pool.Store(new object()));
            Assert.AreEqual(3, pool.Count);
            Assert.IsFalse(pool.Store(new object()));
            Assert.AreEqual(3, pool.Count);
        }

        [Test]
        public void Grab_Retrieves_Object()
        {
            var pool = new ObjectPool<object>();

            var objIn = new object();
            Assert.IsTrue(pool.Store(objIn));
            Assert.IsTrue(pool.Grab(out object objOut));

            Assert.AreEqual(objIn, objOut);
            Assert.AreEqual(0, pool.Count);
        }

        [Test]
        public void Grab_When_Empty_Instantiates_Object_If_AutoCreateObjects_Set()
        {
            var pool = new ObjectPool<object>()
            {
                AutoCreateObjects = true,
            };

            Assert.IsTrue(pool.Grab(out object objOut));
            Assert.IsNotNull(objOut);
        }

        [Test]
        public void Grab_When_Empty_Returns_False_If_AutoCreateObjects_NotSet()
        {
            var pool = new ObjectPool<object>()
            {
                AutoCreateObjects = false,
            };

            Assert.IsFalse(pool.Grab(out object objOut));
            Assert.IsNull(objOut);
        }
    }
}
