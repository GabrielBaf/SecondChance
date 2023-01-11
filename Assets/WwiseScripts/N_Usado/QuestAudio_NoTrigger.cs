using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class QuestAudio_NoTrigger : MonoBehaviour {

    public List<Collider2D> Quests;
    public List<string> Audios;
    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    public GameObject Player;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlaying = false;
    bool PlaySecondSpeech = false;
    string AudioPlay;
    string AudioStop;
    public int SizeOfList;
    int SelectedQuest;

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
                            AudioSelection(i);
                        }
                    }
                }

                if (NPCSubtitlePanel.activeSelf == true)
                {
                    if (IsPlaying == false)
                    {
                        IsPlaying = true;

                        Invoke("FirstText", 0.05f);

                        QuestAudioPlay();
                    }
                }
            }

            if (NPCSubtitlePanel.activeSelf == false && PlaySecondSpeech == true)
            {
                PlaySecondSpeech = false;
                AudioStoping(AudioStop, 1);
                RemoveQuest();
                IsPlaying = false;
            }

            if (IsPlaying == true)
            {
                ResponseButton = FindObjectOfType<Button>();
                if (ResponseButton != null)
                {
                    ResponseButton.onClick.AddListener(() => IsClick = true);
                }

                if (IsClick)
                {
                    IsClick = false;

                    LastSpeech = AtualSpeech;

                    Invoke("WaitToPlay", 0.2f);
                }

                if (PlayWhenChange == true)
                {
                    PlayWhenChange = false;
                    QuestAudioPlay();
                }

            }

        }
        if (SizeOfList == 0)
        {
            Destroy(this, 5.0f);
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

    void FirstText()
    {
        PlaySecondSpeech = true;

        if (NPCSubtitleLine.text.Length > 4)
        {
            AtualSpeech = NPCSubtitleLine.text.Substring(0, 4);
        }
    }

    void WaitToPlay()
    {
        if (NPCSubtitleLine.text.Length > 4)
        {
            AtualSpeech = NPCSubtitleLine.text.Substring(0, 4);
        }

        if (LastSpeech != AtualSpeech)
        {
            PlayWhenChange = true;
            LastSpeech = AtualSpeech;
        }
    }

    public bool FixOtherScript()
    {
        IsPlaying = true;

        Quests.Remove(Quests[0]);
        Audios.Remove(Audios[0]);

        IsPlaying = false;

        return IsPlaying;
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