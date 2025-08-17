using UnityEngine;
using UnityEngine.SceneManagement;

public class ThornDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the GameManager and call LoseLife method
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.LoseLife();
            // play a sound effect when the player takes damage
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null) audio.Play();

        }
    }
}
