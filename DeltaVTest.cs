using System;
using UnityEngine;
using PreFlightTests;

namespace StockishDeltaV
{
    class DeltaVTest : DesignConcernBase
    {           
        public override string GetConcernDescription()
        {
            //FIXME: This has the problem that when the ship gets changed, the sim needs some ticks to run again.
            //Maybe start some kind of delayed info in GameEvents.onEditorPartPlaced
            if (EditorLogic.fetch.ship.vesselDeltaV == null || !EditorLogic.fetch.ship.vesselDeltaV.isReady)
            {
                return "DeltaV not ready"; //FIXME: This never occurs?
            }
            return "Atmosphere: " + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVASL, 0) + "m/s" + Environment.NewLine + "Vacuum DeltaV:" + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVVac, 0) + "m/s";
        }

        public override string GetConcernTitle()
        {
            //FIXME: This has the problem that when the ship gets changed, the sim needs some ticks to run again.
            //Maybe start some kind of delayed info in GameEvents.onEditorPartPlaced
            if (EditorLogic.fetch.ship.vesselDeltaV == null || !EditorLogic.fetch.ship.vesselDeltaV.isReady)
            {
                return "DeltaV not ready";  //FIXME: This never occurs?
            }
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
