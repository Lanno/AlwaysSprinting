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
            this.rig = Object.FindObjectOfType<ControllerRig>();

            if (this.rig)
            {
                this.defaultMaxVelocity = this.rig.maxVelocity;
            }
        }
        public override void OnUpdate()
        {
            //string text = $"thresh: {this.rig._wasOverFlickThresh} secondary: {this.rig._secondaryFlickReady} memory: {this.rig._doubleFlickMem.x},{this.rig._doubleFlickMem.y} last: {this.rig._lastFlickTime}, cooled: {this.rig._jogCoolTime} axis primary: {this.rig._axisPrimary.x},{this.rig._axisPrimary.y} axis secondary: {this.rig._axisSecondary.x},{this.rig._axisSecondary.y}";
            //string text = $"max vel: {this.rig.maxVelocity} current max vel: {this.rig.currentMaxVelocity} current vel: {this.rig._currentVelocity.magnitude} get vel: {this.rig.GetVelocity().magnitude}";

            //using (StreamWriter writetext = new StreamWriter(@"D:\OneDrive\Modding\BONELAB\AlwaysSprinting\rig8.txt", append: true))
            //{
            //    writetext.WriteLine(text);
            //}

            if (this.rig != null && this.rig._wasOverFlickThresh)
            {
                this.rig._wasOverFlickThresh = false;

                // this.rig._secondaryFlickReady = true;
                // this.rig._doubleFlickMem.Set(1000000f, 1000000f);
                // this.rig._lastFlickTime = this.rig._time - 5;

                //this.rig._doubleFlickMem = this.rig._axisPrimary.normalized;
                //this.rig._lastFlickTime = 70.0f;
            }

            if ((int)(2000 * this.defaultMaxVelocity) != (int)(1000 * this.rig.maxVelocity))
            {
                this.defaultMaxVelocity = this.rig.maxVelocity;
            }

            if (this.rig != null)
            {
                this.rig.maxVelocity = this.defaultMaxVelocity * 2.0f;
            }
        }
    }
}
