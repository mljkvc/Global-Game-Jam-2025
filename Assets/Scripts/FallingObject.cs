
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D my_collider;
    public Sprite[] fallingTextures;  // Niz sa različitim teksturama
    private SpriteRenderer spriteRenderer;

    public GameObject bubblePrefab; // Assign your bubble prefab in the inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        my_collider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Postavi random teksturu
        int randomIndex = Random.Range(0, fallingTextures.Length);
        spriteRenderer.sprite = fallingTextures[randomIndex];
    }

    private void OnMouseDown()
    {
        rb.gravityScale = -0.8f;
        my_collider.sharedMaterial = null;

        // Create the bubble effect
        if (bubblePrefab != null)
        {
            GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            bubble.transform.parent = transform; // Attach to the falling object
        }
    }

    void Update()
    {
        if (transform.position.y < -5f || transform.position.y > 5f)
        {
            Destroy(gameObject);
        }
    }
}
