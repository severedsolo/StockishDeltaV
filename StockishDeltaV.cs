﻿using KSP.UI.Screens;
using UnityEngine;
using System.Collections;
using UnityEngine.Collections;

namespace StockishDeltaV
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class StockishDeltaV : MonoBehaviour
    {
        private DeltaVTest _test;

        void Awake()
        {
                GameEvents.onGUIEngineersReportReady.Add(ReportReady);
                GameEvents.onGUIEngineersReportDestroy.Add(ReportDestroyed);
        }

        private IEnumerator AddTest()
        {            
            //Wait for DeltaV simulation to be instantiated and to finish.
            while (EditorLogic.fetch.ship.vesselDeltaV == null || !EditorLogic.fetch.ship.vesselDeltaV.isReady)
            {
                yield return new WaitForSeconds(0.5f);
            }

            //Register our test in the Report
            _test = new DeltaVTest();
            EngineersReport.Instance.AddTest(_test);
            EngineersReport.Instance.ShouldTest(_test);
        }

        private void RemoveTest()
        {
            //In case we're waiting for the DeltaV, stop waiting
            StopAllCoroutines();

            //Only if it was actually added, deregister it.
            if (_test != null) EngineersReport.Instance.RemoveTest(_test);
        }

        private void ReportDestroyed()
        {
            RemoveTest();
        }

        private void ReportReady()
        {
            Debug.Log("[StockishDeltaV] ReportReady");
            RemoveTest();
            StartCoroutine(AddTest());
        }   
    }
}
