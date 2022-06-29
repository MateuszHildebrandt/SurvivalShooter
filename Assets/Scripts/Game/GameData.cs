using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "ScriptableObject/GameData")]
    public class GameData : ScriptableObject
    {
        public Player.PlayerData playerData;
    }
}
