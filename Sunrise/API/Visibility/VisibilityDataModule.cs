using System;
using MapGeneration;

namespace Sunrise.API.Visibility;

internal class VisibilityModule : PluginModule
{
    protected override void OnEnabled()
    {
        SeedSynchronizer.OnGenerationStage += OnMapGenerationStage;
    }

    protected override void OnDisabled()
    {
        SeedSynchronizer.OnGenerationStage -= OnMapGenerationStage;
    }

    static void OnMapGenerationStage(MapGenerationPhase mapGenerationStage)
    {
        if (mapGenerationStage == MapGenerationPhase.RelativePositioningWaypoints)
        {
            foreach (Room room in Room.List)
            {
                try
                {
                    VisibilityData.Get(room);
                }
                catch (Exception e)
                {
                    Log.Error($"Failed to Get visibility data for room {room.Type} during map generation: {e}");
                }
            }
        }
    }
}