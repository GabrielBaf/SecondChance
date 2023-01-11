using UnityEngine;
using System.Collections;

public class DoorAudioDia5A_3 : MonoBehaviour {


    public GameObject OutCam;
    public GameObject CharlieCam;
    public GameObject HallCam;
    public GameObject Hall2Cam;
    public GameObject BrotherCam;
    public GameObject MomCam;
    public GameObject JantarCam;
    public GameObject KitchenCam;
    public GameObject SalaCam;
    public GameObject BathCam;
    public GameObject Bath2Cam;

    int Changing = 2;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (OutCam.activeSelf)
        {
            Changing = 1;
        }
        else if (CharlieCam.activeSelf || JantarCam.activeSelf)
        {
            Changing = 2;
        }
        else if (HallCam.activeSelf || Hall2Cam.activeSelf)
        {
            Changing = 3;
        }
        else if (KitchenCam.activeSelf)
        {
            Changing = 5;
        }
        else if (BathCam.activeSelf || Bath2Cam.activeSelf)
        {
            Changing = 6;
        }
        else if (SalaCam.activeSelf)
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
