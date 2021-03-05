using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject drop;

    bool _canOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _canOpen = true;
    }

    private void Update()
    {
        if (_canOpen && Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
            drop.SetActive(true);
        }
    }
}
