using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelDan : MonoBehaviour {

    public void NextLevel()
    {
        SceneManager.LoadScene(30);
    }
}
