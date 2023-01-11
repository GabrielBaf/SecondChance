using UnityEngine;
using System.Collections;

public class MijandoDia5A_1 : MonoBehaviour {

    public GameObject Fader;

    public CircleCollider2D Player;
    public BoxCollider2D Privada;

    bool AlreadyPlay = false;


    // Update is called once per frame
    void Update()
    {
        if (Player.IsTouching(Privada) && Fader.activeSelf && AlreadyPlay == false)
        {
            AlreadyPlay = true;

            AudioPlaying("Mijando");
        }

        if (Player.IsTouching(Privada) == false && AlreadyPlay)
        {
            AudioStoping("Mijando");
        }
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }

    void AudioStoping(string playing)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject);
    }
}

