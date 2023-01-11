using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DBC_Waypoints_Day4B : MonoBehaviour {

	public GameObject kevin;
	private Waypoints_4WPS kevinWP;
    public GameObject ronald;
    private Waypoints_4WPS ronaldWP;
    public GameObject charlie;
    private Waypoints_4WPS charlieWP;


	void Start ()
	{
		kevinWP = kevin.GetComponent<Waypoints_4WPS>();
        ronaldWP = ronald.GetComponent<Waypoints_4WPS>();
        charlieWP = charlie.GetComponent<Waypoints_4WPS>();
	}

	public void KevinWP()
	{
		kevinWP.firstWPs = true;
	}

    public void ronaldActive()
    {
        ronald.SetActive(true);
    }

    public void RonaldWP1()
    {
        ronaldWP.firstWPs = true;
    }

    public void RonaldWP2()
    {
        ronaldWP.secondWPS = true;
    }

    public void CharlieWP()
    {
        charlieWP.firstWPs = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(25);
    }
}