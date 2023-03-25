using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSquareImageSelector : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public bool updateImageOnRechedTreshold = false;

    private void OnEnable()
    {
        UpdateSquareColorBasedOnCurrentPoints();

        if (updateImageOnRechedTreshold)
            GameEvents.UpdateSquareColor += UpdateSquaresColor;

    }

    private void OnDisable()
    {
        if (updateImageOnRechedTreshold)
            GameEvents.UpdateSquareColor -= UpdateSquaresColor;
    }

    private void UpdateSquareColorBasedOnCurrentPoints()
    {
        foreach (var squareTexture in squareTextureData.activateSquareTextures)
        {
            if (squareTextureData.currentColor == squareTexture.squareColor)
            {
                GetComponent<Image>().sprite = squareTexture.texture;
            }
        }

    }

    private void UpdateSquaresColor(Config.SquareColor color)
    {
        foreach(var squareTexture in squareTextureData.activateSquareTextures)
        {
            if(color == squareTexture.squareColor)
            {
                GetComponent<Image>().sprite = squareTexture.texture;
            }
        }
    }
}
