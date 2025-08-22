//Allows the player to collect mirrors in the game
using UnityEngine;

public class MirrorPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Find the GameManager and call AddMirror method
            //
            GameObject.Find("GameManager").GetComponent<GameManager>().AddMirror();
            //Remove the mirror from the scene after collection
            Destroy(gameObject);
        }
    }
}
