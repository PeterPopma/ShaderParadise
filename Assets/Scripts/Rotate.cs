using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 maxAngularVelocity = Vector3.one * 100;
    public float VelocityChangeRate = 0.01f;

    private float[] maxAngularVelocityArray = new float[3];
    private float[] currentVelocity = new float[3];
    private float[] increaseValue = new float[3];
    private bool[] speedIncreasing = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        maxAngularVelocityArray[0] = maxAngularVelocity.x;
        maxAngularVelocityArray[1] = maxAngularVelocity.y;
        maxAngularVelocityArray[2] = maxAngularVelocity.z;

        for (int k=0; k<3; k++)
        {
            currentVelocity[k] = (0.5f + Random.value / 2f) * maxAngularVelocityArray[k];
            increaseValue[k] = maxAngularVelocityArray[k] / (1/VelocityChangeRate);
            speedIncreasing[k] = Random.value >= 0.5;
        }
    }

    void Update()
    {
        for (int k = 0; k < 3; k++)
        {
            if (speedIncreasing[k])
            {
                currentVelocity[k] += increaseValue[k];
                if (currentVelocity[k] > maxAngularVelocityArray[k])
                {
                    speedIncreasing[k] = false;
                }
            }
            else
            {
                currentVelocity[k] -= increaseValue[k];
                if (currentVelocity[k] < -maxAngularVelocityArray[k])
                {
                    speedIncreasing[k] = true;
                }
            }
        }

        Vector3 angularVelocity = new Vector3(currentVelocity[0], currentVelocity[1], currentVelocity[2]);
        transform.Rotate(angularVelocity * Time.deltaTime, Space.Self);
    }
}
