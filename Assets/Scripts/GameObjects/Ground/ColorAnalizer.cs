using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAnalizer : MonoBehaviour
{
    public Texture2D targetTexture;
    public Color colorToCountClean = Color.white;
    private float percentajeOfClean = 0f;
    public Color colorToCountDirt = Color.red;
    private float percentajeOfDirt = 0f;
    public ColorAnalizer(){}
    public void CAnalizer(){
        int pixelCount = 0;
        int colorCountClean = 0;
        // int colorCountDirt = 0;

        Color[] pixels = targetTexture.GetPixels();

        // Contar píxeles y ocurrencias del color especificado
        foreach (Color pixel in pixels)
        {
            pixelCount++;

            if (pixel == colorToCountClean)
            {
                colorCountClean++;
            }//else if (pixel == colorToCountDirt)
            // {
            //     colorCountDirt++;
            // }
        }
        float colorPercentage = (float)colorCountClean / pixelCount * 100f;
        Debug.Log("Cantidad de píxeles del color " + colorToCountClean + ": " + colorCountClean);
        Debug.Log("Porcentaje de textura pintada de " + colorToCountClean + ": " + colorPercentage.ToString("F2") + "%");

        // colorPercentage = (float)colorCountDirt / pixelCount * 100f;
        // Debug.Log("Cantidad de píxeles del color " + colorToCountDirt + ": " + colorCountDirt);
        // Debug.Log("Porcentaje de textura pintada de " + colorToCountDirt + ": " + colorPercentage.ToString("F2") + "%");
    }
    public float getPercentajeClean{
        get {return percentajeOfClean;}
    }
    public float getPercentajeDirt{
        get{return percentajeOfDirt;}
    }
    
}