//anytie i use CwC in the project it just means Create with Code like Unity

using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 3, -6);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
