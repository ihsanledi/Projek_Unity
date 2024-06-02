using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    public Transform bot;
    public Transform bola;
    public bool ya;
    public bool keluar;

    private void Start()
    {

    }

  




    private void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Ball") && bola.GetComponent<Ballscript>().playing == true)
        {
            bot.GetComponent<Botmusuhscript>().gerak = true;
        }
        else if (bola.GetComponent<Ballscript>().playing == false)
        {
            bot.GetComponent<Botmusuhscript>().gerak = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            bot.GetComponent<Botmusuhscript>().gerak = false;
        }
        if (other.CompareTag("Ball"))
        {
            bot.GetComponent<Botmusuhscript>().gerak = false;
            keluar = true;
        }
    }
}
