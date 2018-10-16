using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.UI.Screens;
using UnityEngine;
using PreFlightTests;

namespace StockishDeltaV
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class StockishDeltaV : MonoBehaviour
    {
        public static StockishDeltaV instance;
        DeltaVTest test;

        void Awake()
        {
            if (instance != null) Destroy(this);
            else instance = this;
            GameEvents.onGUIEngineersReportReady.Add(ReportReady);
            GameEvents.onGUIEngineersReportDestroy.Add(ReportDestroyed);
        }

        private void AddTest()
        {
            if(EditorLogic.fetch.ship.vesselDeltaV == null)
            {
                Invoke("AddTest", 0.5f);
                return;
            }
            if(!EditorLogic.fetch.ship.vesselDeltaV.isReady)
            {
                Invoke("AddTest", 0.5f);
                return;
            }
            test = new DeltaVTest();
            EngineersReport.Instance.AddTest(test);
        }
        private void ReportDestroyed()
        {
            if(test != null) EngineersReport.Instance.RemoveTest(test);
        }

        private void ReportReady()
        {
            Debug.Log("[StockishDeltaV] ReportReady");
            if (test != null) EngineersReport.Instance.RemoveTest(test);
            AddTest();
        }

    }
}
