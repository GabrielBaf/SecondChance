using UnityEngine;
using System.Collections;

public class SwimAudio : MonoBehaviour {

    public GameObject PlayerSwim;
    public Animator PlayerAnimSwim;
    public GameObject DialoguePanel;

    //Check if the player is moving
    float PlayerPosition;
    float StoppedPosition = -16;

    int isMoving;
    bool CanPlay = true;
    bool isPlayed = false;
    bool StopPlaying = false;

    bool StartedSwim = false;
    bool CanPlay02 = false;

    bool FeltWater = false;

    SoundtracksMenuAudio Soundtrack;
    bool ChangeSoundtrack = false;
    bool DestroyThis = false;

    bool IsSwimming = true;

    void Start()
    {
        Invoke("FindSoundtrackMenuAudio", 2.0f);
    }

    void Update()
    {


        //Normal Flow
        if (PlayerSwim.activeSelf && CanPlay == true) //StopPlaying == false
        {
            Anima();

            PlayerPosition = PlayerSwim.transform.position.y;

            if (Mathf.Round(PlayerPosition) == StoppedPosition)
            {
                if (FeltWater == false)
                {
                    FeltWater = true;
                    AudioPlaying("FeltWater");
                }


                Invoke("IsNotSwimming", 0.5f);
            }
            else
            {
                IsSwimming = true;
            }
        }

        if (isPlayed == false && DialoguePanel.activeSelf == false && CanPlay02 == false && IsSwimming)
        {
            if (isMoving == 5 || isMoving == 55)
            {

                PlayingFootstep();
            }
        }

        if (StartedSwim == true && DialoguePanel.activeSelf)
        {
            CanPlay02 = true;

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }

        if (PlayerSwim.activeSelf && ChangeSoundtrack == false && CanPlay02 && isPlayed == false && DialoguePanel.activeSelf == false)
        {
            ChangeSoundtrack = true;
            Soundtrack.AudioStop("Dia3", 1);
            AudioPlaying("Action02");
        }


        if (CanPlay02 && isPlayed == false && DialoguePanel.activeSelf == false && IsSwimming)
        {

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;

            PlayerPosition = PlayerSwim.transform.position.y;

            if (PlayerPosition != StoppedPosition)
            {
                if (isMoving == 5 || isMoving == 55)
                {
                    PlayingFootstep();
                }
            }
        }

        if (ChangeSoundtrack && DialoguePanel.activeSelf && DestroyThis == false)
        {
            AudioStoping("Action02");
            Soundtrack.AudioPlaying("Dia3");
            DestroyThis = true;
        }

    }

    void FindSoundtrackMenuAudio()
    {
        Soundtrack = FindObjectOfType<SoundtracksMenuAudio>();
    }

    void Anima()
    {
        isMoving = PlayerAnimSwim.GetInteger("AnimState");
    }

    void PlayingFootstep()
    {
        isPlayed = true;

        //Check If is Swimming
        if (StartedSwim == false)
        {
            StartedSwim = true;
        }

        AudioPlaying("SwimAudio");

        Invoke("IsPlaying", 0.5f);
    }

    bool IsPlaying()
    {
        isPlayed = false;
        return isPlayed;
    }

    bool PlayAudio()
    {
        CanPlay = true;
        return CanPlay;
    }

    bool IsNotSwimming()
    {
        IsSwimming = false;
        return IsSwimming;
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
