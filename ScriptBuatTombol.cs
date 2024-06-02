using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptBuatTombol : MonoBehaviour
{
    
    
     void Update()
    {
        
    }
       
    public void OnMouseClickAsButton(){
         GameObject.Find("Kumpulan Suara").GetComponent<SistemKumpulanSuara>().U_SuaraSFX(3);
    }
    
}
