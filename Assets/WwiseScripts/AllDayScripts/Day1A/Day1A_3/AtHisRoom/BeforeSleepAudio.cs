using UnityEngine;
using System.Collections;

public class BeforeSleepAudio : MonoBehaviour {

    //Change Soundtrack back
    SoundtracksMenuAudio Soundtrack;

    public GameObject PijamaPlayer;
    public GameObject NoBookTable;
    public GameObject CharlieEscreve;

    bool SeTrocou = false;
    bool PegouDiario = false;
    bool SeDeitou = false;

    void Start()
    {
        //finding soundtrack controller
        Invoke("FindSoundtrackMenuAudio", 2.0f);
    }

    // Update is called once per frame
    void Update () {
        if (PijamaPlayer.activeSelf && SeTrocou == false)
        {
            SeTrocou = true;
            AudioPlaying("Wardrobe");
        }

        if (NoBookTable.activeSelf && PegouDiario == false)
        {
            PegouDiario = true;
            AudioPlaying("PegouDiario");
        }

        if (CharlieEscreve.activeSelf && SeDeitou == false)
        {
            SeDeitou = true;
            AudioPlaying("SeDeitou");

            //Changing soundtrack back

            AudioStoping("Bullying", 4);
            Soundtrack.AudioPlaying("Dia1");

            Destroy(gameObject, 2.0f);
        }
    }

    void FindSoundtrackMenuAudio()
    {
        Soundtrack = FindObjectOfType<SoundtracksMenuAudio>();
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }

    void AudioStoping(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 500, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
