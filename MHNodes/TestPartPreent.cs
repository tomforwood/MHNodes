using Expansions.Missions;
using Expansions.Missions.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MHNodes
{
    class TestPartPresent : TestModule
    {
        [MEGUI_InputField(guiName = "TestPartName")]
        public String testPartName;

        [MEGUI_PartPicker(guiName = "TestPart")]
        public System.Object testPart;

        public TestPartPresent()
        {
        }


        public override string GetInfo()
        {
            return "Tests whether the active vessel has a given part";
        }

        public override void Load(ConfigNode node)
        {
            base.Load(node);
            testPartName = node.GetValue("PartName");
        }

        public override void Save(ConfigNode node)
        {
            base.Save(node);
            node.AddValue("PartName", testPartName);
        }

        public override void Awake()
        {
            Debug.Log("I'm awake");
            base.Awake();
        }

        public override string GetNodeBodyParameterString(BaseAPField field)
        {
            Debug.Log("Getting MBP for " + field.FieldType);
            return base.GetNodeBodyParameterString(field);
        }

        public override bool Test()
        {
            //Debug.Log("Running test for part" + testPart.partName);
            Vessel v = FlightGlobals.ActiveVessel;
            Debug.Log(v.GetDisplayName());
            Debug.Log(v.parts.Count());
            foreach (Part p in v.Parts)
            {
                Debug.Log("Path name = " + p.partName);
                Debug.Log("PartInfoName = " + p.partInfo.name);
                Debug.Log("AVailPart = " + p.partInfo.name);
            }
            return v.Parts.Exists((Part p) => p.partInfo.name == testPartName);
        }
    }
}
