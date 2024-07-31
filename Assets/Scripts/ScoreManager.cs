using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public AudioSource hitSFX;
    public AudioSource missSFX;

    public TMP_Text scoreText;
    public TMP_Text comboText;

    private static int comboScore;
    private static int totalScore;

    void Start()
    {
        Instance = this;
        comboScore = 0;
        totalScore = 0;
        UpdateUI();
    }

    public static void Hit()
    {
        comboScore += 1;
        totalScore += 1;  
        Instance.hitSFX.Play();
        Instance.UpdateUI();
    }

    public static void Miss()
    {
        comboScore = 0;
        Instance.missSFX.Play();  
        Instance.UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text =  totalScore.ToString();
        comboText.text =  comboScore.ToString();
    }

    private void Update()
    {
       
    }
}