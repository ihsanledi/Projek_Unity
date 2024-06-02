using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tombolkembali : MonoBehaviour
{
    public GameObject Menu_Awal;
    public GameObject Menu_Info;
    public GameObject Menu_setting;

    public void OnMouseUpAsButton()
    {
        Menu_Awal.SetActive(true);
        Menu_Info.SetActive(false);
        Menu_setting.SetActive(false);
    }
}
