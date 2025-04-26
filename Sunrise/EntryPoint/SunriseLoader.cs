using Sunrise.API.Backtracking;
using Sunrise.API.Visibility;
using Sunrise.Features.AntiWallhack;
using Sunrise.Features.DoorInteractionValidation;
using Sunrise.Features.PickupEspClutter;
using Sunrise.Features.PickupValidation;
using Sunrise.Features.ServersideBacktrack;
using Sunrise.Features.ServersideTeslaDamage;

namespace Sunrise.EntryPoint;

public class SunriseLoader : PluginModule
{
    protected override List<PluginModule> SubModules { get; } =
    [
        // API
        new BacktrackingModule(),
        new AntiWallhackModule(),
        new VisibilityModule(),

        // Features
        new PickupValidationModule(),
        new ServersideTeslaDamageModule(),
        new AntiDoorManipulatorModule(),
        // new PhantomPickupsModule(), // BUG: Flickering
    ];
}