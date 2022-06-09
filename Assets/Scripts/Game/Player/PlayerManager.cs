using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float _health = 100f;

        private InputActions inputActions;

        public float Health
        {
            get => _health;
            set => _health = value;
        }

        private void Awake()
        {
            SetInputActions();
        }

        private void OnEnable()
        {
            inputActions.Player.Enable();
        }

        private void SetInputActions()
        {
            inputActions = new InputActions();
            var inputActionsReceivers = GetComponentsInChildren<IInputActionsReceiver>();
            foreach (var receiver in inputActionsReceivers)
            {
                receiver.SetInputActions(inputActions);
            }
        }
    }
}