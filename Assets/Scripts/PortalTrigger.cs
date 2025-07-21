using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (gm.mirrorCount >= 3)
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    Debug.Log("Portal opened! Loading next scene...");
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    Debug.Log("Game complete! Loading menu...");
                    SceneManager.LoadScene("Menu"); // Or "Win", if you make a win screen
                }
            }
            else
            {
                Debug.Log("You need more mirrors to open the portal!");
            }
        }
    }
}
