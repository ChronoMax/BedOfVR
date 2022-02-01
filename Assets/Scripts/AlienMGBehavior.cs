using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMGBehavior : MonoBehaviour
{

    [SerializeField]
    GameObject alienPrefab, spawnblock, spawnblock2, destroyBlock, destroyBlock2;

    bool playing;

    public void StartAlienMG()
    {
        if (!playing)
        {
            playing = true;
        }
        else
        {
            playing = false;
        }

        if (playing)
        {
            var time = Random.Range(1f, 5f);
            InvokeRepeating("GetRandomSpawnpoint", 0f, time);
        }

    }

    void GetRandomSpawnpoint()
    {
        if (!playing)
        {
            CancelInvoke();
        }

        var pos = new Vector3(Random.Range(spawnblock.transform.position.x, spawnblock2.transform.position.x), spawnblock.transform.position.y, spawnblock.transform.position.z);
        SpawnAlien(pos);
    }

    void SpawnAlien(Vector3 pos)
    {
        Instantiate(alienPrefab, pos, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fromPos = destroyBlock.transform.position;
        Vector3 toPos = destroyBlock2.transform.position;

        Debug.DrawLine(fromPos, toPos, Color.red);

        if (Physics.Linecast(fromPos, toPos, out hit))
        {
            if (hit.collider != null)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
