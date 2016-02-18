using System;
using System.Collections.Generic;
using RobotController.Navigation.Interface;
using RobotController.Topography.Implementation;
using RobotController.Topography.Interface;

namespace RobotController.Navigation.Implementation
{
    //Short for Acceptance Tile Traversal Manager
    public class AcceptanceTTManager : Interface.RuleSet
    {
        private Dictionary<InteractionElement, Rule> navigationMap;

        public AcceptanceTTManager()
        {
            navigationMap = new Dictionary<InteractionElement, Rule>();
        }

        public Rule GetInteraction(InteractionElement interactionElement)
        {
            Rule interaction;

            if(navigationMap.TryGetValue(interactionElement, out interaction))
            {
                return interaction;
            }

            return null;
        }

        public Rule GetInteraction(byte interactionValue)
        {
            Rule interaction;

            if (navigationMap.TryGetValue(new TeleportTile(interactionValue), out interaction))
            {
                return interaction;
            }

            return null;
        }

        public void SetInteraction(byte interactionValue, Rule interaction)
        {
            Tile interactionElement = new TeleportTile(interactionValue);
            navigationMap.Add(interactionElement, interaction);
        }

        public void SetInteraction(InteractionElement interactionElement, string interaction)
        {
            TileTraversal interactionRule = new TileTraversal(interaction);
            navigationMap.Add(interactionElement, interactionRule);
        }

        public void SetInteraction(InteractionElement interactionElement, Rule interaction)
        {
            navigationMap.Add(interactionElement, interaction);
        }

        public void SetInteraction(byte interactionValue, string interaction)
        {
            Tile interactionElement = new TeleportTile(interactionValue);
            TileTraversal interactionRule = new TileTraversal(interaction);
            navigationMap.Add(interactionElement, interactionRule);
        }
    }
}
