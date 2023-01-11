using UnityEngine;
using System.Collections;

public class GC_Day5B_1 : MonoBehaviour {

    public int LevelN;

    public GameObject IntroFade;
    private bool nada1 = true;

    public GameObject Player;
    private PlayerMovement PMov;

    // Use this for initialization
    void Start () {
        
        PMov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (IntroFade.activeSelf == true)
        {
            PMov.enabled = false;
        }

        if (IntroFade.activeSelf == false && nada1)
        {
            PMov.enabled = true; nada1 = false;
        }

    }
}
