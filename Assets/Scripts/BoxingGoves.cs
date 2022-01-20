using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGoves : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BoxingPlayBtn")
        {
            GameManager.Instance.StartBoxingMG();
        }
        if (collision.gameObject.tag == "BoxingSack")
        {
            GameManager.Instance.addPoint();
        }
    }
}
