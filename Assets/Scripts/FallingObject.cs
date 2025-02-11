﻿using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D my_collider;
    public Sprite[] fallingTextures;  // Niz sa različitim teksturama
    private SpriteRenderer spriteRenderer;

    public GameObject bubblePrefab; // Assign your bubble prefab in the inspector

    private Animator animator;
    bool isInBubble = false;
    private GameObject bubble = null;
    bool flagg = false; 
    bool flag1 = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        my_collider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Postavi random teksturu
        int randomIndex = Random.Range(0, fallingTextures.Length);
        spriteRenderer.sprite = fallingTextures[randomIndex];
    }

    private void OnMouseDown()
    {
        if (flagg)
            return;
        rb.gravityScale = -0.4f;
        my_collider.sharedMaterial = null;
        // Create the bubble effect
        if (!isInBubble)
        {
            bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            bubble.transform.parent = transform; // Attach to the falling object
            isInBubble = true;
        }
        else{
            if (flag1)
                return;
            //napravi animaciju
            animator.SetTrigger("Pop"); 
            rb.gravityScale = 0.4f;
            isInBubble = false; 
            Destroy(bubble);

        }
    }

    void Update()
    {
        if (ArmController.instance.transform.position.y >= -2.1f)
        {
            flag1 = true;
            OnMouseDown();
            flagg = true;

        }
        if (transform.position.y < -5f || transform.position.y > 5.5f)
        {
            if (transform.position.y < -5f) {
                ArmController.instance.MoveHandDown();
            }
            Destroy(gameObject);
        }
    }
}
