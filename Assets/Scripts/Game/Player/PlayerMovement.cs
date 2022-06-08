using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D rigidbody;
        private Animator animator;

        private InputActions inputActions;

        private Vector2 movement;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            inputActions = new InputActions();
            inputActions.Player.Enable();
        }

        private void Update()
        {
            movement = inputActions.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Move();
            Animate();
        }

        private void Animate()
        {
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        private void Move()
        {
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.deltaTime);
        }
    }
}