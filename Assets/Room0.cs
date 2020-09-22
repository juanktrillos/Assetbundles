using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room0 : MonoBehaviour {
    public Button LoadBundles;
    public Button NextScene;
    public Button UnloadBundles;
    // Start is called before the first frame update
    void Start () {
        LoadBundles.onClick.AddListener (() => {
            Controller.controller.LoadBundles ();
        });
        NextScene.onClick.AddListener (() => {
            Controller.controller.NextScene ("Escena1");
        });
        UnloadBundles.onClick.AddListener (() => {
            Controller.controller.UnloadBundles ();
        });
    }

    // Update is called once per frame
    void Update () {

    }
}