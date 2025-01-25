using UnityEngine;

public class CobraSpawner : MonoBehaviour
{
    public GameObject CobraPrefab; // Prefab objekta koji pada
  // Referenca na objekat Vucko
    public float spawnInterval = 10f; // Interval između spawn-ova

    // Start is called before the first frame update
    void Start()
    {
     

        // Počni spawnovanje objekata u regularnim intervalima
        InvokeRepeating("SpawnCobra", 0f, spawnInterval); // Ponavljaj spawn svakih `spawnInterval` sekundi
    }

    void SpawnCobra()
    {
        // Dobijanje pozicije objekta Vucko

        // Randomizacija X pozicije u opsegu oko Vucko objekta
        float randomY = Random.Range(-2.2f, 2.2f); // Odredjujemo opseg u kojem objekti mogu iskakati

        // Pozicija spawn-a sa random X, dok Y pozicija ostaje ista kao Y pozicija Vucko objekta
        Vector2 spawnPosition = new Vector2(-11f, randomY);

        // Instantiate prefab na poziciji spawn
        Instantiate(CobraPrefab, spawnPosition, Quaternion.identity);

        // Ako želiš dodatno randomizovati brzinu ili nešto drugo, to možeš postaviti ovde
    }
}
