using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    GameObject _player, _canvases;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _canvases = GameObject.FindGameObjectWithTag("Canvases");
    }
    public void NextLevelHandler()
    {
        DontDestroyOnLoad(_player);
        DontDestroyOnLoad(_canvases);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

}
