using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo4 : MonoBehaviour
{
    public float speed, startFire;
    private float fireRate;
    public GameObject projectile;
    public bool move = true;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (transform.position.x > 3f)
        {
            move = false;
        }

        else if (transform.position.x < -3f)
        {
            move = true;
        }

        if (move == true)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
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
