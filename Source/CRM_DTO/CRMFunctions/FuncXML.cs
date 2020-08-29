using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace CRM_DTO.CRMFunctions
{
    public class FuncXML
    {
        public static bool IsXMLValid(string _FileName)
        {
            bool bResult = true;
            try
            {
                string sPathFile = Application.StartupPath + "\\" + _FileName;
                if (!File.Exists(sPathFile))
                {
                    bResult = false;
                    throw new Exception("Không tìm thấy file cấu hình");
                }
            }
            catch (Exception ex)
            {
                bResult = false;
                throw new Exception(FuncException.GetDetailsException(ex));                
            }
            return bResult;
        }

        public static XmlDocument UpdateNodeXMLValue(XmlDocument _XMLDoc, string _TagName, string _ValueNew)
        {
            XmlNodeList node = _XMLDoc.GetElementsByTagName(_TagName);
            if (node.Count != 0)
            {
                foreach (XmlNode XMLNode in node)
                {
                    if (XMLNode.ChildNodes.Item(0) == null)
                    {
                        XMLNode.InnerText = _ValueNew;
                    }
                    else
                    {
                        XMLNode.ChildNodes.Item(0).InnerText = _ValueNew;
                    }
                }
            }
            return _XMLDoc;
        }

        public static XmlDocument UpdateNodeXMLAttribute(XmlDocument _XMLDoc, string _TagName, string _AttributeName, string NewValue)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(DTOAttributeSystem.FileConfigName);
            //XmlNode node = xmlDoc.SelectSingleNode("DATA").SelectSingleNode("SKINNAME");
            //node.Attributes["PaintStyle"].Value = _PaintStyle;
            //node.Attributes["Skin"].Value = _SkinName;
            //xmlDoc.Save(DTOAttributeSystem.FileConfigName);
            //bResult = true;
            XmlNodeList lstNode = _XMLDoc.GetElementsByTagName(_TagName);
            if (lstNode.Count != 0)
            {
                foreach (XmlNode XMLNode in lstNode)
                {
                    if (XMLNode.ChildNodes.Item(0) == null)
                    {
                        XMLNode.InnerText = NewValue;
                    }
                    else
                    {
                        XMLNode.ChildNodes.Item(0).InnerText = NewValue;
                    }
                }
            }
            return _XMLDoc;
        }

        public static string GetXMLNodeValue(XmlDocument XMLDoc, string TagName)
        {
            string strResult = "";
            XmlNodeList node = XMLDoc.GetElementsByTagName(TagName);

            if (node.Count != 0)
            {
                strResult = node.Item(0).InnerText.Trim();
            }
            else
            {
                strResult = "";
            }

            return strResult;
        }
    }
}
