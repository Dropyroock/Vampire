using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class EXPManager : MonoBehaviour
{
    public static EXPManager instance;
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel, totalExperience;
    int previousLevelsExperience, nextLevelsExperience;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image expericeFill;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevel();
    }

    public void AddExperience(int ammount) 
    {
        totalExperience += ammount;
        CheckForLevelUp();
        updateInterface();
    }

    void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            UpdateLevel();
        }
    }

    void UpdateLevel()
    {
        previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        updateInterface();
    }

    void updateInterface()
    {
        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + " exp / " + end + " exp";
        expericeFill.fillAmount = (float)start / (float)end;
    }
}
