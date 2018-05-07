using System.Diagnostics;

namespace DescubraOAssassino.Web.Properties {
    
    public sealed partial class Settings {
        
        public Settings() {
            SetWebApiApplicationSettings();
            SetDebugApplicationSettings();
            SetReleaseApplicationSettings();
        }

        [Conditional("WEBAPI")]
        private void SetWebApiApplicationSettings()
        {
          this["RunMode"] = "WEBAPI";
        }

        [Conditional("DEBUG")]
        private void SetDebugApplicationSettings()
        {
          this["RunMode"] = "DEBUG";
        }

        [Conditional("RELEASE")]
        private void SetReleaseApplicationSettings()
        {
          this["RunMode"] = "RELEASE";
        }

    }
}
