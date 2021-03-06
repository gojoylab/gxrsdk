/****************************************************************************
* Copyright 2020 Gojoy Techonology Limited. All rights reserved.
*                                                                                                                                                          
* This file is part of TinyXRSDK.                                                                                                          
*                                                                                                                                                           
* https://www.gojoylab.com       
* 
*****************************************************************************/
namespace TinyXRSDK
{
    using System.Text;
    using System.Xml;
    internal class AndroidXmlDocument : XmlDocument
    {
        protected string m_Path;
        protected XmlNamespaceManager nameSpaceManager;
        public readonly string AndroidXmlNamespace = "http://schemas.android.com/apk/res/android";
        public readonly string AndroidToolsXmlNamespace = "http://schemas.android.com/tools";

        public AndroidXmlDocument(string path)
        {
            m_Path = path;
            using (var reader = new XmlTextReader(m_Path))
            {
                reader.Read();
                Load(reader);
            }
            nameSpaceManager = new XmlNamespaceManager(NameTable);
            nameSpaceManager.AddNamespace("android", AndroidXmlNamespace);
        }

        public string Save()
        {
            return SaveAs(m_Path);
        }

        public string SaveAs(string path)
        {
            using (var writer = new XmlTextWriter(path, new UTF8Encoding(false)))
            {
                writer.Formatting = Formatting.Indented;
                Save(writer);
            }
            return path;
        }
    }

    internal class AndroidManifest : AndroidXmlDocument
    {
        private readonly XmlElement ApplicationElement;

        public AndroidManifest(string path) : base(path)
        {
            ApplicationElement = SelectSingleNode("/manifest/application") as XmlElement;
        }

        private XmlAttribute CreateAndroidAttribute(string key, string value, string name = "android")
        {
            XmlAttribute attr;
            if (name.Equals("tools"))
            {
                attr = CreateAttribute(name, key, AndroidToolsXmlNamespace);
                attr.Value = value;
            }
            else
            {
                attr = CreateAttribute(name, key, AndroidXmlNamespace);
                attr.Value = value;
            }
            return attr;
        }

        internal XmlNode GetActivityWithLaunchIntent()
        {
            return SelectSingleNode("/manifest/application/activity[intent-filter/action/@android:name='android.intent.action.MAIN' and " +
                    "intent-filter/category/@android:name='android.intent.category.LAUNCHER']", nameSpaceManager);
        }

        internal XmlNode GetActivityWithInfoIntent()
        {
            return SelectSingleNode("/manifest/application/activity[intent-filter/action/@android:name='android.intent.action.MAIN' and " +
                   "intent-filter/category/@android:name='android.intent.category.INFO']", nameSpaceManager);
        }

        internal void SetExternalStorage()
        {
            var activity = SelectSingleNode("/manifest/application");
            var rightapplicationData = SelectSingleNode("/manifest/application[@android:requestLegacyExternalStorage='true']", nameSpaceManager);

            if (rightapplicationData == null)
            {
                XmlAttribute newAttribute = CreateAndroidAttribute("requestLegacyExternalStorage", "true");
                activity.Attributes.Append(newAttribute);
            }
        }

        internal void SetCameraPermission()
        {
            var manifest = SelectSingleNode("/manifest");
            if (!manifest.InnerXml.Contains("android.permission.CAMERA"))
            {
                XmlElement child = CreateElement("uses-permission");
                manifest.AppendChild(child);
                XmlAttribute newAttribute = CreateAndroidAttribute("name", "android.permission.CAMERA");
                child.Attributes.Append(newAttribute);
            }
            else
            {
                TXRDebugger.Log("Already has the camera permission.");
            }
        }

        internal void SetBlueToothPermission()
        {
            var manifest = SelectSingleNode("/manifest");
            if (!manifest.InnerXml.Contains("android.permission.BLUETOOTH"))
            {
                XmlElement child = CreateElement("uses-permission");
                manifest.AppendChild(child);
                XmlAttribute newAttribute = CreateAndroidAttribute("name", "android.permission.BLUETOOTH");
                child.Attributes.Append(newAttribute);
                newAttribute = CreateAndroidAttribute("name", "android.permission.BLUETOOTH_ADMIN");
                child.Attributes.Append(newAttribute);
            }
            else
            {
                TXRDebugger.Log("Already has the bluetooth permission.");
            }
        }

        internal void SetAPKDisplayedOnLauncher(bool show)
        {
            var activity = GetActivityWithLaunchIntent();
            if (activity == null)
            {
                activity = GetActivityWithInfoIntent();
            }

            var intentfilter = SelectSingleNode("/manifest/application/activity/intent-filter[action/@android:name='android.intent.action.MAIN']", nameSpaceManager);
            var categoryInfo = SelectSingleNode("/manifest/application/activity/intent-filter/category[@android:name='android.intent.category.INFO']", nameSpaceManager);
            var categoryLauncher = SelectSingleNode("/manifest/application/activity/intent-filter/category[@android:name='android.intent.category.LAUNCHER']", nameSpaceManager);

            if (show)
            {
                // Add launcher category
                XmlElement newcategory = CreateElement("category");
                XmlAttribute newAttribute = CreateAndroidAttribute("name", "android.intent.category.LAUNCHER");
                newcategory.Attributes.Append(newAttribute);
                if (categoryInfo != null)
                {
                    intentfilter.ReplaceChild(newcategory, categoryInfo);
                }
                else if (categoryLauncher == null)
                {
                    intentfilter.AppendChild(newcategory);
                }
            }
            else
            {
                // Add info category
                XmlElement newcategory = CreateElement("category");
                XmlAttribute newAttribute = CreateAndroidAttribute("name", "android.intent.category.INFO");
                newcategory.Attributes.Append(newAttribute);
                newAttribute = CreateAndroidAttribute("node", "replace", "tools");
                newcategory.Attributes.Append(newAttribute);

                if (categoryLauncher != null)
                {
                    intentfilter.ReplaceChild(newcategory, categoryLauncher);
                }
                else if (categoryInfo == null)
                {
                    intentfilter.AppendChild(newcategory);
                }
            }
        }
    }
}