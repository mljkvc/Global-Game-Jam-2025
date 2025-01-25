using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 5f;  // Brzina pomeranja zmije
    public float minY = -3f;  // Minimalna Y pozicija
    public float maxY = 3f;   // Maksimalna Y pozicija

    private int clickCount = 0;  // Broj klikova na zmiju
    private bool isReversing = false;  // Da li zmija ide unazad

    void Start()
    {
        // Postavi zmiju na nasumičnu Y poziciju između -3 i 3
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
    }

    void Update()
    {
        if (isReversing)
        {
            // Ako je zmija u režimu povlačenja unazad, pomeri je u suprotnom pravcu (X-osa)
            transform.Translate(Vector3.left * speed * 2 * Time.deltaTime);
        }
        else
        {
            // Pomeri zmiju po X osi u desno
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    // Ova metoda se poziva svaki put kada klikneš na zmiju
    void OnMouseDown()
    {
        clickCount++;

        if (clickCount >= 3)
        {
            // Kada klikneš tri puta, promeni pravac zmije
            isReversing = true;
            Debug.Log("Zmija se povlači unazad!");
        }
    }
}
