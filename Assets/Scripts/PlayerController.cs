using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    public bool playerIsSafe = false;


    public CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;


    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer.y = 0;
        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * Time.deltaTime * playerSpeed);




    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Obtener el objeto del suelo y su componente Renderer
            GameObject suelo = collision.gameObject;
            Renderer sueloRenderer = suelo.GetComponent<Renderer>();

            // Obtener la posición de colisión
            Vector3 puntoDeColision = collision.contacts[0].point;

            // Obtener las coordenadas de textura correspondientes al punto de colisión
            Vector2 coordenadasTextura = sueloRenderer.material.mainTextureScale;
            coordenadasTextura.x *= puntoDeColision.x / suelo.transform.lossyScale.x;
            coordenadasTextura.y *= puntoDeColision.z / suelo.transform.lossyScale.z;

            Debug.Log("Coordenadas de textura: X = " + coordenadasTextura.x + ", Y = " + coordenadasTextura.y);
    

            // Modificar el color de la textura del suelo en las coordenadas de textura correspondientes
            Texture2D texturaSuelo = (Texture2D)sueloRenderer.material.mainTexture;
            texturaSuelo.SetPixel((int)coordenadasTextura.x, (int)coordenadasTextura.y, Color.black);
            texturaSuelo.Apply(); // Aplicar los cambios a la textura

            // Asignar la textura modificada al material del suelo
            sueloRenderer.material.mainTexture = texturaSuelo;
        }
    }
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }
}
