﻿using Server.Settings.Base;
using Server.Settings.Definition;

namespace Server.Settings
{
    public class GeneralSettings: SettingsBase<SettingsDefinition>
    {
        protected override string Filename => "Settings.xml";
    }
}