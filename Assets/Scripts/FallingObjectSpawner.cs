
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // Prefab objekta koji pada
    public GameObject vucko; // Referenca na objekat Vucko
    public float spawnInterval = 2f; // Interval između spawn-ova

    // Start is called before the first frame update
    void Start()
    {
        if (vucko == null)
        {
            Debug.LogError("Vucko objekat nije dodeljen!");
        }

        // Počni spawnovanje objekata u regularnim intervalima
        InvokeRepeating("SpawnFallingObject", 0f, spawnInterval); // Ponavljaj spawn svakih `spawnInterval` sekundi
    }

    void SpawnFallingObject()
    {
        // Dobijanje pozicije objekta Vucko
        Vector3 vuckoPosition = vucko.transform.position;

        // Randomizacija X pozicije u opsegu oko Vucko objekta
        float randomX = Random.Range(-2.2f, 2.2f); // Odredjujemo opseg u kojem objekti mogu iskakati

        // Pozicija spawn-a sa random X, dok Y pozicija ostaje ista kao Y pozicija Vucko objekta
        Vector2 spawnPosition = new Vector2(randomX, vuckoPosition.y - 1.69f);

        // Instantiate prefab na poziciji spawn
        Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);

        // Ako želiš dodatno randomizovati brzinu ili nešto drugo, to možeš postaviti ovde
    }
}
