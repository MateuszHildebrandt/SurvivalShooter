using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] FloatVariable health;

        private InputActions inputActions;

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