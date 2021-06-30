using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameManager gameManager;
    
    // Start is called before the first frame update
    public void PlayGame()
    {
       // GameSceneManager.Load(GameSceneManager.Scene.Level1);
    }
    
    //OnClick Button
    public void StartGame()
    {
        gameManager.playerState = GameManager.PlayerState.Playing;
        gameManager.StartScreen.SetActive(false);
    }

    public void SkipLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //currentLevelDiamondCount = 0;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    
   
    
    public void ExitGame()
    { 
        Application.Quit();
    }
    
}
