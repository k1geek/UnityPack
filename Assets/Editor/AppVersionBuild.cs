using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AppVersionBuild
{
    public static string dest = Application.streamingAssetsPath;
    public static string from = Base.Packed;
    public static AssetBundleManifest mainManifest;

    public static void Versionbuild(){
        gen();
        CopyFile();
    }

    public static void gen(){
    }

    public static void CopyFile(){
        clear();
        if (!Directory.Exists(dest))
            Directory.CreateDirectory(dest);
        Debug.Log(dest);
        if(mainManifest == null){
            AssetBundle mainManifestAB = AssetBundle.LoadFromFile(from+Path.GetFileName(from.Substring(0, from.Length - 1)));
            mainManifest = mainManifestAB.LoadAsset("assetbundlemanifest") as AssetBundleManifest;
        }
        foreach (var item in mainManifest.GetAllAssetBundles())
        {
            Debug.Log(item);
            //Debug.Log(Path.GetFileName(item));
            string path = dest+"/"+item;
            string pathName = Path.GetDirectoryName(path);
            if (!Directory.Exists(pathName))
                Directory.CreateDirectory(pathName);
            File.Copy(from+item, path,true);
        }
        //File.Copy(abfromDir + abname, f1, true);
    }

    public static void clear(){
        if (Directory.Exists(dest)){
            Directory.Delete(dest,true);
        }
    }
}
