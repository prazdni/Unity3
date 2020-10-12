using System;
using System.IO;
using System.Xml.Serialization;

namespace MyLabyrinth
{
    public class SerializableXMLData<T> : IData<T>
    {
        private static XmlSerializer _formatter;

        public SerializableXMLData()
        {
            _formatter = new XmlSerializer(typeof(T));
        }
        public void Save(T data, string path = "")
        {
            if (data == null && !String.IsNullOrEmpty(path))
                return;

            using (var fs = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(fs, data);
            }

            var text = File.ReadAllText(path);
            text = Crypto.CryptoXOR(text);
            File.WriteAllText(path, text);
        }

        public T Load(string path = null)
        {
            T result;
            if (!File.Exists(path))
                return default;

            var cryptoText = File.ReadAllText(path);
            var uncryptoText = Crypto.CryptoXOR(cryptoText);
            
            File.WriteAllText(path, uncryptoText);
            
            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (T)_formatter.Deserialize(fs);
            }
            
            File.WriteAllText(path, cryptoText);
            
            return result;
        }
    }
}