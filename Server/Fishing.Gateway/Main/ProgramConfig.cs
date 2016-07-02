using System;
using System.Collections.Generic;
using System.Configuration;

class ConfigCommon : ConfigurationSection
{
    [ConfigurationProperty("ListenIp", IsRequired = true)]
    public string ListenIp
    {
        get { return (string)this["ListenIp"]; }
        set { this["ListenIp"] = value; }
    }

    [ConfigurationProperty("ListenPort", IsRequired = true)]
    public int ListenPort
    {
        get { return (int)this["ListenPort"]; }
        set { this["ListenPort"] = value; }
    }
}

public class ProgramConfig
{
    //---------------------------------------------------------------------
    public string ListenIp { get; private set; }
    public int ListenPort { get; private set; }

    //---------------------------------------------------------------------
    public ProgramConfig()
    {
        ListenIp = "";
        ListenPort = 0;
    }

    //---------------------------------------------------------------------
    public void load(string config_filename)
    {
        ExeConfigurationFileMap file = new ExeConfigurationFileMap();
        file.ExeConfigFilename = config_filename;
        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

        ConfigCommon cfg_common = config.SectionGroups["Fishing.Gateway"].Sections["Common"] as ConfigCommon;
        ListenIp = cfg_common.ListenIp;
        ListenPort = cfg_common.ListenPort;
    }

    //---------------------------------------------------------------------
    public void save()
    {
        ConfigCommon cfg_common = new ConfigCommon();
        cfg_common.ListenIp = ListenIp;
        cfg_common.ListenPort = ListenPort;

        ExeConfigurationFileMap file = new ExeConfigurationFileMap();
        file.ExeConfigFilename = "Fishing.Gateway.exe.config";
        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
        if (config.SectionGroups.Get("Fishing.Gateway") == null)
        {
            config.SectionGroups.Add("Fishing.Gateway", new ConfigurationSectionGroup());
        }

        if (config.SectionGroups["Fishing.Gateway"].Sections.Get("Common") == null)
        {
            config.SectionGroups["Fishing.Gateway"].Sections.Add("Common", cfg_common);
        }

        config.Save(ConfigurationSaveMode.Modified);
    }
}
