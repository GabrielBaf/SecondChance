using UnityEngine;
using System.Collections;

public class MaenaCozinha : MonoBehaviour {

    public bool MomHere;
    public GameObject TransportMae;
    private TransportMom transportScript;

	// Use this for initialization
	void Start () {

        transportScript = TransportMae.GetComponent<TransportMom>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (MomHere)
        {
            transportScript.maeNaCozinha = true;
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Kate")
        {
            MomHere = true;
        }
    }

}
