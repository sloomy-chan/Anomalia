using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstDamage : MonoBehaviour
{
    public int hp;
    public int dmg;
    public TimerPontos points;
    public int rotationVar;
    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
        rotationVar = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        TimerdeVida();

        if (this.CompareTag("Obstaculo"))
        {
            if (rotationVar == 1)
                this.transform.Rotate(0, 0, -60 * Time.deltaTime);

            if (rotationVar == 2)
                this.transform.Rotate(0, 0, 40 * Time.deltaTime);

            if (rotationVar == 3)
                this.transform.Rotate(0, 0, -50 * Time.deltaTime);

            if (rotationVar == 4)
                this.transform.Rotate(0, 0, 50 * Time.deltaTime);
        }
        else
            this.transform.Rotate(0, 0, 0);


        if (hp <= 0)
        {
            points.pontos += 200;
            this.GetComponent<ParticleSystem>().Play();
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            obj.GetComponent<Movimento>().vida -= 1;
            obj.GetComponent<Movimento>().part.Play();
            obj.GetComponentInChildren<AudioSource>().Play();
        }
           

        if (obj.CompareTag("Projetil") || obj.CompareTag("Laser"))
        {
            hp -= obj.GetComponent<ProjetilProperties>().valorDano;
            obj.gameObject.SetActive(false);
        }
    }

    public void TimerdeVida()
    {
        if (this.CompareTag("Obstaculo"))
            tempo += 1 * Time.deltaTime;
        if (tempo >= 10)
            this.gameObject.SetActive(false);

    }
}
