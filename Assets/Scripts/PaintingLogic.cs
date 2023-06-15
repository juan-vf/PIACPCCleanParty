using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingLogic : MonoBehaviour
{
    public Transform playerTransform;
    public Texture2D floorTexture;
    public Color paintColor = Color.red;
    public int brushSize = 2;

    private Texture2D paintedTexture; // Textura pintada en formato RGBA32

    private void Start()
    {
        // Copiar la textura original en formato RGBA32
        paintedTexture = new Texture2D(floorTexture.width, floorTexture.height, TextureFormat.RGBA32, false);
        paintedTexture.SetPixels(floorTexture.GetPixels());
        paintedTexture.Apply();

        // Asignar la textura pintada al material del objeto
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = paintedTexture;
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

                // Pintar los píxeles
                for (int i = -brushSize; i <= brushSize; i++)
                {
                    for (int j = -brushSize; j <= brushSize; j++)
                    {
                        // Calcular el índice del píxel en el array de colores de la textura
                        int pixelIndex = (texturePixelY + j) * paintedTexture.width + (texturePixelX + i);

                        // Asignar el nuevo color al píxel en la textura
                        paintedTexture.SetPixel(texturePixelX + i, texturePixelY + j, paintColor);
                    }
                }

                // Aplicar los cambios a la textura
                paintedTexture.Apply();
            }
        }
        floorTexture.Apply();
    }
}

