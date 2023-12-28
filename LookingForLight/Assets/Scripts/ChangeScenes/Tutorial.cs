using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject Player;
    public void OnButtonClick()
    {
        tutorialPanel.SetActive(false);
        Player.SetActive(true);
    }
}
