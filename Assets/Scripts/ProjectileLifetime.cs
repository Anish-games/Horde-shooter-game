using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    
    public float maxDistance = 50f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        float distanceTravelled = Vector3.Distance(startPosition, transform.position);
        if (distanceTravelled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}