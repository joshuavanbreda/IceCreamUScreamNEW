using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float skyboxRotation;

    // Start is called before the first frame update
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", skyboxRotation);
    }
}
