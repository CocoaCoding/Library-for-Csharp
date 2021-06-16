using System.Xml;

namespace Hinzberg.Helper.Xml
{
    public static class XmlHelper
    {
        public const string ATTRIBUTE_VALUE_NAME = "Value";
        public static XmlAttribute CreateAttributeValue(string attributeName, string attributeValue, XmlDocument xmlDocument)
        {
            XmlAttribute attribute = null;

            if (xmlDocument != null)
            {
                attribute = xmlDocument.CreateAttribute(attributeName);
                attribute.Value = attributeValue;
            }
            return attribute;
        }

        public static XmlNode CreateAttributeValueNode(string nodeName, string attributeValue, XmlDocument document, string attributeName = ATTRIBUTE_VALUE_NAME)  // TODO [em] besseren Namen + summary
        {
            XmlNode attributeValueNode = null;

            if (document != null)
            {
                attributeValueNode = document.CreateElement(nodeName);
                attributeValueNode.Attributes.Append(CreateAttributeValue(attributeName, attributeValue, document));
            }
            return attributeValueNode;
        }

        static public string GetSaveAttributeText(XmlNode node, string attributeName)
        {
            string attributeText = string.Empty;
            if (node != null && node.Attributes != null)
            {
                XmlAttribute attribute = node.Attributes[attributeName];
                if (attribute != null)
                {
                    attributeText = attribute.InnerText;
                }
            }
            return attributeText;
        }
    }
}
