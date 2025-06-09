using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider explvlSlider;
    public TMP_Text expLvlText;

    [SerializeField] string startSceneName = "Start";   // scene to load

    void Awake() => instance = this;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // press Esc to return
            LoadStartScene();
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;
        expLvlText.text = "Level: " + currentLvl;
    }

    public void LoadStartScene()               // hook this to a UI Button’s OnClick
    {
        SceneManager.LoadScene(startSceneName); // or use index 0: SceneManager.LoadScene(0);
    }
}