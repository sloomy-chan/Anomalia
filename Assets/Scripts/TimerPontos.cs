using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPontos : MonoBehaviour
{
    public float tempo, pontos;
    public Text caixaTexto;
    public Spawner spwn;
    public Movimento player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TempoEPontuacao();
        caixaTexto.text = pontos.ToString("F0");

        //Controlam a dificuldade de acordo com a sua pontuação
        if (pontos >= 5000)
        {
            spwn.spawnInterval = 2f;
           // spwn.spawnIntervalEn1 = 4f;
            spwn.spawnIntervalEn2 = 4f;
            spwn.spawnIntervalEn3 = 4f;
            
        }


        if (pontos >= 10000)
        { 
            spwn.spawnInterval = 1.5f;
           // spwn.spawnIntervalEn1 = 3f;
            spwn.spawnIntervalEn2 = 3.5f;
            spwn.spawnIntervalEn3 = 3f;
        }

        if (pontos >= 15000)
        {
            spwn.spawnInterval = 1f;
            //spwn.spawnIntervalEn1 = 2.5f;
            spwn.spawnIntervalEn2 = 2f;
            spwn.spawnIntervalEn3 = 3f;
        }
            
    }


    void TempoEPontuacao()
    {
        if(player.vida > 0)
        {
            tempo += 1 * Time.deltaTime;
            pontos = tempo * 100;
        }
   
    }
}
