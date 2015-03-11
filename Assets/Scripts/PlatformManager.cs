using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    List<Platform> activePlatforms;

    void Start()
    {
        // Gather all platforms in the scene
        activePlatforms = FindObjectsOfType<Platform>().ToList();

        // Place the platforms next to eachother
        for (int platform = 0; platform < activePlatforms.Count; platform++)
            activePlatforms[platform].transform.position = new Vector3(0.0f, 0.0f, platform * Constants.PLATFORM_LENGTH);
    }

    void Update()
    {
        for (int platform = 0; platform < activePlatforms.Count; platform++)
        {
            var curPlatform = activePlatforms[platform];
            // Check if the current platform has reached to point to where it will be recycled to the back
            if (curPlatform.transform.position.z <= Constants.RECYCLE_POINT)
            {
                // Grab the platform currently at the end of the stack
                var prevIndex = platform - 1 < 0 ? activePlatforms.Count - 1 : platform - 1;
                var prevPlatform = activePlatforms[prevIndex];

                // Set the current platform behind the last platform
                curPlatform.transform.position = new Vector3(0.0f, 0.0f, prevPlatform.transform.position.z + Constants.PLATFORM_LENGTH);
            }
        }
    }
}