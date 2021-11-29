using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base
{
    public static string data = Application.dataPath.Replace("\\", "/");
    public static string root = data.Substring(0, data.Length - 6);
    public static string Packed = Base.root + "Packed/";
}
