//This script handles the portal trigger logic in the game
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    //called automatically when another collider enters the trigger collider attached to the same GameObject
    void OnTriggerEnter(Collider other)
    {
        //checks if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            //finds the GameManager object in the scene and gets its 
            // GameManager to check if in the game the player has enough mirrors 
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

            //if the player has enough mirrors, it loads the next scene or the win screen
            if (gm.mirrorCount >= 3)
            {
                // Get the current scene name to determine if it's the final level
                string currentScene = SceneManager.GetActiveScene().name;

                // If the current scene is "Scene3", load the win screen
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
