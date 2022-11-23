//----------------------------------------------------------------------------------
//
// CRUNKCINI : Objet INI
//
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FusionX;
using FusionX.Actions;
using FusionX.Application;
using FusionX.Expressions;
using FusionX.Extensions;
using FusionX.Objects;
using FusionX.RunLoop;
using FusionX.Services;
using Microsoft.Xna.Framework;



namespace RuntimeXNA.Extensions
{
    class CRunkcini : CRunExtension
    {
        public const int INI_UTF8=0x0008;
        int saveCounter = 0;
        CIni ini = null;
        short iniFlags;
        String iniName;
        String iniCurrentGroup;
        String iniCurrentItem;
#if !WINDOWS_PHONE
        Object stateobj;
#endif

        public override int getNumberOfConditions()
        {
            return 0;
        }
        void cleanName()
        {
            int pos = iniName.LastIndexOf('\\');
            if (pos < 0)
            {
                pos = iniName.LastIndexOf('/');
            }
            if (pos >= 0 && pos + 1 < iniName.Length)
            {
                iniName = iniName.Substring(pos + 1);
            }
        }
        public override bool createRunObject(CFile file, CCreateObjectInfo cob, int version)
        {
            iniFlags = file.readAShort();
            iniName = file.readAString();
            if (iniName.Length == 0)
            {
                iniName = "Default.ini";
            }
            cleanName();

            ini = new CIni(this, iniFlags);
            saveCounter = 0;
            iniCurrentGroup = "Group";
            iniCurrentItem = "Item";

            return false;
        }


        public override void destroyRunObject(bool bFast)
        {
            ini.saveIni();
        }
        public override int handleRunObject()
        {
            if (saveCounter > 0)
            {
                saveCounter--;
                if (saveCounter <= 0)
                {
                    saveCounter = 0;
                    ini.saveIni();
                }
            }
            return 0;
        }

        // Actions
        // -------------------------------------------------
        public override void action(int num, CActExtension act)
        {
            switch (num)
            {
                case 0:
                    SetCurrentGroup(act);
                    break;
                case 1:
                    SetCurrentItem(act);
                    break;
                case 2:
                    SetValue(act);
                    break;
                case 3:
                    SavePosition(act);
                    break;
                case 4:
                    LoadPosition(act);
                    break;
                case 5:
                    SetString(act);
                    break;
                case 6:
                    SetCurrentFile(act);
                    break;
                case 7:
                    SetValueItem(act);
                    break;
                case 8:
                    SetValueGroupItem(act);
                    break;
                case 9:
                    SetStringItem(act);
                    break;
                case 10:
                    SetStringGroupItem(act);
                    break;
                case 11:
                    DeleteItem(act);
                    break;
                case 12:
                    DeleteGroupItem(act);
                    break;
                case 13:
                    DeleteGroup(act);
                    break;
            }

        }
        void SetCurrentGroup(CActExtension act)
        {
            iniCurrentGroup = act.getParamExpString(rh, 0);
        }
        void SetCurrentItem(CActExtension act)
        {
            iniCurrentItem = act.getParamExpString(rh, 0);
        }
        void SetValue(CActExtension act)
        {
            int value = act.getParamExpression(rh, 0);
            String s = value.ToString();
            ini.writePrivateProfileString(iniCurrentGroup, iniCurrentItem, s, iniName);
            saveCounter = 50;
        }
        void SavePosition(CActExtension act)
        {
            CObject hoPtr = act.getParamObject(rh, 0);
            String s = hoPtr.hoX.ToString() + "," + hoPtr.hoY.ToString();
            String item = "pos."+hoPtr.hoOiList.oilName;
            ini.writePrivateProfileString(iniCurrentGroup, item, s, iniName);
            saveCounter = 50;
        }
        void LoadPosition(CActExtension act)
        {
            CObject hoPtr = act.getParamObject(rh, 0);
            String item = "pos." + hoPtr.hoOiList.oilName;
            String s = ini.getPrivateProfileString(iniCurrentGroup, item, "X", iniName);
            if (string.Compare(s, "X") != 0)
            {
                int virgule = s.IndexOf(",");
                String left = s.Substring(0, virgule);
                String right = s.Substring(virgule + 1);
                try
                {
                    hoPtr.hoX = System.Convert.ToInt32(left, 10);
                }
                catch (FormatException e)
                {
                    e.GetType();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    e.GetType();
                }
                try
                {
                    hoPtr.hoY = System.Convert.ToInt32(right, 10);
                }
                catch (FormatException e)
                {
                    e.GetType();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    e.GetType();
                }
                hoPtr.roc.rcChanged = true;
                hoPtr.roc.rcCheckCollides = true;
            }
        }
        void SetString(CActExtension act)
        {
            String s = act.getParamExpString(rh, 0);
            ini.writePrivateProfileString(iniCurrentGroup, iniCurrentItem, s, iniName);
            saveCounter = 50;
        }
        void SetCurrentFile(CActExtension act)
        {
            iniName = act.getParamExpString(rh, 0);
            cleanName();
        }
        void SetValueItem(CActExtension act)
        {
            String item = act.getParamExpString(rh, 0);
            int value = act.getParamExpression(rh, 1);
            String s = value.ToString();
            ini.writePrivateProfileString(iniCurrentGroup, item, s, iniName);
            saveCounter = 50;
        }
        void SetValueGroupItem(CActExtension act)
        {
            String group = act.getParamExpString(rh, 0);
            String item = act.getParamExpString(rh, 1);
            int value = act.getParamExpression(rh, 2);
            String s = value.ToString();
            ini.writePrivateProfileString(group, item, s, iniName);
            saveCounter = 50;
        }
        void SetStringItem(CActExtension act)
        {
            String item = act.getParamExpString(rh, 0);
            String s = act.getParamExpString(rh, 1);
            ini.writePrivateProfileString(iniCurrentGroup, item, s, iniName);
            saveCounter = 50;
        }
        void SetStringGroupItem(CActExtension act)
        {
            String group = act.getParamExpString(rh, 0);
            String item = act.getParamExpString(rh, 1);
            String s = act.getParamExpString(rh, 2);
            ini.writePrivateProfileString(group, item, s, iniName);
            saveCounter = 50;
        }
        void DeleteItem(CActExtension act)
        {
            ini.deleteItem(iniCurrentGroup, act.getParamExpString(rh, 0), iniName);
            saveCounter = 50;
        }
        void DeleteGroupItem(CActExtension act)
        {
            ini.deleteItem(act.getParamExpString(rh, 0), act.getParamExpString(rh, 1), iniName);
            saveCounter = 50;
        }
        void DeleteGroup(CActExtension act)
        {
            ini.deleteGroup(act.getParamExpString(rh, 0), iniName);
            saveCounter = 50;
        }

