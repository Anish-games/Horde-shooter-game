using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class spinWeapon : MonoBehaviour
{
    public float rotateSpeed = 50f;         // Speed at which the holder rotates
    public Transform player;                // Reference to the player
    public Transform holder;                // Reference to the Fireball Holder
    public float heightOffset = 1f;         // Height offset from the player's position

    private float angle = 0f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Place the holder at the player's position (with the height offset)
            holder.position = new Vector3(player.position.x,
                                          player.position.y + heightOffset,
                                          player.position.z);

            // Increment the rotation angle
            angle += rotateSpeed * Time.deltaTime;

            // Rotate the holder around the Y-axis (its pivot should be at the center)
            holder.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}


