using UnityEngine;

public class MirrorPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddMirror();
            Destroy(gameObject);
        }
    }
}
