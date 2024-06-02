using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tombolsetting : MonoBehaviour
{
    public GameObject Menu_Awal;
    public GameObject Menu_Info;
    public GameObject Menu_setting;

    public void OnMouseUpAsButton()
    {
        Menu_setting.SetActive(true);
        Menu_Info.SetActive(false);
        Menu_Awal.SetActive(false);
            
    }
 



}
