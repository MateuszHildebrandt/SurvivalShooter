using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour, IInputActionsReceiver
    {
        public InputActions InputActions { get; private set; }

        private Animator animator;
        private Vector2 movement;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            movement = InputActions.Player.Move.ReadValue<Vector2>();
            Animate();
        }

        private void Animate()
        {
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        public void SetInputActions(InputActions inputs) => InputActions = inputs;
    }
}