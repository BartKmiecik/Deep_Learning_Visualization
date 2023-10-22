using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Spawner : MonoBehaviour
{
    public Vector2 widthAndHeight = new Vector2 (0, 0);
    public GameObject prefabToSpawn = null;


    public void SpawnObjects()
    {
        if(transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
        for (int width = 0; width < widthAndHeight.x; width++)
        {
            for (int height = 0;height<widthAndHeight.y; height++)
            {
                Instantiate(prefabToSpawn, new Vector3(width, height, transform.position.z), Quaternion.identity, transform);
            }
        }
    }

    public void DestroyAll()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }
}
