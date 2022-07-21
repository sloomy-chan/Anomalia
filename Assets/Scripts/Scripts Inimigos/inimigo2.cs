using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo2 : MonoBehaviour
{
    public float speed, stop, close, startFire;
    private float fireRate;
    public GameObject projectile;
    private Transform Char;

    private void Start()
    {
        Char = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Char.position) > stop)
        {
            transform.position = Vector2.MoveTowards(transform.position, Char.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Char.position) < stop && Vector2.Distance(transform.position, Char.position) > close)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, Char.position) < close)
        {
            transform.position = Vector2.MoveTowards(transform.position, Char.position, -speed * Time.deltaTime);
        }


        if (fireRate <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            fireRate = startFire;
        }

        else
        {
            fireRate -= Time.deltaTime;
        }
    }

}
