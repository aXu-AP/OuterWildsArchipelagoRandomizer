using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipEnhancements;

namespace ArchipelagoRandomizer;

internal class ShipEnhancementItems
{
    public static bool hasScoutRetrieval;
    public static bool hasAdvancedAutopilot;
    public static bool hasExtraEjectButtons;
    public static uint gravityCrystalLevel;
    public static uint shipOxygenCapacityUpgrades;
    public static uint shipFuelCapacityUpgrades;
    public static uint lessBrokenShipLevel;
    public static uint headlightsLevel;
    public static bool hasSignalShip;
    public static bool hasPortableCampfire;
    public static bool hasPortableTractorBeam;
    public static bool hasPortableFuelCanister;
    public static bool hasRepairWrench;
    public static bool hasTether;
    public static bool hasResourcePump;
    public static bool hasGravityLandingGear;
    public static bool hasThrustModulator;
    public static bool hasShipLights;
    public static bool hasDamageIndicators;
    public static bool hasSeatbelt;
    public static bool hasMedkit;
    public static bool hasHatch;
    public static bool hasShipTractorBeam;
    public static bool hasHullReinforcement;
    public static bool hasAutomaticShipOxygenIntake;
    public static bool hasMinimapMarkers;
    public static bool hasExpeditionFlag;
    public static bool hasRadio;
    public static bool hasClock;
    public static bool hasErnesto;

    public static void InitializeSettings()
    {
        ShipEnhancements.IShipEnhancements api = APRandomizer.ShipEnhancementsAPI;
        if (api == null)
            return;
        api.SetSettingsOptionVisible(SESettings.disableLandingCamera, false);
        api.SetSettingsOptionVisible(SESettings.disableScoutLaunching, false);
        api.SetSettingsOptionVisible(SESettings.disableEjectButton, false);
        api.SetSettingsOptionVisible(SESettings.disableShipSuit, false);
        api.SetSettingsOptionVisible(SESettings.disableShipOxygen, false);
        api.SetSettingsOptionVisible(SESettings.enableJetpackRefuelDrain, false);

        api.SetSettingsOptionVisible(SESettings.disableScoutRecall, false);
        api.SetSettingsOptionVisible(SESettings.enableManualScoutRecall, false);
        api.SetSettingsOptionVisible(SESettings.enableEnhancedAutopilot, false);
        api.SetSettingsOptionVisible(SESettings.extraEjectButtons, false);
        api.SetSettingsOptionVisible(SESettings.enableShipFuelTransfer, false);
        api.SetSettingsOptionVisible(SESettings.oxygenDrainMultiplier, false);
        api.SetSettingsOptionVisible(SESettings.fuelDrainMultiplier, false);
        api.SetSettingsOptionVisible(SESettings.fuelTransferMultiplier, false);
        api.SetSettingsOptionVisible(SESettings.shipDamageMultiplier, false);
        api.SetSettingsOptionVisible(SESettings.shipDamageSpeedMultiplier, false);
        api.SetSettingsOptionVisible(SESettings.randomHullDamage, false);
        api.SetSettingsOptionVisible(SESettings.randomComponentDamage, false);
        api.SetSettingsOptionVisible(SESettings.disableHeadlights, false);
        api.SetSettingsOptionVisible(SESettings.disableAutoLights, false);
        api.SetSettingsOptionVisible(SESettings.addShipSignal, false);
        api.SetSettingsOptionVisible(SESettings.addPortableCampfire, false);
        api.SetSettingsOptionVisible(SESettings.addPortableTractorBeam, false);
        api.SetSettingsOptionVisible(SESettings.addFuelCanister, false);
        api.SetSettingsOptionVisible(SESettings.repairWrenchType, false);
        api.SetSettingsOptionVisible(SESettings.addTether, false);
        api.SetSettingsOptionVisible(SESettings.addResourcePump, false);
        api.SetSettingsOptionVisible(SESettings.shipWarpCoreType, false);
        api.SetSettingsOptionVisible(SESettings.enableGravityLandingGear, false);
        api.SetSettingsOptionVisible(SESettings.enableThrustModulator, false);
        api.SetSettingsOptionVisible(SESettings.disableShipLights, false);
        api.SetSettingsOptionVisible(SESettings.disableGravityCrystal, false);
        api.SetSettingsOptionVisible(SESettings.enableRemovableGravityCrystal, false);
        api.SetSettingsOptionVisible(SESettings.disableDamageIndicators, false);
        api.SetSettingsOptionVisible(SESettings.disableSeatbelt, false);
        api.SetSettingsOptionVisible(SESettings.disableShipMedkit, false);
        api.SetSettingsOptionVisible(SESettings.disableHatch, false);
        api.SetSettingsOptionVisible(SESettings.singleUseTractorBeam, false);
        api.SetSettingsOptionVisible(SESettings.shipOxygenRefill, false);
        api.SetSettingsOptionVisible(SESettings.disableMinimapMarkers, false);
        api.SetSettingsOptionVisible(SESettings.addExpeditionFlag, false);
        api.SetSettingsOptionVisible(SESettings.addRadio, false);
        api.SetSettingsOptionVisible(SESettings.addShipClock, false);
        api.SetSettingsOptionVisible(SESettings.addErnesto, false);

        api.GetPreShipInitializeEvent().AddListener(() => { UpdateState(); });
    }