        // Expressions
        // --------------------------------------------
        public override CValue expression(int num)
        {
            switch (num)
            {
                case 0:
                    return GetValue();
                case 1:
                    return GetString();
                case 2:
                    return GetValueItem();
                case 3:
                    return GetValueGroupItem();
                case 4:
                    return GetStringItem();
                case 5:
                    return GetStringGroupItem();
            }
            return null;
        }
        CValue GetValue()
        {
            String s = ini.getPrivateProfileString(iniCurrentGroup, iniCurrentItem, "", iniName);
            int value=0;
            if (s.Length > 0)
            {
                try
                {
                    value = System.Convert.ToInt32(s, 10); ;
                }
                catch (FormatException e)
                {
                    e.GetType();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    e.GetType();
                }
            }
            return new CValue(value);
        }
        CValue GetString()
        {
            String s = ini.getPrivateProfileString(iniCurrentGroup, iniCurrentItem, "", iniName);
            return new CValue(s);
        }
        CValue GetValueItem()
        {
            String item = ho.getExpParam().getString();
            String s = ini.getPrivateProfileString(iniCurrentGroup, item, "", iniName);
            int value=0;
            if (s.Length > 0)
            {
                try
                {
                    value = System.Convert.ToInt32(s, 10); ;
                }
                catch (FormatException e)
                {
                    e.GetType();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    e.GetType();
                }
            }
            return new CValue(value);
        }
        CValue GetValueGroupItem()
        {
            String group = ho.getExpParam().getString();
            String item = ho.getExpParam().getString();
            String s = ini.getPrivateProfileString(group, item, "", iniName);
            int value=0;
            if (s.Length > 0)
            {
                try
                {
                    value = System.Convert.ToInt32(s, (Int32)10);
                }
                catch (FormatException e)
                {
                    e.GetType();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    e.GetType();
                }
            }
            return new CValue(value);
        }
        CValue GetStringItem()
        {
            String item = ho.getExpParam().getString();
            String s = ini.getPrivateProfileString(iniCurrentGroup, item, "", iniName);
            return new CValue(s);
        }
        CValue GetStringGroupItem()
        {
            String group = ho.getExpParam().getString();
            String item = ho.getExpParam().getString();
            String s = ini.getPrivateProfileString(group, item, "", iniName);
            return new CValue(s);
        }
    }

    class CIni
    {
        CRunkcini ini;
        CArrayList strings = null;
        String currentFileName = null;
        short flags;

