using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from player
        float horizontal = Input.GetAxis("Horizontal1");
        float vertical = Input.GetAxis("Vertical1");

        // Move character based on input
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
