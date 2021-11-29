using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBundleBuilder
{
    public static string dest = Base.Packed;
    // public static string packres = dest + "packres/";

    [MenuItem("Tools/AssetBundleTool/BuildAsstBundleWin")]
    public static void BuildAsstBundleWin(){
        build(BuildTarget.StandaloneWindows64);
        AppVersionBuild.Versionbuild();
    }

    public static void build(BuildTarget target){
        if (!Directory.Exists(dest))
            Directory.CreateDirectory(dest);

        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(dest,
            BuildAssetBundleOptions.DisableLoadAssetByFileName |
            BuildAssetBundleOptions.DisableLoadAssetByFileNameWithExtension |
            BuildAssetBundleOptions.StrictMode |
            BuildAssetBundleOptions.DeterministicAssetBundle |
            BuildAssetBundleOptions.ChunkBasedCompression,
        target);

        if (manifest == null){
            Debug.LogError("[BuildPipeline.BuildAssetBundles] build AssetBundle failed");
            throw new Exception("[E]Error:build AssetBundle failed");
        }else{
            Debug.Log("pack assetBundle success");
        }
    }

    public static void clear(){
        if (Directory.Exists(dest)){
            Directory.Delete(dest,true);
        }
    }
}