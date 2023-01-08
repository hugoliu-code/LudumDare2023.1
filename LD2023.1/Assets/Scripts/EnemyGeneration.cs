using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] GameObject basicEnemy;
    [SerializeField] float spawnRadius;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnWave(200, 100, 90, 20));
    }

    // Update is called once per frame
    void Update()
    {
        
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
