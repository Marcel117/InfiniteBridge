using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    private Renderer meshRender;
    private Material currentmaterial;

    public float incrementoOffset;
    public float speed;

    public string sortingLayer;
    public int orderInLayer;

    private float offset;
    

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
        meshRender.sortingLayerName = sortingLayer;
        meshRender.sortingOrder = orderInLayer;

        currentmaterial = meshRender.material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset += incrementoOffset;
        currentmaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
