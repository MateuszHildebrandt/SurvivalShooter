using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
        GameObject hitObject = Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
        Destroy(hitObject, 1);
    }
}
