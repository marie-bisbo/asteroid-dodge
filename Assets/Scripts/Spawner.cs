using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 screenBounds;

    [SerializeField]
    private GameObject asteroidPrefab;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        AddForceToAsteroids();
        // InvokeRepeating("AddForceToAsteroids", 3f, 3f);
    }

    // Alternative way to get asteroids into the scene
    private void SpawnAsteroid()
    {
        // Want to spawn an asteroid at a random location just outside every few seconds
        // Option 1: Randomly pick a position based on camera and spawn asteroid there
        // Option 2: Add empty game objects at various locations and randomly choose from these
        GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
        float spawnPositionX = Random.Range(-screenBounds.x, screenBounds.x);
        float spawnPositionY = Random.Range(-screenBounds.y, screenBounds.y);
        asteroid.transform.position = new Vector2(spawnPositionX, spawnPositionY);
    }

    private void AddForceToAsteroids()
    {
        Asteroid[] asteroids = FindObjectsOfType<Asteroid>();
        foreach(Asteroid asteroid in asteroids)
        {
            float forceX = Random.Range(-100, 100f);
            float forceY = Random.Range(-100, 100f);
            asteroid.rigidBody.AddForce(new Vector2(forceX, forceY));
        }
    }
}
