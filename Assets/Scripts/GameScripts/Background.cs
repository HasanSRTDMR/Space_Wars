using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    float ofsettY=0;
    // Update is called once per frame
    void Update()
    {
        ofsettY += 0.1f*Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex",new Vector2(0,ofsettY));
        
    }
}
