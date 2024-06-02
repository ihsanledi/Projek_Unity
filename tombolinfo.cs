using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tombolsetting1 : MonoBehaviour
{
    public GameObject Menu_Awal;
    public GameObject Menu_Info;
    public GameObject Menu_setting;

    public void OnMouseUpAsButton()
    {
        Menu_Info.SetActive(true);
        Menu_Awal.SetActive(false);
        Menu_setting.SetActive(false);
    }
  
}

