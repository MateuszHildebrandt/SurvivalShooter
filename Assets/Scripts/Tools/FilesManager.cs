using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace Tools
{
    public class FilesManager
    {
        private const bool _isDebug = true;
        private const string password = @"@QUz6r@#Ne#hAH_^=zzk^FYjhf#y-Y^apfAKLGuTyTgd*crZ8aWf^N^KFZ*qwRJHkW7#eKKjDYFm^fMEK";

        private static string _playerDataPath;
        public static string PlayerDataPath
        {
            get
            {
                if (string.IsNullOrEmpty(_playerDataPath))
                    _playerDataPath = Path.Combine(Application.persistentDataPath, "PlayerData.sav");
                return _playerDataPath;
            }
        }

        internal static T Load<T>(string filePath, bool isAES) where T : class
        {
            if (File.Exists(filePath) == false)
                return null;

            string json;
            if (isAES)
            {
                byte[] decrypt = File.ReadAllBytes(filePath);
                json = AES.Decrypt(decrypt, password);
            }
            else
                json = File.ReadAllText(filePath);

            T data = JsonConvert.DeserializeObject<T>(json);

            if (_isDebug)
                Debug.Log("<b>Load</b> " + filePath);

            return data;
        }

        internal static bool LoadScriptableObject<T>(string filePath, T scriptableObject, bool isAES) where T : class
        {
            if (File.Exists(filePath) == false)
                return false;

            string json;
            if (isAES)
            {
                byte[] decrypt = File.ReadAllBytes(filePath);
                json = AES.Decrypt(decrypt, password);
            }
            else
                json = File.ReadAllText(filePath);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
            };

            JsonConvert.PopulateObject(json, scriptableObject, settings);

            if (_isDebug)
                Debug.Log("<b>Load</b> " + filePath);

            return true;
        }

        internal static void Save<T>(T getData, string filePath, bool isAES) where T : class
        {
            string json = JsonConvert.SerializeObject(getData);

            if (isAES)
            {
                byte[] encrypt = AES.Encrypt(System.Text.Encoding.UTF8.GetBytes(json), password);
                File.WriteAllBytes(filePath, encrypt);
            }
            else
                File.WriteAllText(filePath, json);

            if (_isDebug)
                Debug.Log("<b>Save</b> " + filePath);
        }
    }
}
