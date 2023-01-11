using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractionAudio : MonoBehaviour {


    public List<Collider2D> Interactions;
    public List<string> Audios;
    GameObject NPCSubtitlePanel;
    public GameObject[] Player;
    CircleCollider2D[] PlayerColliders;

    bool IsPlayed = false;
    string AudioPlay;

    int PlayerSelect;
    int SizeOfPlayer;
    bool SelectThePlayer = false;
    bool GetThingsRight = false;

    int SizeOfColliders;
    int SizeOfList;

    void Awake() {

        NPCSubtitlePanel = GameObject.Find("NPC Subtitle Panel");
    }


    void Start()
    {
        //Select The Actual Player
        SizeOfPlayer = Player.Length;

        if (SizeOfPlayer == 1)
        {
            PlayerSelect = 0;
        }

        if (SizeOfPlayer > 1)
        {
            SelectThePlayer = true;

            if (SelectThePlayer)
            {
                if (Player[0].activeSelf)
                {
                    PlayerSelect = 0;
                }

                if (Player[1].activeSelf)
                {
                    PlayerSelect = 1;
                }
            }
        }

        //Get The Player Colliders
        PlayerColliders = Player[PlayerSelect].GetComponents<CircleCollider2D>();
        SizeOfColliders = PlayerColliders.Length;


        SizeOfList = Interactions.Count;
    }

    void Update () {

        if (SelectThePlayer)
        {
            if (Player[PlayerSelect].activeSelf == false)
            {
                GetThingsRight = true;
            }

            if (Player[0].activeSelf && GetThingsRight == true)
            {
                GetThingsRight = false;
                PlayerSelect = 0;

                //Get The Player Colliders
                PlayerColliders = Player[PlayerSelect].GetComponents<CircleCollider2D>();
                SizeOfColliders = PlayerColliders.Length;
            }

            if (Player[1].activeSelf && GetThingsRight == true)
            {
                GetThingsRight = false;
                PlayerSelect = 1;

                //Get The Player Colliders
                PlayerColliders = Player[PlayerSelect].GetComponents<CircleCollider2D>();
                SizeOfColliders = PlayerColliders.Length;
            }
        }

        foreach (var interaction in Interactions)
        {
            if (PlayerColliders[SizeOfColliders - 1].IsTouching(interaction))
            {
                foreach (var Audio in Audios)
                {
                    for (int i = 0; i < SizeOfList; i++)
                    {
                        AudioSelect(i);
                    }
                }

                if (NPCSubtitlePanel.activeSelf == true)
                {
                    if (IsPlayed == false)
                    {
                        IsPlayed = true;
                        AudioPlaying(AudioPlay);
                    }
                }
            }

            if (NPCSubtitlePanel.activeSelf == false)
            {
                AudioStoping(AudioPlay, 1);
                IsPlayed = false;
            }
        }
    }

    void AudioSelect(int selectedObject)
    {
        if (PlayerColliders[SizeOfColliders - 1].IsTouching(Interactions[selectedObject]))
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
