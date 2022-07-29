using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Movimento : MonoBehaviour
{
    public Animator anim;
    public bool Tiro, Esq, Dir, paused;
    public GameObject prefabProjetil;
    private Rigidbody2D corpo;
    public float MoveSpeed;
    public int vida;
    public DiceRoll dado;
    public Transform balaCoord;
    public ParticleSystem part, partDeath;
    public GameObject gameOverScreen, pauseScreen;
    public AudioSource gunshot;
    public Text vidaText;

    // Start is called before the first frame update
    void Start()
    {
     
    }
    // Update is called once per frame
    void Update()
    {
        vidaText.text = vida.ToString();

        //Essas 3 linhas fazer com as variáveis Tiro, Dir, e Esq sejam equivalentes às variáveis do animator//
        anim.SetBool("Tiro", Tiro);
        anim.SetBool("VirDireita", Dir);
        anim.SetBool("VirEsquerda", Esq);

        //Movimentação
        corpo = this.GetComponent<Rigidbody2D>();
        var velocityY = corpo.velocity.y;

        if(vida > 0)
        {
            if (dado.diceValue != 5)
            {
                //Cima
                if (Input.GetKey(KeyCode.W) && dado.diceValue != 1)
                    this.corpo.velocity = new Vector3(0, MoveSpeed, 0);
                //Direita
                if (Input.GetKey(KeyCode.D))
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(MoveSpeed, 0, 0);
                }
                else
                    Dir = false;
                //Diagonal sup direita
                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && dado.diceValue != 1)
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(MoveSpeed, MoveSpeed, 0);
                }
     

                //Esquerda
                if (Input.GetKey(KeyCode.A))
                {
                    Esq = true;
                    this.corpo.velocity = new Vector3(-MoveSpeed, 0, 0);
                }
                else
                    Esq = false;
                
                //Diagonal sup esquerda
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && dado.diceValue != 1)
                {
                    Esq = true;
                    this.corpo.velocity = new Vector3(-MoveSpeed, MoveSpeed, 0);
                }
   

                //Baixo
                if (Input.GetKey(KeyCode.S) && dado.diceValue != 1)
                    this.corpo.velocity = new Vector3(0, -MoveSpeed, 0);

                //Diagonal inf esquerda
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && dado.diceValue != 1)
                {
                    Esq = true;
                    this.corpo.velocity = new Vector3(-MoveSpeed, -MoveSpeed, 0);
                }
     

                //Diagonal inf Direita
                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && dado.diceValue != 1)
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(MoveSpeed, -MoveSpeed, 0);
                }
    


            }
            else

            {
                //Baixo (Invertido)
                if (Input.GetKey(KeyCode.W) && dado.diceValue != 1)
                    this.corpo.velocity = new Vector3(0, -MoveSpeed, 0);

                //Diagonal inf esquerda (Invertido)
                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && dado.diceValue != 1)
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(-MoveSpeed, -MoveSpeed, 0);
                }

                //Esquerda (Invertido)
                if (Input.GetKey(KeyCode.D))
                {
                    Esq = true;
                    this.corpo.velocity = new Vector3(-MoveSpeed, 0, 0);
                }
                else
                    Esq = false;

                //Diagonal inf (Invertido)
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && dado.diceValue != 1)
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(MoveSpeed, -MoveSpeed, 0);
                }

                //Direita (Invertido)
                if (Input.GetKey(KeyCode.A))
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(MoveSpeed, 0, 0);
                }
                else
                    Dir = false;

                //Diagonal sup direito (Invertido)
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && dado.diceValue != 1)
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(MoveSpeed, MoveSpeed, 0);
                }

                //Diagonal sup esquerdo (Invertido)
                if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && dado.diceValue != 1)
                {
                    Dir = true;
                    this.corpo.velocity = new Vector3(-MoveSpeed, MoveSpeed, 0);
                }

                //Cima(Invertido)
                if (Input.GetKey(KeyCode.S) && dado.diceValue != 1)
                    this.corpo.velocity = new Vector3(0, MoveSpeed, 0);
            }
        }
        

        //Controla os tiros
        if (Input.GetKeyDown(KeyCode.Mouse0) && dado.diceValue != 4 && dado.diceValue != 10 && paused == false && vida > 0)
        {

            Instantiate(prefabProjetil, balaCoord);
            gunshot.Play();
            Tiro = true;
        }
        else
            Tiro = false;


        //salva
        if (vida <= 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            partDeath.Play();
            gameOverScreen.SetActive(true);    
            if(gameOverScreen.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
            {
                this.GetComponent<SaveDATA>().canSave = true;
                SceneManager.LoadSceneAsync("Menu");
            }    
        }
        else
        {
            gameOverScreen.SetActive(false);
            this.GetComponent<SaveDATA>().canSave = false;
        }
       
        //Pausa/despausa
        if(Input.GetKeyDown(KeyCode.Escape) && pauseScreen.activeSelf == false)        
            paused = true;
        
        if (Input.GetKeyDown(KeyCode.Escape) && pauseScreen.activeSelf == true)
            paused = false;
 

        if (paused == true)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
