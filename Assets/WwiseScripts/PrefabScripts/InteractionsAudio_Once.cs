using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InteractionsAudio_Once : MonoBehaviour {


    public List<BoxCollider2D> Quests;
    public List<string> Audios;
    GameObject NPCSubtitlePanel;
    GameObject AlertText;
    public CircleCollider2D Player;

    bool IsPlaying = false;
    bool PlaySecondSpeech = false;
    string AudioPlay;
    string AudioStop;
    int SizeOfList;
    int SelectedQuest;

    void Awake()
    {

        NPCSubtitlePanel = GameObject.Find("NPC Subtitle Panel");

        AlertText = GameObject.Find("Alert Panel");

    }

    void Start()
    {
        SizeOfList = Quests.Count;
    }

    void Update()
    {
        SizeOfList = Quests.Count;

        foreach (var quest in Quests.ToList())
        {
            if (Player.GetComponent<CircleCollider2D>().IsTouching(quest))
            {

                foreach (var Audio in Audios.ToList())
                {
                    if (IsPlaying == false)
                    {
                        for (int i = 0; i < SizeOfList; i++)
                        {
                            if (IsPlaying == false)
                            {
                                AudioSelection(i);
                            }
                        }
                    }
                }

                if (IsPlaying == false)
                {
                    if (AlertText.activeSelf == true || NPCSubtitlePanel.activeSelf == true)
                    {
                        if (Input.GetKey(KeyCode.Space))
                        {
                            IsPlaying = true;

                            QuestAudioPlay();

                            PlaySecondSpeech = true;

                        }
                    }
                }

            }
        }


            if (AlertText.activeSelf == false && NPCSubtitlePanel.activeSelf == false && PlaySecondSpeech == true)
            {
                PlaySecondSpeech = false;
                AudioStoping(AudioStop, 1);
                RemoveQuest();
                IsPlaying = false;
            }


        if (SizeOfList == 0)
        {
            Destroy(this, 2.0f);
        }
    }

    void AudioSelection(int selectedObject)
    {
        if (Player.GetComponent<CircleCollider2D>().IsTouching(Quests[selectedObject]))
        {
            AudioPlay = Audios[selectedObject];
            SelectedQuest = selectedObject;
        }
    }

    void QuestAudioPlay()
    {
        AudioStop = AudioPlay;
        AudioStoping(AudioStop, 1);
        AudioPlaying(AudioPlay);
    }

    void RemoveQuest()
    {
        Quests.Remove(Quests[SelectedQuest]);
        Audios.Remove(Audios[SelectedQuest]);
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
