using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botmusuhscript : MonoBehaviour
{
    float speed = 30f; // moveSpeed
    //float force = 30;
    Animator animator;
    public Transform ball;
    public Transform aimTarget; // aiming gameObject
    public Transform Centerbot;
    public Transform Bot;
    public Transform[] targets; // array of targets to aim at

    Vector3 aimTargetInitialPosition; // initial position of the aiming gameObject which is the center of the opposite court
    Vector3 targetPosition; // position to where the bot will want to move
    Vector3 gerakMundur;
    shotmanajer shotManager; // shot manager class/component
    public bool gerak = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position; // initialize the targetPosition to its initial position in the court
        animator = GetComponent<Animator>(); // referennce out animator

        aimTargetInitialPosition = aimTarget.position; // initialise the aim position to the center( where we placed it in the editor )
        shotManager = GetComponent<shotmanajer>(); // reference to our shot manager to acces shots
        gerakMundur.z = Centerbot.transform.position.z;
        gerakMundur.y = 7.4f;
    }
    // Update is called once per frame
    void Update()
    {
        move();
        
    }

    private void move()
    {
        if (gerak == true && GameObject.Find("ball").GetComponent<Ballscript>().hitter == "Player")
        {
            targetPosition.x = ball.position.x; // update the target position to the ball's x position so the bot only moves on the x axis
            targetPosition.z = ball.position.z + 3f;
            //transform.position = Vector3.MoveTowards(targetPosition, transform.position, speed * Time.deltaTime); // lerp it's position

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // lerp it's position

            
        }
       else if(ball.GetComponent<Ballscript>().hitter == "Bot")
        {
            transform.position = Vector3.MoveTowards(transform.position,gerakMundur, speed * Time.deltaTime);
        }
      
    }
    Vector3 PickTarget() // picks a random target from the targets array to be aimed at
    {
        int randomValue = Random.Range(0, targets.Length); // get a random value from 0 to length of our targets array-1
        return targets[randomValue].position; // return the chosen target
    }

    Shot PickShot() // picks a random shot to be played
    {
        int randomValue = Random.Range(0, 2); // pick a random value 0 or 1 since we have 2 shots possible currently
        if (randomValue == 0) // if equals to 0 return a top spin shot type
            return shotManager.topSpin;
        else                   // else return a flat shot type
            return shotManager.flat;
    }

  

    private void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Ball"))// if we collide with the ball 
        {
            Shot currentShot = PickShot(); // pick a random shot to be played

            Vector3 dir = PickTarget() - transform.position; // get the direction to where to send the ball

            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
            //add force to the ball plus some upward force according to the shot being played

            Vector3 ballDir = ball.position - transform.position; // get the direction of the ball compared to us to know if it is
           
                animator.Play("pukulanbot");                        // play a forhand animation if the ball is on our right
            
            ball.GetComponent<Ballscript>().hitter = "Bot";
            aimTarget.position = aimTargetInitialPosition; // reset the position of the aiming gameObject to it's original position ( center)
        }


    }
}
