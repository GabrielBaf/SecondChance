using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class VoicesAudio : MonoBehaviour {

    public GameObject Player;
    CircleCollider2D[] PlayerCollider;

    public GameObject[] NPCColliders;

    //Choose Colliders Of Player
    int SizeOfPlayerColliders;
    int ThePlayerCollider;


    GameObject DialoguePanel;
    GameObject AlertPanel;

    Text NPCPortraitName;
    Text NPCSubtitleLine;

    //Dialog Can Play?
    bool StartEverything = false;
    public bool StartDialogueAudio = false;

    //Calculating NPC that is Talking
    string AtualNPC;
    string LastNPC;

    //Calculating Speech Time
    string AtualSpeech;
    string LastSpeech;

    //Processing time to next audio
    bool PlayWhenChange = false;
    bool CanProcessText = true;

    //Identifying Audio
    string NPCSwitch;
    string AudioToStop;

    //Speech Time and Custom voice
    float LengthOfAudio;
    int CustomSpeech = 1;

    //If is a thinking or a speech
    bool ThinkingDialog = false;


    void Awake()
    {
        //Find Dialog, PC and Alert Panel Game-objects
        DialoguePanel = GameObject.Find("Dialogue Panel");
        AlertPanel = GameObject.Find("Alert Panel");

        //Find Npc name and Text
        NPCPortraitName = GameObject.Find("NPC Portrait Name").GetComponent<Text>();
        NPCSubtitleLine = GameObject.Find("NPC Subtitle Line").GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        StartDialogueAudio = false;

        //Find Player Colliers
        PlayerCollider = Player.GetComponents<CircleCollider2D>();
        SizeOfPlayerColliders = PlayerCollider.Length;

        //Choose The Right Collider
        if (SizeOfPlayerColliders == 1)
        {
            ThePlayerCollider = 0;
        }
        else if (SizeOfPlayerColliders > 1)
        {
            ThePlayerCollider = 1;
        }

    }

	// Update is called once per frame
	void Update () {

        //Stop Everything
        if (DialoguePanel.activeSelf == false && AlertPanel.activeSelf == false)
        {
            if (StartEverything == true)
            {
                AudioLength();
                StartDialogueAudio = false;
                StartEverything = false;

                //Reset Custom Speech
                CustomSpeech = 1;
            }
        }

 //Start Everything
        if (DialoguePanel.activeSelf && StartEverything == false)
        {

            foreach (var npcColliders in NPCColliders)
            {
                if (npcColliders.GetComponents<Collider2D>().Length > 1)
                {
                    if (PlayerCollider[ThePlayerCollider].IsTouching(npcColliders.GetComponents<Collider2D>()[1]))
                    {
                        StartEverything = true;
                        StartDialogueAudio = true;

                        //First time calculating NPC and Speech
                        AtualPortraitName();
                    }
                }
                else if (npcColliders.GetComponents<Collider2D>().Length == 1)
                {
                    if (PlayerCollider[ThePlayerCollider].IsTouching(npcColliders.GetComponents<Collider2D>()[0]))
                    {
                        StartEverything = true;
                        StartDialogueAudio = true;

                        //First time calculating NPC and Speech
                        AtualPortraitName();
                    }
                }

            }
        }

        if (StartDialogueAudio == true)
        {
            //Calculating Portrait
            AtualPortraitName();

            //Calculating Text
            AtualTextLine();

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;

                if (CustomSpeech >= 4)
                {
                    CustomSpeech = 1;
                }

                //Set The NPC Audio To Actual Character and play audio
                NPCSwitch = AtualNPC;
                NPCAudio();
            }
        }
	}

    void NPCAudio()
    {
        if (AtualSpeech.Length >= 4)
        {
            if (AtualSpeech.Contains("(") || AtualSpeech.Contains("..."))
            {
                AudioLength();
                ThinkingDialog = true;
            }
            else
            {
                ThinkingDialog = false;
            }
        }

        if(ThinkingDialog == false)
        {
            CalculateLengthOfAudio();

            switch (NPCSwitch)
            {
                case "Charlie.":
                    AudioLength();
                    AudioToPlay("CharlieCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Charlie":
                    AudioLength();
                    AudioToPlay("CharlieCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Ronald":
                    AudioLength();
                    AudioToPlay("RonaldCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Anne":
                    AudioLength();
                    AudioToPlay("AnneCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Andy":
                    AudioLength();
                    AudioToPlay("AndyCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Kevin":
                    AudioLength();
                    AudioToPlay("KevinCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Stephen":
                    AudioLength();
                    AudioToPlay("StephenCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Sophia":
                    AudioLength();
                    AudioToPlay("SecretariaCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Emily":
                    AudioLength();
                    AudioToPlay("EmilyCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "George":
                    AudioLength();
                    AudioToPlay("GeorgeCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Kate":
                    AudioLength();
                    AudioToPlay("KateCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Big B":
                    AudioLength();
                    AudioToPlay("BigBCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Dan":
                    AudioLength();
                    AudioToPlay("DanCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Marianne":
                    AudioLength();
                    AudioToPlay("MarianneCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Pamela":
                    AudioLength();
                    AudioToPlay("PamelaCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Steven":
                    AudioLength();
                    AudioToPlay("StevenCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Jenna":
                    AudioLength();
                    AudioToPlay("JennaCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Jenny":
                    AudioLength();
                    AudioToPlay("JennyCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "James":
                    AudioLength();
                    AudioToPlay("JamesCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Elizabeth":
                    AudioLength();
                    AudioToPlay("ElizabethCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Chris":
                    AudioLength();
                    AudioToPlay("CrisCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Leroy":
                    AudioLength();
                    AudioToPlay("LeroyCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Jack":
                    AudioLength();
                    AudioToPlay("JackCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Luke":
                    AudioLength();
                    AudioToPlay("LukeCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
                case "Case":
                    AudioLength();
                    AudioToPlay("CaseCustom_0" + CustomSpeech, LengthOfAudio);
                    CustomSpeech++;
                    break;
            }
        }
    }

    void AudioToPlay(string AudioName, float ForSeconds)
    {
        AudioToStop = AudioName;

        AudioPlaying(AudioName);
        Invoke("AudioLength", ForSeconds);
    }

    void AudioLength()
    {
        AudioStoping(AudioToStop, 1);
    }

    void AtualPortraitName()
    {
        AtualNPC = NPCPortraitName.text;
    }

    void AtualTextLine()
    {
        if (NPCSubtitleLine.text.Length > 4)
        {
            AtualSpeech = NPCSubtitleLine.text.Substring(0, 4);
        }

        if (LastSpeech != AtualSpeech || LastNPC != AtualNPC)
        {
            if (NPCSubtitleLine.text.Length > 4)
            {
                if (PlayWhenChange == false && AtualSpeech.Contains("<") == false)
                {
                    PlayWhenChange = true;

                    LastNPC = AtualNPC;
                    LastSpeech = AtualSpeech;
                }
            }
        }
    }

    void CalculateLengthOfAudio()
    {
        if (NPCSubtitleLine.text.Length <= 40)
        {
            LengthOfAudio = 0.4f;
        }

        if (NPCSubtitleLine.text.Length > 40 && NPCSubtitleLine.text.Length <= 70)
        {
            LengthOfAudio = 1.0f;
        }

        if (NPCSubtitleLine.text.Length > 70 && NPCSubtitleLine.text.Length <= 100)
        {
            LengthOfAudio = 1.5f;
        }

        if (NPCSubtitleLine.text.Length > 100 && NPCSubtitleLine.text.Length <= 130)
        {
            LengthOfAudio = 2.0f;
        }

        if (NPCSubtitleLine.text.Length > 130)
        {
            LengthOfAudio = 2.5f;
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
