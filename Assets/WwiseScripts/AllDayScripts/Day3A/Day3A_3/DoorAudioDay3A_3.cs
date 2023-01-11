using UnityEngine;
using System.Collections;

public class DoorAudioDay3A_3 : MonoBehaviour {


    public GameObject PiscinaCam;
    public GameObject VestiarioCam;
    public GameObject VestiarioPapelaoCam;
    public GameObject HallCam;
    public GameObject HallPapelaoCam;

    int Changing = 1;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (PiscinaCam.activeSelf)
        {
            Changing = 1;
        }
        else if (HallCam.activeSelf || HallPapelaoCam.activeSelf)
        {
            Changing = 2;
        }
        else if (VestiarioCam.activeSelf || VestiarioPapelaoCam.activeSelf)
        {
            Changing = 3;
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
