using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDATA : MonoBehaviour
{
    public static float maxScore, currScore;
    public TimerPontos player;
    public bool canSave;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        currScore = player.pontos;
        SaveSco();

       
    }

    void SaveSco()
    {
        if (canSave == true && currScore > maxScore)
        {
            maxScore = currScore;
            PlayerPrefs.SetFloat("score", maxScore);
            PlayerPrefs.Save();
        }
    }
}
