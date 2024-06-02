using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    public Transform aimTarget; // the target where we aim to land the ball
    public Transform MainCamera;
    public Transform ball; // the ball

    public GameObject bola;

    public bool bergerak = true;
    public bool Targeting = false;

    public float Forces;
    public float ForcesUp;
    public float ForcesStart;
    public int gantiPukulan;
    public float ForcesUpStart;
    Animator animator;

    public Vector3 posisiRaket;
    Vector3 aimTargetInitialPosition; // initial position of the aiming gameObject which is the center of the opposite court
    Vector3 MainCameraReset;
    

    shotmanajer shotManager; // reference to the shotmanager component
    Shot currentShot; // the current shot we are playing to acces it's attributes
    public Vector3 posisiawalbola;

    [SerializeField] Text tipe_shot;
    [SerializeField] Transform serveRight;
    [SerializeField] Transform serveLeft;

    public bool ending;
    float GerakanTarget;
    float Power;
    float power2;
    bool servedRight = true;
    public bool lempar = true;

    // Start is called before the first frame update
    void Start()
    {
        posisiawalbola = ball.GetComponent<Transform>().position;
        gantiPukulan = 1;


        Forces = GameObject.Find("Player").GetComponent<shotmanajer>().topSpin.hitForce;
        ForcesUp = GameObject.Find("Player").GetComponent<shotmanajer>().topSpin.upForce;

        animator = GetComponent<Animator>(); // referennce out animator

        shotManager = GetComponent<shotmanajer>(); // accesing our shot manager component 

        aimTargetInitialPosition = aimTarget.position; // initialise the aim position to the center( where we placed it in the editor )
        posisiRaket = GameObject.Find("raket").transform.position;


        currentShot = shotManager.topSpin; // defaulting our current shot as topspin

        //Forces = GetComponent<shotmanajer>().Force;

        // ForcesUp = GetComponent<shotmanajer>().ForceUp;

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    if (!ending){

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (lempar)
            {
                currentShot = shotManager.flatServe;
                GetComponent<BoxCollider>().enabled = false;
                Vector3 dir = aimTarget.position - transform.position; // get the direction to where we want to send the ball
                ball.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce,0) ;
                tipe_shot.text = "Shot type:\nFlat Serve";

            if (ball.GetComponent<Ballscript>().playing == true)
            {
                lempar = false;
            }
           // ball.GetComponent<Ballscript>().pukulan2 = true;
           }
        }

    

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (lempar)
            {
                tipe_shot.text = "Shot type:\nKick Serve";
                currentShot = shotManager.kickServe;
                GetComponent<BoxCollider>().enabled = false;
                Vector3 dir = aimTarget.position - transform.position; // get the direction to where we want to send the ball
                ball.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce,0) ;
                 

                if (ball.GetComponent<Ballscript>().playing == true)
                {
                    lempar = false;
                }
               // ball.GetComponent<Ballscript>().pukulan1 = true;
            }
        }

        if (Input.GetKey(KeyCode.Y))
        {
            Targeting = true;

            GerakanTarget = Input.GetAxisRaw("Horizontal");

            GameObject.Find("Target").GetComponent<Transform>().Translate(new Vector3(GerakanTarget, 0, 0) * 40f * Time.deltaTime);
        }

        //charge
        if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            gantiPukulan++;

            if(gantiPukulan % 2 == 1){
                tipe_shot.text = "Shot type:\nForehand";
                Forces = GameObject.Find("Player").GetComponent<shotmanajer>().topSpin.hitForce;
                ForcesUp = GameObject.Find("Player").GetComponent<shotmanajer>().topSpin.upForce;
            }
            else{
                tipe_shot.text = "Shot type:\nBackhand";
                Forces = GameObject.Find("Player").GetComponent<shotmanajer>().flat.hitForce;
                ForcesUp = GameObject.Find("Player").GetComponent<shotmanajer>().flat.upForce;
            }
            if (gantiPukulan == 2){
                gantiPukulan = 0;
            }
        }

       

        //servis
        if (ball.GetComponent<Ballscript>().playerScore != 6 &ball.GetComponent<Ballscript>().botScore != 6){
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.L))
        {
             

            if (lempar)
            {
                animator.Play("pukul kanan");
               //Instantiate(ball, new Vector3(GameObject.Find("raket").GetComponent<Transform>().position.x, GameObject.Find("raket").GetComponent<Transform>().position.y +4f,GameObject.Find("raket").GetComponent<Transform>().position.z), Quaternion.identity);

                ball.GetComponent<Ballscript>().Force.text =  "Force       " + currentShot.hitForce + "\nUP Force  " + currentShot.upForce;

                bergerak = true;
                GameObject.Find("Kumpulan Suara").GetComponent<SistemKumpulanSuara>().U_SuaraSFX(6);

                ball.GetComponent<Ballscript>().hitter = "Player";
                bola.SetActive(true);
                //Instantiate(ball,new  Vector3(posisiRaket.x,0,posisiRaket.z),Quaternion.identity);
                ball.GetComponent<MeshRenderer>().enabled = true;
                ball.GetComponent<TrailRenderer>().enabled = true;
                
                GetComponent<BoxCollider>().enabled = true;

                ball.transform.position = transform.position + new Vector3(0.2f, 1, 0);

                ball.GetComponent<Ballscript>().playing = true;

                if (ball.GetComponent<Ballscript>().playing == true){
                    lempar = false;
                }
                 
            }

        }
        }
        else{
            ball.GetComponent<Ballscript>().tampilkan();
        }

        }
    }
       
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Ball"))// if we collide with the ball 
        {
            Vector3 dir = aimTarget.position - transform.position; // get the direction to where we want to send the ball
            other.GetComponent<Rigidbody>().velocity = dir.normalized * Forces + new Vector3(0, ForcesUp, 0);
            //add force to the ball plus some upward force according to the shot being played

            Vector3 ballDir = ball.position - transform.position; // get the direction of the ball compared to us to know if it is

            if (ballDir.x >= 0)                                   // on out right or left side 
            {
                animator.Play("pukul kanan");                        // play a forhand animation if the ball is on our right
            }
            else                                                  // otherwise play a backhand animation 
            {
                animator.Play("pukul kiri"); // need to be fixed!!!
            }

            ball.GetComponent<Ballscript>().hitter = "Player";
            aimTarget.position = aimTargetInitialPosition; // reset the position of the aiming gameObject to it's original position ( center)
        }

       
    }

   


   

        public void Reset()
    {
        if (!servedRight)
        {
            bergerak = false ;
            //MainCameraReset = serveLeft.position - new Vector3 (0,0,42.03f);
            transform.position = serveLeft.position;
           //MainCamera.transform.position = MainCameraReset + new Vector3 (0,31.33f,0) ;
        }
        else
        {
            bergerak = false;
            //MainCameraReset = serveRight.position - new Vector3(0, 0, 42.03f);
            transform.position = serveRight.position;
            //MainCamera.transform.position = MainCameraReset + new Vector3(0, 31.33f, 0);
        }
        lempar = true;
        servedRight = !servedRight;
    }
    void SpawnObject()
    {
        
    }
    
}