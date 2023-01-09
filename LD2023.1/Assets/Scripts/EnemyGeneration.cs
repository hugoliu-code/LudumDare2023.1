using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] GameObject basicEnemy;
    [SerializeField] float spawnRadius;
    [SerializeField] GameObject player;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(SpawnWave(20, 30, 90, 1f));
        startTime = Time.time;
        StartCoroutine(MediumSpawns());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MediumSpawns()
    {
        yield return new WaitForSeconds(15);
        while(Time.time - startTime < 666)
        {
            yield return new WaitForSeconds(Random.Range(20, 30));
            Debug.Log("Spawning: " + (int)((Time.time - startTime) / 60) * 5 + 5);

            StartCoroutine(SpawnWave((int)((Time.time - startTime) / 60) * 5+5, Random.Range(0, 360), Random.Range(0, 360), 2));
        }
    }
    //spawn a wave of a certain number of enemies, in a certain range (a range of degrees), at a certain spsed (spawns per second)
    IEnumerator SpawnWave(int number, float range, float direction, float speed)
    {
        while(number > 0)
        {
            SpawnEnemy(basicEnemy, Random.Range(direction - range / 2, direction + range / 2));
            yield return new WaitForSeconds(1f / speed);
            number--;
        }
    }
    //direction from 0 degrees to 360
    void SpawnEnemy(GameObject enemy, float direction)
    {
        Vector3 enemySpawnDirection = new Vector3(Mathf.Cos(direction * Mathf.Deg2Rad), Mathf.Sin(direction * Mathf.Deg2Rad),0);
        Instantiate(enemy, player.transform.position+enemySpawnDirection*spawnRadius, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(player.transform.position, spawnRadius);
    }
}
