using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemKumpulanSuara : MonoBehaviour
{
    public static SistemKumpulanSuara Instance;
    public AudioClip[] DataSuara;
    public AudioSource SourceSuaraSFX;



    private void OnEnable()
    {
        Instance = this;
    }

    public void U_SuaraSFX(int IDSuara)
    {
        SourceSuaraSFX.PlayOneShot(DataSuara[IDSuara]);
    }

}
