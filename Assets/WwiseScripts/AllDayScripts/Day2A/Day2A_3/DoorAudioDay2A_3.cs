using UnityEngine;
using System.Collections;

public class DoorAudioDay2A_3 : MonoBehaviour {


    public GameObject OutCam;
    public GameObject RecepcaoCam;
    public GameObject HallCam;
    public GameObject RefeitorioCam;
    public GameObject ClassCam;
    public GameObject JantarCam;
    public GameObject HomeHallCam;

    int Changing = 5;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (RecepcaoCam.activeSelf)
        {
            Changing = 1;
        }
        else if (HallCam.activeSelf)
        {
            Changing = 2;
        }
        else if (HomeHallCam.activeSelf || RefeitorioCam.activeSelf || OutCam.activeSelf)
        {
            Changing = 3;
        }
        else if (JantarCam.activeSelf)
        {
            Changing = 4;
        }
        else if (ClassCam.activeSelf)
        {
            Changing = 5;
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

