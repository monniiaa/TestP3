using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AcessCam : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    Inputs input;
    static WebCamTexture backCam;
    Screenshot image;
    [SerializeField]
    Slider loadingSlider;
    [SerializeField]
    RawImage faceOutline;
    [SerializeField]
    Button nextSceneButton;
    [SerializeField]
    ImageType imageType;
    [SerializeField]
    string pythonPath;
    [SerializeField]
    string nextscenename;
    public Timer timer;
    bool hascaptured = false;

    private void Awake()
    {
        input = new Inputs();
    }
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.FindObjectOfType<Screenshot>().GetComponent<Screenshot>();
        faceOutline.gameObject.SetActive(true);
        loadingSlider.gameObject.SetActive(false);
        loadingSlider.value = 0;
        if (backCam == null)
            backCam = new WebCamTexture();

        GetComponent<RawImage>().texture = backCam;
        if (!backCam.isPlaying)
        {
            backCam.Play();

        }
    }

    private void Update()
    {
        if (imageType == ImageType.FaceImage && Input.GetKeyDown(KeyCode.Space))
        {
            TakeScreenShot(pythonPath, imageType);

        }
        else if (imageType == ImageType.ClothesImage && Input.GetKeyDown(KeyCode.Space))
        {
            timer.startCounter = true;

        }
        if (timer.currentTime <= 0 && hascaptured==false)
        {
            TakeScreenShot(pythonPath, imageType);
            hascaptured = true;
        }
        if (loadingSlider.value >= 1)
        {
            ManageScenes.LoadScene(nextscenename);
        }
    }

    IEnumerator ScreenshotTaker(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        TakeScreenShot(pythonPath, imageType);
    }
    void TakeScreenShot(string path, ImageType imagetype)
    {
        image.TakeSnapshot(backCam, "/Python/Communication/" + path, imagetype);
        backCam.Stop();
        audioSource.Play();
    }

    public void Retry()
    {
        timer.currentTime = 10;
        hascaptured = false;
        backCam.Play();
    }

    public void ConfirmedImage(float seconds)
    {
        image.ConfirmedImage(imageType, pythonPath);
        faceOutline.gameObject.SetActive(false);
        loadingSlider.gameObject.SetActive(true);
        StartCoroutine(LinearInterpolation(0, 1, seconds));


    }

    IEnumerator LinearInterpolation( float startPosition, float endPosition, float duration)
    {
        loadingSlider.value = startPosition;
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            //changes the position of the circle over time
            loadingSlider.value = Mathf.Lerp(startPosition, endPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        // snaps the circle position to the end position
        loadingSlider.value = endPosition;
    }

}
