using UnityEditor;
class WebGLBuilder {
    static void build () {

        // Place all your scenes here
        string[] scenes = {
            "Assets/Scenes/Escena0.unity"
        };

        string pathToDeploy = "Build/WebGLversion/";

        BuildPipeline.BuildPlayer (scenes, pathToDeploy, BuildTarget.WebGL, BuildOptions.None);
    }
}