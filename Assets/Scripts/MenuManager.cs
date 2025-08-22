//Mnaages scebe transitions in the game. lets u load different scenes from UI triggers
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
// Loads the main menu scene when the game starts
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1"); // Or your first level scene
    }
// Loads all the different scenes based on the button pressed
    public void GoToScene1()
    {
        SceneManager.LoadScene("Scene1");//for ur scene1 
    }

    public void GoToScene2()
    {
        SceneManager.LoadScene("Scene2");//for ur scene2
    }
    public void GoToScene3()
    {
        SceneManager.LoadScene("Scene3");//for ur scene2
    }

    public void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");//for ur game over scene
    }

    public void GoToWin()
    {
        SceneManager.LoadScene("Win");//for ur win scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu"); // Load the main menu scene
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene1");// Restart the game by loading the first scene
    }
}



