using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider explvlSlider;
    public TMP_Text expLvlText;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;

        expLvlText.text = "Level: " + currentLvl;
    }
}
