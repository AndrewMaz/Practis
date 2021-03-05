using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    GameObject _player, _canvases;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _canvases = GameObject.FindGameObjectWithTag("Canvases");
    }
    public void Restart()
    {
        Destroy(_player);
        Destroy(_canvases);
        SceneManager.LoadScene(1);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
