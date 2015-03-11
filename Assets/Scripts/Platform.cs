using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    void Start()
    {
    }

    void FixedUpdate()
    {
        // Move the platform towards the camera every fixed frame
        transform.Translate(0.0f, 0.0f, -Constants.WORLD_SPEED * Time.deltaTime);
    }
}