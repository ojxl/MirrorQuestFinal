using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Scene1"); // or whatever your menu scene is named
    }
}
