using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUD : MonoUI
    {
        [Header("References")]
        [SerializeField] Image healthBar;
        [Header("Resources")]
        [SerializeField] Player.PlayerData playerData;

        private const float MAX_TIMER = 0.2f;
        private float _timer = 0;

        private void Start()
        {
            playerData.onHealth += () => UpdateHealthBar();
        }

        /*private void Update()
        {
            if (IsActive() == false)
                return;

            _timer += Time.deltaTime;

            if (_timer > MAX_TIMER)
            {
                UpdateHealthBar();
                _timer = 0;
            }
        }*/

        private void UpdateHealthBar()
        {
            float normalizeValue = playerData.Health / playerData.maxHealth;
            if (healthBar.fillAmount != normalizeValue)
                healthBar.fillAmount = normalizeValue;
        }
    }
}
