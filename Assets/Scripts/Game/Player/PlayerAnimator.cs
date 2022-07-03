using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour, IInputActionsReceiver
    {
        public InputActions InputActions { get; private set; }

        private Animator _animator;
        private Vector2 _movement;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _movement = InputActions.Player.Move.ReadValue<Vector2>();
            Animate();
        }

        private void Animate()
        {
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Speed", _movement.sqrMagnitude);
        }

        public void SetInputActions(InputActions inputs) => InputActions = inputs;
    }
}