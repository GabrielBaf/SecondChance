using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WPControllerDia5A3 : MonoBehaviour {

    public GameObject kate;
    public GameObject kate1;
    public GameObject escada;

	void Start ()
    {

	}
	
	void Update ()
    {

	}

    public void TrocaKatie()
    {
        kate.SetActive(false);
        kate1.SetActive(true);
    }

    public void Escada()
    {
        escada.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Dia5A4");
    }
}