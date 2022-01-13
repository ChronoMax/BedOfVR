using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    GameObject bullet, raycastPos, endRaycastPos;

    public void SchootBullet()
    {
        RaycastHit hit;

        if (Physics.Linecast(raycastPos.transform.position, endRaycastPos.transform.position, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
                //Add point
            }
            else if (hit.collider.tag == "PlayBtnAlien")
            {
                GameManager.Instance.StartAlienMG();
            }
        }

        //Instantiate(bullet, this.transform.position, Quaternion.identity);
    }
}
