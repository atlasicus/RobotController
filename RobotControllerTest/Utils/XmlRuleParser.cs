using System.Xml;

namespace RobotControllerTest.Utils
{
    class XmlRuleParser
    {
        public static void LoadRules(string fileName, ref Mocks.Navigation.MockRuleSet ruleSet)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            var ruleSetNode = document.SelectSingleNode("/ruleset");

            foreach (XmlNode node in ruleSetNode)
            {
                string name = node.Attributes["name"]?.InnerText;
                byte interactionValue = 0;
                interactionValue = byte.Parse(node.InnerText);

                ruleSet.SetInteraction(interactionValue, name);
            }
        }
    }
}
