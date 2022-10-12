using MelonLoader;
using SLZ.Rig;
using UnityEngine;
using System.IO;
using SLZ.VRMK;

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
        private ControllerRig rig;
        private PhysicsRig physicsRig;
        private PhysTorso physTorso;

        private float defaultMaxVelocity;
        private float previousMass;
        private bool waitForVelocityChange;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            rig = Object.FindObjectOfType<ControllerRig>();
            physicsRig = Object.FindObjectOfType<PhysicsRig>();
            physTorso = Object.FindObjectOfType<PhysTorso>();
        }

        public float GetMass()
        {
            float mass = 0;

            if (physTorso)
                mass = physTorso.rbChest.mass + physTorso.rbHead.mass + physTorso.rbPelvis.mass + physTorso.rbSpine.mass;

            return mass;
        }

        public override void OnUpdate()
        {
            if (!rig || !physTorso)
                return;

            // Disable double tap sprint
            if (rig._wasOverFlickThresh)
                rig._wasOverFlickThresh = false;

            // Use change in mass to check if avatar has changed. 
            if (1.05 * previousMass <= GetMass() || GetMass() <= 0.95 * previousMass)
            {
                previousMass = GetMass();
                waitForVelocityChange = true;
            }

            // Check flag and wait for an unscaled velocity value to appear.
            if (waitForVelocityChange && (rig.maxVelocity < 1.9f * defaultMaxVelocity || defaultMaxVelocity == 0))
            {
                defaultMaxVelocity = rig.maxVelocity;
                waitForVelocityChange = false;
            }

            // Only change when flagged and when not moving vertically. The latter is to prevent errors if the change occurs 
            // during freefall. The engine changes rig.maxVelocity during freefall to represent critical velocity.
            if (!waitForVelocityChange && (-0.1 < physicsRig.wholeBodyVelocity.y && physicsRig.wholeBodyVelocity.y < 0.1))
            {
                rig.maxVelocity = 2.0f * defaultMaxVelocity;
            }
        }
    }
}
