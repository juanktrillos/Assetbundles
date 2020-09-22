using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public static Controller controller;
    public string[] bundleList;
    public string[] pathList;
    public List<AssetBundle> bundles;
    private string bundlePath;
    private void Awake () {
        if (controller == null) {
            controller = this;
            DontDestroyOnLoad (this);
        } else if (controller != null)
            Destroy (this.gameObject);
    }

    // Start is called before the first frame update
    void Start () {
        bundlePath = Application.streamingAssetsPath;
        pathList = new string[bundleList.Length];

        for (int i = 0; i < bundleList.Length; i++) {
            string filePath = bundlePath + '/' + bundleList[i];
            if (!System.IO.File.Exists (filePath))
                pathList[i] = null;
            else
                pathList[i] = filePath;
        }
    }

    public void LoadBundles () {
        bundles = new List<AssetBundle> ();
        for (int i = 0; i < pathList.Length; i++) {
            if (!string.IsNullOrEmpty (pathList[i])) {
                bundles.Add (AssetBundle.LoadFromFile (pathList[i]));
            }
        }
    }

    public void UnloadBundles () {
        for (int i = 0; i < bundles.Count; i++) {
            bundles[i].Unload (true);
        }
        bundles.Clear ();
        // AssetBundle.UnloadAllAssetBundles (true);
    }

    public void LoadBundle (string nameBundle) {
        for (int i = 0; i < bundleList.Length; i++) {
            if (bundleList[i].Equals (nameBundle)) {
                bundles.Add (AssetBundle.LoadFromFile (pathList[i]));
            }
        }
    }

    public void UnloadBundle (string nameBundle) {
        for (int i = 0; i < bundles.Count; i++) {
            if (bundles[i].name.Equals (nameBundle)) {
                bundles[i].Unload (true);
                bundles.RemoveAt (i);
            }
        }

    }

    public void NextScene (string name) {
        UnityEngine.SceneManagement.SceneManager.LoadScene (name);
    }

    public GameObject LoadAsset (string nameAsset, string nameBundle = null) {
        for (int i = 0; i < bundles.Count; i++) {
            if (!string.IsNullOrEmpty (nameBundle)) {
                if (bundles[i].name.Equals (nameBundle)) {
                    // Debug.Log ("Loaded Asset: " + nameAsset);
                    return Instantiate (bundles[i].LoadAsset<GameObject> (nameAsset));
                } else
                    continue;
            } else {
                string[] assets = bundles[i].GetAllAssetNames () != null?bundles[i].GetAllAssetNames () : new string[0];
                for (int j = 0; j < assets.Length; j++) {
                    // Debug.Log (assets[j]);
                    if (assets[j].Contains (nameAsset)) {
                        Debug.Log ("Loaded Asset: " + assets[j]);
                        return Instantiate (bundles[i].LoadAsset<GameObject> (assets[j]));
                    }
                }
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update () {

    }
}