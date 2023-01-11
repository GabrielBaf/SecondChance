using UnityEngine;
using System.Collections;

public class DoorAudioDia5A_2 : MonoBehaviour {

    public GameObject OutCam;
    public GameObject RecepCam;
    public GameObject HallCam;


    int Changing = 1;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (OutCam.activeSelf || RecepCam.activeSelf)
        {
            Changing = 1;
        }
        else if (HallCam.activeSelf)
        {
            Changing = 2;
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
