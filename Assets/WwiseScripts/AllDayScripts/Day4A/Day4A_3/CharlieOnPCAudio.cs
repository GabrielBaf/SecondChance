using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharlieOnPCAudio : MonoBehaviour {

    public GameObject RoomCam;
    public Text NPCTextLine;

    string LastType;

    bool IsPlayed = true;
    bool AlreadyPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (RoomCam.activeSelf)
        {
            if (NPCTextLine.text.Substring(0,1) != LastType)
            {
                AlreadyPlayed = true;

                LastType = NPCTextLine.text.Substring(0, 1);

                AudioPlaying("CharlieTyping");
            }

            if (AlreadyPlayed && NPCTextLine.gameObject.activeSelf == false)
            {
                Destroy(this);
            }
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
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
