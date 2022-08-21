using Tools;
using UnityEngine;
using Newtonsoft.Json;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                onHealth?.Invoke();
            }
        }

        [JsonIgnore]
        public System.Action onHealth;
        [SerializeField] float _health;
        public float Health
        {
            get => _health;
            set
            {
                _health = value;
                onHealth.Invoke();
            }
        }

        public float maxHealth;
        public Float2 position;

        public void ClampHealth(float value) => _health = Mathf.Clamp(value, 0, maxHealth);

        public void SetDefault()
        {
            _health = 50f;
            maxHealth = 100f;
            position = new Float2(0, 0);
        }
    }
}
