using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

    [SerializeField] int maxAngle;
    [SerializeField] int minAngle;
    [SerializeField] int maxIntensity;
    [SerializeField] int minIntensity;
    [Space]
    [SerializeField] float angleRate;
    [SerializeField] float intensityRate;


    [SerializeField] Camera cam;
    Light lightComponent;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
        lightComponent.type = LightType.Spot;
    }

    private void Update()
    {
        FaceMouse();
        ConsumeFuel();
    }

    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        mousePos.z = 0;
        transform.LookAt(mousePos);
    }

    public void AddFuel(int angle, int intensity)
    {
        lightComponent.spotAngle = Mathf.Min(lightComponent.spotAngle + angle, maxAngle);
        lightComponent.intensity = Mathf.Min(lightComponent.intensity + intensity, maxIntensity);
    }

    void ConsumeFuel()
    {
        lightComponent.spotAngle = Mathf.Max(lightComponent.spotAngle - angleRate * Time.deltaTime, minAngle); ;
        lightComponent.intensity = Mathf.Max(lightComponent.intensity - intensityRate * Time.deltaTime, minIntensity);
    }
}