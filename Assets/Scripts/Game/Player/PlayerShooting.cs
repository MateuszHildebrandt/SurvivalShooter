using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float bulletForce = 10f;
        [Header("Resources")]
        [SerializeField] GameObject bulletPrefab;

        private Camera _camera;
        private SpriteRenderer _spriteRenderer;

        private float _bulletOffset = 0.2f;

        private void Awake()
        {
            _camera = Camera.main;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            //TODO: shoot on click
        }

        [ExposeMethodInEditor]
        public void Shoot()
        {
            Vector2 mouseWorldPoint = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
            Debug.DrawRay(transform.position, direction, Color.red, 1);
            GameObject bullet = Instantiate(bulletPrefab, SetBulletPosition(direction), Quaternion.identity, transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 5);
        }

        private Vector3 SetBulletPosition(Vector2 direction)
        {
            Bounds bounds = _spriteRenderer.bounds;

            //4 directions
            if (direction.x > 0)
                return new Vector2(bounds.max.x + _bulletOffset, bounds.center.y);
            else if (direction.x < 0)
                return new Vector2(bounds.min.x - _bulletOffset, bounds.center.y);
            else if (direction.y > 0)
                return new Vector2(bounds.center.x + _bulletOffset, bounds.max.y);
            else
                return new Vector2(bounds.center.x, bounds.min.y - _bulletOffset);

        }
    }
}
