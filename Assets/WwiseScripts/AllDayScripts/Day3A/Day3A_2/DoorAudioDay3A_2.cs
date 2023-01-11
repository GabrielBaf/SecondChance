using UnityEngine;
using System.Collections;

public class DoorAudioDay3A_2 : MonoBehaviour {

    public GameObject VestiarioCam;
    public GameObject PiscinaCam;


    int Changing = 1;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (VestiarioCam.activeSelf)
        {
            Changing = 1;
        }
        else if (PiscinaCam.activeSelf)
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
