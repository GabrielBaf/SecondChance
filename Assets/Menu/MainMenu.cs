using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

   public void NovoJogo()
   {
       SceneManager.LoadScene(1);
   }
   
   public void Continuar()
   {
       //SceneManager.LoadScene("");
   }
   
   public void Opcoes()
   {
       //SceneManager.LoadScene("");
   }

    public void Cheats()
    {
        SceneManager.LoadScene(32);
    }
   
   public void Sair()
   {
       Application.Quit();
   }
}