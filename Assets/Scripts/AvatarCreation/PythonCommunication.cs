using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using Sunbox.Avatars;

public class PythonCommunication : MonoBehaviour
{    
    public UdpSocket reciever;
    public Screenshot images;


    // Start is called before the first frame update
    void Start()    
    {
        reciever.dataRecievedEvent += OnDataRecieved;
        images.SentImageEvent += SendImageData;
    }

    void SendImageData(ImageType imagetype, string image)
    {
        Debug.Log("Sending screenshot to python");
        reciever.SendData(imagetype.ToString() + image);
        Debug.Log(imagetype.ToString() + image);
    }

    private void OnDisable()
    {
        images.SentImageEvent -= SendImageData;
    }


    void OnDataRecieved(string data)
    {
        char type = data[0];
        string data1 = data.Remove(0, 1);
        switch (type)  
        {
            case 'C':
                string shirtdata = data1.Remove(0, 1);
                if (data1[0] == 'R')
                {
                    AvatarData.RGBShirtColor.r = float.Parse(shirtdata) / 255f;
                }
                else if (data1[0] == 'B')
                {
                    AvatarData.RGBShirtColor.b = float.Parse(shirtdata) / 255f;
                }
                else if (data1[0] == 'G')
                {
                    AvatarData.RGBShirtColor.g = float.Parse(shirtdata) / 255f;
                }
                break;
            case 'P':
                string pantsdata = data1.Remove(0, 1);
                if (data1[0] == 'R')
                {
                    AvatarData.RGBPantsColor.r = float.Parse(pantsdata) / 255f;
                }
                else if (data1[0] == 'B')
                {
                    AvatarData.RGBPantsColor.b = float.Parse(pantsdata) / 255f;
                }
                else if (data1[0] == 'G')
                {
                    AvatarData.RGBPantsColor.g = float.Parse(pantsdata) / 255f;
                }
                break;
            case 'G':
                if (data1[0] == 'F')
                {
                    AvatarData.Gender = 1;
                }
                else AvatarData.Gender = 0;
                break;
           case 'E':
                AvatarData.EyeSize = float.Parse(data1);
              break;
            case 'Y':
                if (data1[0] == '0')
                {
                    AvatarData.eyeMaterialIndex = 0;
                } else if (data1[0] == '1')
                {
                    AvatarData.eyeMaterialIndex = 1;
                } else if (data1[0] == '2')
                {
                    AvatarData.eyeMaterialIndex= 2;
                }
                break;
            case 'S':
                string skindata = data1.Remove(0, 1);
                if (data1[0] == 'R')
                {
                    AvatarData.RGBSkinColor.r = float.Parse(skindata) / 255f;
                    
                } else if (data1[0] == 'G')
                {
                    AvatarData.RGBSkinColor.g = float.Parse(skindata)/ 255f;
                } else if (data1[0] == 'B')
                {
                    AvatarData.RGBSkinColor.b = float.Parse(skindata)/ 255f;
                    Debug.Log(AvatarData.RGBSkinColor);
                }
                    break;
            case 'H':
                string hairdata = data1.Remove(0, 1);
                if (data1[0] == 'R')
                {
                    
                    AvatarData.RGBHairColor.r = float.Parse(hairdata)/ 255f;
                }
                else if (data1[0] == 'G')
                {
                    AvatarData.RGBHairColor.g = float.Parse(hairdata)/255f;
                }
                else if (data1[0] == 'B')
                {
                    AvatarData.RGBHairColor.b = float.Parse(hairdata)/255f;
                    Debug.Log(AvatarData.RGBHairColor);
                }
                break;
           default:
              break;
        }
    }

}