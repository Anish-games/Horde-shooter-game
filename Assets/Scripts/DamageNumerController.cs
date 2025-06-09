using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumerController : MonoBehaviour
{

    public static DamageNumerController Instance;
    public float spawnYOffset = 1f;

    private void Awake()
    {
        Instance = this;
    }
    public DamageNumber numberToSpawn;

    public Transform numberCanvas;

    private List<DamageNumber> numberPool = new List<DamageNumber>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int roundoff = Mathf.RoundToInt(damageAmount);

        // Calculate the spawn location using the offset.
        Vector3 spawnLocation = location + Vector3.up * spawnYOffset;

        // Use spawnLocation instead of location when instantiating.
        DamageNumber newDamage = GetFromPool();

        newDamage.Setup(roundoff);
        newDamage.gameObject.SetActive(true);

        newDamage.transform.position = location;
    }


    public DamageNumber GetFromPool()
    {
        DamageNumber numberToOutput = null;

        if (numberPool.Count == 0)
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        }
        else
        {
            numberToOutput = numberPool[0];
            numberPool.RemoveAt(0);
        }

        return numberToOutput;
    }
    public void PlaceInPool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);

        numberPool.Add(numberToPlace);
    }

}
