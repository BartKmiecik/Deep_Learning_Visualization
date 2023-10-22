using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ConvolutionSpawner : MonoBehaviour
{
    public int widthAndHeight = 0;
    public GameObject prefabToSpawn = null;
    List<Vector4> convolLayers = new List<Vector4>();
    public float offset;

    private void OnEnable()
    {
        convolLayers.Clear();
        convolLayers.Add(new Vector4(2,-1,-1,-1));
        convolLayers.Add(new Vector4(-1, 2, -1, -1));
        convolLayers.Add(new Vector4(-1, -1, 2, -1));
        convolLayers.Add(new Vector4(-1, -1, -1, 2));
        convolLayers.Add(new Vector4(1, -1, 1, -1));
        convolLayers.Add(new Vector4(-1, 1, -1, 1));
        convolLayers.Add(new Vector4(1, 1, -1, -1));
        convolLayers.Add(new Vector4(1, -1, -1, 1));
        convolLayers.Add(new Vector4(-1, 1, 1, -1));
        convolLayers.Add(new Vector4(1, 1, 1, -1));
        DestroyAll();
        SpawnObjects();
    }


    public void SpawnObjects()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
        for (int height = 0; height < widthAndHeight; height++)
        {
            GameObject temp = Instantiate(prefabToSpawn, new Vector3(transform.position.x,transform.position.y + height * offset, transform.position.z), Quaternion.Euler(0,90,0), transform);
            temp.GetComponent<ManipulateMaterial>().SetConvoLayer(convolLayers[height]);
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
