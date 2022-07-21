using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManagerInteraction
{
	private ConstructionManager constructionManager;
	
	public ConstructionManagerInteraction(ConstructionManager constructionManager)
	{
		this.constructionManager = constructionManager;
	}
	
	public void AddEventListenersForNode(NodeInteraction nodeInteraction)
	{
		nodeInteraction.OnEnter += HighlightNodeForHover;
	}
	
	public void AddEventListenersForTurret(TurretInteraction turretInteraction)
	{
		turretInteraction.OnEnter += HighlightNodeForSelect;
		turretInteraction.OnEnter += HighlightTurretForSelect;
		turretInteraction.OnExit += FadeNodeForSelect;
	}
	
	private void HighlightNodeForHover(NodeInteraction nodeInteraction)
	{
		if(constructionManager.IsBlueprintSelected() == false) return;
		if(constructionManager.IsNodeEmpty(nodeInteraction) == false) return;
		nodeInteraction.HighlightForHover();
	}
	
	private void HighlightNodeForSelect(TurretInteraction turretInteraction)
	{
		NodeInteraction nodeInteraction = constructionManager.GetNodeInteractionForTurret(turretInteraction);
		if(nodeInteraction == null) return;
		nodeInteraction.HighlightForSelect();
	}
	
	private void FadeNodeForSelect(TurretInteraction turretInteraction)
	{
		NodeInteraction nodeInteraction = constructionManager.GetNodeInteractionForTurret(turretInteraction);
		if(nodeInteraction == null) return;
		nodeInteraction.FadeToIdle();
		turretInteraction.Fade();
	}
	
	private void HighlightTurretForSelect(TurretInteraction turretInteraction)
	{
		turretInteraction.Highlight();
	}
}