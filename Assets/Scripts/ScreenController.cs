using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [field:SerializeField] public GameObject WinnerScreen { get; private set; }
    [field:SerializeField] public GameObject GameOverScreen { get; private set; }
    [SerializeField] private GameObject _lineDrawer;

    public void ActivateScreen(GameObject screen)
    {
        screen.SetActive(true);
        _lineDrawer.SetActive(false);
    }
}
