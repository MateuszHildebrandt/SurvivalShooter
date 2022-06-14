using Player;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData EnemyData;

        private EnemyMovement movement;
        private SpriteLibrary spriteLibrary;
        private PlayerManager player;

        private void Awake()
        {
            movement = GetComponent<EnemyMovement>();
            spriteLibrary = GetComponent<SpriteLibrary>();
            player = FindObjectOfType<PlayerManager>();
        }

        private void Start()
        {
            movement.Speed = EnemyData.speed;
            movement.Target = player.gameObject.transform;
            spriteLibrary.spriteLibraryAsset = EnemyData.spriteLibrary;
        }
    }
}