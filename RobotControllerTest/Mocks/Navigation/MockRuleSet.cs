using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotController.Navigation.Interface;
using RobotController.Topography.Interface;
using RobotControllerTest.Mocks.Topography;

namespace RobotControllerTest.Mocks.Navigation
{
    public class MockRuleSet : RobotController.Navigation.Interface.RuleSet
    {
        private Dictionary<InteractionElement, Rule> navigationMap;

        public MockRuleSet()
        {
            navigationMap = new Dictionary<InteractionElement, Rule>();
        }

        public Rule GetInteraction(InteractionElement interactionElement)
        {
            Rule interaction;

            if (navigationMap.TryGetValue(interactionElement as MockInteractionElement, out interaction))
            {
                return interaction;
            }

            return null;
        }

        public Rule GetInteraction(byte interactionValue)
        {
            Rule interaction;

            if (navigationMap.TryGetValue(new MockInteractionElement(interactionValue), out interaction))
            {
                return interaction;
            }

            return null;
        }

        public void SetInteraction(InteractionElement interactionElement, string interaction)
        {
            throw new NotImplementedException();
        }

        public void SetInteraction(byte interactionValue, string interaction)
        {
            MockInteractionElement interactionElement = new MockInteractionElement(interactionValue);
            MockRule interactionRule = new MockRule(interaction);
            navigationMap.Add(interactionElement, interactionRule);
        }

        public void SetInteraction(byte interactionValue, Rule interaction)
        {
            MockInteractionElement interactionElement = new MockInteractionElement(interactionValue);
            navigationMap.Add(interactionElement, interaction);
        }

        public void SetInteraction(InteractionElement interactionElement, Rule interaction)
        {
            navigationMap.Add(interactionElement, interaction);
        }
    }
}
