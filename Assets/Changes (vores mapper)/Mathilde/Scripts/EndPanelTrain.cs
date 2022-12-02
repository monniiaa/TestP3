using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EndPanelTrain : MonoBehaviour
{
    public GameObject flPanel;
    public GameObject abPanel;
    public GameObject paPanel;
    public GameObject idPanel;

    public Button fl11, fl12, fl13, fl14, fl15;
    public Button fl21, fl22, fl23, fl24, fl25;
    public Button fl31, fl32, fl33, fl34, fl35;
    public Button fl41, fl42, fl43, fl44, fl45;

    public Button ab11, ab12, ab13, ab14, ab15;
    public Button ab21, ab22, ab23, ab24, ab25;
    public Button ab31, ab32, ab33, ab34, ab35;
    public Button ab41, ab42, ab43, ab44, ab45;

    public Button pa11, pa12, pa13, pa14, pa15;
    public Button pa21, pa22, pa23, pa24, pa25;

    public Button id11, id12, id13, id14, id15;
    public Button id21, id22, id23, id24, id25;
    public Button id31, id32, id33, id34, id35;

    public bool fl11Clicked, fl12Clicked, fl13Clicked, fl14Clicked, fl15Clicked, fl21Clicked, fl22Clicked, fl23Clicked, fl24Clicked, fl25Clicked;
    public bool fl31Clicked, fl32Clicked, fl33Clicked, fl34Clicked, fl35Clicked, fl41Clicked, fl42Clicked, fl43Clicked, fl44Clicked, fl45Clicked;

    public bool ab11Clicked, ab12Clicked, ab13Clicked, ab14Clicked, ab15Clicked, ab21Clicked, ab22Clicked, ab23Clicked, ab24Clicked, ab25Clicked;
    public bool ab31Clicked, ab32Clicked, ab33Clicked, ab34Clicked, ab35Clicked, ab41Clicked, ab42Clicked, ab43Clicked, ab44Clicked, ab45Clicked;

    public bool pa11Clicked, pa12Clicked, pa13Clicked, pa14Clicked, pa15Clicked, pa21Clicked, pa22Clicked, pa23Clicked, pa24Clicked, pa25Clicked;

    public bool id11Clicked, id12Clicked, id13Clicked, id14Clicked, id15Clicked, id21Clicked, id22Clicked, id23Clicked, id24Clicked, id25Clicked;
    public bool id31Clicked, id32Clicked, id33Clicked, id34Clicked, id35Clicked;

    void Start()
    {
        fl11.onClick.AddListener(delegate { CheckFL1Amount(1); }); fl12.onClick.AddListener(delegate { CheckFL1Amount(2); }); fl13.onClick.AddListener(delegate { CheckFL1Amount(3); });
        fl14.onClick.AddListener(delegate { CheckFL1Amount(4); }); fl15.onClick.AddListener(delegate { CheckFL1Amount(5); });
        fl21.onClick.AddListener(delegate { CheckFL2Amount(1); }); fl22.onClick.AddListener(delegate { CheckFL2Amount(2); });fl23.onClick.AddListener(delegate { CheckFL2Amount(3); });
        fl24.onClick.AddListener(delegate { CheckFL2Amount(4); }); fl25.onClick.AddListener(delegate { CheckFL2Amount(5); });
        fl31.onClick.AddListener(delegate { CheckFL3Amount(1); }); fl32.onClick.AddListener(delegate { CheckFL3Amount(2); });fl33.onClick.AddListener(delegate { CheckFL3Amount(3); });
        fl34.onClick.AddListener(delegate { CheckFL3Amount(4); }); fl35.onClick.AddListener(delegate { CheckFL3Amount(5); });
        fl41.onClick.AddListener(delegate { CheckFL4Amount(1); }); fl42.onClick.AddListener(delegate { CheckFL4Amount(2); }); fl43.onClick.AddListener(delegate { CheckFL4Amount(3); });
        fl44.onClick.AddListener(delegate { CheckFL4Amount(4); }); fl45.onClick.AddListener(delegate { CheckFL4Amount(5); });

        ab11.onClick.AddListener(delegate { CheckAB1Amount(1); }); ab12.onClick.AddListener(delegate { CheckAB1Amount(2); }); ab13.onClick.AddListener(delegate { CheckAB1Amount(3); });
        ab14.onClick.AddListener(delegate { CheckAB1Amount(4); }); ab15.onClick.AddListener(delegate { CheckAB1Amount(5); });
        ab21.onClick.AddListener(delegate { CheckAB2Amount(1); }); ab22.onClick.AddListener(delegate { CheckAB2Amount(2); }); ab23.onClick.AddListener(delegate { CheckAB2Amount(3); });
        ab24.onClick.AddListener(delegate { CheckAB2Amount(4); }); ab25.onClick.AddListener(delegate { CheckAB2Amount(5); });
        ab31.onClick.AddListener(delegate { CheckAB3Amount(1); }); ab32.onClick.AddListener(delegate { CheckAB3Amount(2); }); ab33.onClick.AddListener(delegate { CheckAB3Amount(3); });
        ab34.onClick.AddListener(delegate { CheckAB3Amount(4); }); ab35.onClick.AddListener(delegate { CheckAB3Amount(5); });
        ab41.onClick.AddListener(delegate { CheckAB4Amount(1); }); ab42.onClick.AddListener(delegate { CheckAB4Amount(2); }); ab43.onClick.AddListener(delegate { CheckAB4Amount(3); });
        ab44.onClick.AddListener(delegate { CheckAB4Amount(4); }); ab45.onClick.AddListener(delegate { CheckAB4Amount(5); });

        pa11.onClick.AddListener(delegate { CheckPA1Amount(1); }); pa12.onClick.AddListener(delegate { CheckAB1Amount(2); }); pa13.onClick.AddListener(delegate { CheckPA1Amount(3); });
        pa14.onClick.AddListener(delegate { CheckPA1Amount(4); }); pa15.onClick.AddListener(delegate { CheckPA1Amount(5); });
        pa21.onClick.AddListener(delegate { CheckPA2Amount(1); }); pa22.onClick.AddListener(delegate { CheckPA2Amount(2); }); pa23.onClick.AddListener(delegate { CheckPA2Amount(3); });
        pa24.onClick.AddListener(delegate { CheckPA2Amount(4); }); pa25.onClick.AddListener(delegate { CheckPA2Amount(5); });

        id11.onClick.AddListener(delegate { CheckID1Amount(1); }); id12.onClick.AddListener(delegate { CheckID1Amount(2); }); id13.onClick.AddListener(delegate { CheckID1Amount(3); });
        id14.onClick.AddListener(delegate { CheckID1Amount(4); }); id15.onClick.AddListener(delegate { CheckID1Amount(5); });
        id21.onClick.AddListener(delegate { CheckID2Amount(1); }); id22.onClick.AddListener(delegate { CheckID2Amount(2); }); id23.onClick.AddListener(delegate { CheckFL1Amount(3); });
        id24.onClick.AddListener(delegate { CheckID2Amount(4); }); id25.onClick.AddListener(delegate { CheckID2Amount(5); });
        id31.onClick.AddListener(delegate { CheckID3Amount(1); }); id32.onClick.AddListener(delegate { CheckID3Amount(2); }); id33.onClick.AddListener(delegate { CheckID3Amount(3); });
        id34.onClick.AddListener(delegate { CheckID3Amount(4); }); id35.onClick.AddListener(delegate { CheckID3Amount(5); });
    }

    public void DisablePanels()
    {
        flPanel.SetActive(false);
        abPanel.SetActive(false);
        paPanel.SetActive(false);
        idPanel.SetActive(false);
    }

    public void CheckFL1Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                fl11Clicked = true;
                fl11.GetComponent<Image>().color = Color.gray;
                fl12Clicked = false;
                fl12.GetComponent<Image>().color = Color.white;
                fl13Clicked = false;
                fl13.GetComponent<Image>().color = Color.white;
                fl14Clicked = false;
                fl14.GetComponent<Image>().color = Color.white;
                fl15Clicked = false;
                fl15.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                fl11Clicked = false;
                fl11.GetComponent<Image>().color = Color.white;
                fl12Clicked = true;
                fl12.GetComponent<Image>().color = Color.gray;
                fl13Clicked = false;
                fl13.GetComponent<Image>().color = Color.white;
                fl14Clicked = false;
                fl14.GetComponent<Image>().color = Color.white;
                fl15Clicked = false;
                fl15.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                fl11Clicked = false;
                fl11.GetComponent<Image>().color = Color.white;
                fl12Clicked = false;
                fl12.GetComponent<Image>().color = Color.white;
                fl13Clicked = true;
                fl13.GetComponent<Image>().color = Color.gray;
                fl14Clicked = false;
                fl14.GetComponent<Image>().color = Color.white;
                fl15Clicked = false;
                fl15.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                fl11Clicked = false;
                fl11.GetComponent<Image>().color = Color.white;
                fl12Clicked = false;
                fl12.GetComponent<Image>().color = Color.white;
                fl13Clicked = false;
                fl13.GetComponent<Image>().color = Color.white;
                fl14Clicked = true;
                fl14.GetComponent<Image>().color = Color.gray;
                fl15Clicked = false;
                fl15.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                fl11Clicked = false;
                fl11.GetComponent<Image>().color = Color.white;
                fl12Clicked = false;
                fl12.GetComponent<Image>().color = Color.white;
                fl13Clicked = false;
                fl13.GetComponent<Image>().color = Color.white;
                fl14Clicked = false;
                fl14.GetComponent<Image>().color = Color.white;
                fl15Clicked = true;
                fl15.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckFL2Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                fl21Clicked = true;
                fl21.GetComponent<Image>().color = Color.gray;
                fl22Clicked = false;
                fl22.GetComponent<Image>().color = Color.white;
                fl23Clicked = false;
                fl23.GetComponent<Image>().color = Color.white;
                fl24Clicked = false;
                fl24.GetComponent<Image>().color = Color.white;
                fl25Clicked = false;
                fl25.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                fl21Clicked = false;
                fl21.GetComponent<Image>().color = Color.white;
                fl22Clicked = true;
                fl22.GetComponent<Image>().color = Color.gray;
                fl23Clicked = false;
                fl23.GetComponent<Image>().color = Color.white;
                fl24Clicked = false;
                fl24.GetComponent<Image>().color = Color.white;
                fl25Clicked = false;
                fl25.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                fl21Clicked = false;
                fl21.GetComponent<Image>().color = Color.white;
                fl22Clicked = false;
                fl22.GetComponent<Image>().color = Color.white;
                fl23Clicked = true;
                fl23.GetComponent<Image>().color = Color.gray;
                fl24Clicked = false;
                fl24.GetComponent<Image>().color = Color.white;
                fl25Clicked = false;
                fl25.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                fl21Clicked = false;
                fl21.GetComponent<Image>().color = Color.white;
                fl22Clicked = false;
                fl22.GetComponent<Image>().color = Color.white;
                fl23Clicked = false;
                fl23.GetComponent<Image>().color = Color.white;
                fl24Clicked = true;
                fl24.GetComponent<Image>().color = Color.gray;
                fl25Clicked = false;
                fl25.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                fl21Clicked = false;
                fl21.GetComponent<Image>().color = Color.white;
                fl22Clicked = false;
                fl22.GetComponent<Image>().color = Color.white;
                fl23Clicked = false;
                fl23.GetComponent<Image>().color = Color.white;
                fl24Clicked = false;
                fl24.GetComponent<Image>().color = Color.white;
                fl25Clicked = true;
                fl25.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckFL3Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                fl31Clicked = true;
                fl31.GetComponent<Image>().color = Color.gray;
                fl32Clicked = false;
                fl32.GetComponent<Image>().color = Color.white;
                fl33Clicked = false;
                fl33.GetComponent<Image>().color = Color.white;
                fl34Clicked = false;
                fl34.GetComponent<Image>().color = Color.white;
                fl35Clicked = false;
                fl35.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                fl31Clicked = false;
                fl31.GetComponent<Image>().color = Color.white;
                fl32Clicked = true;
                fl32.GetComponent<Image>().color = Color.gray;
                fl33Clicked = false;
                fl33.GetComponent<Image>().color = Color.white;
                fl34Clicked = false;
                fl34.GetComponent<Image>().color = Color.white;
                fl35Clicked = false;
                fl35.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                fl31Clicked = false;
                fl31.GetComponent<Image>().color = Color.white;
                fl32Clicked = false;
                fl32.GetComponent<Image>().color = Color.white;
                fl33Clicked = true;
                fl33.GetComponent<Image>().color = Color.gray;
                fl34Clicked = false;
                fl34.GetComponent<Image>().color = Color.white;
                fl35Clicked = false;
                fl35.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                fl31Clicked = false;
                fl31.GetComponent<Image>().color = Color.white;
                fl32Clicked = false;
                fl32.GetComponent<Image>().color = Color.white;
                fl33Clicked = false;
                fl33.GetComponent<Image>().color = Color.white;
                fl34Clicked = true;
                fl34.GetComponent<Image>().color = Color.gray;
                fl35Clicked = false;
                fl35.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                fl31Clicked = false;
                fl31.GetComponent<Image>().color = Color.white;
                fl32Clicked = false;
                fl32.GetComponent<Image>().color = Color.white;
                fl33Clicked = false;
                fl33.GetComponent<Image>().color = Color.white;
                fl34Clicked = false;
                fl34.GetComponent<Image>().color = Color.white;
                fl35Clicked = true;
                fl35.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckFL4Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                fl41Clicked = true;
                fl41.GetComponent<Image>().color = Color.gray;
                fl42Clicked = false;
                fl42.GetComponent<Image>().color = Color.white;
                fl43Clicked = false;
                fl43.GetComponent<Image>().color = Color.white;
                fl44Clicked = false;
                fl44.GetComponent<Image>().color = Color.white;
                fl45Clicked = false;
                fl45.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                fl41Clicked = false;
                fl41.GetComponent<Image>().color = Color.white;
                fl42Clicked = true;
                fl42.GetComponent<Image>().color = Color.gray;
                fl43Clicked = false;
                fl43.GetComponent<Image>().color = Color.white;
                fl44Clicked = false;
                fl44.GetComponent<Image>().color = Color.white;
                fl45Clicked = false;
                fl45.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                fl41Clicked = false;
                fl41.GetComponent<Image>().color = Color.white;
                fl42Clicked = false;
                fl42.GetComponent<Image>().color = Color.white;
                fl43Clicked = true;
                fl43.GetComponent<Image>().color = Color.gray;
                fl44Clicked = false;
                fl44.GetComponent<Image>().color = Color.white;
                fl45Clicked = false;
                fl45.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                fl41Clicked = false;
                fl41.GetComponent<Image>().color = Color.white;
                fl42Clicked = false;
                fl42.GetComponent<Image>().color = Color.white;
                fl43Clicked = false;
                fl43.GetComponent<Image>().color = Color.white;
                fl44Clicked = true;
                fl44.GetComponent<Image>().color = Color.gray;
                fl45Clicked = false;
                fl45.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                fl41Clicked = false;
                fl41.GetComponent<Image>().color = Color.white;
                fl42Clicked = false;
                fl42.GetComponent<Image>().color = Color.white;
                fl43Clicked = false;
                fl43.GetComponent<Image>().color = Color.white;
                fl44Clicked = false;
                fl44.GetComponent<Image>().color = Color.white;
                fl45Clicked = true;
                fl45.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckAB1Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                ab11Clicked = true;
                ab11.GetComponent<Image>().color = Color.gray;
                ab12Clicked = false;
                ab12.GetComponent<Image>().color = Color.white;
                ab13Clicked = false;
                ab13.GetComponent<Image>().color = Color.white;
                ab14Clicked = false;
                ab14.GetComponent<Image>().color = Color.white;
                ab15Clicked = false;
                ab15.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                ab11Clicked = false;
                ab11.GetComponent<Image>().color = Color.white;
                ab12Clicked = true;
                ab12.GetComponent<Image>().color = Color.gray;
                ab13Clicked = false;
                ab13.GetComponent<Image>().color = Color.white;
                ab14Clicked = false;
                ab15.GetComponent<Image>().color = Color.white;
                ab15Clicked = false;
                ab15.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                ab11Clicked = false;
                ab11.GetComponent<Image>().color = Color.white;
                ab12Clicked = false;
                ab12.GetComponent<Image>().color = Color.white;
                ab13Clicked = true;
                ab13.GetComponent<Image>().color = Color.gray;
                ab14Clicked = false;
                ab14.GetComponent<Image>().color = Color.white;
                ab15Clicked = false;
                ab15.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                ab11Clicked = false;
                ab11.GetComponent<Image>().color = Color.white;
                ab12Clicked = false;
                ab12.GetComponent<Image>().color = Color.white;
                ab13Clicked = false;
                ab13.GetComponent<Image>().color = Color.white;
                ab14Clicked = true;
                ab14.GetComponent<Image>().color = Color.gray;
                ab15Clicked = false;
                ab15.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                ab11Clicked = false;
                ab11.GetComponent<Image>().color = Color.white;
                ab12Clicked = false;
                ab12.GetComponent<Image>().color = Color.white;
                ab13Clicked = false;
                ab13.GetComponent<Image>().color = Color.white;
                ab14Clicked = false;
                ab14.GetComponent<Image>().color = Color.white;
                ab15Clicked = true;
                ab15.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckAB2Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                ab21Clicked = true;
                ab21.GetComponent<Image>().color = Color.gray;
                ab22Clicked = false;
                ab22.GetComponent<Image>().color = Color.white;
                ab23Clicked = false;
                ab23.GetComponent<Image>().color = Color.white;
                ab24Clicked = false;
                ab24.GetComponent<Image>().color = Color.white;
                ab25Clicked = false;
                ab25.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                ab21Clicked = false;
                ab21.GetComponent<Image>().color = Color.white;
                ab22Clicked = true;
                ab22.GetComponent<Image>().color = Color.gray;
                ab23Clicked = false;
                ab23.GetComponent<Image>().color = Color.white;
                ab24Clicked = false;
                ab24.GetComponent<Image>().color = Color.white;
                ab25Clicked = false;
                ab25.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                ab21Clicked = false;
                ab21.GetComponent<Image>().color = Color.white;
                ab22Clicked = false;
                ab22.GetComponent<Image>().color = Color.white;
                ab23Clicked = true;
                ab23.GetComponent<Image>().color = Color.gray;
                ab24Clicked = false;
                ab24.GetComponent<Image>().color = Color.white;
                ab25Clicked = false;
                ab25.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                ab21Clicked = false;
                ab21.GetComponent<Image>().color = Color.white;
                ab22Clicked = false;
                ab22.GetComponent<Image>().color = Color.white;
                ab23Clicked = false;
                ab23.GetComponent<Image>().color = Color.white;
                ab24Clicked = true;
                ab24.GetComponent<Image>().color = Color.gray;
                ab25Clicked = false;
                ab25.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                ab21Clicked = false;
                ab21.GetComponent<Image>().color = Color.white;
                ab22Clicked = false;
                ab22.GetComponent<Image>().color = Color.white;
                ab23Clicked = false;
                ab23.GetComponent<Image>().color = Color.white;
                ab24Clicked = false;
                ab24.GetComponent<Image>().color = Color.white;
                ab25Clicked = true;
                ab25.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckAB3Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                ab31Clicked = true;
                ab31.GetComponent<Image>().color = Color.gray;
                ab32Clicked = false;
                ab32.GetComponent<Image>().color = Color.white;
                ab33Clicked = false;
                ab33.GetComponent<Image>().color = Color.white;
                ab34Clicked = false;
                ab34.GetComponent<Image>().color = Color.white;
                ab35Clicked = false;
                ab35.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                ab31Clicked = false;
                ab31.GetComponent<Image>().color = Color.white;
                ab32Clicked = true;
                ab32.GetComponent<Image>().color = Color.gray;
                ab33Clicked = false;
                ab33.GetComponent<Image>().color = Color.white;
                ab34Clicked = false;
                ab34.GetComponent<Image>().color = Color.white;
                ab35Clicked = false;
                ab35.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                ab31Clicked = false;
                ab31.GetComponent<Image>().color = Color.white;
                ab32Clicked = false;
                ab32.GetComponent<Image>().color = Color.white;
                ab33Clicked = true;
                ab33.GetComponent<Image>().color = Color.gray;
                ab34Clicked = false;
                ab34.GetComponent<Image>().color = Color.white;
                ab35Clicked = false;
                ab35.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                ab31Clicked = false;
                ab31.GetComponent<Image>().color = Color.white;
                ab32Clicked = false;
                ab32.GetComponent<Image>().color = Color.white;
                ab33Clicked = false;
                ab33.GetComponent<Image>().color = Color.white;
                ab34Clicked = true;
                ab34.GetComponent<Image>().color = Color.gray;
                ab35Clicked = false;
                ab35.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                ab31Clicked = false;
                ab31.GetComponent<Image>().color = Color.white;
                ab32Clicked = false;
                ab32.GetComponent<Image>().color = Color.white;
                ab33Clicked = false;
                ab33.GetComponent<Image>().color = Color.white;
                ab34Clicked = false;
                ab34.GetComponent<Image>().color = Color.white;
                ab35Clicked = true;
                ab35.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckAB4Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                ab41Clicked = true;
                ab41.GetComponent<Image>().color = Color.gray;
                ab42Clicked = false;
                ab42.GetComponent<Image>().color = Color.white;
                ab43Clicked = false;
                ab43.GetComponent<Image>().color = Color.white;
                ab44Clicked = false;
                ab44.GetComponent<Image>().color = Color.white;
                ab45Clicked = false;
                ab45.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                ab41Clicked = false;
                ab41.GetComponent<Image>().color = Color.white;
                ab42Clicked = true;
                ab42.GetComponent<Image>().color = Color.gray;
                ab43Clicked = false;
                ab43.GetComponent<Image>().color = Color.white;
                ab44Clicked = false;
                ab44.GetComponent<Image>().color = Color.white;
                ab45Clicked = false;
                ab45.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                ab41Clicked = false;
                ab41.GetComponent<Image>().color = Color.white;
                ab42Clicked = false;
                ab42.GetComponent<Image>().color = Color.white;
                ab43Clicked = true;
                ab43.GetComponent<Image>().color = Color.gray;
                ab44Clicked = false;
                ab44.GetComponent<Image>().color = Color.white;
                ab45Clicked = false;
                ab45.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                ab41Clicked = false;
                ab41.GetComponent<Image>().color = Color.white;
                ab42Clicked = false;
                ab42.GetComponent<Image>().color = Color.white;
                ab43Clicked = false;
                ab43.GetComponent<Image>().color = Color.white;
                ab44Clicked = true;
                ab44.GetComponent<Image>().color = Color.gray;
                ab45Clicked = false;
                ab45.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                ab41Clicked = false;
                ab41.GetComponent<Image>().color = Color.white;
                ab42Clicked = false;
                ab42.GetComponent<Image>().color = Color.white;
                ab43Clicked = false;
                ab43.GetComponent<Image>().color = Color.white;
                ab44Clicked = false;
                ab44.GetComponent<Image>().color = Color.white;
                ab45Clicked = true;
                ab45.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckPA1Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                pa11Clicked = true;
                pa11.GetComponent<Image>().color = Color.gray;
                pa12Clicked = false;
                pa12.GetComponent<Image>().color = Color.white;
                pa13Clicked = false;
                pa13.GetComponent<Image>().color = Color.white;
                pa14Clicked = false;
                pa14.GetComponent<Image>().color = Color.white;
                pa15Clicked = false;
                pa15.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                pa11Clicked = false;
                pa11.GetComponent<Image>().color = Color.white;
                pa12Clicked = true;
                pa12.GetComponent<Image>().color = Color.gray;
                pa13Clicked = false;
                pa13.GetComponent<Image>().color = Color.white;
                pa14Clicked = false;
                pa14.GetComponent<Image>().color = Color.white;
                pa15Clicked = false;
                pa15.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                pa11Clicked = false;
                pa11.GetComponent<Image>().color = Color.white;
                pa12Clicked = false;
                pa12.GetComponent<Image>().color = Color.white;
                pa13Clicked = true;
                pa13.GetComponent<Image>().color = Color.gray;
                pa14Clicked = false;
                pa14.GetComponent<Image>().color = Color.white;
                pa15Clicked = false;
                pa15.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                pa11Clicked = false;
                pa11.GetComponent<Image>().color = Color.white;
                pa12Clicked = false;
                pa12.GetComponent<Image>().color = Color.white;
                pa13Clicked = false;
                pa13.GetComponent<Image>().color = Color.white;
                pa14Clicked = true;
                pa14.GetComponent<Image>().color = Color.gray;
                pa15Clicked = false;
                pa15.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                pa11Clicked = false;
                pa11.GetComponent<Image>().color = Color.white;
                pa12Clicked = false;
                pa12.GetComponent<Image>().color = Color.white;
                pa13Clicked = false;
                pa13.GetComponent<Image>().color = Color.white;
                pa14Clicked = false;
                pa14.GetComponent<Image>().color = Color.white;
                pa15Clicked = true;
                pa15.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckPA2Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                pa21Clicked = true;
                pa21.GetComponent<Image>().color = Color.gray;
                pa22Clicked = false;
                pa22.GetComponent<Image>().color = Color.white;
                pa23Clicked = false;
                pa23.GetComponent<Image>().color = Color.white;
                pa24Clicked = false;
                pa24.GetComponent<Image>().color = Color.white;
                pa25Clicked = false;
                pa25.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                pa21Clicked = false;
                pa21.GetComponent<Image>().color = Color.white;
                pa22Clicked = true;
                pa22.GetComponent<Image>().color = Color.gray;
                pa23Clicked = false;
                pa23.GetComponent<Image>().color = Color.white;
                pa24Clicked = false;
                pa25.GetComponent<Image>().color = Color.white;
                pa25Clicked = false;
                pa25.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                pa21Clicked = false;
                pa21.GetComponent<Image>().color = Color.white;
                pa22Clicked = false;
                pa22.GetComponent<Image>().color = Color.white;
                pa23Clicked = true;
                pa23.GetComponent<Image>().color = Color.gray;
                pa24Clicked = false;
                pa24.GetComponent<Image>().color = Color.white;
                pa25Clicked = false;
                pa25.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                pa21Clicked = false;
                pa21.GetComponent<Image>().color = Color.white;
                pa22Clicked = false;
                pa22.GetComponent<Image>().color = Color.white;
                pa23Clicked = false;
                pa23.GetComponent<Image>().color = Color.white;
                pa24Clicked = true;
                pa24.GetComponent<Image>().color = Color.gray;
                pa25Clicked = false;
                pa25.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                pa21Clicked = false;
                pa21.GetComponent<Image>().color = Color.white;
                pa22Clicked = false;
                pa22.GetComponent<Image>().color = Color.white;
                pa23Clicked = false;
                pa23.GetComponent<Image>().color = Color.white;
                pa24Clicked = false;
                pa24.GetComponent<Image>().color = Color.white;
                pa25Clicked = true;
                pa25.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckID1Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                id11Clicked = true;
                id11.GetComponent<Image>().color = Color.gray;
                id12Clicked = false;
                id12.GetComponent<Image>().color = Color.white;
                id13Clicked = false;
                id13.GetComponent<Image>().color = Color.white;
                id14Clicked = false;
                id14.GetComponent<Image>().color = Color.white;
                id15Clicked = false;
                id15.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                id11Clicked = false;
                id11.GetComponent<Image>().color = Color.white;
                id12Clicked = true;
                id12.GetComponent<Image>().color = Color.gray;
                id13Clicked = false;
                id13.GetComponent<Image>().color = Color.white;
                id14Clicked = false;
                id14.GetComponent<Image>().color = Color.white;
                id15Clicked = false;
                id15.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                id11Clicked = false;
                id11.GetComponent<Image>().color = Color.white;
                id12Clicked = false;
                id12.GetComponent<Image>().color = Color.white;
                id13Clicked = true;
                id13.GetComponent<Image>().color = Color.gray;
                id14Clicked = false;
                id14.GetComponent<Image>().color = Color.white;
                id15Clicked = false;
                id15.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                id11Clicked = false;
                id11.GetComponent<Image>().color = Color.white;
                id12Clicked = false;
                id12.GetComponent<Image>().color = Color.white;
                id13Clicked = false;
                id13.GetComponent<Image>().color = Color.white;
                id14Clicked = true;
                id14.GetComponent<Image>().color = Color.gray;
                id15Clicked = false;
                id15.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                id11Clicked = false;
                id11.GetComponent<Image>().color = Color.white;
                id12Clicked = false;
                id12.GetComponent<Image>().color = Color.white;
                id13Clicked = false;
                id13.GetComponent<Image>().color = Color.white;
                id14Clicked = false;
                id14.GetComponent<Image>().color = Color.white;
                id15Clicked = true;
                id15.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckID2Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                id21Clicked = true;
                id21.GetComponent<Image>().color = Color.gray;
                id22Clicked = false;
                id22.GetComponent<Image>().color = Color.white;
                id23Clicked = false;
                id23.GetComponent<Image>().color = Color.white;
                id24Clicked = false;
                id24.GetComponent<Image>().color = Color.white;
                id25Clicked = false;
                id25.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                id21Clicked = false;
                id21.GetComponent<Image>().color = Color.white;
                id22Clicked = true;
                id22.GetComponent<Image>().color = Color.gray;
                id23Clicked = false;
                id23.GetComponent<Image>().color = Color.white;
                id24Clicked = false;
                id24.GetComponent<Image>().color = Color.white;
                id25Clicked = false;
                id25.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                id21Clicked = false;
                id21.GetComponent<Image>().color = Color.white;
                id22Clicked = false;
                id22.GetComponent<Image>().color = Color.white;
                id23Clicked = true;
                id23.GetComponent<Image>().color = Color.gray;
                id24Clicked = false;
                id24.GetComponent<Image>().color = Color.white;
                id25Clicked = false;
                id25.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                id21Clicked = false;
                id21.GetComponent<Image>().color = Color.white;
                id22Clicked = false;
                id22.GetComponent<Image>().color = Color.white;
                id23Clicked = false;
                id23.GetComponent<Image>().color = Color.white;
                id24Clicked = true;
                id24.GetComponent<Image>().color = Color.gray;
                id25Clicked = false;
                id25.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                id21Clicked = false;
                id21.GetComponent<Image>().color = Color.white;
                id22Clicked = false;
                id22.GetComponent<Image>().color = Color.white;
                id23Clicked = false;
                id23.GetComponent<Image>().color = Color.white;
                id24Clicked = false;
                id24.GetComponent<Image>().color = Color.white;
                id25Clicked = true;
                id25.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckID3Amount(int answer)
    {
        switch (answer)
        {
            case 1:
                id31Clicked = true;
                id31.GetComponent<Image>().color = Color.gray;
                id32Clicked = false;
                id32.GetComponent<Image>().color = Color.white;
                id33Clicked = false;
                id33.GetComponent<Image>().color = Color.white;
                id34Clicked = false;
                id34.GetComponent<Image>().color = Color.white;
                id35Clicked = false;
                id35.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                id31Clicked = false;
                id31.GetComponent<Image>().color = Color.white;
                id32Clicked = true;
                id32.GetComponent<Image>().color = Color.gray;
                id33Clicked = false;
                id33.GetComponent<Image>().color = Color.white;
                id34Clicked = false;
                id34.GetComponent<Image>().color = Color.white;
                id35Clicked = false;
                id35.GetComponent<Image>().color = Color.white;
                break;
            case 3:
                id31Clicked = false;
                id31.GetComponent<Image>().color = Color.white;
                id32Clicked = false;
                id32.GetComponent<Image>().color = Color.white;
                id33Clicked = true;
                id33.GetComponent<Image>().color = Color.gray;
                id34Clicked = false;
                id34.GetComponent<Image>().color = Color.white;
                id35Clicked = false;
                id35.GetComponent<Image>().color = Color.white;
                break;
            case 4:
                id31Clicked = false;
                id31.GetComponent<Image>().color = Color.white;
                id32Clicked = false;
                id32.GetComponent<Image>().color = Color.white;
                id33Clicked = false;
                id33.GetComponent<Image>().color = Color.white;
                id34Clicked = true;
                id34.GetComponent<Image>().color = Color.gray;
                id35Clicked = false;
                id35.GetComponent<Image>().color = Color.white;
                break;
            case 5:
                id31Clicked = false;
                id31.GetComponent<Image>().color = Color.white;
                id32Clicked = false;
                id32.GetComponent<Image>().color = Color.white;
                id33Clicked = false;
                id33.GetComponent<Image>().color = Color.white;
                id34Clicked = false;
                id34.GetComponent<Image>().color = Color.white;
                id35Clicked = true;
                id35.GetComponent<Image>().color = Color.gray;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void ChangePanel(string panelName)
    {
        switch (panelName)
        {
            case "AB":
                DisablePanels();
                abPanel.SetActive(true);
                break;
            case "PA":
                DisablePanels();
                paPanel.SetActive(true);
                break;
            case "ID":
                DisablePanels();
                idPanel.SetActive(true);
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void FLPanel()
    {
        if (fl11Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL1 = 1;
        }
        else if (fl12Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL1 = 2;
        }
        else if (fl13Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL1 = 3;
        }
        else if (fl14Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL1 = 4;
        }
        else if (fl15Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL1 = 5;
        }

        if (fl21Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL2 = 1;
        }
        else if (fl22Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL2 = 2;
        }
        else if (fl23Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL2 = 3;
        }
        else if (fl24Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL2 = 4;
        }
        else if (fl25Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL2 = 5;
        }

        if (fl31Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL3 = 1;
        }
        else if (fl32Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL3 = 2;
        }
        else if (fl33Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL3 = 3;
        }
        else if (fl34Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL3 = 4;
        }
        else if (fl35Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL3 = 5;
        }

        if (fl41Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL4 = 1;
        }
        else if (fl42Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL4 = 2;
        }
        else if (fl43Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL4 = 3;
        }
        else if (fl44Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL4 = 4;
        }
        else if (fl45Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].FL4 = 5;
        }

        DisablePanels();
        abPanel.SetActive(true);
    }

    public void ABPanel()
    {
        if (ab11Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB1 = 1;
        }
        else if (ab12Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB1 = 2;
        }
        else if (ab13Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB1 = 3;
        }
        else if (ab14Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB1 = 4;
        }
        else if (ab15Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB1 = 5;
        }

        if (ab21Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB2 = 1;
        }
        else if (ab22Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB2 = 2;
        }
        else if (ab23Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB2 = 3;
        }
        else if (ab24Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB2 = 4;
        }
        else if (ab25Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB2 = 5;
        }

        if (ab31Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB3 = 1;
        }
        else if (ab32Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB3 = 2;
        }
        else if (ab33Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB3 = 3;
        }
        else if (ab34Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB3 = 4;
        }
        else if (ab35Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB3 = 5;
        }

        if (ab41Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB4 = 1;
        }
        else if (ab42Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB4 = 2;
        }
        else if (ab43Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB4 = 3;
        }
        else if (ab44Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB4 = 4;
        }
        else if (ab45Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].AB4 = 5;
        }

        DisablePanels();
        paPanel.SetActive(true);
    }

    public void PAPanel()
    {
        if (pa11Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA1 = 1;
        }
        else if (pa12Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA1 = 2;
        }
        else if (pa13Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA1 = 3;
        }
        else if (pa14Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA1 = 4;
        }
        else if (pa15Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA1 = 5;
        }

        if (pa21Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA2 = 1;
        }
        else if (pa22Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA2 = 2;
        }
        else if (pa23Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA2 = 3;
        }
        else if (pa24Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA2 = 4;
        }
        else if (pa25Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].PA2 = 5;
        }

        DisablePanels();
        idPanel.SetActive(true);
    }

    public void IDPanel()
    {
        if (id11Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID1 = 1;
        }
        else if (id12Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID1 = 2;
        }
        else if (id13Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID1 = 3;
        }
        else if (id14Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID1 = 4;
        }
        else if (id15Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID1 = 5;
        }

        if (id21Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID2 = 1;
        }
        else if (id22Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID2 = 2;
        }
        else if (id23Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID2 = 3;
        }
        else if (id24Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID2 = 4;
        }
        else if (id25Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID2 = 5;
        }

        if (id31Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID3 = 1;
        }
        else if (id32Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID3 = 2;
        }
        else if (id33Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID3 = 3;
        }
        else if (id34Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID3 = 4;
        }
        else if (id35Clicked)
        {
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].ID3 = 5;
        }

        DisablePanels();
        ChangeScene("MainMenu");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
