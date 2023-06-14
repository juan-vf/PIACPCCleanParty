using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingLogic : MonoBehaviour
{
    public Transform playerTransform;
    public Texture2D floorTexture;
    public Color paintColor = Color.red;
    public int brushSize = 2;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Texture2D textureCopy = new Texture2D(floorTexture.width, floorTexture.height, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(floorTexture, textureCopy);
        renderer.material.mainTexture = textureCopy;
        floorTexture = textureCopy;
    }

    private void Update()
    {
        Vector3 playerPosRelativeToFloor = playerTransform.position - transform.position;
        Debug.Log(playerTransform.position);
        

        int texturePosX = Mathf.FloorToInt((playerPosRelativeToFloor.x / transform.localScale.x + 2) * floorTexture.width);
        int texturePosY = Mathf.FloorToInt((playerPosRelativeToFloor.z / transform.localScale.z + 2) * floorTexture.height);

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