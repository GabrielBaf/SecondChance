using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DaySelect_Provisorio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Dia1()
    {
        SceneManager.LoadScene("CharlieHouse_Inicio");
    }

    public void Dia1Escola()
    {
        SceneManager.LoadScene("School_1");
    }

    public void Dia2()
    {
        SceneManager.LoadScene("CharlieHouse_Ini1");
    }

    public void Dia2Kevin()
    {
        SceneManager.LoadScene("Day2_SchoolKevinFight");
    }

    public void Dia2Refeitorio()
    {
        SceneManager.LoadScene("Day2_SchoolRefeitorio");
    }

    public void Dia3()
    {
        SceneManager.LoadScene("Day3_Casa1");
    }

    public void Dia3Vestiario()
    {
        SceneManager.LoadScene("Day3_VestiarioPiscina");
    }

}
