using UnityEngine;
using System.Collections;

public class Intros : MonoBehaviour {

    public GameObject IntroOBJ;
    public GameObject IntroText;
    public GameObject Player;
    private PlayerMovement PMov;
    private bool IntroOn = true;

	// Use this for initialization
	void Start () {

        PMov = Player.GetComponent<PlayerMovement>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (IntroOBJ.activeSelf)
        {
            PMov.enabled = false;
        }

        if (!IntroOBJ.activeSelf && IntroOn)
        {
            IntroText.SetActive(true);
            PMov.enabled = true;
            IntroOn = false;
        }
	
	}
}
