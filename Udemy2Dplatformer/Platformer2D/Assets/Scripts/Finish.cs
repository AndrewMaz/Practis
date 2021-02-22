using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject changeLevel;
    [SerializeField] GameObject messageUI;

    bool _isFinished = false;
    public void ActivateFinish()
    {
        _isFinished = true;
        messageUI.SetActive(false);
    }

    public void FinishGame()
    {

        if (_isFinished)
        {
            gameObject.SetActive(false);
            changeLevel.SetActive(true);
            Time.timeScale = 0f;
        }

        else
            messageUI.SetActive(true);

    }
}
