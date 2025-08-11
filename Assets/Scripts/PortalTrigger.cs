using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
// SceneManager.GetActiveScene() and .buildIndex used from Unity Scripting API:
// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetActiveScene.html

            if (gm.mirrorCount >= 2)
            {
                string currentScene = SceneManager.GetActiveScene().name;

                if (currentScene == "Scene3")
                {
                    Debug.Log("Final level complete! Loading WIN screen...");
                    SceneManager.LoadScene("Win");
                }
                else
                {
                    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                    Debug.Log("Portal opened! Loading next scene...");
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
            else
            {
                Debug.Log("You need more mirrors to open the portal!");
            }
        }
    }
}
