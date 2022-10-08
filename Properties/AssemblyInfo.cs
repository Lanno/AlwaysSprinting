using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(AlwaysSprinting.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AlwaysSprinting.BuildInfo.Company)]
[assembly: AssemblyProduct(AlwaysSprinting.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + AlwaysSprinting.BuildInfo.Author)]
[assembly: AssemblyTrademark(AlwaysSprinting.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(AlwaysSprinting.BuildInfo.Version)]
[assembly: AssemblyFileVersion(AlwaysSprinting.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(AlwaysSprinting.AlwaysSprinting), AlwaysSprinting.BuildInfo.Name, AlwaysSprinting.BuildInfo.Version, AlwaysSprinting.BuildInfo.Author, AlwaysSprinting.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]