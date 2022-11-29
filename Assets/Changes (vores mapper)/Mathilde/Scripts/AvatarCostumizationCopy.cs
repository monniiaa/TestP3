using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sunbox.Avatars;
using UnityEditor;
using UnityEngine.UI;
public class AvatarCostumizationCopy : MonoBehaviour
{

    public GameObject femalePrefab;
    public GameObject malePrefab;
    // public ClothingItem top;
    public AvatarCustomization avatar;
    public Vector3 avatarPlacement;
    public Transform avatarPlacementPanel;
    public Vector3 scaleSize;

    public Material hairMaterial;
    public Material skinMaterial;
    public Material shirtMaterial;
    public Material pantsMaterial;
    public Slider BodyFat;
    public Slider BodyMass;
    public Slider BreastSize;
    public Button[] hairItem;
    

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
    private void Start()
    {
        UpdateGenderCopy(AvatarData.Gender);
        avatar.EyeMaterialIndex = AvatarData.eyeMaterialIndex;
        //avatar.EyesSize = AvatarData.EyeSize;
        Debug.Log(AvatarData.RGBSkinColor);
        Debug.Log(AvatarData.RGBHairColor);
        //UpdateSkinColor(AvatarData.RGBSkinColor);
        //UpdateHairColor(AvatarData.RGBHairColor);
        BodyFat.minValue = -50f;
        BodyMass.minValue = -50f;
        BodyFat.value = BodyFat.minValue;
        BodyMass.value = BodyMass.minValue;

        avatar.UpdateClothing();
        hairMaterial.color = AvatarData.RGBHairColor;
        skinMaterial.color = AvatarData.RGBSkinColor;
        shirtMaterial.color = AvatarData.RGBShirtColor;
        pantsMaterial.color = AvatarData.RGBPantsColor;
        avatar.UpdateCustomization();
        CreatePrefabCopy();
        BodyFat.onValueChanged.AddListener(delegate { SetBodyFat(); });
        BodyMass.onValueChanged.AddListener(delegate { SetBodyMass(); });

    }


   public void CreateAvatarCopy(GameObject prefab)
    {
        GameObject avatarInstance = Instantiate(prefab, avatarPlacement, Quaternion.identity);
        avatar = avatarInstance.GetComponent<AvatarCustomization>();
        avatarInstance.transform.localScale = scaleSize;
        
    }

    void UpdateShirtCopy(ClothingItem top, int variation)
    {
        avatar.AttachClothingItem(item: top, variationIndex: variation);

        avatar.UpdateClothing();
    }

    void UpdateEyesCopy(float eyeArea)
    {
        if (eyeArea > 100)
        {
            eyeArea = 100;
        }
        if (eyeArea < 0)
        {
            eyeArea = 0;
        }
        avatar.EyesSize = eyeArea;
        avatar.UpdateCustomization();
    }


    void UpdateGenderCopy(int gender)
    {
        if (gender == 0)
        {
            CreateAvatarCopy(malePrefab);
            SetHair(0);
            
        }
        else
        {
            CreateAvatarCopy (femalePrefab);
            SetHair(0);
        }
    }

    void CreateShirtCopy(ClothingItem top)
    {
        avatar.AttachClothingItem(item: top, variationIndex: 1);

        avatar.UpdateClothing();
    }

    void CreatePrefabCopy()
    {
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(avatar.gameObject, "Assets/Prefabs/Model.prefab");
        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

}