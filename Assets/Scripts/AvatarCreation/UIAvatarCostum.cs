using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sunbox.Avatars;

public class UIAvatarCostum : MonoBehaviour
{
    public Slider BodyFat;
    public Slider BodyMass;
    public Slider BreastSize;
    public AvatarCustomization avatar;
    public Button[] hairItem; 

    private void Start()
    {
        BodyFat.onValueChanged.AddListener(delegate { SetBodyFat(); });
        BodyMass.onValueChanged.AddListener(delegate { SetBodyMass(); });
    }
    public void SetBodyFat()
    {
        avatar.BodyFat = BodyFat.value;
        avatar.UpdateCustomization();
    }

    public void SetBodyMass()
    {
        avatar.BodyMuscle = BodyMass.value;
        avatar.UpdateCustomization();
    }

    public void SetHair(int index)
    {
        avatar.HairStyleIndex = index;
        avatar.UpdateCustomization();
    }
}
