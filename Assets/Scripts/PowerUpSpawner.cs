using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float spawnInterval = 45f; // Tiempo entre spawns, modificable desde el Inspector

    private List<GameObject> powerUps; // Lista de power-ups

    void Start()
    {
        // Rellena la lista de power-ups con los hijos de este objeto
        powerUps = new List<GameObject>();
        foreach (Transform child in transform)
        {
            powerUps.Add(child.gameObject);
        }

        // Desactiva todos los power-ups al inicio
        foreach (GameObject powerUp in powerUps)
        {
            powerUp.SetActive(false);
        }

        // Inicia la corutina que maneja el spawn de power-ups
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Espera el intervalo de tiempo definido
            
            yield return new WaitForSeconds(spawnInterval);

            // Desactiva todos los power-ups
            foreach (GameObject powerUp in powerUps)
            {
                if (powerUp != null)
                {
                    powerUp.SetActive(false);
                }
            }

            // Activa un power-up aleatorio
            if (powerUps != null)
            {

                int randomIndex = Random.Range(0, powerUps.Count);
                if (powerUps[randomIndex] != null)
                { 
                    powerUps[randomIndex].SetActive(true);
               
                }
            }
        }
    }
}