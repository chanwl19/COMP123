using COMP123.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static COMP123.Utility.Parameters;

namespace COMP123.Utility
{
    public static class SerializationHandler
    {

        private static StreamWriter sw;
        private static string userFile = ConfigurationManager.AppSettings["userFilePath"] + ConfigurationManager.AppSettings["userFile"];
        public static void JsonSerializater<T>(T obj, string filePath)
        {
            Logger.WriteLog((int)LogLevels.Info, "SerializationHandler - JsonSerialization", $"Start to serialize Object {obj} to filePath {filePath}");
            JsonSerializer jsonSerializer = new JsonSerializer();
            try
            {
                if (File.Exists(filePath))
                {
                    string newFileName = filePath.Replace(".txt", "_" + DateTime.Now.ToString(Parameters.BACKUP_FILE_FORMAT) + ".txt");
                    File.Move(filePath, newFileName);
                    Logger.WriteLog((int)LogLevels.Info, "SerializationHandler - JsonSerialization", $"File {filePath} already exists, change the file name to {newFileName}");
                }
                sw = new StreamWriter(filePath);
                jsonSerializer.Serialize(sw, obj);
            }
            catch (Exception e)
            {
                Logger.WriteLog((int)LogLevels.Error, "SerializationHandler - JsonSerialization", e);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                Logger.WriteLog((int)LogLevels.Info, "SerializationHandler - JsonSerialization", $"Finish to serialize Object {obj} to filePath {filePath}");
            }
        }
        public static T JsonDeserialization<T>(string filePath)
        {
            Logger.WriteLog((int)LogLevels.Info, "SerializationHandler - JsonDeserialization", $"Start to deserialize Object from filePath {filePath}");
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
                Logger.WriteLog((int)LogLevels.Error, "SerializationHandler - JsonDeserialization", e);
                return default(T);
            }
            finally
            {
                Logger.WriteLog((int)LogLevels.Info, "SerializationHandler - JsonDeserialization", $"Finish to deserialize Object from filePath {filePath}");
            }
        }

        //Overloading JsonDeserialization
        public static List<Staff> JsonDeserialization()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            Logger.WriteLog((int)LogLevels.Info, "SerializationHandler - JsonUsersDeserializater", $"Start to extract staff list from filePath {userFile}");
            try
            {
                if (File.Exists(userFile))
                {
                    string json = File.ReadAllText(userFile);
                    JArray jsonArray = JArray.Parse(json);
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
                Logger.WriteLog((int)LogLevels.Error, "SerializationHandler - JsonUsersDeserializater", e);
                return null;
            }
            finally
            {
                Logger.WriteLog((int)LogLevels.Info, "SerializationHandler - JsonUsersDeserializater", $"Finish to extract staff list from filePath {userFile}");
            }
        }
    }
}
