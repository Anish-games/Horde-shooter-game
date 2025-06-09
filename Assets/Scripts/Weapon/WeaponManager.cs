using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
   
    public PlayerShooter playerShooter;

    public float shooterActiveDuration = 5f;

    
    public float cooldownDuration = 10f;

    private bool shooterActive = false;
    private bool inCooldown = false;

    void Start()
    {
       
        if (playerShooter != null)
        {
            playerShooter.enabled = false;
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !shooterActive && !inCooldown)
        {
            shooterActive = true;
            if (playerShooter != null)
            {
                playerShooter.enabled = true;
            }
            StartCoroutine(HandlePlayerShooterActivation());
        }
    }

    IEnumerator HandlePlayerShooterActivation()
    {
        
        yield return new WaitForSeconds(shooterActiveDuration);

        
        if (playerShooter != null)
        {
            playerShooter.enabled = false;
        }
        shooterActive = false;

        
        inCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        inCooldown = false;
    }
}