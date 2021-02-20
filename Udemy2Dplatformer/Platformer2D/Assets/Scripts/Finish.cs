using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    bool _isFinished = false;
    public void ActivateFinish()
    {
        _isFinished = true;
    }

    public void FinishGame()
    {
        if (_isFinished)
            gameObject.SetActive(false);
    }
}
