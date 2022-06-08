using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float _health = 100f;

    public float Health
    {
        get => _health;
        set => _health = value;
    }
}
