using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreBar : MonoBehaviour
{
    public Image fillInImage;
    public Text bestScoreText;

    private void OnEnable()
    {
        GameEvents.UpdateBestScoreBar += UpdateBestScoreBar;
    }

    private void OnDisable()
    {
        GameEvents.UpdateBestScoreBar -= UpdateBestScoreBar;
    }

    private void UpdateBestScoreBar(int currentScore, int bestScore)
    {
        float currentPrecentage = (float)currentScore / (float)bestScore;
        fillInImage.fillAmount = currentPrecentage;
        bestScoreText.text = bestScore.ToString();
    }

}
