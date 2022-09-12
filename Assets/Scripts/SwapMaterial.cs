using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
    [SerializeField] private Material[] firstMaterials;
    [SerializeField] private Material[] secondMaterials;
    [SerializeField] private float swapTime = 1;
    SkinnedMeshRenderer skinnedMeshRenderer;
    bool isSecondMaterial;

    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        bool second_material = time % (swapTime*2) > swapTime;
        if (isSecondMaterial != second_material)
        {
            isSecondMaterial = second_material;
            if(isSecondMaterial)
            {
                skinnedMeshRenderer.materials = secondMaterials;
            }
            else
            {
                skinnedMeshRenderer.materials = firstMaterials;
            }
        }
    }
}
