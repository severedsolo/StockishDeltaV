using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using PreFlightTests;

namespace StockishDeltaV
{
    class DeltaVTest : DesignConcernBase
    {           
        public override string GetConcernDescription()
        {
            if (EditorLogic.fetch.ship.vesselDeltaV == null) return "";
            return "Atmosphere: " + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVASL,0) + "m/s"+Environment.NewLine+ "Vacuum DeltaV:" + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVVac,0)+"m/s";
        }

        public override string GetConcernTitle()
        {
            if (EditorLogic.fetch.ship.vesselDeltaV == null) return "Delta V: Not Ready";
            return "Delta V: " + Math.Round(EditorLogic.fetch.ship.vesselDeltaV.totalDeltaVVac,0)+"m/s";
        }

        public override DesignConcernSeverity GetSeverity()
        {
            return DesignConcernSeverity.NOTICE;
        }

        public override bool TestCondition()
        {
            bool condition = EditorLogic.fetch.ship.vesselDeltaV == null;
            Debug.Log("[StockishDeltaV] condition = " + condition);
            return condition;
        }
    }
}
