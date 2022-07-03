using Player;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData EnemyData;

        private EnemyMovement _movement;
        private SpriteLibrary _spriteLibrary;
        private PlayerManager _player;

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _spriteLibrary = GetComponent<SpriteLibrary>();
            _player = FindObjectOfType<PlayerManager>();
        }

        private void Start()
        {
            _movement.Speed = EnemyData.speed;
            _movement.Target = _player.gameObject.transform;
            _spriteLibrary.spriteLibraryAsset = EnemyData.spriteLibrary;
        }
    }
}