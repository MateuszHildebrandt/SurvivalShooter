using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour, IDoDamage
    {
        public EnemyData Data { get; set; }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<IDamageable>(out IDamageable damageable))
                return;

            Attack(damageable);
        }

        public void Attack(IDamageable damageable)
        {
            damageable.DealDamage(Data.attack);
        }
    }
}