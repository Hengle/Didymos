﻿using System;


public struct Point
{
	public Point(int x,int y){
		this.x = x;
		this.y = y;
	}
	public override string ToString(){
		return x + " " + y;
	}
	public readonly int x;
	public readonly int y;

}


