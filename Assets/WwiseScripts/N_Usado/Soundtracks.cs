using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.Examples;

public class Soundtracks : MonoBehaviour {

    public List<string> Scenes;
    public string Soundtrack;
    public GameObject PauseUI;
    bool IsPlayed = false;
    bool IsPlaying = false;
    bool PlayNow;

    private static Soundtracks instanceRef;

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Update()
    {
        if (gameObject != null)
        {
            foreach (var scene in Scenes)
            {
                if (PauseUI.activeSelf == true && IsPlayed == false)
                {
                    AudioPause(Soundtrack, 3);
                    IsPlayed = true;
                }
                else if (PauseUI.activeSelf == false && IsPlayed == true)
                {
                    AudioResume(Soundtrack, 3);
                    IsPlayed = false;
                }

                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(scene))
                {
                    PlayNow = true;
                }
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(scene))
                {
                    PlayNow = false;
                }

                if (PlayNow == true && IsPlaying == false)
                {
                    Invoke("SoundtrackPlaying", 0.5f);
                    IsPlaying = true;
                }
                else if (PlayNow == false && IsPlaying == true)
                {
                    AudioStop(Soundtrack, 5);
                    IsPlaying = false;
                }
            }
        }
    }

    void SoundtrackPlaying()
    {
        AudioPlaying(Soundtrack);
    }

     public void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }

    void AudioResume(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Resume, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

    void AudioPause(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Pause, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

    public void AudioStop(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
