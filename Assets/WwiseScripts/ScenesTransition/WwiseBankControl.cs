using UnityEngine;
using UnityEngine.SceneManagement;


public class WwiseBankControl : MonoBehaviour {


public string Scene;
public float WaitSeconds;

// Use this for initialization
void Start()
{

        GetComponent<AkBank>().enabled = true;
}

// Update is called once per frame
void Update()
{
    if (SceneManager.GetSceneByName(Scene).isLoaded == false)
    {
        Invoke("WaitUncheckBank", WaitSeconds);
    }
}



void WaitUncheckBank()
{
    GetComponent<AkBank>().enabled = false;
}

}