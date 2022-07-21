using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilProperties : MonoBehaviour
{

    public int valorDano;
    public float velocidadeProj;
    public bool startTimer;
    public float aliveTimer;
    public float maxTimer;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.CompareTag("Projetil"))
        {
            var corpo = this.GetComponent<Rigidbody2D>();
            corpo.AddForce(corpo.transform.up * velocidadeProj, ForceMode2D.Impulse);
        }
      


        if(startTimer == true)       
            aliveTimer += 1 * Time.deltaTime;

        if (aliveTimer >= maxTimer)
            this.gameObject.SetActive(false);
    }

    /*
    private void OnTriggerEnter2D(Collider2D obst)
    {
        if (obst.CompareTag("Obstaculo"))
            
    }
    */
}
