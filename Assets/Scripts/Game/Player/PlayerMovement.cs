using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IInputActionsReceiver
    {
        [Header("Settings")]
        [SerializeField] private float speed;
        [Header("Resources")]
        [SerializeField] private PlayerData playerData;

        private Rigidbody2D _rigidbody;
        private Vector2 _movement;

        public InputActions InputActions { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _movement = InputActions.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.MovePosition(_rigidbody.position + _movement * speed * Time.deltaTime);
            playerData.position = transform.position;
        }

        public void SetInputActions(InputActions inputs) => InputActions = inputs;
    }
}