using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CholestrolSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    public float enemyCount = 20f;
    int enemyCounter = 0;

    public Vector3[] positions;
    [SerializeField] private bool random;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    void Update()
    {
        if (enemyCounter >= enemyCount)
        {
            StopCoroutine(SpawnEnemyRoutine());
            if (GameObject.FindGameObjectsWithTag("Virus").Length == 0)
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
                if(random){
                    transform.position = positions[Random.Range(0,positions.Length)];
                } else{
                    transform.position = positions[enemyCounter];
                }
                
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemyCounter++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
