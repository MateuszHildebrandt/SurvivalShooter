using Tools;
using UnityEngine;

namespace Game
{
    public class SaveSystem : MonoBehaviour
    {
        [Header("Resoureces")]
        [SerializeField] GameData gameData;
        [SerializeField] Player.PlayerManager playerManager; //TODO: Use zenject

        private static SaveSystem _instance;
        public static SaveSystem I
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<SaveSystem>();
                return _instance;
            }
        }

        private void Start()
        {
            Load();
        }

        private void OnApplicationQuit()
        {
            if (Application.isEditor == false)
                Save();
        }

        [ContextMenu("Save")]
        internal void Save()
        {
            FilesManager.Save(gameData, FilesManager.PlayerDataPath, false);
        }

        [ContextMenu("Load")]
        internal void Load()
        {
            bool loaded = FilesManager.LoadScriptableObject(FilesManager.PlayerDataPath, gameData, false);

            if (loaded == false)
                gameData.playerData.SetDefault();

            playerManager.Load();
        }
    }
}
