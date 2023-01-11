using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControler5B2G : MonoBehaviour {

	public GameObject George;
	public GameObject Charlie5B;
	public GameObject Case;
	public GameObject Jantar2;

	private Waypoints_4WPS George5BG;
	private Waypoints_4WPS Charlie5BG;
	private Waypoints_4WPS Case5BG;
    public int LevelN;

    // Use this for initialization
    void Start () {
		George5BG = George.GetComponent<Waypoints_4WPS> ();
		Charlie5BG = Charlie5B.GetComponent<Waypoints_4WPS> ();
		Case5BG = Case.GetComponent<Waypoints_4WPS> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Sair(){
		George5BG.firstWPs = true;
	}
	public void IrCozinha(){
		George5BG.secondWPS = true;
	}
	public void IrCozinhaSair(){
		George5BG.thirdWPs = true;
	}
	public void IrPraCima(){
		Charlie5BG.firstWPs = true;
	}
	public void IrJogarCima(){
		Case5BG.firstWPs = true;
	}
	public void FimJantar1 (){
		Jantar2.SetActive(true);
	}
    public void NextStage()
    {
        StartCoroutine(NextLevel());

    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(LevelN);
    }


}
