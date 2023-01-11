using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day3_3_VoltaQuarto : MonoBehaviour {

	public GameObject camHall;
	public GameObject camRoom;

	public GameObject FadeInn;

	public GameObject PlayerBox;
	public GameObject PlayerSunga;
	public GameObject EndText;

	public int LevelN;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator GoRoom()
	{
		FadeInn.SetActive(true);
		PlayerSunga.SetActive(false);
		PlayerBox.SetActive(false);
		yield return new WaitForSeconds(3f);
		camHall.SetActive(false);
		camRoom.SetActive(true);
		EndText.SetActive(true);
	}

	public IEnumerator NextLevel()
	{
		FadeInn.SetActive(true);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(LevelN);
	}

}
