using UnityEngine;
using System.Collections;

public class IntroAudioDia4A_3 : MonoBehaviour {

    public GameObject RoomCam;

    SoundtracksMenuAudio Soundtrack;

    bool SoundtrackBack = false;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;

        Invoke("FindSoundtrackMenuAudio", 2.0f);
    }

	// Update is called once per frame
	void Update () {

        if (RoomCam.activeSelf)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;


            if (SoundtrackBack == false)
            {
                SoundtrackBack = true;

                AudioStoping("Bullying", 3);
                Soundtrack.AudioPlaying("Dia4");
            }

            Destroy(this, 0.5f);
        }

	}

    void FindSoundtrackMenuAudio()
    {
        Soundtrack = FindObjectOfType<SoundtracksMenuAudio>();


        Soundtrack.AudioStop("Dia4", 3);
        AudioPlaying("Bullying"); ;
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }

    void AudioStoping(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
