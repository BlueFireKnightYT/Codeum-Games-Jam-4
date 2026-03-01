using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    colliding pointScript;

    GameObject player;
    public GameObject enemyPrefab;
    public float spawnrate = 4;
    public float minSpawnRate;
    int lastCheckedPoints = 0;
    int nextCheckPoint = 10;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        pointScript = player.GetComponent<colliding>();
        StartCoroutine(spawnTimer());
    }
    void SpawnEnemy()
    {
        // 0: Left, 1: Right, 2: Bottom, 3: Top
        int side = Random.Range(0, 4);
        Vector3 viewportPos = Vector3.zero;

        switch (side)
        {
            case 0: viewportPos = new Vector3(-0.1f, 0.5f, 10f); break; // Left
            case 1: viewportPos = new Vector3(1.1f, 0.5f, 10f); break;  // Right
            case 2: viewportPos = new Vector3(0.5f, -0.1f, 10f); break; // Bottom
            case 3: viewportPos = new Vector3(0.5f, 1.1f, 10f); break;  // Top
        }

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
        Instantiate(enemyPrefab, worldPos, Quaternion.identity);
    }

    void LowerSpawnRate()
    {
        if (pointScript.points >= nextCheckPoint)
        { 
            lastCheckedPoints = pointScript.points;

            spawnrate = Mathf.Max(minSpawnRate, spawnrate - 0.4f);
            Debug.Log(spawnrate);
            nextCheckPoint += 10;
        }
    }

    IEnumerator spawnTimer()
    {
        while (true)
        {
            SpawnEnemy();
            LowerSpawnRate();
            yield return new WaitForSeconds(spawnrate);
        }
    }
}
