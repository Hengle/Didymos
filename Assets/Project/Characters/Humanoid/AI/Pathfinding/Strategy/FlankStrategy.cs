﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlankStrategy : PathfinderStrategy
{
    [SerializeField]
    private HumanoidModel strategizer;
    [SerializeField]
    private HumanoidTargeter targeter;

    [SerializeField]
    private HeightPenaltyAttributes heightData;
    [SerializeField]
    private CoverDisparityPenaltyAttributes coverDisparityData;


    private void Awake()
    {

    }

    private void Start()
    {

    }

    /*
     * Need to cache the result of this
     */
    public override int GetAdditionalCostAt(Vector3 start, Vector3 end)
    {
        var enemyMarkers = targeter.GetEnemyMarkers();
        var enemyVantages = new List<HumanoidVantage>();

        foreach(CommunicatableEnemyMarker enemy in enemyMarkers){
            enemyVantages.Add(enemy.GetEnemyMarker().GetVantage());
        }

        float heightDifference = end.y - start.y;
        float heightPenalty = CostCalculatorHelper.CalculateHeightPenalty(
            heightDifference,
            heightData.goingUpPenalty,
            heightData.climbUpThreshold,
            heightData.climbUpThreshold,
            heightData.goingDownPenalty,
            heightData.climbDownPenalty,
            heightData.climbDownThreshold
        );

        float totalCoverDisparity = CostCalculatorHelper.CalculateTotalCoverDisparity(
            strategizer.InfoGetVantageData(),
            enemyVantages,
            end
        );

        float totalCoverDisparityPenalty = totalCoverDisparity * coverDisparityData.coverDisparityPenalty;

        return (int)(heightPenalty + totalCoverDisparityPenalty);
    }
}