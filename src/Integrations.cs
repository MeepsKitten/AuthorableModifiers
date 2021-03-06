﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace AuthorableModifiers
{
    public static class Integrations
    {
        public static bool arenaLoaderFound = false;
        public static bool scoreOverlayFound = false;
        public static bool autoLightshowFound = false;
        public static void LookForIntegrations()
        {
            foreach (MelonMod mod in MelonHandler.Mods)
            {
                if (mod.Assembly.GetName().Name == "ArenaLoader")
                {
                    var scoreVersion = new Version(mod.Info.Version);
                    var lastUnsupportedVersion = new Version("0.2.3");
                    var result = scoreVersion.CompareTo(lastUnsupportedVersion);
                    if (result > 0)
                    {
                        arenaLoaderFound = true;
                        MelonLogger.Log("Arena Loader found");

                    }
                    else
                    {
                        MelonLogger.LogWarning("Arena Loader version not compatible. Update Arena Loader to use it with Authorable Modifiers.");
                        arenaLoaderFound = false;
                    }
                }      
                else if(mod.Assembly.GetName().Name == "ScoreOverlay")
                {
                    var scoreVersion = new Version(mod.Info.Version);
                    var lastUnsupportedVersion = new Version("2.0.2");
                    var result = scoreVersion.CompareTo(lastUnsupportedVersion);
                    if (result > 0)
                    {
                        scoreOverlayFound = true;
                        MelonLogger.Log("Score Overlay found");

                    }
                    else
                    {
                        MelonLogger.LogWarning("Score Overlay version not compatible. Update Score Overlay to use it with Authorable modifiers.");
                        scoreOverlayFound = false;
                    }
                }
                else if (mod.Assembly.GetName().Name == "AutoLightshow")
                {
                    var scoreVersion = new Version(mod.Info.Version);
                    var lastUnsupportedVersion = new Version("1.0.0");
                    var result = scoreVersion.CompareTo(lastUnsupportedVersion);
                    if (result > 0)
                    {
                        autoLightshowFound = true;
                        MelonLogger.Log("Auto Lightshow found");
                    }
                    else
                    {
                        MelonLogger.LogWarning("Auto Lightshow version not compatible. Update Auto Lightshow to use it with Authorable modifiers.");
                        autoLightshowFound = false;
                    }
                }
            }
        }
    }
}
