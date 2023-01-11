using UnityEngine;
using System.Collections;

public class ChangingClothesAudio : MonoBehaviour {

    public GameObject Player;

	// Update is called once per frame
	void Update () {
        if (Player.activeSelf)
        {
            AudioPlaying("Wardrobe");
            Destroy(this);
        }
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
