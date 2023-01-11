using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class MeninaCorredorAudio : MonoBehaviour {

    public ConversationTrigger GarotaOutraSala;
    public GameObject NPCSubtitlePanel;

    bool IsPlayed = false;

	// Update is called once per frame
	void Update () {

        if (GarotaOutraSala == null)
        {
            if (NPCSubtitlePanel.activeSelf && IsPlayed == false)
            {
                IsPlayed = true;
                AudioToPlay("AnneCustom_01", 1.0f);
            }
            else if (NPCSubtitlePanel.activeSelf == false && IsPlayed == true)
            {
                AudioStoping("AnneCustom_01", 1);
                Destroy(this, 1.0f);
            }
        }
	}

    void AudioToPlay(string AudioName, float ForSeconds)
    {
        AudioPlaying(AudioName);
        Invoke("AudioLength", ForSeconds);
    }

    void AudioLength()
    {
        AudioStoping("AnneCustom_01", 1);
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
