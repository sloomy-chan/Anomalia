using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    public int diceValue;
    public float diceTiming;
    public Movimento playerCode;
    public GameObject player;
    public Text textBox;
    public ProjetilProperties projetil;
    public GameObject shotgunPrefab;
    public GameObject defaultProjetil;
    public GameObject laserPrefab;
    public Image alertaImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (diceTiming > 15 && player.GetComponent<Movimento>().vida > 0)
            alertaImage.gameObject.SetActive(true);
        else
            alertaImage.gameObject.SetActive(false);


        //Um contador de rng que escolhe um número aleatório a cada 20 segundos
        if (player.GetComponent<Movimento>().vida > 0)
        {
            diceTiming += 1 * Time.deltaTime;
        }

        if (diceTiming >= 20)
        {
            diceValue = Random.Range(1, 13);
            diceTiming = 0;
        }
        //Se diceValue = 1, então o jogador só pode se mover pros lados:.
        //Se diceValue = 4, então não dá pra atirar
        //Se diceValue = 5, então os controles serão invertidos, e o tempo será menor
        if (diceValue == 1)
        {
            textBox.text = "STRAFE";    
        }
          
        if (diceValue == 4)
        {
            textBox.text = "PACIFIST";
            diceTiming += 10 * Time.deltaTime;
        }
        

        if (diceValue == 5)
        {
            textBox.text = "INVERTED";
            textBox.rectTransform.localScale = new Vector3(-1, 1);
        }
        else
            textBox.rectTransform.localScale = new Vector3(1, 1);

        //Duplica a velocidade
        if (diceValue == 2)
        {
            playerCode.MoveSpeed = 4;
            textBox.text = "WEEEEEEEEE";
        }           
        else
            playerCode.MoveSpeed = 2;
    
        //Põe a vida em 1
        if (diceValue == 3)
        {
            LowHealth();
            textBox.text = "LOW HEALTH";
        }            

        //Câmera rápida
        if (diceValue == 6)
        {
            Time.timeScale = 2f;
            diceTiming += 3 * Time.deltaTime;
            textBox.text = "FAST MOTION";
        }

        //Menos dano
        if (diceValue == 7)
        {
            textBox.text = "DAMAGE --";
            projetil.valorDano = 1;
        }      
        else
            projetil.valorDano = 2;

        //Mais dano
        if (diceValue == 8)
        {
            projetil.valorDano = 4;
            textBox.text = "DAMAGE ++";
        }
        else
            projetil.valorDano = 2;

        //Shotgun
        if (diceValue == 9)
        {
            playerCode.prefabProjetil = shotgunPrefab;
            textBox.text = "SHOTGUN";
        }
        else
            playerCode.prefabProjetil = defaultProjetil;

        //Laser
        if (diceValue == 10)
        {
            laserPrefab.SetActive(true);
            textBox.text = "LASER";
        }
        else
            laserPrefab.SetActive(false);

        //Inverte o sprite
        if (diceValue == 11)
        {
            player.GetComponent<SpriteRenderer>().flipY = true;
            textBox.text = "HUH";
        }

        //Te deixa gigante
        if (diceValue == 12)
        {
            player.GetComponent<Transform>().localScale = new Vector3(2, 2);
            textBox.text = "GIANT";
        }

        if(diceValue == 13)
        {
            player.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f);
            textBox.text = "SMALL";
        }



        void LowHealth()
        {
          
            if (player.GetComponent<Movimento>().vida == 5)
                player.GetComponent<Movimento>().vida -= 4;

            if (player.GetComponent<Movimento>().vida == 4)
                player.GetComponent<Movimento>().vida -= 3;

            if (player.GetComponent<Movimento>().vida == 3)
                player.GetComponent<Movimento>().vida -= 2;

            if (player.GetComponent<Movimento>().vida == 2)
                player.GetComponent<Movimento>().vida -= 1;
        }
    }
}
