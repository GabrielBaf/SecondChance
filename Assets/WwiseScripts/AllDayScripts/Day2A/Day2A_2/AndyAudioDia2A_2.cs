using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class AndyAudioDia2A_2 : MonoBehaviour {

    public ConversationTrigger AndyDay2A_2;
    public GameObject NPCSubtitlePanel;

    bool IsPlaying = false;


    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    // Update is called once per frame
    void Update()
    {

        if (AndyDay2A_2 == null && NPCSubtitlePanel.activeSelf)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;

                AndyAudioPlay();

            }
        }


        if (IsPlaying == true && NPCSubtitlePanel.activeSelf == false)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;

            Destroy(this);
        }

    }

    void AndyAudioPlay()
    {
        gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
    }


}
