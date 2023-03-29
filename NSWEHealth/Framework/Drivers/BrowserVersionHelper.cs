using System.Diagnostics;
using Microsoft.Win32;
using Browser = NSWEHealth.Framework.Wrapper.TestConstant.BrowserType;

namespace NSWEHealth.Framework.Drivers
{
    internal class BrowserVersionHelper
    {
        private object? _path;

        [System.Diagnostics.CodeAnalysis.SuppressMessage
            ("Interoperability", "CA1416:Validate platform compatibility",
                Justification = "Currently the build systems are all Windows based VMs")]
        public string? GetBrowserVersion(Browser browserName)

        {
            _path = browserName switch
            {
                Browser.Chrome => Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "",
                    "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"),
                Browser.Firefox => Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\firefox.exe", "",
                    "C:\\Program Files\\Mozilla Firefox\\firefox.exe"),
                Browser.Edge => Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\msedge.exe", "",
                    "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe"),
                Browser.InternetExplorer => Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\iexplore.exe", "",
                    "C:\\Program Files (x86)\\Internet Explorer\\iexplore.exe"),
                Browser.ChromeHeadless => Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "",
                    "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"),
                Browser.ChromeIncognito => Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "",
                    "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"),
                _ => _path
            };
            return FileVersionInfo.GetVersionInfo(_path?.ToString() ?? string.Empty).FileVersion;
        }
    }
}
