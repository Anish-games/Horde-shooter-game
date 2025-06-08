using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera targetCamera; // Assign your main camera in the Inspector

    void LateUpdate()
    {
        // Determine the direction to the camera...
        Vector3 targetPosition = transform.position + targetCamera.transform.rotation * Vector3.forward;
        // ...and the up direction (to keep it upright)
        Vector3 upDirection = targetCamera.transform.rotation * Vector3.up;

        // Rotate the slider to face the camera
        transform.LookAt(targetPosition, upDirection);
    }
}