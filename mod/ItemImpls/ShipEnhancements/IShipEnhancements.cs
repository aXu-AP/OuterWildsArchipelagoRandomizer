using System;
using UnityEngine;
using UnityEngine.Events;

namespace ShipEnhancements;

public interface IShipEnhancements
{
    /// <summary>
    /// Gets the in-game value of the specified config setting.
    /// </summary>
    /// <param name="configName">The name of the setting. It should be in lower camel case.</param>
    /// <returns>The current in-game value of the config setting, not the value as seen in the config.</returns>
    public object GetSettingsProperty(string configName);

    /// <summary>
    /// Sets the in-game value of the specified config setting. Doesn't affect the displayed value in the mod config.
    /// </summary>
    /// <param name="configName">The name of the setting. It should be in lower camel case.</param>
    /// <param name="value">The value to assign to the setting. This will reset every time the scene loads.</param>
    public void SetSettingsProperty(string configName, object value);

    /// <summary>
    /// Sets the visibility of a config setting in the mod settings menu. This resets when the game closes.
    /// </summary>
    /// <param name="configName">The name of the setting. It should be in lower camel case.</param>
    /// <param name="visible">Should this setting be visible in the mod settings menu?</param>
    /// <param name="forceRefresh">Set this to true if the mod settings menu is open when you call the method.</param>
    public void SetSettingsOptionVisible(string configName, bool visible, bool forceRefresh = false);

    /// <summary>
    /// Hides all of the config settings in the mod settings menu. This resets when the game closes.
    /// </summary>
    /// <param name="forceRefresh">Set this to true if the mod settings menu is open when you call the method.</param>
    public void HideAllSettings(bool forceRefresh = false);

    /// <summary>
    /// Shows all of the config settings in the mod settings menu. This resets when the game closes.
    /// </summary>
    /// <param name="forceRefresh">Set this to true if the mod settings menu is open when you call the method.</param>
    public void ShowAllSettings(bool forceRefresh = false);

    /// <summary>
    /// Gets the event that is invoked before Ship Enhancements makes any changes to the ship.
    /// </summary>
    /// <returns>The UnityEvent event that will be invoked.</returns>
    public UnityEvent GetPreShipInitializeEvent();

    /// <summary>
    /// Gets the event that is invoked after Ship Enhancements finishes making changes to the ship.
    /// </summary>
    /// <returns>The UnityEvent event that will be invoked</returns>
    public UnityEvent GetPostShipInitializeEvent();
}

