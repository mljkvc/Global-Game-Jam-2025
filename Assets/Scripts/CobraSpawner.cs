using UnityEngine;

public class CobraSpawner : MonoBehaviour
{
    public GameObject CobraPrefab; // Prefab objekta koji pada
  // Referenca na objekat Vucko
    public float spawnInterval = 10f; // Interval između spawn-ova
    bool isSpawning = true;
    // Start is called before the first frame update
    void Start()
    {
     

        // Počni spawnovanje objekata u regularnim intervalima
        InvokeRepeating("SpawnCobra", 0f, spawnInterval); // Ponavljaj spawn svakih `spawnInterval` sekundi
    }

    void SpawnCobra()
    {
        // Dobijanje pozicije objekta Vucko
        if (!isSpawning)
        {
            return;
        }

        if(ArmController.instance.transform.position.y >= -2.1f)
            isSpawning = false; 

        float armY = ArmController.instance.transform.position.y + 6f;
        if( armY < -2.2f)
        {
            armY = -2.2f;
        }

        // Randomizacija X pozicije u opsegu oko Vucko objekta
        float randomY = Random.Range(-2.1f, armY); // Odredjujemo opseg u kojem objekti mogu iskakati

        // Pozicija spawn-a sa random X, dok Y pozicija ostaje ista kao Y pozicija Vucko objekta
        Vector2 spawnPosition = new Vector2(-7f, randomY);

        // Instantiate prefab na poziciji spawn
        Instantiate(CobraPrefab, spawnPosition, Quaternion.identity);

        // Ako želiš dodatno randomizovati brzinu ili nešto drugo, to možeš postaviti ovde
    }
}
