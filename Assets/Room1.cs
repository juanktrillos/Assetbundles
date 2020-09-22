using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room1 : MonoBehaviour {
    public string namePlayer;
    public string nameObstaculo;
    public Button escena0;
    public Button load1;
    public Button unload1;
    public Button loadObs;
    public Button destroyObs;
    private List<GameObject> objstaculs;

    // Start is called before the first frame update
    void Start () {
        Controller.controller.LoadAsset ("player");
        objstaculs = new List<GameObject> ();

        escena0.onClick.AddListener (() => {
            Controller.controller.NextScene ("Escena0");
        });
        load1.onClick.AddListener (() => {
            Controller.controller.LoadBundle ("obstaculo");
        });
        unload1.onClick.AddListener (() => {
            Controller.controller.UnloadBundle ("obstaculo");
        });
        loadObs.onClick.AddListener (() => {
            objstaculs.Add (Controller.controller.LoadAsset ("gameobject"));
        });
        destroyObs.onClick.AddListener (() => {
            DestroyObjs ();
        });
    }

    void DestroyObjs () {
        for (int i = 0; i < objstaculs.Count; i++) {
            Destroy (objstaculs[i]);
        }
        objstaculs.Clear ();
    }

    // Update is called once per frame
    void Update () {

    }
}