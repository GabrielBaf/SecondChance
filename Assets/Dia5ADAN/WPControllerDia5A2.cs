using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WPControllerDia5A2 : MonoBehaviour {

    public GameObject kevin;
    private Waypoints_4WPS kevinWP;
    public GameObject dan;
    private Waypoints_4WPS danWP;
    public GameObject bob;
    private Waypoints_4WPS bobWP;
    public GameObject emily;
    private Waypoints_4WPS emilyWP;
    public GameObject jenna;
    private Waypoints_4WPS jennaWP;
    public GameObject pamela;
    private Waypoints_4WPS pamelaWP;
    public GameObject steven;
    private Waypoints_4WPS stevenWP;

    public void Start()
    {
        kevinWP = kevin.GetComponent<Waypoints_4WPS>();
        danWP = dan.GetComponent<Waypoints_4WPS>();
        bobWP = bob.GetComponent<Waypoints_4WPS>();
        emilyWP = emily.GetComponent<Waypoints_4WPS>();
        jennaWP = jenna.GetComponent<Waypoints_4WPS>();
        pamelaWP = pamela.GetComponent<Waypoints_4WPS>();
        stevenWP = steven.GetComponent<Waypoints_4WPS>();
    }

    public void ativaWPs()
    {
        kevinWP.firstWPs = true;
        danWP.firstWPs = true;
        bobWP.firstWPs = true;
        emilyWP.firstWPs = true;
        jennaWP.firstWPs = true;
        pamelaWP.firstWPs = true;
        stevenWP.firstWPs = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Dia5A3");
    }
}