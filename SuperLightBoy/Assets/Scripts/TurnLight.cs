using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLight : MonoBehaviour
{
    private GameObject spotlight;  // Дочерний объект Spot Light 2D

    private void Start()
    {
        spotlight = transform.Find("SpotLight2D").gameObject; // Убедитесь, что дочерний объект имеет правильное имя
        spotlight.SetActive(false); // Выключаем свет при старте
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateSpotlight(true);
        }
    }

    private void ActivateSpotlight(bool activate)
    {
        // Включаем или выключаем свет
        spotlight.SetActive(activate);
    }
}