using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergerakan_player : MonoBehaviour
{
    [SerializeField] public float h ;
    [SerializeField] public float v ;
    [SerializeField] float speed = 13f; // move speed

    public Transform batas_kiri;
    public Transform batas_kanan;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerScript>().bergerak == true)
        {
            // if(Input.GetKeyDown(KeyCode.RightArrow)){
            //     if (h == 0){
            //         h += 1;
            //     }
            // };// get the horizontal axis of the keyboard

            // if(Input.GetKeyUp(KeyCode.RightArrow)){
            //     h = 0;
            // };

            // if(Input.GetKeyDown(KeyCode.LeftArrow)){
            //     if (h == 0){
            //     h -= 1;
            //     }
            // }; 
            // if(Input.GetKeyUp(KeyCode.LeftArrow)){
            //     h = 0;
            // };
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical"); // get the vertical axis of the keyboard
        }



        if (h != 0 || v != 0) // if we want to move and we are not hitting the ball
        {

            if (player.position.x <35f & player.position.x >-20f & player.position.z <-20f & player.position.z >-83f ){
              transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); // move on the court
            }
            //if stuck on horizontal line
            else if (h == -1 & player.position.x >33 ){ 
                if (v != 0){
                    transform.Translate(new Vector3(0, 0, v) * speed * Time.deltaTime); // move on the court
                }
                 else{
                    transform.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime); // move on the court
                }
            }
            else if (h == 1 & player.position.x <-19){
                if (v != 0){
                transform.Translate(new Vector3(0, 0, v) * speed * Time.deltaTime); // move on the court
                }
                else{
                transform.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime); // move on the court
                }
            }
            //if stuck on vertical line
              else if (v == -1 & player.position.z > -80){
                if( h !=0 ){
                transform.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime); // move on the court
                }
                else{
                    transform.Translate(new Vector3(0, 0, v) * speed * Time.deltaTime); // move on the court
                }
            }
            else if (v == 1 & player.position.z < -15){
                if (h != 0 ){
                transform.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime); // move on the court
                }
                else{
                 transform.Translate(new Vector3(0, 0, v) * speed * Time.deltaTime); // move on the court
                }
            }
            //MainCamera.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);



        }
        
    }
}