public static class SESettings
{
    public static readonly string disableGravityCrystal = "disableGravityCrystal";
    public static readonly string disableEjectButton = "disableEjectButton";
    public static readonly string disableHeadlights = "disableHeadlights";
    public static readonly string disableLandingCamera = "disableLandingCamera";
    public static readonly string disableShipLights = "disableShipLights";
    public static readonly string disableShipOxygen = "disableShipOxygen";
    public static readonly string oxygenDrainMultiplier = "oxygenDrainMultiplier";
    public static readonly string fuelDrainMultiplier = "fuelDrainMultiplier";
    public static readonly string shipDamageMultiplier = "shipDamageMultiplier";
    public static readonly string shipDamageSpeedMultiplier = "shipDamageSpeedMultiplier";
    public static readonly string shipOxygenRefill = "shipOxygenRefill";
    public static readonly string enableGravityLandingGear = "enableGravityLandingGear";
    public static readonly string disableAirAutoRoll = "disableAirAutoRoll";
    public static readonly string disableWaterAutoRoll = "disableWaterAutoRoll";
    public static readonly string enableThrustModulator = "enableThrustModulator";
    public static readonly string temperatureZonesAmount = "temperatureZonesAmount";
    public static readonly string enableShipFuelTransfer = "enableShipFuelTransfer";
    public static readonly string enableJetpackRefuelDrain = "enableJetpackRefuelDrain";
    public static readonly string disableReferenceFrame = "disableReferenceFrame";
    public static readonly string disableMapMarkers = "disableMapMarkers";
    public static readonly string gravityMultiplier = "gravityMultiplier";
    public static readonly string fuelTransferMultiplier = "fuelTransferMultiplier";
    public static readonly string oxygenRefillMultiplier = "oxygenRefillMultiplier";
    public static readonly string temperatureResistanceMultiplier = "temperatureResistanceMultiplier";
    public static readonly string enableAutoHatch = "enableAutoHatch";
    public static readonly string oxygenTankDrainMultiplier = "oxygenTankDrainMultiplier";
    public static readonly string fuelTankDrainMultiplier = "fuelTankDrainMultiplier";
    public static readonly string atmosphereAngularDragMultiplier = "atmosphereAngularDragMultiplier";
    public static readonly string spaceAngularDragMultiplier = "spaceAngularDragMultiplier";
    public static readonly string disableRotationSpeedLimit = "disableRotationSpeedLimit";
    public static readonly string gravityDirection = "gravityDirection";
    public static readonly string disableScoutRecall = "disableScoutRecall";
    public static readonly string disableScoutLaunching = "disableScoutLaunching";
    public static readonly string enableScoutLauncherComponent = "enableScoutLauncherComponent";
    public static readonly string enableManualScoutRecall = "enableManualScoutRecall";
    public static readonly string enableShipItemPlacement = "enableShipItemPlacement";
    public static readonly string addPortableCampfire = "addPortableCampfire";
    public static readonly string keepHelmetOn = "keepHelmetOn";
    public static readonly string showWarningNotifications = "showWarningNotifications";
    public static readonly string shipExplosionMultiplier = "shipExplosionMultiplier";
    public static readonly string shipBounciness = "shipBounciness";
    public static readonly string enableEnhancedAutopilot = "enableEnhancedAutopilot";
    public static readonly string shipInputLatency = "shipInputLatency";
    public static readonly string addEngineSwitch = "addEngineSwitch";
    public static readonly string idleFuelConsumptionMultiplier = "idleFuelConsumptionMultiplier";
    public static readonly string shipLightColorOptions = "shipLightColorOptions";
    public static readonly string shipLightColor1 = "shipLightColor1";
    public static readonly string shipLightColor2 = "shipLightColor2";
    public static readonly string shipLightColor3 = "shipLightColor3";
    public static readonly string shipLightColorBlend = "shipLightColorBlend";
    public static readonly string hotThrusters = "hotThrusters";
    public static readonly string extraNoise = "extraNoise";
    public static readonly string interiorHullColorOptions = "interiorHullColorOptions";
    public static readonly string interiorHullColor1 = "interiorHullColor1";
    public static readonly string interiorHullColor2 = "interiorHullColor2";
    public static readonly string interiorHullColor3 = "interiorHullColor3";
    public static readonly string interiorHullColorBlend = "interiorHullColorBlend";
    public static readonly string exteriorHullColorOptions = "exteriorHullColorOptions";
    public static readonly string exteriorHullColor1 = "exteriorHullColor1";
    public static readonly string exteriorHullColor2 = "exteriorHullColor2";
    public static readonly string exteriorHullColor3 = "exteriorHullColor3";
    public static readonly string exteriorHullColorBlend = "exteriorHullColorBlend";
    public static readonly string addTether = "addTether";
    public static readonly string disableDamageIndicators = "disableDamageIndicators";
    public static readonly string addShipSignal = "addShipSignal";
    public static readonly string reactorLifetimeMultiplier = "reactorLifetimeMultiplier";
    public static readonly string shipFriction = "shipFriction";
    public static readonly string enableSignalscopeComponent = "enableSignalscopeComponent";
    public static readonly string rustLevel = "rustLevel";
    public static readonly string dirtAccumulationTime = "dirtAccumulationTime";
    public static readonly string thrusterColorOptions = "thrusterColorOptions";
    public static readonly string thrusterColor1 = "thrusterColor1";
    public static readonly string thrusterColor2 = "thrusterColor2";
    public static readonly string thrusterColor3 = "thrusterColor3";
    public static readonly string thrusterColorBlend = "thrusterColorBlend";
    public static readonly string disableSeatbelt = "disableSeatbelt";
    public static readonly string addPortableTractorBeam = "addPortableTractorBeam";
    public static readonly string disableShipSuit = "disableShipSuit";
    public static readonly string indicatorColorOptions = "indicatorColorOptions";
    public static readonly string indicatorColor1 = "indicatorColor1";
    public static readonly string indicatorColor2 = "indicatorColor2";
    public static readonly string indicatorColor3 = "indicatorColor3";
    public static readonly string indicatorColorBlend = "indicatorColorBlend";
    public static readonly string disableAutoLights = "disableAutoLights";
    public static readonly string addExpeditionFlag = "addExpeditionFlag";
    public static readonly string addFuelCanister = "addFuelCanister";
    public static readonly string cycloneChaos = "cycloneChaos";
    public static readonly string moreExplosionDamage = "moreExplosionDamage";
    public static readonly string singleUseTractorBeam = "singleUseTractorBeam";
    public static readonly string disableThrusters = "disableThrusters";
    public static readonly string maxDirtAccumulation = "maxDirtAccumulation";
    public static readonly string shipWarpCoreType = "shipWarpCoreType";
    public static readonly string repairTimeMultiplier = "repairTimeMultiplier";
    public static readonly string airDragMultiplier = "airDragMultiplier";
    public static readonly string addShipClock = "addShipClock";
    public static readonly string enableStunDamage = "enableStunDamage";
    public static readonly string enableRepairConfirmation = "enableRepairConfirmation";
    public static readonly string enableRemovableGravityCrystal = "enableRemovableGravityCrystal";
    public static readonly string randomHullDamage = "randomHullDamage";
    public static readonly string randomComponentDamage = "randomComponentDamage";
    public static readonly string enableFragileShip = "enableFragileShip";
    public static readonly string addErnesto = "addErnesto";
    public static readonly string repairLimit = "repairLimit";
    public static readonly string extraEjectButtons = "extraEjectButtons";
    public static readonly string preventSystemFailure = "preventSystemFailure";
    public static readonly string addShipCurtain = "addShipCurtain";
    public static readonly string repairWrenchType = "repairWrenchType";
    public static readonly string funnySounds = "funnySounds";
    public static readonly string alwaysAllowLockOn = "alwaysAllowLockOn";
    public static readonly string disableShipMedkit = "disableShipMedkit";
    public static readonly string addRadio = "addRadio";
    public static readonly string disableFluidPrevention = "disableFluidPrevention";
    public static readonly string disableHazardPrevention = "disableHazardPrevention";
    public static readonly string prolongDigestion = "prolongDigestion";
    public static readonly string unlimitedItems = "unlimitedItems";
    public static readonly string noiseMultiplier = "noiseMultiplier";
    public static readonly string waterDamage = "waterDamage";
    public static readonly string sandDamage = "sandDamage";
    public static readonly string disableMinimapMarkers = "disableMinimapMarkers";
    public static readonly string scoutPhotoMode = "scoutPhotoMode";
    public static readonly string enableAutoAlign = "enableAutoAlign";
    public static readonly string shipHornType = "shipHornType";
    public static readonly string randomIterations = "randomIterations";
    public static readonly string randomDifficulty = "randomDifficulty";
    public static readonly string disableHatch = "disableHatch";
    public static readonly string splitLockOn = "splitLockOn";
    public static readonly string enableColorBlending = "enableColorBlending";
    public static readonly string enableShipTemperature = "enableShipTemperature";
    public static readonly string temperatureDifficulty = "temperatureDifficulty";
    public static readonly string passiveTemperatureGain = "passiveTemperatureGain";
    public static readonly string addResourcePump = "addResourcePump";
    public static readonly string addWaterTank = "addWaterTank";
    public static readonly string waterDrainMultiplier = "waterDrainMultiplier";
    public static readonly string addWaterCooling = "addWaterCooling";
    public static readonly string enableReactorOverload = "enableReactorOverload";
    public static readonly string buttonsRequireFlightChair = "buttonsRequireFlightChair";
    public static readonly string enableQuantumShip = "enableQuantumShip";
    public static readonly string persistentShipState = "persistentShipState";
    public static readonly string enableGasLeak = "enableGasLeak";
}
