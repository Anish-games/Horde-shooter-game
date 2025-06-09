using UnityEngine;

public class DroneFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // set your offset here

    void LateUpdate()
    {
        // Make the drone follow the player’s position + offset
        transform.position = player.position + offset;
        // Optionally, reset rotation too:
        transform.rotation = Quaternion.identity;
    }
}