using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class ManipulateMaterial : MonoBehaviour
{
    Renderer rend;
    public Vector4 convoLayer;

    private void OnEnable()
    {
        rend = GetComponent<Renderer>();
        ChangeMaterialProperties();
    }

    public void SetConvoLayer(Vector4 convoLayer)
    {
        this.convoLayer = convoLayer;
        ChangeMaterialProperties();
    }

    public void ChangeMaterialProperties()
    {
        rend.material.SetVector("_Convo", convoLayer);
    }
}
