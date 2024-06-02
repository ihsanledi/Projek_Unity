using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ballscript : MonoBehaviour
{
    //Vector3 initialPos; // ball's initial position
    public string hitter;
    public GameObject bola;
    public GameObject Player;
    public int playerScore;
    public int botScore;
    public int forceValue;
    public bool sudahmain;
    public bool playing = true;
   public float forceUp;
   public float forceN;

   public GameObject MenuMenang;
   public GameObject MenuKalah;
   // public bool pukulan1 = false;//
   // public bool pukulan2 = false;//
   // int force;//
   // int forceup;//


    [SerializeField] Text PlayerScoreText;
    [SerializeField] Text BotScoreText;
   [SerializeField] public Text Force;

    private void Start()
    {
        forceN = GameObject.Find("Player").GetComponent<PlayerScript>().Forces;
        forceUp = GameObject.Find("Player").GetComponent<PlayerScript>().ForcesUp;
        
        //initialPos = transform.position; // default it to where we first place it in the scene
        playerScore = 0;
        botScore = 0;
        //gaya = GameObject.Find("Player").GetComponent<shotmanajer>().Force;
       // gayaAtas = GameObject.Find("Player").GetComponent<shotmanajer>().ForceUp;
    }

    private void Update()
    {
        forceN = GameObject.Find("Player").GetComponent<PlayerScript>().Forces;
        forceUp = GameObject.Find("Player").GetComponent<PlayerScript>().ForcesUp;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (bola.transform.position.y >1)
        {
            GameObject.Find("Kumpulan Suara").GetComponent<SistemKumpulanSuara>().U_SuaraSFX(6);

        }

        // if (pukulan1 = true)//
        // {
        //     forceup = 2;
        //     force = 30;

        // }
        // else if (pukulan2 = true)//
        // {
        //     forceup = 1;//
        //     force = 40;//
        // }

        if (collision.transform.CompareTag("in") && playing)
        {
            if (playing)
            {
                GetComponent<TrailRenderer>().enabled = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero; // reset it's velocity to 0 so it doesn't move anymore
                GameObject.Find("Player").GetComponent<Pergerakan_player>().h = 0;
                GameObject.Find("Player").GetComponent<Pergerakan_player>().v = 0;
                if (hitter == "Player")
                {
                    playerScore++;
                    updateScore();


                }
                else if (hitter == "Bot")
                {
                    playerScore++;
                    updateScore();


                }
            }

            playing = false;
            if (GameObject.Find("Player").GetComponent<PlayerScript>().lempar == false && playing == false)
            {
                GameObject.Find("Player").GetComponent<PlayerScript>().Reset();
            }
        }

        if (collision.transform.CompareTag("Inbot")){
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero; // reset it's velocity to 0 so it doesn't move anymore
            GameObject.Find("Player").GetComponent<Pergerakan_player>().h = 0;
            GameObject.Find("Player").GetComponent<Pergerakan_player>().v = 0;

            if (playing)
            {
                if (hitter == "Player")
                {
                    botScore++;
                    updateScore();


                }
                else if (hitter == "Bot")
                {
                    botScore++;
                    updateScore();


                }
            }
            
            playing = false;

            if (GameObject.Find("Player").GetComponent<PlayerScript>().lempar == false && playing == false)
            {
                GameObject.Find("Player").GetComponent<PlayerScript>().Reset();
            }
        }
        

        if (collision.transform.CompareTag("wall") || collision.transform.CompareTag("out") || collision.transform.CompareTag("batas belakang") || collision.transform.CompareTag("batas kanan") || collision.transform.CompareTag("batas kiri") && playing) // if the ball hits a wall
        {
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero; // reset it's velocity to 0 so it doesn't move anymore
            GameObject.Find("Player").GetComponent<Pergerakan_player>().h = 0;
            GameObject.Find("Player").GetComponent<Pergerakan_player>().v = 0;

            if (playing)
            {
                if (hitter == "Player")
                {
                    botScore++;
                    updateScore();


                }
                else if (hitter == "Bot")
                {
                    playerScore++;
                    updateScore();


                }
            }
            
            playing = false;

            if (GameObject.Find("Player").GetComponent<PlayerScript>().lempar == false && playing == false)
            {
                GameObject.Find("Player").GetComponent<PlayerScript>().Reset();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
       {
           Force.text =  "Force       " + forceN + "\nUP Force  " + forceUp;
       }

        if (other.CompareTag("Player") || other.CompareTag("Bot"))
        {
            GameObject.Find("Kumpulan Suara").GetComponent<SistemKumpulanSuara>().U_SuaraSFX(6);
        }

        if (other.CompareTag("out") && playing)
        {
            if (hitter == "Player")
            {
                botScore++;
                updateScore();
                playing = false;

            }
            else if (hitter == "Bot")
            {
                playerScore++;
                updateScore();
                playing = false;
            }

            
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(3);

    }

    void updateScore()
    {
        //Destroy(GameObject.Find("ball"), 2.5f);
        PlayerScoreText.text = "Player Score \n" + playerScore;
        BotScoreText.text = "Bot Score \n" + botScore;
        //Force.text = "Up Force " + forceup + "\n Force " + force;//
        GameObject.Find("Kumpulan Suara").GetComponent<SistemKumpulanSuara>().U_SuaraSFX(1);
        // Destroy(GameObject.Find("ball"));
        StartCoroutine(Delay());
        this.GameObject().GetComponent<TrailRenderer>().enabled = false;
        this.GameObject().GetComponent<MeshRenderer>().enabled = false;
        transform.position = GameObject.Find("Player").GetComponent<PlayerScript>().posisiawalbola;
        this.GameObject().SetActive(false);

       

        
    }

    public void tampilkan(){
         if (playerScore == 6){
            MenuMenang.SetActive(true);
            
            
        }
        else if (botScore == 6){
            MenuKalah.SetActive(true);
            
        }
    }
       
    
}
