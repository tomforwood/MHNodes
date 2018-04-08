using Expansions.Missions;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace MHNodes
{
    public class ActionKillWarp : ActionModule
    {
        public string Name
        {
            get { return "Kill warp"; }
        }

        public new String GetDisplayName()

        {
            String s = base.GetDisplayName();
            return Name + " " + s;
        }

        public override string GetInfo()
        {
            return "A node which simply kills the timewarp when hit";
        }

        public override IEnumerator Fire()
        {
            Debug.Log("Fire is being called");
            TimeWarp.SetRate(0, false, false);
            return Enumerable.Empty<int>().GetEnumerator();
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Load(ConfigNode node)
        {
            base.Load(node);
        }

        public override void Save(ConfigNode node)
        {
            base.Save(node);
        }
    }
}
