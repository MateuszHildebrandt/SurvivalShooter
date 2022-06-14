using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Enemies
{
    [CreateAssetMenu(menuName ="Enemy/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public int health;
        public int attack;
        public float speed;
        public SpriteLibraryAsset spriteLibrary;
    }
}