using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] AudioSource ambient;
    [SerializeField] AudioSource prevAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        prevAudio.mute = true;
        ambient.Play();
    }
}
