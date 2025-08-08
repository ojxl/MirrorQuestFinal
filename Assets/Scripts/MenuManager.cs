using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1"); // Or your first level scene
    }

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
}



