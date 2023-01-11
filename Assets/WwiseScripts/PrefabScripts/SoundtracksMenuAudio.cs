using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SoundtracksMenuAudio : MonoBehaviour {

    public List<string> Scenes;
    public string Soundtrack;
    bool IsPlayed = false;
    bool IsPlaying = false;
    bool PlayNow = false;
    bool MenuIsOpen = false;

    int SizeOfScenes;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SizeOfScenes = Scenes.Count;
    }

    void Start()
    {
        SizeOfScenes = Scenes.Count;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && MenuIsOpen == false)
        {
            if (GameObject.Find("PauseUI") != null && IsPlayed == false)
            {
                MenuIsOpen = true;

                AudioPause(Soundtrack, 2);
                AudioPlaying("MainMenuSoundtrack");
                IsPlayed = true;
            }
        }

        if (MenuIsOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameObject.Find("PauseUI") == null && IsPlayed == true)
                {
                    MenuIsOpen = false;

                    AudioStop("MainMenuSoundtrack", 2);
                    AudioResume(Soundtrack, 3);
                    IsPlayed = false;
                }
            }
            else if (EventSystem.current.currentSelectedGameObject || Input.GetMouseButtonDown(0))
            {
                if (GameObject.Find("PauseUI") == null && IsPlayed == true)
                {
                    MenuIsOpen = false;

                    AudioStop("MainMenuSoundtrack", 2);
                    AudioResume(Soundtrack, 3);
                    IsPlayed = false;
                }
            }
        }

            foreach (var scene in Scenes)
            {
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(scene))
                {
                    PlayNow = true;
                }

                if (PlayNow == true && IsPlaying == false)
                {
                    Invoke("SoundtrackPlaying", 0.5f);
                    IsPlaying = true;
                }

            }

        if (SizeOfScenes == 1)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[0]))
            {
                PlayNow = false;
            }
        }

        if (SizeOfScenes == 2)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[0]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[1]))
            {
                PlayNow = false;
            }
        }

        if (SizeOfScenes == 3)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[0]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[1]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[2]))
            {
                PlayNow = false;
            }
        }

        if (SizeOfScenes == 4)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[0]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[1]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[2]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[3]))
            {
                PlayNow = false;
            }
        }

        if (SizeOfScenes == 5)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[0]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[1]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[2]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[3]) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName(Scenes[4]))
            {
                PlayNow = false;
            }
        }

        if (PlayNow == false && IsPlaying == true)
        {
            AudioStop(Soundtrack, 3);
            IsPlaying = false;
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
