using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private XPSystem xpSystem;

    private void Start()
    {
        if (xpSystem == null)
        {
            Debug.LogError("XPSystem is not assigned to ProgressBarUI.");
        }
    }

    private void Update()
    {
        if (xpSystem != null)
        {
            image.fillAmount = xpSystem.GetNormalizedXP();
        }
    }
}
