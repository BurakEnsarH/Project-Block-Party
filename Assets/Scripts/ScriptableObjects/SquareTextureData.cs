using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class SquareTextureData : ScriptableObject
{
    [System.Serializable]
    public class TextureData
    {
        public Sprite texture;
        public Config.SquareColor squareColor;
    }

    public int tresholdVal = 10;
    private const int StartTresholdVal = 10;
    public List<TextureData> activateSquareTextures;

    public Config.SquareColor currentColor;
    private Config.SquareColor _nextColor;

    public int GetCurrentColorIndex()
    {
        var currentIndex = 0;

        for(int index = 0; index < activateSquareTextures.Count ; index++)
        {
            if (activateSquareTextures[index].squareColor == currentColor)
            {
                currentIndex = index;
            }
        }

        return currentIndex;
    }

    public void UpdateColors(int current_score)
    {
        currentColor = _nextColor;
        var currentColorIndex = GetCurrentColorIndex();

        if (currentColorIndex == activateSquareTextures.Count - 1)
            _nextColor = activateSquareTextures[0].squareColor;
        else
            _nextColor = activateSquareTextures[currentColorIndex + 1].squareColor;

        tresholdVal = StartTresholdVal + current_score;
        
    }

    public void SetStartColor()
    {
        tresholdVal = StartTresholdVal;
        currentColor = activateSquareTextures[0].squareColor;
        _nextColor = activateSquareTextures[1].squareColor;
    }

    private void Awake()
    {
        SetStartColor();
    }

    private void OnEnable()
    {
        SetStartColor();
    }
}
