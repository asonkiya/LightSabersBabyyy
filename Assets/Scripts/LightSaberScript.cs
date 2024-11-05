using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberScript : MonoBehaviour
{
    public float extendSpeed = 0.1f;
    public bool weaponActive = true;
    public float scaleMin = 0f;
    private float scaleMax;
    private float extendDelta;
    private float scaleCurrent;
    private float localScaleX, localScaleZ;
    public GameObject blade;

    void Start()
    {
        localScaleX = transform.localScale.x;
        localScaleZ = transform.localScale.z;
        scaleMax = transform.localScale.y;
        scaleCurrent = scaleMax;
        extendDelta = scaleMax / extendSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            extendDelta = weaponActive ? -Mathf.Abs(extendDelta) : Mathf.Abs(extendDelta);
        }

        scaleCurrent += extendDelta * Time.deltaTime;
        scaleCurrent = Mathf.Clamp(scaleCurrent, scaleMin, scaleMax);
        transform.localScale = new Vector3(localScaleX, scaleCurrent, localScaleZ);
        weaponActive = scaleCurrent > 0;

        if (weaponActive && !blade.activeSelf)
        {
            blade.SetActive(true);
        }
        else if (!weaponActive && blade.activeSelf)
        {
            blade.SetActive(false);
        }
    }
}
