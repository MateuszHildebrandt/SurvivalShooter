using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IInputActionsReceiver
    {
        [Header("Settings")]
        [SerializeField] float speed;
        [Header("Resources")]
        [SerializeField] PlayerData playerData;

        private Rigidbody2D rigidbody;
        private Vector2 movement;

        public InputActions InputActions { get; private set; }

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            movement = InputActions.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.deltaTime);
            playerData.position = transform.position;
        }

        public void SetInputActions(InputActions inputs) => InputActions = inputs;
    }
}