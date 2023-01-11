using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CorredorAudioDay3A_3 : MonoBehaviour {

    public GameObject HallCam;
    public GameObject HallCamCaixa;

    public GameObject Player;
    public GameObject PlayerCaixa;
    public BoxCollider2D GoBoxRoom;
    public BoxCollider2D GoRoom;

    SoundtracksMenuAudio Soundtrack;

    bool CorredorPlayed = false;

    void Start()
    {
        Invoke("FindSoundtrackMenuAudio", 2.0f);
    }

    // Update is called once per frame
    void Update () {

        if (HallCam.activeSelf || HallCamCaixa.activeSelf)
        {
            if (CorredorPlayed == false)
            {
                CorredorPlayed = true;

                Soundtrack.AudioStop("Dia3", 3);
                AudioPlaying("Bullying");

                gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
            }

        }

        if (HallCam.activeSelf == false && HallCamCaixa.activeSelf == false && CorredorPlayed)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;

            if (PlayerCaixa.activeSelf == false)
            {
                AudioStoping("Bullying", 3);

                Destroy(gameObject, 0.5f);
            }
        }

        if (PlayerCaixa.GetComponents<CircleCollider2D>()[1].IsTouching(GoBoxRoom) || Player.GetComponents<CircleCollider2D>()[1].IsTouching(GoRoom) || PlayerCaixa.GetComponents<CircleCollider2D>()[1].IsTouching(GoRoom))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;

                AudioStoping("Bullying", 3);
                Destroy(gameObject, 0.5f);
            }
        }
	}

    void FindSoundtrackMenuAudio()
    {
        Soundtrack = FindObjectOfType<SoundtracksMenuAudio>();
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }

    void AudioStoping(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
