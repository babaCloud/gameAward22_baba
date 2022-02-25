using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "MapData")]
public class MapData : ScriptableObject
{
    public Material[] wallMat;
    public WallDirectionManager.Wall[] wallData = new WallDirectionManager.Wall[4];
    public float mapAngleMoveAmount;

}
