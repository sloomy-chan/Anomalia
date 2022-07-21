using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilEnem1 : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D colide)
    {
        if (colide.CompareTag("Player") && colide.GetComponent<Movimento>().vida > 0)
        {
            this.gameObject.SetActive(false);
                colide.GetComponent<Movimento>().vida -= 1;
            colide.GetComponent<Movimento>().part.Play();
            colide.GetComponentInChildren<AudioSource>().Play();
        }
    }


}
