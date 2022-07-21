using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aspidshot : MonoBehaviour
{
    private Transform shootAt;
    private Vector2 target;

    void Start()
    {
        shootAt = GameObject.FindGameObjectWithTag("target").transform;
        target = new Vector2(shootAt.position.x, shootAt.position.y);
    }

    void Update()
    {

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D colide)
    {
        if (colide.CompareTag("target"))
        {
            this.gameObject.SetActive(false);
        }

      
            if (colide.CompareTag("Player") && colide.GetComponent<Movimento>().vida > 0)
            {
                this.gameObject.SetActive(false);
            colide.GetComponent<Movimento>().vida -= 1;
            colide.GetComponent<Movimento>().part.Play();
            colide.GetComponentInChildren<AudioSource>().Play();
        }
 
    }



}
