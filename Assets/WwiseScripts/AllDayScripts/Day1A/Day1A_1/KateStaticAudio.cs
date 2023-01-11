using UnityEngine;
using System.Collections;

public class KateStaticAudio : MonoBehaviour {

    public BoxCollider2D Kate;
    public CircleCollider2D Player;
    GameObject NPCSubtitlePanel;

    bool IsPlaying = false;

    void Awake()
    {
        NPCSubtitlePanel = GameObject.Find("NPC Subtitle Panel");
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.IsTouching(Kate) && gameObject.GetComponent<KateFirstSpeechAudio>() == null)
        {
            if (IsPlaying == false && NPCSubtitlePanel.activeSelf)
            {
                IsPlaying = true;

                KateAudioPlay();
            }
        }

        if (NPCSubtitlePanel.activeSelf == false)
        {
            AudioStoping("KateCustom_01", 1);
            IsPlaying = false;
        }

    }

    void KateAudioPlay()
    {
        AudioPlaying("KateCustom_01");
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