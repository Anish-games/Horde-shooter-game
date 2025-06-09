using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    public float maxRange = 50f; // Editable range in the Inspector

    public LineRenderer lineRenderer; // Assign this in the Inspector

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        // Setup the line renderer initially
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true; // We'll control this via OnEnable/OnDisable
    }

    // When the PlayerShooter is enabled, show the line renderer.
    void OnEnable()
    {
        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
        }
    }

    // When the PlayerShooter is disabled, hide the line renderer.
    void OnDisable()
    {
        if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
        }
    }

    void Update()
    {
        // Get the current mouse cursor position in world space
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(1000);
        }

        // Determine direction and limit the distance to maxRange
        Vector3 direction = (targetPoint - firePoint.position).normalized;
        float distance = Vector3.Distance(firePoint.position, targetPoint);
        if (distance > maxRange)
        {
            targetPoint = firePoint.position + direction * maxRange;
        }

        // Update the Line Renderer's positions for continuous aiming
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, targetPoint);

        // Fire projectile on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direction * projectileSpeed, ForceMode.VelocityChange);
            }
        }
    }
}