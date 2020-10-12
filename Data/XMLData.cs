using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

namespace MyLabyrinth
{
    public class XMLData : IData<SavedData>
    {
        public void Save(SavedData player, string path = "")
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            if (File.Exists(path) && new FileInfo(path).Length == 0)
            {
                var root = xmlDoc.CreateElement("rootElement");
                xmlDoc.AppendChild(root);
            }
            else
            {
                xmlDoc.Load(path);
            }


            var rootNode = xmlDoc.CreateElement("GameObjectName");
            rootNode.SetAttribute("value", player.Name);
            xmlDoc.DocumentElement.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Pos");
            var attribute = xmlDoc.CreateAttribute("PosX");
            attribute.Value = player.Position.X.ToString();
            element.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("PosY");
            attribute.Value = player.Position.Y.ToString();
            element.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("PosZ");
            attribute.Value = player.Position.Z.ToString();
            element.Attributes.Append(attribute);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("Rot");
            attribute = xmlDoc.CreateAttribute("RotX");
            attribute.Value = player.Rotation.X.ToString();
            element.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("RotY");
            attribute.Value = player.Rotation.Y.ToString();
            element.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("RotZ");
            attribute.Value = player.Rotation.Z.ToString();
            element.Attributes.Append(attribute);
            rootNode.AppendChild(element);
            
            element = xmlDoc.CreateElement("IsEnabled");
            element.SetAttribute("value", player.IsEnabled.ToString());
            rootNode.AppendChild(element);

            var userNode = xmlDoc.CreateElement("Info");
            attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " + Application.systemLanguage;
            rootNode.AppendChild(userNode);
            
            xmlDoc.Save(path);
        }

        public SavedData Load(string path = null)
        {
            var result = new SavedData();
            
            if (!File.Exists(path))
                return result;

            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement("GameObjectName"))
                        result.Name = reader.GetAttribute("value");

                    if (reader.IsStartElement("Pos"))
                    {
                        result.Position.X = reader.GetAttribute("PosX").ToSingle();
                        result.Position.Y = reader.GetAttribute("PosY").ToSingle();
                        result.Position.Z = reader.GetAttribute("PosZ").ToSingle();
                    }

                    if (reader.IsStartElement("Rot"))
                    {
                        result.Rotation.X = reader.GetAttribute("RotX").ToSingle();
                        result.Rotation.Y = reader.GetAttribute("RotY").ToSingle();
                        result.Rotation.Z = reader.GetAttribute("RotZ").ToSingle();
                    }
                    
                    if (reader.IsStartElement("IsEnabled"))
                        result.IsEnabled = reader.GetAttribute("value").ToBool();
                }
            }

            return result;
        }

        private void WritePosition(string posName)
        {
            
        }
    }
}