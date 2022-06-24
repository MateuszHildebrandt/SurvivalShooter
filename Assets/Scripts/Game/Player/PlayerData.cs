using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float health;
        public float maxHealth;

        public void ClampHealth(float value) => health = Mathf.Clamp(value, 0, maxHealth);

        public void SetDefault()
        {
            health = 50f;
            maxHealth = 100f;
        }
    }
}
