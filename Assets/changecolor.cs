using UnityEngine;
using System.Collections;

public class changecolor : MonoBehaviour
{


    Color lerpedColor = Color.white;
    Color lerpedColor2 = Color.white;
    float duration = 5f;
    private float t = 0;
    private Renderer rend;
    private Color original;
    private Color original2;
    private Color newColor;
    private Color newColor2;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        
        original = rend.material.GetColor("_PatCol");
        original2 = rend.material.GetColor("_PatCol2");
        newColor = rend.material.GetColor("_NewColor");
        newColor2 = rend.material.GetColor("_NewColor2");
    }

    // Update is called once per frame
    void Update()
    {
       
        lerpedColor = Color.Lerp(original,newColor,t);
        lerpedColor2 = Color.Lerp(original2,newColor2, t);

        rend.material.SetColor("_NewColor", lerpedColor);
        rend.material.SetColor("_NewColor2", lerpedColor2);
        if (t < 1)
        {

            t += Time.deltaTime / duration;

        }
    }
}
