using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowChanger : MonoBehaviour
{
    [SerializeField] private float changeSpeed = 100;              
    MeshRenderer meshRenderer;
  
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        float snowPercentage = time * changeSpeed % 100 / 100;
        if (time * changeSpeed % 200 > 100)
            snowPercentage = 1 - snowPercentage;

        meshRenderer.material.SetFloat("_SnowPercentage", snowPercentage * 100);
    }
}
