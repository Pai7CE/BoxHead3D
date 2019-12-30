using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public GameObject playerToFollow;
    public float spawnPeriod = 3.0f;
    public List<GameObject> spawns = new List<GameObject>();

    private GameObject spawn0;
    private GameObject spawn1;
    private GameObject spawn2;
    private GameObject spawn3;

    IEnumerator spawnInterval()
    {
        while (true)
        {
            spawnEnemy();
            yield return new WaitForSeconds(spawnPeriod);
        }
    }
    void Start()
    {
        StartCoroutine(spawnInterval());
        spawn0 = spawns[0];
        spawn1 = spawns[1];
        spawn2 = spawns[2];
        spawn3 = spawns[3];
    }
    
    private void spawnEnemy()
    {
        int randomSpawn = Mathf.RoundToInt(Random.Range(0f, spawns.Count-1));
        print(randomSpawn);
        GameObject enemy;
        enemy = Instantiate(enemyToSpawn, spawns[randomSpawn].transform.position, spawns[randomSpawn].transform.rotation);
        enemy.GetComponent<EnemyController>().target = playerToFollow;
    }
}
