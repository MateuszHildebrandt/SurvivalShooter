using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUD : MonoUI<HUD>
    {
        [Header("References")]
        [SerializeField] Image healthBar;
        [Header("Resources")]
        [SerializeField] Player.PlayerData playerData;

        private bool _isActive; //TODO

        private const float MAX_TIMER = 0.2f;
        private float _timer = 0;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > MAX_TIMER)
            {
                UpdateHealthBar();
                _timer = 0;
            }
        }

        private void UpdateHealthBar()
        {
            float normalizeValue = playerData.health / playerData.maxHealth;
            if (healthBar.fillAmount != normalizeValue)
                healthBar.fillAmount = normalizeValue;
        }
    }
}
