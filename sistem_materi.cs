using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sistem_materi : MonoBehaviour
{

    [System.Serializable]

    public class DataMateri
    {
        public string materi_nama;
        public Text materi_isi;
        public AudioClip materi_suara;

    }

    //Memasukkan class DataMateri ke dalam list _Data
    public List<DataMateri> _Data;

    [Header("Data komponen")]
    public int Data_materi;
    public Text isi;
    public Text Nama_Materi;


    public AudioSource SourceSuara;

    // Start is called before the first frame update
    void Start()
    {
        Data_materi = 0;
        U_SetMateri();
    }


    //function tombol next and prev
    public void U_tombol(bool ArahKanan)
    {
        SistemKumpulanSuara.Instance.U_SuaraSFX(0);

        if (ArahKanan)
        {
            
            
            if (Data_materi <= _Data.Count) 
            {
                Data_materi++;
                U_SetMateri();

                SourceSuara.Play();

            }
            else
            {
                Data_materi--;
            }
           
        }
        else
        {
            

            if (Data_materi > 0)
            {
                Data_materi--;
                U_SetMateri();

                SourceSuara.Play();

            }
            else
            {
                Data_materi++;
            }
        }

        
    }



    //mengatur materi yang ditampilkan
    public void U_SetMateri()
    {
        isi.GetComponent<Animation> ().Play ("Animasi Materi");
        
        //mention gambar dan text dari list data yang ada di class
        // Gambar_materi.sprite = _Data[Data_materi].materi_isi;
        Nama_Materi.text = _Data[Data_materi].materi_nama;
        // isi.text = _Data[Data_materi].materi_isi;
        U_SetSuara();




    }

    public void U_SetSuara()
    {
        if (SourceSuara.clip != null && SourceSuara.isPlaying)
        {
            SourceSuara.Stop();

        }

        SourceSuara.clip = _Data[Data_materi].materi_suara;
    }

    public void U_panggilSuara()
    {
        SistemKumpulanSuara.Instance.U_SuaraSFX(0);

        if (SourceSuara.clip != null && SourceSuara.isPlaying)
        {
            SourceSuara.Stop();

        }

        SourceSuara.Play();
    }
}
