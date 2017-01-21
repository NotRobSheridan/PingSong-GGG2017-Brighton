using UnityEngine;
using System.Collections;

public class Visualiser : MonoBehaviour {

    public int detail = 500;
    public float minValue = 1.0f;
    public float amplitude = 0.1f;
    public float sizeBias;
    public Color firstColor;
    public Color secondColor;

    float randomAmplitude = 1.0f;
    Vector3 startScale;

	void Start ()
    {
        startScale = transform.localScale;

        randomAmplitude = Random.Range(1.0f, 3.0f);
	}
	
	void Update ()
    {
        float[] info = new float[detail];
        AudioListener.GetOutputData(info, 0);
        float packagedData = 0.0f;

        for(int i=0; i < info.Length; i++)
        {
            packagedData += System.Math.Abs(info[i]);
        }

        transform.localScale = new Vector3(startScale.x, (packagedData * amplitude * randomAmplitude) + startScale.y * sizeBias, startScale.z);
	}
}
