using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingLogic : MonoBehaviour
{
    public Transform playerTransform; // Referencia al transform del jugador
    public Texture2D floorTexture; // Referencia a la textura del suelo
    public Color paintColor = Color.red; // El color con el que pintaremos
    public int brushSize = 2; // Tamaño del "pincel"

    private void Start()
    {
        // Obtiene la textura del plano en el start y la convierte a Texture2D.
        Renderer renderer = GetComponent<Renderer>();
        Texture2D textureCopy = new Texture2D(floorTexture.width, floorTexture.height, floorTexture.format, false);
        Graphics.CopyTexture(floorTexture, textureCopy);
        renderer.material.mainTexture = textureCopy;
        floorTexture = textureCopy;
    }

    private void Update()
    {
        Vector3 playerPosRelativeToFloor = playerTransform.position - transform.position;
        // Pasar de posición del mundo a posición de textura
        int texturePosX = Mathf.FloorToInt((playerPosRelativeToFloor.x / transform.localScale.x + 0.5f) * floorTexture.width);
        int texturePosY = Mathf.FloorToInt((playerPosRelativeToFloor.z / transform.localScale.z + 0.5f) * floorTexture.height);
        // Pintar los píxeles
        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                floorTexture.SetPixel(texturePosX + i, texturePosY + j, paintColor);
            }
        }
        floorTexture.Apply();
    }
}