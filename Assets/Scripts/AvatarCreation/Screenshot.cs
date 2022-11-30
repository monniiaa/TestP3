using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public delegate void SentImageData(ImageType imageType, string image);
    public event SentImageData SentImageEvent;

    float timeLeft = 0;
    public int captures = 0;
    // Start is called before the first frame update

    public void TakeSnapshot(WebCamTexture camTexture, string _SavePath, ImageType imagetype)
    {
        if (timeLeft <= 0)
        {
            if (imagetype == ImageType.FaceImage)
            {
                Texture2D snap = new Texture2D(camTexture.width, camTexture.height);
                snap.SetPixels(camTexture.GetPixels());
                snap.Apply();

                byte[] bytes = snap.EncodeToPNG();
                System.IO.File.WriteAllBytes(Application.dataPath + _SavePath, bytes);
                Debug.Log("Imagesaved at " + Application.dataPath + _SavePath + "face0.png");
                Debug.Log("TookScreenshot");
                timeLeft = 5;

            }
            else
            {
                Texture2D snap = new Texture2D(camTexture.width, camTexture.height);
                snap.SetPixels(camTexture.GetPixels());
                snap.Apply();

                byte[] bytes = snap.EncodeToPNG();
                System.IO.File.WriteAllBytes(Application.dataPath + _SavePath, bytes);
                Debug.Log("Imagesaved at " + Application.dataPath + _SavePath);
                Debug.Log("TookScreenshot");
                timeLeft = 5;
            }
        }
    }

    public void ConfirmedImage(ImageType imagetype, string pythonPath)
    {
        SentImageEvent?.Invoke(imagetype, pythonPath);
    }
   
    private void Update()
    {
        timeLeft = timeLeft - Time.deltaTime;
    }

}
    