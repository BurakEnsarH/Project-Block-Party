using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BestScoreData
{
    public int score = 10;
}

public class Scores : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public Text socreText;

    private bool newBestScore_ = false;
    private BestScoreData bestScores_ = new BestScoreData();
    private int currentScores_;

    private string bestScoreKey_ = "bsdat";

    private void Awake()
    {
        if(BinaryDataStream.Exist(bestScoreKey_))
        {
            StartCoroutine(ReadDataFile());
        }    
    }

    private IEnumerator ReadDataFile()
    {
        bestScores_ = BinaryDataStream.Read<BestScoreData>(bestScoreKey_);
        yield return new WaitForEndOfFrame();
        GameEvents.UpdateBestScoreBar(currentScores_, bestScores_.score);
    }

    void Start()
    {
        currentScores_ = 0;
        newBestScore_ = false;
        squareTextureData.SetStartColor();
        UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvents.AddScores += AddScores;
        GameEvents.GameOver += SaveBestScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScores -= AddScores;
        GameEvents.GameOver -= SaveBestScores;
    }

    public void SaveBestScores(bool newBestScores)
    {
        BinaryDataStream.Save<BestScoreData>(bestScores_, bestScoreKey_);
    }

    private void AddScores(int socres)
    {
        currentScores_ += socres;
        if(currentScores_ > bestScores_.score)
        {
            newBestScore_ = true;
            bestScores_.score = currentScores_;
            SaveBestScores(true);
        }

        UpdateSquareColor();
        GameEvents.UpdateBestScoreBar(currentScores_, bestScores_.score);
        UpdateScoreText();
    }

    private void UpdateSquareColor()
    {
        if( GameEvents.UpdateSquareColor != null && currentScores_ >= squareTextureData.tresholdVal)
        {
            squareTextureData.UpdateColors(currentScores_);
            GameEvents.UpdateSquareColor(squareTextureData.currentColor);
        }
    }

    private void UpdateScoreText()
    {
        socreText.text = currentScores_.ToString();
    }

}
