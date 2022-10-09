using MelonLoader;
using SLZ.Rig;
using UnityEngine;
using System.IO;

namespace AlwaysSprinting
{
    public static class BuildInfo
    {
        public const string Name = "AlwaysSprinting"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "Lanno"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "0.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class AlwaysSprinting : MelonMod
    {
        ControllerRig rig;
        float defaultMaxVelocity;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            rig = Object.FindObjectOfType<ControllerRig>();

            if (rig)
            {
                defaultMaxVelocity = rig.maxVelocity;
            }
        }
        public override void OnUpdate()
        {
            if (!rig)
            {
                return;
            }

            if (rig._wasOverFlickThresh)
            {
                rig._wasOverFlickThresh = false;
            }

            // Attempt to determine if max velocity has changed based on avatar swap
            if ((-0.01 < rig.jumpVelocity && rig.jumpVelocity < 0.01) && (2.1f * defaultMaxVelocity <= rig.maxVelocity || rig.maxVelocity <= 1.9f * defaultMaxVelocity))
            {
                defaultMaxVelocity = rig.maxVelocity;
            }

            // Guard against multiple entries
            if (rig.maxVelocity < defaultMaxVelocity * 1.9f)
            {
                rig.maxVelocity = defaultMaxVelocity * 2.0f;
            }
        }
    }
}
