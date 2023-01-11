using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WPControllerDia5A : MonoBehaviour {

    public GameObject outside;

	void Start ()
    {

	}
	
	void Update ()
    {
	
	}

    public void Outside()
    {
        outside.SetActive(true);
    }

    public void AulaTreta()
    {
        SceneManager.LoadScene("Dia5A2");
    }
}