using UnityEngine;

public class RotateObject : MonoBehaviour   // or Spin
{
    public float speed = 180f;              // degrees per second

    void Update()
    {
        // Rotate around Y axis by 'speed' degrees/second
        //Unit 4 and unit 1 
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
