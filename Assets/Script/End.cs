using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PJ"))
        {
            gameOver.SetActive(true);
        }
    }
}
