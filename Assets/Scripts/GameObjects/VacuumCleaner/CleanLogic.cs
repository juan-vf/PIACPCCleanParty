using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanLogic : MonoBehaviour
{
    private int ClearPixelCount = 0;
    private int DirtPixelCount = 0;
    public Transform playerTransform;
    public Transform EnemyTransform;
    public Texture2D floorTexture;
    public Color CleanColor = Color.blue;
    public Color DirtColor = Color.red;
    public int cleanSize = 8;
    private int cleanNormalSize;
    private Texture2D paintedTexture; // Textura pintada en formato RGBA32
    private ColorAnalizer colorAnalizer = new ColorAnalizer();
    private float time = 0f;
    private int PixelCountPaintedForStorage = 0;
    private bool Clean = false;
    private bool Dirt = false;
    public int brushSize = 2;
    private int brushNormalSize;

    private void Awake()
    {
        colorAnalizer.targetTexture = floorTexture;
        cleanNormalSize = cleanSize;
        // Copiar la textura original en formato RGBA32
        paintedTexture = new Texture2D(floorTexture.width, floorTexture.height, TextureFormat.RGBA32, false);
        paintedTexture.SetPixels(floorTexture.GetPixels());
        paintedTexture.Apply();
        // Asignar la textura pintada al material del objeto
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = paintedTexture;
    }
    private void Start()
    {
        cleanSize = 8;
        CleanColor = Color.blue;
        DirtColor = Color.red;
        brushSize = 8;
        brushNormalSize = brushSize;
        BatteryEventSystem.m_BES.OnBatteryLow += LowBrushSize;
        BatteryEventSystem.m_BES.OnCleaning += Cleaning;
        BatteryEventSystem.m_BES.OnDecomposed += () => { Clean = false; };

        FluffEventsManager.Instance.OnEnhanced += EnhacedChanges;
        FluffEventsManager.Instance.OnNormal += BrushReset;
        FluffEventsManager.Instance.OnEscape += NoBrush;

        FluffEventsManager.Instance.OnDirtying += Dirting;
    }
    private void Update()
    {
        if (Clean)
        {
            RaycastHit hit;
            Ray ray = new Ray(playerTransform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit))
            {
                Renderer renderer = hit.transform.GetComponent<Renderer>();
                if (renderer != null && renderer.material.mainTexture == paintedTexture)
                {
                    Debug.Log("empieza a limpiar 0111");
                    // Obtener las coordenadas de textura del impacto del rayo
                    Vector2 textureCoord = hit.textureCoord;
                    // Calcular las coordenadas de píxeles en la textura
                    int texturePixelX = Mathf.FloorToInt(textureCoord.x * paintedTexture.width);
                    int texturePixelY = Mathf.FloorToInt(textureCoord.y * paintedTexture.height);
                    // Pintar los píxeles

                    for (int i = -cleanSize; i <= cleanSize; i++)
                    {
                        for (int j = -cleanSize; j <= cleanSize; j++)
                        {
                            int pixelIndex = (texturePixelY + j) * paintedTexture.width + (texturePixelX + i);

                            // Asegúrate de que el pixel aún no está pintado para no contar repetidos
                            Color currentPixelColor = paintedTexture.GetPixel(texturePixelX + i, texturePixelY + j);
                            if (currentPixelColor != CleanColor)
                            {
                                paintedTexture.SetPixel(texturePixelX + i, texturePixelY + j, CleanColor);
                                ClearPixelCount++;
                                PixelCountPaintedForStorage++;
                                //CONTADOR ASPIRADORA AZUL
                                BatteryEventSystem.m_BES.CleaningPixels(ClearPixelCount);
                                Debug.Log("Aspiradora"+ClearPixelCount);
                            }
                        }
                    }
                    // // Aplicar los cambios a la textura
                    paintedTexture.Apply();
                }
            }
            PlayerPrefs.SetInt("PlayerScore", ClearPixelCount);
            Debug.Log(ClearPixelCount);
            PlayerPrefs.Save();
        }
        if (Dirt)
        {
            RaycastHit hit;
            Ray ray = new Ray(EnemyTransform.position, Vector3.down);

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
                    for (int i = -brushSize; i <= brushSize; i++)
                    {
                        for (int j = -brushSize; j <= brushSize; j++)
                        {
                            int pixelIndex = (texturePixelY + j) * paintedTexture.width + (texturePixelX + i);

                            // Asegúrate de que el pixel aún no está pintado para no contar repetidos
                            Color currentPixelColor = paintedTexture.GetPixel(texturePixelX + i, texturePixelY + j);
                            if (currentPixelColor != DirtColor)
                            {
                                paintedTexture.SetPixel(texturePixelX + i, texturePixelY + j, DirtColor);
                                DirtPixelCount++;
                                Debug.Log("Enemy"+DirtPixelCount);
                                //CONTADOR ASPIRADORA AZUL
                            }
                        }
                    }
                    paintedTexture.Apply();
                }
            }

            floorTexture.Apply();
            PlayerPrefs.SetInt("EnemyScore", DirtPixelCount);
            PlayerPrefs.Save();
        }
    }
    private void ResetPixels()
    {
        PixelCountPaintedForStorage = 0;
    }
    private void Cleaning()
    {
        Clean = !Clean;
    }
    private void LowBrushSize()
    {
        cleanSize = cleanSize - 4;
    }
    private int getPixelsClean { get { return ClearPixelCount; } }

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
    private void Dirting()
    {
        Dirt = !Dirt;
    }

}
