using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner4 : MonoBehaviour
{

   
    [SerializeField]
    private GameObject inimigo4;

    [SerializeField]
    public float spawnIntervalEn4 = 2.0f;



    void Start()
    {
        StartCoroutine(spawnEnemy(spawnIntervalEn4, inimigo4));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2.1f, 2.17f), Random.Range(1f, 0.98f), 0), Quaternion.identity);
   



        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
