using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{

    public float amountOfDamage;
    public bool shouldKnockback;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        { 
            other.GetComponent<enemyController>().takeDamage(amountOfDamage , shouldKnockback);
        }
    }
}
