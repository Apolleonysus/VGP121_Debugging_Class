using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private float lifetime = 2.0f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetVelocity(float xVel, float yVel)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xVel, yVel);
        Debug.Log($"Projectile velocity set to: {rb.velocity}");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug log for collisions
        Debug.Log($"Projectile collided with: {other.gameObject.name}");

        // Destroy projectile if it collides with something that isn't the player, collectible, or power-up
        if (!other.CompareTag("Player") && !other.CompareTag("Collectible") && !other.CompareTag("PowerUp"))
        {
            Destroy(gameObject);
        }
    }
}
