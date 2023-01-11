using UnityEngine;
using System.Collections;

public class DoorAudioDia2A_1 : MonoBehaviour {

    public GameObject CharlieCam;
    public GameObject PijamaCam;
    public GameObject HallCam;
    public GameObject Hall2Cam;
    public GameObject Sala_Cam;
    public GameObject Kitchen_Cam;
    public GameObject Jantar_Cam;
    public GameObject Out_Cam;

    int Changing = 1;
    int LastChanging;
    bool Started = false;

    void Start()
    {
        Invoke("Wait", 1.0f);

        if (PijamaCam.activeSelf)
        {
            Changing = 1;
        }
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
        else if (Out_Cam.activeSelf)
        {
            Changing = 3;
        }
        else if (Kitchen_Cam.activeSelf)
        {
            Changing = 4;
        }
        else if (Sala_Cam.activeSelf)
        {
            Changing = 5;
        }
        else if (Jantar_Cam.activeSelf)
        {
            Changing = 6;
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