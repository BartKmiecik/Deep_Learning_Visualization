using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using Color = UnityEngine.Color;

[ExecuteInEditMode]
public class SpawnLines : MonoBehaviour
{
    public GameObject imageSpawner;
    public GameObject convoSpawner;
    public Texture2D text;
    public Vector4 convoTransf;
    public Color[,] confColors = new Color[28, 28];
    public Material lineMaterial;
    // Start is called before the first frame update
    void OnEnable()
    {
        Color cobn = text.GetPixel(1, 1);
        // Debug.DrawLine(Vector3.zero, new Vector3(100, 500, 0), color);
        convoTransf = new Vector4(1, -1, 1, -1);
        CalculateConvo();
        CreateLines();
    }

    // Update is called once per frame
    public void CalculateConvo()
    {
        for(int width = 1; width < 26; width++)
        {
            for(int height = 1; height < 26; height++) { 
                Color color1 = text.GetPixel(width, height);
                Color color2 = text.GetPixel(width + 1, height);
                Color color3 = text.GetPixel(width, height+1);
                Color color4 = text.GetPixel(width + 1, height + 1);
                Vector4 sumColors = (Vector4)color1 * convoTransf[0] + (Vector4)color2 * convoTransf[1] + (Vector4)color3 * convoTransf[2] + (Vector4)color4 * convoTransf[3];
                confColors[height, width] = new Color(sumColors.x, sumColors.y, sumColors.z, 1);
            }
        }
    }

    public void CreateLines()
    {
        Transform test = convoSpawner.GetComponent<Transform>().GetChild(0);
        LineRenderer renderTest = test.AddComponent<LineRenderer>();
        renderTest.positionCount = 26*26*2;
        for (int width = 1; width < 26; width++)
        {
            for (int height = 1; height < 26; height++)
            {
                renderTest.material = lineMaterial;
                Vector3 test2 = imageSpawner.GetComponent<Transform>().GetChild(width * 26 + height).position;
                renderTest.SetPosition(((width - 1) * 26 + height) * 2, test2);
                renderTest.startColor = confColors[width, height];
                renderTest.endColor = confColors[width, height];
                renderTest.enabled = true;
                renderTest.SetPosition(((width - 1) * 26 + height) * 2 + 1, test.position);
                Debug.Log(((width - 1) * 26 + height) * 2 + 1);
                Debug.Log(test2);
                Debug.Log(test.position);
            }
        }
    }
}
