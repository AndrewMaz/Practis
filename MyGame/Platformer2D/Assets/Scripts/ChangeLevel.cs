using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    GameObject _player, _camera, _canvases;
    public void NextLevelHandler()
    {
        DontDestroyOnLoad(_player = GameObject.FindGameObjectWithTag("Player"));
        DontDestroyOnLoad(_camera = GameObject.FindGameObjectWithTag("MainCamera"));
        DontDestroyOnLoad(_canvases= GameObject.FindGameObjectWithTag("Canvases"));
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

}
