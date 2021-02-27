using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] GameObject abilityListCanvas;
    public void ContinueHandler()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AbilityListHandler()
    {
        gameObject.SetActive(false);
        abilityListCanvas.SetActive(true);
    }
}
