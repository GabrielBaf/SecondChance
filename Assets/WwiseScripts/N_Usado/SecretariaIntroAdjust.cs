using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecretariaIntroAdjust : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		if (gameObject.GetComponent<QuestAudio>() == null)
		{

			//Fixing ArgumentOutOfRangeException
			gameObject.GetComponent<QuestAudio_NoTrigger>().FixOtherScript();

            Destroy(this);

        }

		if (gameObject.GetComponent<QuestAudio_NoTrigger>().SizeOfList <= 1)
		{
			Destroy(gameObject.GetComponent<QuestAudio>());

			Destroy(this);
		}
    }

}
