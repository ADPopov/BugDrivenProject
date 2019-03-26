using System;
using System.Collections.Generic;

namespace BugDrivenProject
{
    internal class HashDictionary
    {
        /// <summary>
        /// Хэш ключа
        /// </summary>
        public readonly int KeyHash;
        /// <summary>
        /// Значение
        /// </summary>
        public object Value { get; set; }

        public HashDictionary(int keyHash, object value)
        {
            this.KeyHash = keyHash;
            this.Value = value;
        }
    }

    /// <summary>
    /// Хэш-таблица
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Хранит пару хэш-значение
        /// </summary>
        private readonly List<HashDictionary>[] _hashDataLists;

        /// <summary>
        /// Конструктор контейнера
        /// </summary>
        /// <param name="size">Размер хэш-таблицы</param>
        public HashTable(int size)
        {
            _hashDataLists = new List<HashDictionary>[size];
        }

        /// <summary>
        /// Метод складывающий пару ключ-значение в таблицу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public void PutPair(object key, object value)
        {
            var keyHashCode = key.GetHashCode();
            var index = Math.Abs(keyHashCode) % _hashDataLists.Length;

            if (_hashDataLists[index] == null)
            {
                var keyValue = new HashDictionary(keyHashCode, value);
                _hashDataLists[index] = new List<HashDictionary> { keyValue };
            }
            else
            {
                HashDictionary elementDictionary = null;
                for (var i = 0; i < _hashDataLists[index].Count; i++)
                {
                    var x = _hashDataLists[index][i];
                    if (x.KeyHash != keyHashCode) continue;
                    elementDictionary = x;
                    break;
                }

                if (elementDictionary == null)
                    _hashDataLists[index].Add(new HashDictionary(keyHashCode, value));
                else
                    elementDictionary.Value = value;
            }
        }

        /// <summary>
        /// Поиск значения по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Значение null, если ключ отсутствует</returns>
        public object GetValueByKey(object key)
        {
            var keyHashCode = key.GetHashCode();
            var valueByKey = _hashDataLists[Math.Abs(keyHashCode) % _hashDataLists.Length];
            try
            {
                return valueByKey?.Find(delegate(HashDictionary x) { return x.KeyHash == keyHashCode; }).Value;
            }
            catch
            {
                return null;
            }
        }
    }
}
