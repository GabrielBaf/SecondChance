using UnityEngine;
using System.Collections;

public class KeysAudioDia4A_1 : MonoBehaviour {

    public BoxCollider2D Keys;
    public CircleCollider2D Player;

    public GameObject DialoguePanel;

    bool AlreadyPlayed = false;

	// Update is called once per frame
	void Update () {
        if (Player.IsTouching(Keys) && AlreadyPlayed == false && DialoguePanel.activeSelf)
        {
            AlreadyPlayed = true;

            AudioPlaying("CarKeys");

            Destroy(this, 0.5f);
        }
	}

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
