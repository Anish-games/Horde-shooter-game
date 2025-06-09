using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public PlayerShooter playerShooter;
    public float shooterActiveDuration = 5f;
    public float cooldownDuration = 10f;
    public GameObject crossImage;
    public GameObject eText;

    private bool shooterActive = false;
    private bool inCooldown = false;

    void Start()
    {
        if (playerShooter != null)
        {
            playerShooter.enabled = false;
        }
        if (crossImage != null)
        {
            crossImage.SetActive(false);
        }
        if (eText != null)
        {
            eText.SetActive(true);
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
        if (crossImage != null)
        {
            crossImage.SetActive(true);
        }
        if (eText != null)
        {
            eText.SetActive(false);
        }
        yield return new WaitForSeconds(cooldownDuration);
        inCooldown = false;
        if (crossImage != null)
        {
            crossImage.SetActive(false);
        }
        if (eText != null)
        {
            eText.SetActive(true);
        }
    }
}