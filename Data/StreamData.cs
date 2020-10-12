using System;
using System.IO;

namespace MyLabyrinth
{
    public class StreamData : IData<SavedData>
    {
        public void Save(SavedData data, string path = "")
        {
            if (path == "")
                return;

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(data.Name);
                sw.WriteLine(data.Position.X);
                sw.WriteLine(data.Position.Y);
                sw.WriteLine(data.Position.Z);
                sw.WriteLine(data.IsEnabled);
            }
        }

        public SavedData Load(string path = "")
        {
            var result = new SavedData();

            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    result.Name = sr.ReadLine();
                    result.Position.X = sr.ReadLine().ToSingle();
                    result.Position.X = sr.ReadLine().ToSingle();
                    result.Position.X = sr.ReadLine().ToSingle();
                    result.IsEnabled = sr.ReadLine().ToBool();
                }
            }

            return result;
        }
    }
}