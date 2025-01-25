using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // Prefab objekta koji pada
    public Vector2 spawnPosition = new Vector2(-1f, 3f); // Pozicija sa koje objekti padaju
    public float spawnInterval = 2f; // Interval između spawn-ova

    void Start()
    {
        // Počni spawnovanje objekata u regularnim intervalima
        InvokeRepeating("SpawnFallingObject", 0f, spawnInterval); // Ponavljaj spawn svakih `spawnInterval` sekundi
    }

    void SpawnFallingObject()
    {
        // Kreiraj objekat na random poziciji iz spawn pozicije
        Vector2 randomPosition = spawnPosition + new Vector2(Random.Range(-1f, 10f), 0); // Možeš dodati random offset na X osovini

        // Instantiate prefab na poziciji spawn
        GameObject fallingObject = Instantiate(fallingObjectPrefab, randomPosition, Quaternion.identity);

        // Ako želiš dodatno randomizovati brzinu ili nešto drugo, to možeš postaviti ovde
        Rigidbody2D rb = fallingObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Možeš postaviti brzinu pada objekta ako želiš
            rb.gravityScale = 1f; // Standardna gravitacija
        }
    }
}
