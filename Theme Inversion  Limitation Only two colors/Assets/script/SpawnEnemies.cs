using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnrate;

    private void Start()
    {
        StartCoroutine(spawnTimer());
    }
    void SpawnEnemy()
    {
        // 0: Left, 1: Right, 2: Bottom, 3: Top
        int side = Random.Range(0, 4);
        Vector3 viewportPos = Vector3.zero;

        switch (side)
        {
            case 0: viewportPos = new Vector3(-0.1f, Random.value, 10f); break; // Left
            case 1: viewportPos = new Vector3(1.1f, Random.value, 10f); break;  // Right
            case 2: viewportPos = new Vector3(Random.value, -0.1f, 10f); break; // Bottom
            case 3: viewportPos = new Vector3(Random.value, 1.1f, 10f); break;  // Top
        }

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
        Instantiate(enemyPrefab, worldPos, Quaternion.identity);
    }

    IEnumerator spawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            SpawnEnemy();
        }
    }
}
