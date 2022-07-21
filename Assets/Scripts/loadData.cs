using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadData : MonoBehaviour
{
    public Text scoreTexto, scoreNumb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("score");
        scoreTexto.text = "Your high score is: "; 
        scoreNumb.text = SaveDATA.maxScore.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
