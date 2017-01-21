using UnityEngine;
using System.Collections;
 
public class SineWave : MonoBehaviour {

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 40;
    public float lineSpeed = 5.0f;
    public float yPos;

    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);
    }
    void Update() {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        int i = 0;
        while (i < lengthOfLineRenderer) {
            yPos = Mathf.Sin(i + Time.time * lineSpeed);

            Vector3 pos = new Vector3(i * 0.5F, yPos, 0);
            lineRenderer.SetPosition(i, pos);
            i++;
        }
    }
}