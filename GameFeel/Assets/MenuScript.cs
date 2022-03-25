using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public SpaceShipController spaceShipController = null;
    public StarFieldMovement starField = null;

    public Toggle inertiaInputToggle = null;
    public Toggle BoostShakeToggle = null;
    public Toggle StarFieldToggle = null;
    public Slider ShipSpeedSlider = null;
    public Slider StarFieldSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        inertiaInputToggle.onValueChanged.AddListener(delegate { ToggleInertiaInputValueChanged(inertiaInputToggle); });
        BoostShakeToggle.onValueChanged.AddListener(delegate { ToggleBoostShakeValueChanged(BoostShakeToggle); });
        StarFieldToggle.onValueChanged.AddListener(delegate { ToggleStarFieldValueChanged(StarFieldToggle); });
    }

    // Update is called once per frame
    void Update()
    {
        spaceShipController.shipSpeed = ShipSpeedSlider.value;
        starField.movementScale = StarFieldSlider.value;
    }

    void ToggleInertiaInputValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            spaceShipController.controlType = SpaceShipController.ControlTypeEnum.Inertia;
        }
        else
        {
            spaceShipController.controlType = SpaceShipController.ControlTypeEnum.Simple;
        }
    }
    void ToggleBoostShakeValueChanged(Toggle change)
    {
        spaceShipController.enableBoostShake = change.isOn;
    }
    void ToggleStarFieldValueChanged(Toggle change)
    {
        starField.gameObject.SetActive(change.isOn);
    }

}
