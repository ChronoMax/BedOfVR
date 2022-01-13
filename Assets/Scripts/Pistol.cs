using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    public void SchootBullet()
    {
        Instantiate(bullet, this.transform.position, Quaternion.identity);
    }
}
