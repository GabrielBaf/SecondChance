using UnityEngine;
using System.Collections;

public class DoorAudioDia5A_1 : MonoBehaviour {

    public GameObject OutCam;
    public GameObject CharlieCam;
    public GameObject HallCam;
    public GameObject Hall2Cam;
    public GameObject BrotherCam;
    public GameObject SalaCam;
    public GameObject JantarCam;
    public GameObject BathCam;
    public GameObject MomCam;
    public GameObject KitchenCam;


    int Changing = 1;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (CharlieCam.activeSelf)
        {
            Changing = 1;
        }
        else if (HallCam.activeSelf || Hall2Cam.activeSelf)
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
        else if (MomCam.activeSelf)
        {
            Changing = 7;
        }
        else if (BrotherCam.activeSelf)
        {
            Changing = 8;
        }
        else if (KitchenCam.activeSelf)
        {
            Changing = 9;
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
