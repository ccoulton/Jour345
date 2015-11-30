using UnityEngine;
using System.Collections;

public class ScrollingBG : MonoBehaviour  
{

    public float speed;
    private Material mat;
    
    void Start ()
    {
        mat = gameObject.GetComponent<>();
    }
    
    void Update ()
    {
        float offset = Time.time * speed;   
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
