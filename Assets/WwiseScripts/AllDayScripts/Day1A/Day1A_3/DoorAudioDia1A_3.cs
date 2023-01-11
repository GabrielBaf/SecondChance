using UnityEngine;
using System.Collections;

public class DoorAudioDia1A_3 : MonoBehaviour {

    public GameObject OutCam;
    public GameObject ClassCam;
    public GameObject HallCam;
    public GameObject Recep_Cam;
    public GameObject Ref_Cam;

    int Changing = 2;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);
    }

    void Update()
    {

        if (ClassCam.activeSelf)
        {
            Changing = 1;
        }
        else if (HallCam.activeSelf)
        {
            Changing = 2;
        }
        else if (OutCam.activeSelf || Recep_Cam.activeSelf)
        {
            Changing = 3;
        }
        else if (Ref_Cam.activeSelf)
        {
            Changing = 4;
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