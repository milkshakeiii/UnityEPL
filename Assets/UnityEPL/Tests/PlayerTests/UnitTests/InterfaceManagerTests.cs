using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using UnityEPL;

namespace UnityEPL {

    public class InterfaceManagerTests {
        InterfaceManager manager;

        const double ONE_FRAME_MS = 1000.0 / 120.0;
        const double DELAY_JITTER_MS = 9;
        // TODO: JPB: (bug) The acceptable jitter for InterfaceManager.Delay() should be less than 9ms

        [OneTimeSetUp]
        public void InterfaceManagerSetup() {
            manager = GameObject.FindObjectOfType<InterfaceManager>();
            if (manager == null) {
                manager = new GameObject().AddComponent<InterfaceManager>();
            }
        }

        // A Test behaves as an ordinary method
        [Test]
        public void Creation() {
            Assert.AreNotEqual(null, manager);
        }

        // Async Delay has 9ms leniency (because it's bad)
        [Test]
        public void Delay() {
            Task.Run(async () => {
                var start = Clock.UtcNow;
                await InterfaceManager.Delay(1000);
                var diff = (Clock.UtcNow - start).TotalMilliseconds;
                Assert.GreaterOrEqual(diff, 1000);
                Assert.LessOrEqual(diff, 1000 + DELAY_JITTER_MS);
            }).Wait();
        }

        // Enumerator Delay has 9ms leniency (due to frame linking at 120fps)
        [UnityTest]
        public IEnumerator DelayE() {
            var start = Clock.UtcNow;
            yield return InterfaceManager.DelayE(1000);
            var diff = (Clock.UtcNow - start).TotalMilliseconds;
            Assert.GreaterOrEqual(diff, 1000);
            Assert.LessOrEqual(diff, 1000 + ONE_FRAME_MS);
        }

        // Enumerator Delay has 3ms leniency
        [UnityTest]
        public IEnumerator IEnumeratorDelay() {
            var start = Clock.UtcNow;
            yield return InterfaceManager.Delay(1000).ToEnumerator();
            var diff = (Clock.UtcNow - start).TotalMilliseconds;
            Assert.GreaterOrEqual(diff, 1000);
            Assert.LessOrEqual(diff, 1003);
        }

        
    }

}


