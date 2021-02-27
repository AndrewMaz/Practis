using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject messageUI;

    GameObject changeLevel;

    bool _isFinished = false;

    private void Start()
    {
        changeLevel = GameObject.FindGameObjectWithTag("Canvases");
    }
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
            changeLevel.transform.Find("NextLevelCanvas").gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        else
            messageUI.SetActive(true);

    }
}
