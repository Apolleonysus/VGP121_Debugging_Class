using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;  // Reference to the player's SpriteRenderer

    [Range(0, 10)]
    public float xVel;
    [Range(0, 10)]
    public float yVel;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public Projectile projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Find the SpriteRenderer component in the parent (Player) GameObject
        playerSpriteRenderer = GetComponentInParent<SpriteRenderer>();

        if (xVel == 0 && yVel == 0)
            xVel = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Please set default values on the shoot script for object " + gameObject.name);
    }

    public void Fire()
    {
        if (!playerSpriteRenderer.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointRight.position, Quaternion.identity);
            curProjectile.SetVelocity(xVel, yVel);
        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointLeft.position, Quaternion.identity);
            curProjectile.SetVelocity(-xVel, yVel); // Negative xVel for left direction
        }
    }
}
