using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossBattleStart : MonoBehaviour
{
    CinemachineVirtualCamera _camera;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("Player").transform.Find("MainCAmera").transform.Find("MainCamera").GetComponent<CinemachineVirtualCamera>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _camera.m_Lens.OrthographicSize = 8;
    }
}
