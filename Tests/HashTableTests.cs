using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HashTable.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        /// <summary>
        /// Добавление трёх элементов, поиск трёх элементов
        /// </summary>
        [Test]
        public void TestAdding3Elements()
        {
            const string el1 = "Germany";
            const string key1 = "Berlin";
            const string el2 = "Russia";
            const string key2 = "Moscow";
            const string el3 = "Great Britain";
            const string key3 = "London";

            var hashTable = new BugDrivenProject.HashTable(3);
            hashTable.PutPair(key1, el1);
            hashTable.PutPair(key2, el2);
            hashTable.PutPair(key3, el3);

            Assert.AreEqual(el1, hashTable.GetValueByKey(key1));
            Assert.AreEqual(el2, hashTable.GetValueByKey(key2));
            Assert.AreEqual(el3, hashTable.GetValueByKey(key3));
        }

        /// <summary>
        /// Добавление одного и того же ключа дважды с
        /// разными значениями сохраняет последнее добавленное значение
        /// </summary>
        [Test]
        public void TestAddingSameElement()
        {
            const string el2 = "Russia";
            const string newElement2Value = "Poland";
            const string key2 = "Warsaw";

            var ht = new BugDrivenProject.HashTable(3);
            ht.PutPair(key2, el2);
            ht.PutPair(key2, newElement2Value);

            Assert.AreEqual(newElement2Value, ht.GetValueByKey(key2));

        }

        /// <summary>
        /// Добавление 10000 элементов в структуру и поиск одного из них.
        /// </summary>
        [Test]
        public void Test10000Elements()
        {
            var findingKey = 0;
            var findingElement = 0;
            const int size = 10000;
            var rnd = new Random(5);
            var flag = rnd.Next(size);

            var hashTable = new BugDrivenProject.HashTable(size);
            for (var i = 0; i < size; i++)
            {
                var element = rnd.Next();
                var key = rnd.Next();
                hashTable.PutPair(key, element);
                if (i != flag) continue;
                findingElement = element;
                findingKey = key;
            }

            Assert.AreEqual(findingElement, hashTable.GetValueByKey(findingKey));
        }

        /// <summary>
        /// Добавление 10000 элементов в структуру и поиск 1000
        /// не добавленных ключей, поиск которых должен вернуть null
        /// </summary>
        [Test]
        public void TestFindingAlienKeys()
        {
            const int size = 10000;
            var rnd = new Random(280004);

            var hashTable = new BugDrivenProject.HashTable(size);
            for (var i = size - 1; i >= 0; i--)
            {
                var element = rnd.Next();
                hashTable.PutPair(i, element);
            }

            for (var i = 1000 - 1; i >= 0; i--)
                Assert.AreEqual(null, hashTable.GetValueByKey(rnd.Next(1000) + 10000));
        }
    }

}
