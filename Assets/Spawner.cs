using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab;

    void Start()
    {
        // InvokeRepeating("SpawnAsteroid", 0f, 5f);
    }

    private void SpawnAsteroid()
    {
        Vector2 spawnPosition = new Vector2(-6f, -3f);
        GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
        asteroid.transform.position = spawnPosition;
    }
}
