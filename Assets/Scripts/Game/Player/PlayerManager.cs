using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour, IDamageable
    {
        [Header("Resources")]
        [SerializeField] private PlayerData playerData;

        private InputActions _inputActions;

        private void Awake()
        {
            SetInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Player.Enable();
        }

        private void SetInputActions()
        {
            _inputActions = new InputActions();
            var inputActionsReceivers = GetComponentsInChildren<IInputActionsReceiver>();
            foreach (var receiver in inputActionsReceivers)
            {
                receiver.SetInputActions(_inputActions);
            }
        }

        internal void Load()
        {
            transform.position = playerData.position;
        }

        public void DealDamage(int damage)
        {
            playerData.Health -= damage;
        }
    }
}