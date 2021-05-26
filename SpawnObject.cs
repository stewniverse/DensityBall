using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    Vector3 center;
    public Vector3 size; 
    public float radius;
    public GameObject preFab;

    public int numItems;
    private int objectCount = 0;

    private void Start()
    {
        for (int i = 0; i < numItems; i++)
        {
            spawnObject();
        }
    }

    ~SpawnObject()
    {
        objectCount--;
    }

    private void Update()
    {
        
    }

    public void spawnObject()
    {
        Vector3 pos = RandomizeCenter();
        Instantiate(preFab, pos, Quaternion.identity);
        preFab.name = "ball." + objectCount++;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0f);
        Gizmos.DrawSphere(center, radius);
    }

    private Vector3 RandomizeCenter() => new Vector3(Random.Range(-size.x / 2, size.x / 2), 1f * preFab.transform.up.y, Random.Range(-size.y / 2, size.y / 2));
}
