using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundball : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("map"))
        {
            SoundManager.instance.PlaySFX("kick");
            Debug.Log("Sound hit!!!");
        }

        if (collision.gameObject.CompareTag("Goal1") || collision.gameObject.CompareTag("Goal2"))
        {
            SoundManager.instance.PlaySFX("letgo");
            Debug.Log("sound Goal!!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1") || collision.gameObject.CompareTag("Goal2"))
        {
            SoundManager.instance.PlaySFX("letgo");
            Debug.Log("sound Goal!!!");
        }
    }

}
