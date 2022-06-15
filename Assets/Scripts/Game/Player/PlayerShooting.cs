using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour, IInputActionsReceiver
    {
        [Header("Settings")]
        [SerializeField] float bulletForce = 10f;
        [Header("Resources")]
        [SerializeField] GameObject bulletPrefab;

        private Camera _camera;
        private SpriteRenderer _spriteRenderer;

        private float _bulletOffset = 0.2f;

        public InputActions InputActions { get; private set; }

        private void Awake()
        {
            _camera = Camera.main;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InputActions.Player.Fire.performed += (_) => Shoot();
        }

        [ExposeMethodInEditor]
        public void Shoot()
        {
            Vector2 mouseWorldPoint = _camera.ScreenToWorldPoint(InputActions.Player.Aim.ReadValue<Vector2>());
            Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
            //Debug.DrawRay(transform.position, direction, Color.red);
            GameObject bullet = Instantiate(bulletPrefab, SetBulletPosition(direction), Quaternion.identity, transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 5);
        }

        private Vector3 SetBulletPosition(Vector2 direction)
        {
            Bounds bounds = _spriteRenderer.bounds;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //4 directions
            if (angle >= -45 && angle <= 45) //Right
                return new Vector2(bounds.max.x + _bulletOffset, bounds.center.y);
            else if (angle > 45 && angle < 135) //Up
                return new Vector2(bounds.center.x, bounds.max.y + _bulletOffset);
            else if (angle > -135 && angle < -45) //Down
                return new Vector2(bounds.center.x, bounds.min.y - _bulletOffset);
            else //Left
                return new Vector2(bounds.min.x - _bulletOffset, bounds.center.y);

        }

        public void SetInputActions(InputActions inputs) => InputActions = inputs;
    }
}
