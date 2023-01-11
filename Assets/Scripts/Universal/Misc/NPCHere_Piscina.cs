using UnityEngine;
using System.Collections;

public class NPCHere_Piscina : MonoBehaviour
{

    public bool Kevin;
    public bool Emily;
    public bool Brian;
    public bool Steven;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "BigB")
        {
            Brian = true;
        }

        if (other.name == "Emily")
        {
            Emily = true;
        }

        if (other.name == "StevenPool")
        {
            Steven = true;
        }

        if (other.name == "Kevin")
        {
            Kevin = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "BigB")
        {
            Brian = false;
        }

        if (other.name == "Emily")
        {
            Emily = false;
        }

        if (other.name == "StevenPool")
        {
            Steven = false;
        }

        if (other.name == "Kevin")
        {
            Kevin = false;
        }

    }

}
