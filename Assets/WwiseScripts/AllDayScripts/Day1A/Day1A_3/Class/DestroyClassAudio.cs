using UnityEngine;
using System.Collections;

public class DestroyClassAudio : MonoBehaviour {

    public GameObject Hall_Cam;

	// Update is called once per frame
	void Update () {

        if (Hall_Cam.activeSelf)
        {
            Destroy(gameObject.GetComponent<StephenAudio>());
            Destroy(gameObject.GetComponent<DanEKevinAudio>());
            Destroy(this, 0.5f);
        }
	}
}
