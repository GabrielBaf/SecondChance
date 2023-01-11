using UnityEngine;
using System.Collections;

public class DetectChars : MonoBehaviour {

    public GameObject Steven;
    public GameObject Pamela;
    public GameObject Jenny;
    public GameObject Jenna;
    public GameObject BigB;
    public GameObject Kevin;
    public GameObject Dan;

    public GameObject Elizabeth;

    private bool StevenH;
    private bool PamelaH;
    private bool JennyH;
    private bool JennaH;
    private bool BigBH;
    private bool KevinH;
    private bool DanH;

    private bool ElizabethH;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (StevenH)
        {
            Steven.SetActive(false);
            StevenH = false;
        }

        if (PamelaH)
        {
            Pamela.SetActive(false);
            StevenH = false;
        }

        if (JennyH)
        {
            Jenny.SetActive(false);
            JennyH = false;
        }
        if (JennaH)
        {
            Jenna.SetActive(false);
            JennaH = false;
        }
        if (BigBH)
        {
            BigB.SetActive(false);
            BigBH = false;
        }
        if (KevinH)
        {
            Kevin.SetActive(false);
            KevinH = false;
        }
        if (DanH)
        {
            Dan.SetActive(false);
            DanH = false;
        }

        if (ElizabethH)
        {
            Elizabeth.SetActive(false);
            ElizabethH = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Pamela")
        {
            PamelaH = true;
        }

        if (other.name == "Steven")
        {
            StevenH = true;
        }

        if (other.name == "Jenny")
        {
            JennyH = true;
        }
        if (other.name == "Jenna")
        {
            JennaH = true;
        }
        if (other.name == "BigB")
        {
            BigBH = true;
        }
        if (other.name == "Kevin")
        {
            KevinH = true;
        }
        if (other.name == "Dan")
        {
            DanH = true;
        }


        if (other.name == "Elizabeth")
        {
            ElizabethH = true;
        }

            }

}
