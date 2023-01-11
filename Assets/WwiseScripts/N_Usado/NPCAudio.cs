using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCAudio : MonoBehaviour {



    public List<BoxCollider2D> Interactions;
    public List<string> Audios;
    public GameObject DialogueText;
    public GameObject Player;

    bool IsPlayed = false;
    string AudioPlay;
    int SizeOfList;


    void Start()
    {
        SizeOfList = Interactions.Count;
    }

    void Update()
    {

        foreach (var interaction in Interactions)
        {
            if (Player.GetComponent<CircleCollider2D>().IsTouching(interaction))
            {
                if (gameObject.GetComponent<QuestAudio>() == null)
                {

                    foreach (var Audio in Audios)
                    {
                        for (int i = 0; i < SizeOfList; i++)
                        {
                            AudioSelect(i);
                        }

                    }

                    if (DialogueText.activeSelf == true)
                    {
                        if (IsPlayed == false)
                        {
                            IsPlayed = true;
                            AudioPlaying(AudioPlay);
                        }
                    }
                    else if (DialogueText.activeSelf == false)
                    {
                        AudioStoping(AudioPlay, 1);
                        IsPlayed = false;
                    }
                }

            }
        }
    }

    void AudioSelect(int selectedObject)
    {
        if (Player.GetComponent<CircleCollider2D>().IsTouching(Interactions[selectedObject]))
        {
            AudioPlay = Audios[selectedObject];
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