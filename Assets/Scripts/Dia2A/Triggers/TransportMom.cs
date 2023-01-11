using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransportMom : MonoBehaviour {

    public bool transport;
    private bool nada1 = true;
    public bool maeNaCozinha;
    public Vector2 IrpraCozinha;
    public GameObject Mom;
    private Waypoint_1WPS WPMom;
    private NPCFacePlayer faceplayer;

    public GameObject FalanaCozinha;
    public GameObject LongFade;

    public int LevelN;

    // Use this for initialization
    void Start()
    {
        WPMom = Mom.GetComponent<Waypoint_1WPS>();
        faceplayer = Mom.GetComponent<NPCFacePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transport)
        {
            Mom.transform.position = IrpraCozinha;
            WPMom.firstWPs = false;
            WPMom.enabled = false;
            transport = false;
        }

        if (maeNaCozinha && nada1)
        {
            nada1 = false;
            MaenaCozinha();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Kate")
        {
            transport = true;
        }
    }

    public void MomWalk()
    {
        WPMom.firstWPs = true;
        faceplayer.enabled = false;
    }

    public void MaenaCozinha()
    {
        FalanaCozinha.SetActive(true); faceplayer.enabled = true;
    }

    public void IrpraEscola()
    {
        LongFade.SetActive(true);
        //trocar isso nas novas builds
        SceneManager.LoadScene(LevelN);
    }

}
