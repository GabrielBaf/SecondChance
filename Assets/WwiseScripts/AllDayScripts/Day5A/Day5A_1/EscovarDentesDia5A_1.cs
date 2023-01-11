using UnityEngine;
using System.Collections;

public class EscovarDentesDia5A_1 : MonoBehaviour {

    public GameObject Fader;

    public CircleCollider2D Player;
    public BoxCollider2D Sink;

    bool AlreadyPlay = false;


	// Update is called once per frame
	void Update () {
        if (Player.IsTouching(Sink) && Fader.activeSelf && AlreadyPlay == false)
        {
            AlreadyPlay = true;

            AudioPlaying("Sink");
        }

        if (Player.IsTouching(Sink) == false && AlreadyPlay == true)
        {
            AudioStoping("Sink");
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
