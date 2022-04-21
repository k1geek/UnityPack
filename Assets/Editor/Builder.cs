using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Builder
{
    [MenuItem("Tools/Build/PerforWindowsBuild")]
    public static void BuildWin(){
        AssetBundleBuilder.BuildAsstBundleWin();
        AppVersionBuild.Versionbuild();

        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
        BuildOptions opt = BuildOptions.Development | BuildOptions.AllowDebugging | BuildOptions.AcceptExternalModificationsToPlayer;
        BuildPipeline.BuildPlayer(GetLevels(), "../build_windows/textBuild.exe", BuildTarget.StandaloneWindows64, opt);
    }

    static string[] GetLevels()
    {
        string[] scenes = new string[] {
            "Assets/Scenes/SampleScene.unity"
        };
        return scenes;
    }
}
