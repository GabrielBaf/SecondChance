using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickAudioOp2 : MonoBehaviour {

    Button[] ResponseButtons;
    bool IsPlayed = false;


    // Update is called once per frame
    void Update()
    {
        ResponseButtons = FindObjectsOfType<Button>();

        foreach (var responseButton in ResponseButtons)
        {
            if (IsPlayed == false)
            {
                responseButton.onClick.AddListener(() => WaitUntilPlay());
            }
        }
    }

    void WaitUntilPlay()
    {
        IsPlayed = true;
        AudioPlaying("Click");
        Invoke("PlayAgain", 0.1f);
    }

    bool PlayAgain()
    {
        IsPlayed = false;
        return IsPlayed;
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}

