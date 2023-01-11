using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuSoundtrack : MonoBehaviour {

    bool IsPlaying;
    bool DestroyTrigger = false;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        IsPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying == false && SceneManager.GetSceneByName("Menu") == SceneManager.GetActiveScene())
        {
            IsPlaying = true;
            Invoke("MenuSoundtrackPlaying", 0.5f);
        }

        if (IsPlaying == true && SceneManager.GetSceneByName("Menu") != SceneManager.GetActiveScene())
        {
            IsPlaying = false;
            AudioStop("MainMenuSoundtrack", 1);
            DestroyTrigger = true;
        }

        if (DestroyTrigger == true)
        {
            Destroy(gameObject,4.0f);
        }

    }


    void MenuSoundtrackPlaying()
    {
        AudioPlaying("MainMenuSoundtrack");
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }

    void AudioStop(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}