    public static void UpdateState()
    {
        IShipEnhancements api = APRandomizer.ShipEnhancementsAPI;
        if (api == null)
            return;
        // These settings have overlapping functionality with AP.
        api.SetSettingsProperty(SESettings.disableLandingCamera, false);
        api.SetSettingsProperty(SESettings.disableScoutLaunching, false);
        api.SetSettingsProperty(SESettings.disableEjectButton, false);
        api.SetSettingsProperty(SESettings.disableShipSuit, false);
        api.SetSettingsProperty(SESettings.disableShipOxygen, false);
        api.SetSettingsProperty(SESettings.enableJetpackRefuelDrain, true);

        // Item implementations.
        api.SetSettingsProperty(SESettings.disableScoutRecall, !hasScoutRetrieval);
        api.SetSettingsProperty(SESettings.enableManualScoutRecall, !hasScoutRetrieval);
        api.SetSettingsProperty(SESettings.enableEnhancedAutopilot, hasAdvancedAutopilot);
        api.SetSettingsProperty(SESettings.extraEjectButtons, hasExtraEjectButtons);
        api.SetSettingsProperty(SESettings.disableGravityCrystal, gravityCrystalLevel == 0);
        api.SetSettingsProperty(SESettings.enableRemovableGravityCrystal, gravityCrystalLevel > 1);
        api.SetSettingsProperty(SESettings.oxygenDrainMultiplier, 1500f / (shipOxygenCapacityUpgrades + 1)); // Approximately 0.5 min without upgrades.
        float fuelMultiplier = 15f / (shipFuelCapacityUpgrades * shipFuelCapacityUpgrades + 1);
        api.SetSettingsProperty(SESettings.fuelDrainMultiplier, fuelMultiplier); // Approximately 2.3 mins without upgrades.
        api.SetSettingsProperty(SESettings.fuelTransferMultiplier, fuelMultiplier / 2f);
        api.SetSettingsProperty(SESettings.addShipSignal, hasSignalShip);
        api.SetSettingsProperty(SESettings.addPortableCampfire, hasPortableCampfire);
        api.SetSettingsProperty(SESettings.addPortableTractorBeam, hasPortableTractorBeam);
        api.SetSettingsProperty(SESettings.addFuelCanister, hasPortableFuelCanister); 
        api.SetSettingsProperty(SESettings.repairWrenchType, hasRepairWrench ? "Enabled" : "Disabled");
        api.SetSettingsProperty(SESettings.addTether, hasTether);
        api.SetSettingsProperty(SESettings.addResourcePump, hasResourcePump);
        api.SetSettingsProperty(SESettings.enableGravityLandingGear, hasGravityLandingGear);
        api.SetSettingsProperty(SESettings.enableThrustModulator, hasThrustModulator);
        api.SetSettingsProperty(SESettings.disableShipLights, !hasShipLights);
        api.SetSettingsProperty(SESettings.disableHeadlights, headlightsLevel == 0);
        api.SetSettingsProperty(SESettings.disableAutoLights, headlightsLevel > 1);
        api.SetSettingsProperty(SESettings.disableDamageIndicators, !hasDamageIndicators);
        api.SetSettingsProperty(SESettings.disableSeatbelt, !hasSeatbelt);
        api.SetSettingsProperty(SESettings.disableShipMedkit, !hasMedkit);
        api.SetSettingsProperty(SESettings.disableHatch, !hasHatch);
        api.SetSettingsProperty(SESettings.singleUseTractorBeam, !hasShipTractorBeam);
        api.SetSettingsProperty(SESettings.enableShipFuelTransfer, true);
        api.SetSettingsProperty(SESettings.shipDamageMultiplier, hasHullReinforcement ? 1f : 3f);
        api.SetSettingsProperty(SESettings.shipDamageSpeedMultiplier, hasHullReinforcement ? 1f : 3f);
        api.SetSettingsProperty(SESettings.randomHullDamage, lessBrokenShipLevel < 2 ? .3f : 0f);
        api.SetSettingsProperty(SESettings.randomComponentDamage, lessBrokenShipLevel < 1 ? .1f : 0f);
        api.SetSettingsProperty(SESettings.shipOxygenRefill, hasAutomaticShipOxygenIntake);
        api.SetSettingsProperty(SESettings.disableMinimapMarkers, !hasMinimapMarkers);
        api.SetSettingsProperty(SESettings.addExpeditionFlag, hasExpeditionFlag);
        api.SetSettingsProperty(SESettings.addRadio, hasRadio);
        api.SetSettingsProperty(SESettings.addShipClock, hasClock);
        api.SetSettingsProperty(SESettings.addErnesto, hasErnesto);

    }
}

