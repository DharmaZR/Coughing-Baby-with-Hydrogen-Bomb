using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    public float enemyCount = 10f;
    int enemyCounter = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }
    void Update()
    {
        if (enemyCounter >= enemyCount)
        {
            StopCoroutine(SpawnEnemyRoutine());
            if(GameObject.FindGameObjectsWithTag("Virus").Length == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            if (enemyCounter < enemyCount)
            {
                transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemyCounter++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
