using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;



public class TestExperiment4 : ExperimentBase4 {
    public TestExperiment4(InterfaceManager2 manager) : base(manager) {
        Run();
    }

    protected async Task RepeatedGetKey() {
        var key = await manager.inputManager.GetKey();
        UnityEngine.Debug.Log("Got key " + key);
        Do(RepeatedGetKey);
    }

    public override async Task MainStates() {
        //await manager.textDisplayer.AwaitableUpdateText("AwaitableUpdateText");
        //await InterfaceManager2.Delay(1000);
        //manager.textDisplayer.UpdateText("DONE");
        //var a = await manager.textDisplayer.ReturnableUpdateText("ReturnableUpdateText");
        //UnityEngine.Debug.Log("DoGet: " + a);

        //var cts = DoRepeating(1000, 10, 500, async () => { Debug.Log("Repeat"); });
        //await manager.inputManager.GetKey();
        //cts.Cancel();
        //await manager.inputManager.GetKey();

        //var key = await manager.inputManager.GetKey();
        //UnityEngine.Debug.Log("Got key " + key);

        //DelayedGet();
        //DelayedStop();
        //DelayedTriggerKeyPress();
        //KeyMsg keyMsg = await WaitOnKey(default);
        //UnityEngine.Debug.Log("MainStates - WaitOnKey: " + keyMsg.key);
        //manager.textDisplayer.UpdateText("UpdateText");
        //await InterfaceManager2.Delay(1000);
        //await DelayedGet();
    }
}
