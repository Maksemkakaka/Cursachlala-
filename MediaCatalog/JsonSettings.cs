using System;
using System.IO;
using Newtonsoft.Json;

namespace MediaCatalog
{
    public static class JsonSettings
    {
        private static string FolderPath => Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        public static void Save<T>(T settings, string filename = null) where T : class
        {
            filename = string.IsNullOrEmpty(filename) ? typeof(T).ToString() + ".json" : filename;
            string path = Path.Combine(FolderPath, filename);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(settings, Formatting.Indented));
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T Get<T>(string filename = null) where T : class
        {
            filename = string.IsNullOrEmpty(filename) ? typeof(T).ToString() + ".json" : filename;
            string path = Path.Combine(FolderPath, filename);
             
            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    try
                    {
                        var result = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                        return result;

                    }
                    catch (Exception ex)
                    {
                        throw new JsonSerializationException($"Cant deserialize configuration file {path}", ex);
                    }
                    finally
                    {
                        streamReader.Close();
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("File with configurations not found", path);
            }
        }

    }
}
