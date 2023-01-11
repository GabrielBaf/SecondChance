using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeChange : MonoBehaviour {

    public Vector2 pos;
    public GameObject player;
    public GameObject charlie;
    public GameObject charlieD;

    public void Fade()
    {
        player.transform.position = pos;
        charlie.SetActive(true);
        charlieD.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Dia4B4");
    }
}
