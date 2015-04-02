using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool IsActive { get; set; }

    void Start()
    {
        IsActive = false;
    }

    void FixedUpdate()
    {
        // Move the platform towards the camera every fixed frame
        if (IsActive)
        {
            transform.Translate(0.0f, 0.0f, -Constants.WORLD_SPEED * Time.deltaTime);

            Vector3 pos = transform.position;
            if (pos.z <= Constants.RECYCLE_POINT)
            {
                transform.position = new Vector3(0.0f, 0.5f, -10.0f);
                IsActive = false;
            }

        }
    }
}