using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo1 : MonoBehaviour
{
    public float RotateSpeed = 2f, Radius = 2f, angle, startFire, speed, stop;
    private float fireRate;
    public GameObject projectile;
    private Transform Char;

    private Vector2 centre;

    private void Start()
    {
        Char = GameObject.FindGameObjectWithTag("Player").transform;
        centre = transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Char.position) > stop)
        {
            transform.position = Vector2.MoveTowards(transform.position, Char.position, speed * Time.deltaTime);
        }

        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

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