        public CIni(CRunkcini i, short f)
        {
            ini=i;
            flags = f;
        }
        public void loadFromProject()
        {
            CFile cfile = null;
            CEmbeddedFile efile = ini.rh.rhApp.getEmbeddedFile(currentFileName);
            if (efile!=null)
            {
                cfile = efile.open();
            }
            if (cfile==null)
            {
                string name = currentFileName;
                int pos = name.LastIndexOf('.');
                if (pos >= 0)
                {
                    name = name.Substring(0, pos);
                }
                BinaryRead.Data iniFile = null;
                try
                {
                    iniFile = ini.rh.rhApp.content.Load<BinaryRead.Data>(name);
                }
                catch (Exception e)
                {
                    e.GetType();
                }
                if (iniFile != null)
                {
                    cfile = new CFile(iniFile.data);
                }
            }
            if (cfile!=null)
            {
                if ((flags & CRunkcini.INI_UTF8) != 0)
                    cfile.setUnicode(false);
                while (cfile.isEOF() == false)
                {
                    string currentLine = cfile.readAStringEOL();
                    if (currentLine == null)
                    {
                        break;
                    }
                    strings.add(currentLine);
                }
            }
        }
        public void loadIni(String fileName)
        {
            bool reload = true;
            if (currentFileName != null)
            {
                if (string.Compare(currentFileName, fileName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    reload = false;
                }
            }
            if (reload)
            {
                saveIni();
                strings = new CArrayList();

                currentFileName = fileName;
                //using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    //if (isf.FileExists(currentFileName))
                    if (File.Exists(currentFileName))
                    {
                        using (FileStream isfs = new FileStream(currentFileName, FileMode.Open))
                        {
                            using (StreamReader reader = new StreamReader(isfs))
                            {
                                try
                                {
                                    while (true)
                                    {
                                        string currentLine = reader.ReadLine();
                                        if (currentLine == null)
                                        {
                                            break;
                                        }
                                        strings.add(currentLine);
                                    }
                                }
                                catch (IOException e)
                                {
                                    e.GetType();
                                }
                                reader.Close();
                                reader.Dispose();
                            }
                        }
                    }
                    else
                    {
                        loadFromProject();
                    }
                    //isf.Dispose();
                } 

            }
        }
        public void saveIni()
        {
            if (strings != null && currentFileName != null)
            {
                //using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (FileStream isfs = new FileStream(currentFileName, FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(isfs))
                        {
                            try
                            {
                                int i;
                                for (i = 0; i < strings.size(); i++)
                                {
                                    writer.WriteLine((string)strings.get(i));
                                }
                            }
                            catch (IOException e)
                            {
                                e.GetType();
                            }
                            writer.Flush();
                            writer.Close();
                            writer.Dispose();
                        }
                    }
                    //isf.Dispose();
                }
            }
        }
        int findSection(String sectionName)
        {
            int l;
            String s, s2;
            for (l = 0; l < strings.size(); l++)
            {
                s = (string)strings.get(l);
                if (s[0] == '[')
                {
                    int last = s.LastIndexOf(']');
                    if (last >= 1)
                    {
                        s2 = s.Substring(1, last-1);
                        if (string.Compare(s2, sectionName, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            return l;
                        }
                    }
                }
            }
            return -1;
        }
        int findKey(int l, String keyName)
        {
            String s, s2;
            int last;
            for (; l < strings.size(); l++)
            {
                s = (string)strings.get(l);
                if (s[0] == '[')
                {
                    return -1;
                }
                last = s.IndexOf('=');
                if (last >= 0)
                {
                    s2 = s.Substring(0, last);
                    if (string.Compare(s2, keyName) == 0)
                    {
                        return l;
                    }
                }
            }
            return -1;
        }
        public String getPrivateProfileString(String sectionName, String keyName, String defaultString, String fileName)
        {
            loadIni(fileName);

            int l = findSection(sectionName);
            if (l >= 0)
            {
                l = findKey(l + 1, keyName);
                if (l >= 0)
                {
                    String s = (string)strings.get(l);
                    int last = s.IndexOf('=');

                    int start;
                    for (start = last+1; start < s.Length; start++)
                    {
                        if (s[start] != ' ')
                        {
                            break;
                        }
                    }
                    int end;
                    for (end = s.Length; end > start; end--)
                    {
                        if (s[end - 1] != ' ')
                        {
                            break;
                        }
                    }
                    if (end > start)
                    {
                        return s.Substring(start, end - start);
                    }
                }
            }
            return defaultString;
        }
        public void writePrivateProfileString(String sectionName, String keyName, String name, String fileName)
        {
            loadIni(fileName);

            String s;
            int section = findSection(sectionName);
            if (section < 0)
            {
                s = "[" + sectionName + "]";
                strings.add(s);
                s = keyName + "=" + name;
                strings.add(s);
                return;
            }

            int key = findKey(section + 1, keyName);
            if (key >= 0)
            {
                s = keyName + "=" + name;
                strings.set(key, s);
                return;
            }

            for (key = section + 1; key < strings.size(); key++)
            {
                s = (string)strings.get(key);
                if (s[0] == '[')
                {
                    s = keyName + "=" + name;
                    strings.add(key, s);
                    return;
                }
            }
            s = keyName + "=" + name;
            strings.add(s);
        }
        public void deleteItem(String group, String item, String iniName)
        {
            loadIni(iniName);

            int s = findSection(group);
            if (s >= 0)
            {
                int k = findKey(s + 1, item);
                if (k >= 0)
                {
                    strings.remove(k);
                }
            }
        }
        public void deleteGroup(String group, String iniName)
        {
            loadIni(iniName);

            int s = findSection(group);
            if (s >= 0)
            {
                strings.remove(s);
                while (true)
                {
                    if (s >= strings.size())
                    {
                        break;
                    }
                    if (((string)strings.get(s))[0] == '[')
                    {
                        break;
                    }
                    strings.remove(s);
                }
            }
        }
    }

}
