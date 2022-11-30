using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sunbox.Avatars;
using UnityEditor;
using UnityEngine.UI;
public class AvatarCostumization : MonoBehaviour
{

    public GameObject femalePrefab;
    public GameObject malePrefab;
    public AvatarCustomization avatar;

    public Material hairMaterial;
    public Material skinMaterial;
    public Material shirtMaterial;
    public Material pantsMaterial;

    public Button[] hairItem;


    public void SetHair(int index)
    {
        avatar.HairStyleIndex = index;
        avatar.UpdateCustomization();
       
    }
    private void Start()
    {
        UpdateGender(AvatarData.Gender);
        avatar.EyeMaterialIndex = AvatarData.eyeMaterialIndex;
        //avatar.EyesSize = AvatarData.EyeSize;
        Debug.Log(AvatarData.RGBSkinColor);
        Debug.Log(AvatarData.RGBHairColor);
        //UpdateSkinColor(AvatarData.RGBSkinColor);
        //UpdateHairColor(AvatarData.RGBHairColor);

        avatar.UpdateClothing();
        hairMaterial.color = AvatarData.RGBHairColor;
        skinMaterial.color = AvatarData.RGBSkinColor;
        shirtMaterial.color = AvatarData.RGBShirtColor;
        pantsMaterial.color = AvatarData.RGBPantsColor;

        Debug.Log(AvatarData.RGBHairColor);
        Debug.Log(AvatarData.RGBSkinColor);
        Debug.Log(AvatarData.RGBShirtColor);
        avatar.UpdateCustomization();
        CreatePrefab();
    }


   public void CreateAvatar(GameObject prefab)
    {
        GameObject avatarInstance = Instantiate(prefab, new Vector3(0.1f, 0.2f, -1), Quaternion.identity);
        avatar = avatarInstance.GetComponent<AvatarCustomization>();
        
    }

    void UpdateShirt(ClothingItem top, int variation)
    {
        avatar.AttachClothingItem(item: top, variationIndex: variation);

        avatar.UpdateClothing();
    }

    void UpdateEyes(float eyeArea)
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


    void UpdateGender(int gender)
    {
        if (gender == 0)
        {
            CreateAvatar(malePrefab);
            SetHair(0);
            
        }
        else
        {
            CreateAvatar(femalePrefab);
            SetHair(0);
        }
    }

    void CreateShirt(ClothingItem top)
    {
        avatar.AttachClothingItem(item: top, variationIndex: 1);

        avatar.UpdateClothing();
    }

    void CreatePrefab()
    {
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(avatar.gameObject, "Assets/Prefabs/Model.prefab");
        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

}