using UnityEngine;
using System.Collections;

public class SumirQuandoKevin : MonoBehaviour {

    public GameObject[] Sumir;
    public bool SumircomTudo;
    private bool sumiucomTudo;
    public GameObject Porta;
    public GameObject dialogodaporta;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (SumircomTudo)
        {
            sumiucomTudo = true;
            Porta.SetActive(true); dialogodaporta.SetActive(false);
            foreach (GameObject obj in Sumir)
            {
                obj.active = false;
            }
        }

        if(!SumircomTudo && sumiucomTudo)
        {
            sumiucomTudo = false;
            Porta.SetActive(false); dialogodaporta.SetActive(true);
            foreach (GameObject obj in Sumir)
            {
                obj.active = true;
            }

        }
	
	}
}
