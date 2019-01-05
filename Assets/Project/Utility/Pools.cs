﻿using UnityEngine;
using System.Collections.Generic;
/*
 * If something wierd happens, blame
 * the incorrect recycling of lists 
 * and poolable objects
 */
public class Pools : MonoBehaviour {
    private static Pools instance;

  


    private Pool<List<MapNode>> listMapNodes;
    private Pool<List<Point>> listPoints;
    private Pool<MapNode> mapNodes;
    private Pool<List<EnvironmentPhysics.IntersectionResult>> listIntersectionResults;
    private Pool<HashSet<Point>> hashSetPoints;
    private Pool<Point> points;
    private Pool<List<Vector2>> listVector2s;
    private Pool<List<Vector3>> listVector3s;

    public static MapNode MapNode
    {
        get
        {
            MapNode data = instance.mapNodes.Get();
            data.Clear();
            return data;
        }
        set
        {
            instance.mapNodes.Recycle(value);
        }
    }
    public static Point Point
    {
        get
        {
            Point data = instance.points.Get();
            data.Clear();
            return data;
        }
        set
        {
            instance.points.Recycle(value);
        }
    }
    public static List<MapNode> ListMapNodes
    {
        get
        {
            List<MapNode> mapnodes = 
                instance.listMapNodes.Get();
            mapnodes.Clear();
            return mapnodes;
        }
        set
        {
            instance.listMapNodes.Recycle(value);
        }
    }
    public static void FreeListPoints(List<Point> data)
    {
        for(int i = 0; i < data.Count; i++){
            Point = data[i];
        }
    }
    public static void FreeHashSetPoints(HashSet<Point> data)
    {
        IEnumerator<Point> enumerator = data.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Point = enumerator.Current;
        }
    }
    public static List<Point> ListPoints
    {
        get
        {
            List<Point> data =
                instance.listPoints.Get();
            data.Clear();
            return data;
        }
        set
        {
            instance.listPoints.Recycle(value);
        }
    }
    public static HashSet<Point> HashSetPoints
    {
        get
        {
            HashSet<Point> data =
                instance.hashSetPoints.Get();
            data.Clear();
            return data;
        }
        set
        {
            instance.hashSetPoints.Recycle(value);
        }
    }
    public static List<EnvironmentPhysics.IntersectionResult> ListIntersectionResults
    {
        get
        {
            List<EnvironmentPhysics.IntersectionResult> data =
                instance.listIntersectionResults.Get();
            data.Clear();
            return data;
        }
        set
        {
            instance.listIntersectionResults.Recycle(value);
        }
    }
    public static List<Vector2> ListVector2s
    {
        get
        {
            List<Vector2> data =
                instance.listVector2s.Get();
            data.Clear();
            return data;
        }
        set
        {
            instance.listVector2s.Recycle(value);
        }
    }

    public static List<Vector3> ListVector3s
    {
        get
        {
            List<Vector3> data =
                instance.listVector3s.Get();
            data.Clear();
            return data;
        }
        set
        {
            instance.listVector3s.Recycle(value);
        }
    }
    private void Awake() {
        listMapNodes = new Pool<List<MapNode>>(30);
        mapNodes = new Pool<MapNode>(1000);
        listPoints = new Pool<List<Point>>(30);
        listIntersectionResults = new Pool<List<EnvironmentPhysics.IntersectionResult>>(30);
        hashSetPoints = new Pool<HashSet<Point>>(30);
        points = new Pool<Point>(1000);
        listVector2s = new Pool<List<Vector2>>(100);
        listVector3s = new Pool<List<Vector3>>(100);
        instance = this; 
    }

    private void Update()
    {

    }

}