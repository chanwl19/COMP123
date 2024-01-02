using COMP123.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static COMP123.Utility.Parameters;

namespace COMP123.Utility
{
    public static class ObjectHandler
    {

        private static StreamWriter sw;
        private static StreamReader sr;
        private static string userFile = ConfigurationManager.AppSettings["userFilePath"] + ConfigurationManager.AppSettings["userFile"];
        public static void JsonSerializater<T>(T obj, string filePath)
        {
            Logger.WriteLog((int)LogLevels.Info, "ObjectHandler - JsonSerialization", $"Start to serialize Object {obj} to filePath {filePath}");
            JsonSerializer jsonSerializer = new JsonSerializer();
            try
            {
                if (File.Exists(filePath))
                {
                    string newFileName = filePath.Replace(".txt", DateTime.Now.ToString(Parameters.backupFileFormat) + ".txt");
                    File.Move(filePath, newFileName);
                    Logger.WriteLog((int)LogLevels.Info, "ObjectHandler - JsonSerialization", $"File {filePath} already exists, change the file name to {newFileName}");
                }
                sw = new StreamWriter(filePath);
                jsonSerializer.Serialize(sw, obj);
            }
            catch (Exception e)
            {
                Logger.WriteLog((int)LogLevels.Error, "ObjectHandler - JsonSerialization", e);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                Logger.WriteLog((int)LogLevels.Info, "ObjectHandler - JsonSerialization", $"Finish to serialize Object {obj} to filePath {filePath}");
            }
        }
        public static T JsonDeserialization<T>(string filePath)
        {
            Logger.WriteLog((int)LogLevels.Info, "ObjectHandler - JsonDeserialization", $"Start to deserialize Object from filePath {filePath}");
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    throw new FileNotFoundException($"File {filePath} not found ");
                }
            }
            catch (Exception e)
            {
                Logger.WriteLog((int)LogLevels.Error, "ObjectHandler - JsonDeserialization", e);
                return default(T);
            }
            finally
            {
                Logger.WriteLog((int)LogLevels.Info, "ObjectHandler - JsonDeserialization", $"Finish to deserialize Object from filePath {filePath}");
            }
        }


        public static List<Staff> JsonUsersDeserializater()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            Logger.WriteLog((int)LogLevels.Info, "ObjectHandler - JsonUsersDeserializater", $"Start to extract staff list from filePath {userFile}");
            try
            {
                if (File.Exists(userFile))
                {
                    sr = new StreamReader(userFile);
                    string jsonContent = sr.ReadToEnd();
                    JArray jsonArray = JArray.Parse(jsonContent);
                    List<JToken> tokens = jsonArray.ToList();
                    List<Staff> staffs = new List<Staff>();
                    foreach (JToken token in tokens)
                    {
                        int role = (int)token.SelectToken("Role");
                        Staff staff;
                        switch (role)
                        {
                            case 0:
                                staff = JsonConvert.DeserializeObject<Admin>(token.ToString());
                                break;
                            case 1:
                                staff = JsonConvert.DeserializeObject<Accountant>(token.ToString());
                                break;
                            case 2:
                                staff = JsonConvert.DeserializeObject<Manager>(token.ToString());
                                break;
                            default:
                                staff = null;
                                break;
                        }
                        staffs.Add(staff);
                    }
                    return staffs;
                }
                return null;
            }
            catch (Exception e)
            {
                Logger.WriteLog((int)LogLevels.Error, "ObjectHandler - JsonUsersDeserializater", e);
                return null;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                Logger.WriteLog((int)LogLevels.Info, "ObjectHandler - JsonUsersDeserializater", $"Finish to extract staff list from filePath {userFile}");
            }
        }
    }
}
