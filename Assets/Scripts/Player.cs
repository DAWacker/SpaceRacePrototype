using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // Assumes three lanes for now
    enum Location { Left, Middle, Right };

    Location curLocation;
    float horizontalMovement = 3.0f;

    // These variables deal with limiting the player movement.  It prevents
    // the player from holding the key down and moving quickly across the platform.
    // It allows for a better interval of movement rather than quick teleportation.
    float inputCooldown = 0.15f;
    float durationSinceLastInput = 0.0f;
    bool gatherInput = true;

    void Start()
    {
        curLocation = Location.Middle;
    }

    void Update()
    {
        // Is it a good time to gather input?
        if (gatherInput)
        {
            // Check for left movement input
            if (Input.GetKey(KeyCode.A))
            {
                // Do not allow the player to move off the platform
                if (curLocation == Location.Left)
                    return;
                transform.Translate(-horizontalMovement, 0.0f, 0.0f);
                curLocation = curLocation == Location.Middle ? Location.Left : Location.Middle;
                gatherInput = false;
                durationSinceLastInput = 0.0f;
            }

            // Check for right movement input
            if (Input.GetKey(KeyCode.D))
            {
                // Do not allow the player to move off the platform
                if (curLocation == Location.Right)
                    return;
                transform.Translate(horizontalMovement, 0.0f, 0.0f);
                curLocation = curLocation == Location.Middle ? Location.Right : Location.Middle;
                gatherInput = false;
                durationSinceLastInput = 0.0f;
            }
        }

        else
        {
            durationSinceLastInput += Time.deltaTime;
            // It has been long enough since the last recorded input, begin gathering input again
            if (durationSinceLastInput >= inputCooldown)
                gatherInput = true;
        }
    }
}