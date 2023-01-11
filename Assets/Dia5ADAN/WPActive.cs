using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WPActive : MonoBehaviour {

    public GameObject kevin;
    private Waypoints_4WPS kevinWP;
    public GameObject charlie;
    public GameObject charliePool;

    void Start()
    {
        kevinWP = kevin.GetComponent<Waypoints_4WPS>();
    }

    public void KevinWP()
    {
        kevinWP.firstWPs = true;
    }

    public void CharlieSprite()
    {
        charlie.SetActive(false);
        charliePool.SetActive(true);
    }

    public void NextLevel1()
    {
        SceneManager.LoadScene("Dia4B3");
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene("Dia4B5");
    }

    public void NextLevel3()
    {
        SceneManager.LoadScene("Dia4B6");
    }
}
