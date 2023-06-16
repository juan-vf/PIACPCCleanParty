using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingLogic : MonoBehaviour
{
    public int paintedPixelCount = 0;
    public Transform playerTransform;
    public Texture2D floorTexture;
    public Color paintColor = Color.red;
    public int brushSize = 2;
    private int brushNormalSize;

    private Texture2D paintedTexture; // Textura pintada en formato RGBA32

    private void Start()
    {
        brushSize = 8;
        brushNormalSize = brushSize;
        // Copiar la textura original en formato RGBA32
        paintedTexture = new Texture2D(floorTexture.width, floorTexture.height, TextureFormat.RGBA32, false);
        paintedTexture.SetPixels(floorTexture.GetPixels());
        paintedTexture.Apply();

        // Asignar la textura pintada al material del objeto
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = paintedTexture;

        FluffEventsManager.Instance.OnEnhanced += EnhacedChanges;
        FluffEventsManager.Instance.OnNormal += BrushReset;
        FluffEventsManager.Instance.OnEscape += NoBrush;



    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerTransform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit))
        {
            Renderer renderer = hit.transform.GetComponent<Renderer>();

            if (renderer != null && renderer.material.mainTexture == paintedTexture)
            {
                // Obtener las coordenadas de textura del impacto del rayo
                Vector2 textureCoord = hit.textureCoord;

                // Calcular las coordenadas de píxeles en la textura
                int texturePixelX = Mathf.FloorToInt(textureCoord.x * paintedTexture.width);
                int texturePixelY = Mathf.FloorToInt(textureCoord.y * paintedTexture.height);

                //Pintar los píxeles
                //for (int i = -brushSize; i <= brushSize; i++)
                //{
                //    for (int j = -brushSize; j <= brushSize; j++)
                //    {
                //        Calcular el índice del píxel en el array de colores de la textura
                //        int pixelIndex = (texturePixelY + j) * paintedTexture.width + (texturePixelX + i);

                //        Asignar el nuevo color al píxel en la textura
                //        paintedTexture.SetPixel(texturePixelX + i, texturePixelY + j, paintColor);
                //    }
                //}

                //Aplicar los cambios a la textura
                //paintedTexture.Apply();
                for (int i = -brushSize; i <= brushSize; i++)
                {
                    for (int j = -brushSize; j <= brushSize; j++)
                    {
                        int pixelIndex = (texturePixelY + j) * paintedTexture.width + (texturePixelX + i);

                        // Asegúrate de que el pixel aún no está pintado para no contar repetidos
                        Color currentPixelColor = paintedTexture.GetPixel(texturePixelX + i, texturePixelY + j);
                        if (currentPixelColor != paintColor)
                        {
                            paintedTexture.SetPixel(texturePixelX + i, texturePixelY + j, paintColor);
                            paintedPixelCount++;
                            //Debug.Log("PIXELES CONTADOR" + paintedPixelCount);
                        }
                    }
                }

                paintedTexture.Apply();


            }
        }
     
        floorTexture.Apply();
    }

    private void EnhacedChanges()
    {
        brushSize = brushNormalSize + 4;
    }
    private void BrushReset()
    {
        brushSize = brushNormalSize;
    }
    private void NoBrush()
    { 
        brushSize = 0; 
    
    }
}

