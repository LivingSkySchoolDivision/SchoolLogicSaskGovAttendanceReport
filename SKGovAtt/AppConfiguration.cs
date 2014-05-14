using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKGovAtt
{
    static class AppConfiguration
    {
        // Configuration items needed
        //  Database connection - hostname, username, password, database
        //  School Division DAN
        //  School Division prefix code

        // How long the cache lifetime is when loading objects from the database
        public static readonly TimeSpan CacheLifetime = new TimeSpan(0, 0, 2, 0);

        private const string ConfigConnectionStringKeyName = "ConnString";
        private const string ConfigDANStringKeyName = "DistrictDAN";
        private const string ConfigPrefixStringKeyName = "DistrictPrefix";
        private const string ConfigFirstRunKeyName = "FirstRun";

        public static bool IsFirstRun()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(ConfigFirstRunKeyName))
            {
                config.AppSettings.Settings.Add(ConfigFirstRunKeyName, "FALSE");
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static string GetConnectionString()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(ConfigConnectionStringKeyName))
            {
                config.AppSettings.Settings.Add(ConfigConnectionStringKeyName, "");
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                return string.Empty;
            }
            else
            {
                return config.AppSettings.Settings[ConfigConnectionStringKeyName].Value;
            }
        }

        public static string GetDivisionDAN()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(ConfigDANStringKeyName))
            {
                config.AppSettings.Settings.Add(ConfigDANStringKeyName, "");
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                return "0000000";
            }
            else
            {
                return config.AppSettings.Settings[ConfigDANStringKeyName].Value;
            }
        }

        public static string GetDivisionPrefix()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(ConfigPrefixStringKeyName))
            {
                config.AppSettings.Settings.Add(ConfigPrefixStringKeyName, "");
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                return "PREFIX";
            }
            else
            {
                return config.AppSettings.Settings[ConfigPrefixStringKeyName].Value;
            }
        }
        
        public static void SetDivisionDAN(string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(ConfigDANStringKeyName))
            {
                config.AppSettings.Settings.Add(ConfigDANStringKeyName, newValue);
            }
            else
            {
                config.AppSettings.Settings[ConfigDANStringKeyName].Value = newValue;
            }
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void SetDivisionPrefix(string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(ConfigPrefixStringKeyName))
            {
                config.AppSettings.Settings.Add(ConfigPrefixStringKeyName, newValue);
            }
            else
            {
                config.AppSettings.Settings[ConfigPrefixStringKeyName].Value = newValue;
            }
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void SetConnectionString(string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(ConfigConnectionStringKeyName))
            {
                config.AppSettings.Settings.Add(ConfigConnectionStringKeyName, newValue);
            }
            else
            {
                config.AppSettings.Settings[ConfigConnectionStringKeyName].Value = newValue;
            }
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }


    }
}
