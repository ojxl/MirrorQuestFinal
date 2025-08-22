//anytime i use CwC in the project it just means Create with Code like Unity
//Makes the camera follow the player
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
// Reference to the player GameObject
    public GameObject player;
    //how far above and behind the player the camera should be
    private Vector3 offset = new Vector3(0, 3, -6);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
