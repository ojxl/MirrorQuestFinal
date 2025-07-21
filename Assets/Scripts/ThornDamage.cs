using UnityEngine;
using UnityEngine.SceneManagement;

public class ThornDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.LoseLife();
        }
    }
}
