using Player;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public EnemyData EnemyData;

        private EnemyMovement _movement;
        private EnemyAttack _attack;
        private SpriteLibrary _spriteLibrary;
        private PlayerManager _player;

        public void DealDamage(int damage)
        {
            EnemyData.health -= damage;
        }

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _attack = GetComponentInChildren<EnemyAttack>();
            _spriteLibrary = GetComponent<SpriteLibrary>();
            _player = FindObjectOfType<PlayerManager>();
        }

        private void Start()
        {
            _movement.Data = EnemyData;
            _attack.Data = EnemyData;
            _movement.Target = _player.gameObject.transform;
            _spriteLibrary.spriteLibraryAsset = EnemyData.spriteLibrary;
        }
    }
}