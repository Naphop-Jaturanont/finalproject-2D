using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public float bounceForce = 10f; // The force to apply when bouncing
    public float minVelocity = 1f; // The minimum velocity required to trigger a bounce
    public PhysicsMaterial2D bounceMaterial; // The physics material to use when bouncing

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = bounceMaterial;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > minVelocity)
        {
            Vector2 direction = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(rb.velocity.magnitude, bounceForce);
        }
    }
}