﻿
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 5f;  // Brzina pomeranja zmije
    public float minY = -3f;  // Minimalna Y pozicija
    public float maxY = 3f;   // Maksimalna Y pozicija

    private int clickCount = 0;  // Broj klikova na zmiju
    private bool isReversing = false;  // Da li zmija ide unazad

    private Animator animator;

    float armPosY;
    

    void Start()
    {
        // Postavi zmiju na nasumičnu Y poziciju između -3 i 3
        float randomY = Random.Range(minY, ArmController.instance.transform.position.y + 7);
        transform.position = new Vector3(transform.position.x, randomY, transform.position.z);


        Debug.Log($"Spawn Cobra at Y: {randomY}, Arm Y: {ArmController.instance.transform.position.y + 7}");
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == ArmController.instance.gameObject)
        {
            ArmController.instance.MoveHandDownCobra();
            isReversing |= true;
        }
    }

    void Update()
    {
        armPosY = ArmController.instance.transform.position.y;
        if(armPosY >= -2.1f)
        {
            isReversing = true; 
        }
        if (isReversing)
        {
            // Ako je zmija u režimu povlačenja unazad, pomeri je u suprotnom pravcu (X-osa)
            transform.Translate(Vector3.left * speed * 2 * Time.deltaTime);
            if(transform.position.x < -6.5f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Pomeri zmiju po X osi u desno
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if(transform.position.x > 10)
            {
                Destroy(gameObject);
            }
        }
    }

    // Ova metoda se poziva svaki put kada klikneš na zmiju
    void OnMouseDown()
    {

        animator.SetTrigger("udarena"); 
        
        clickCount++;

        if (clickCount >= 3)
        {
            // Kada klikneš tri puta, promeni pravac zmije
            isReversing = true;
            Debug.Log("Zmija se povlači unazad!");
        }
    }
}
