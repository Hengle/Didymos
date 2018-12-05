﻿using System;

public class RestrictByHCost : INodeDistanceClamper{
    public RestrictByHCost(){

    }

    public bool WithinRangeOfStart(PathfinderNode node, int nodeDistance){
        return node.GetHCost() < nodeDistance;
    }
}
