using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo3 : MonoBehaviour
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D colide)
    {
        if (colide.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }


}
