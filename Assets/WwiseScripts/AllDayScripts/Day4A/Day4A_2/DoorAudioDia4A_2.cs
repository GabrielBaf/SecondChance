using UnityEngine;
using System.Collections;

public class DoorAudioDia4A_2 : MonoBehaviour {
    public GameObject OutCam;
    public GameObject HallCam;
    public GameObject SalaCam;
    public GameObject JantarCam;
    public GameObject BathCam;
    public GameObject KitchenCam;
    public GameObject PoolCam;


    int Changing = 3;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (PoolCam.activeSelf)
        {
            Changing = 1;
        }
        else if (HallCam.activeSelf)
        {
            Changing = 2;
        }
        else if (OutCam.activeSelf)
        {
            Changing = 3;
        }
        else if (JantarCam.activeSelf)
        {
            Changing = 4;
        }
        else if (SalaCam.activeSelf)
        {
            Changing = 5;
        }
        else if (BathCam.activeSelf)
        {
            Changing = 6;
        }
        else if (KitchenCam.activeSelf)
        {
            Changing = 7;
        }



        //If door open
        if (Changing != LastChanging && Started == true)
        {
            DoorSound();
        }
    }

    void DoorSound()
    {
        LastChanging = Changing;
        AudioPlaying("Doors");
    }

    bool Wait()
    {
        LastChanging = Changing;
        Started = true;
        return Started;
    }


    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
