using System.IO;
using System.Xml;
using RobotController.Navigation.Implementation;

namespace RobotController.Utils
{
    public static class XmlRuleParser
    {
        public static void LoadRules(string fileName, ref AcceptanceTTManager ruleSet)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            var ruleSetNode = document.SelectSingleNode("/ruleset");

            foreach(XmlNode node in ruleSetNode)
            {
                string name = node.Attributes["name"]?.InnerText;
                byte interactionValue = 0;
                interactionValue = byte.Parse(node.InnerText);

                ruleSet.SetInteraction(interactionValue, name);
            }
        }
    }
}
