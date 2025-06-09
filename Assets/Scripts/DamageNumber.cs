using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText;

    public float Floatspeed = 1f;

    public float lifeTime;
    private float lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = lifeTime;

    }
    // Update is called once per frame
    void Update()
    {
        if (lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime;

            if (lifeCounter <= 0)
            {
                DamageNumerController.Instance.PlaceInPool(this);
            }

        }

        transform.position += Vector3.up * Floatspeed * Time.deltaTime;
    }

    public void Setup(int damageDisplay)
    {
        lifeCounter = lifeTime;

        damageText.text = damageDisplay.ToString();
    }

}
