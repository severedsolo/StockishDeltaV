using System;
using UnityEngine;
using PreFlightTests;
using System.Collections;
using UnityEngine.Collections;
using KSP.UI.Screens;

namespace StockishDeltaV
{
    class DeltaVTest : DesignConcernBase
    {           
        public override string GetConcernDescription()
        {
            //FIXME: This has the problem that when the ship gets changed, the sim needs some ticks to run again.
            //Maybe start some kind of delayed info in GameEvents.onEditorPartPlaced
            //isReady is only set once when the vesselDeltaV class is instantiated. SimulationRunning is always true - I don't think there is a way to make it wait until the calc is done.
            return "Atmosphere: " + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVASL, 0) + "m/s" + Environment.NewLine + "Vacuum:" + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVVac, 0) + "m/s";
        }

        public override string GetConcernTitle()
        {
            //FIXME: This has the problem that when the ship gets changed, the sim needs some ticks to run again.
            //Maybe start some kind of delayed info in GameEvents.onEditorPartPlaced
            //isReady is only set once when the vesselDeltaV class is instantiated. SimulationRunning is always true - I don't think there is a way to make it wait until the calc is done.
            return "Delta V: " + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVVac, 0) + "m/s";
        }

        public override DesignConcernSeverity GetSeverity()
        {
            return DesignConcernSeverity.NOTICE;
        }

        public override bool TestCondition()
        {
            return false;
        }
    }
}
