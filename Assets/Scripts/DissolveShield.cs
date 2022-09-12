using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveShield : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed = 100;
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
        float dissolveValue = time * dissolveSpeed % 100 / 100;
        if (time * dissolveSpeed % 200 > 100)
            dissolveValue = 1 - dissolveValue;

        meshRenderer.material.SetFloat("_Dissolve", dissolveValue);
    }
}
