using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Sprite mtrSmall, mtrMed, mtrLarge;
    public int varObs;

    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private GameObject inimigo1;
    [SerializeField]
    private GameObject inimigo2;
    [SerializeField]
    private GameObject inimigo3;


    [SerializeField]
    public float spawnInterval = 2.0f;
   // [SerializeField]
 //   public float spawnIntervalEn1 = 2.0f;
    [SerializeField]
    public float spawnIntervalEn2 = 2.0f;
    [SerializeField]
    public float spawnIntervalEn3 = 2.0f;
  



    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, obstaclePrefab));
      //  StartCoroutine(spawnEnemy(spawnIntervalEn1, inimigo1));
        StartCoroutine(spawnEnemy(spawnIntervalEn2, inimigo2));
        StartCoroutine(spawnEnemy(spawnIntervalEn3, inimigo3));
      


    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        varObs = Random.Range(1, 3);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2.1f, 2.17f), Random.Range(3.1f, 3.7f), 0), Quaternion.identity);
        if (varObs == 1)
        {
            if (newEnemy.CompareTag("Obstaculo"))
            {
                newEnemy.transform.localScale = new Vector2(1f, 1f);
                newEnemy.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                newEnemy.GetComponent<SpriteRenderer>().sprite = mtrSmall;
            }
        }
           
        if (varObs == 2)
        {

            if (newEnemy.CompareTag("Obstaculo"))
            {
                newEnemy.transform.localScale = new Vector2(1f, 1f);
                newEnemy.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
                newEnemy.GetComponent<SpriteRenderer>().sprite = mtrMed;
            }
             
        }
                       
        if (varObs == 3)
        {
            if(newEnemy.CompareTag("Obstaculo"))
            {
                newEnemy.transform.localScale = new Vector2(2f, 2f);
                newEnemy.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                newEnemy.GetComponent<SpriteRenderer>().sprite = mtrLarge;
            }

        }
       
       
         
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
