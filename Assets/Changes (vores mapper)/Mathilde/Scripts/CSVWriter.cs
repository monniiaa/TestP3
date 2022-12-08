using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;


    public class CSVWriter : MonoBehaviour
    {
        string filename = "";

        [System.Serializable]

        public class Player
        {
            public string scenario;
            public string feeling;
            public int feelingAmountBefore, feelingAmountAfter;
            public int FL1, FL2, FL3, FL4;
            public int AB1, AB2, AB3, AB4;
            public int PA1, PA2;
            public int ID1, ID2, ID3;
        }

        [System.Serializable]

        public class PlayerList
        {
            public Player[] player;
        }

        public PlayerList myPlayerList = new PlayerList();

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            filename = Application.dataPath + "/Answer.csv";
        }

        public void WriteCSV()
        {
            if (myPlayerList.player.Length > 0)
            {
                TextWriter tw = new StreamWriter(filename, false);
                tw.WriteLine("Scenario" + ";" + "Feeling" + ";" + "Amount of feeling before" + ";" + "Amount of feeling after" + ";" +
                "FL1" + ";" + "FL2" + ";" + "FL3" + ";" + "FL4" + ";" + "AB1" + ";" + "AB2" + ";" + "AB3" + ";" + "AB4" + ";" + "PA1" +
                ";" + "PA2" + ";" + "ID1" + ";" + "ID2" + ";" + "ID3");
                tw.Close();

                tw = new StreamWriter(filename, true);

                for (int i = 0; i < myPlayerList.player.Length; i++)
                {
                    tw.WriteLine(myPlayerList.player[i].scenario + ";" + myPlayerList.player[i].feeling + ";" + myPlayerList.player[i].feelingAmountBefore + ";"
                    + myPlayerList.player[i].feelingAmountAfter + ";" + myPlayerList.player[i].FL1 + ";"
                    + myPlayerList.player[i].FL2 + ";" + myPlayerList.player[i].FL3 + ";" + myPlayerList.player[i].FL4 + ";"
                    + myPlayerList.player[i].AB1 + ";" + myPlayerList.player[i].AB2 + ";" + myPlayerList.player[i].AB3 + ";"
                    + myPlayerList.player[i].AB4 + ";" + myPlayerList.player[i].PA1 + ";" + myPlayerList.player[i].PA2 + ";"
                    + myPlayerList.player[i].ID1 + ";" + myPlayerList.player[i].ID2 + ";" + myPlayerList.player[i].ID3);
                }
                tw.Close();
            }
        }
    }
