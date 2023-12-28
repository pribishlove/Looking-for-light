using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLight : MonoBehaviour
{
    private GameObject spotlight;  // �������� ������ Spot Light 2D

    private void Start()
    {
        spotlight = transform.Find("SpotLight2D").gameObject; // ���������, ��� �������� ������ ����� ���������� ���
        spotlight.SetActive(false); // ��������� ���� ��� ������
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
        // �������� ��� ��������� ����
        spotlight.SetActive(activate);
    }
}