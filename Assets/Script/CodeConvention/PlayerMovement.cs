using UnityEngine;

/// <summary>
/// Handles simple horizontal movement for the player.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Reads horizontal input and applies movement to the Rigidbody.
    /// </summary>
    private void Move()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 velocity = new Vector3(input * _moveSpeed, _rigidbody.linearVelocity.y, 0f);
        _rigidbody.linearVelocity = velocity;
    }
}
