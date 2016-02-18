using System;
using RobotController.Topography.Interface;

namespace RobotController.Navigation.Interface
{
    public interface RuleSet
    {
        void SetInteraction(InteractionElement interactionElement, Rule interaction);
        void SetInteraction(byte interactionValue, Rule interaction);
        void SetInteraction(InteractionElement interactionElement, string interaction);
        void SetInteraction(byte interactionValue, string interaction);
        Rule GetInteraction(byte interactionValue);
        Rule GetInteraction(InteractionElement interactionElement);
    }
}
