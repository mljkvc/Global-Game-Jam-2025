using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D my_collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        my_collider = GetComponent<CircleCollider2D>();
    }

    private void OnMouseDown()
    {
        rb.gravityScale = -0.8f;
        my_collider.sharedMaterial = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
