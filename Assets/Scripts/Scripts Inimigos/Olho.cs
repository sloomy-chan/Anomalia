using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olho : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        var dir = player.transform.position - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
