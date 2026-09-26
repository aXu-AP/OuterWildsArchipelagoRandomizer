using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipEnhancements;

namespace ArchipelagoRandomizer;

internal class ShipEnhancementItems
{
    private class ISEItem
    {
        public Func<long, string> hudDescription;
        public Action<IShipEnhancements> onInit;
        public Action<IShipEnhancements, long> onApply;
    }

    private static Dictionary<Item, ISEItem> items = new()
    {
        {
            Item.ScoutRetrieval, new ISEItem
            {
                hudDescription = (count) => "SCOUT RETRIEVAL WILL BE FIXED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableScoutLaunching, false);
                    api.SetSettingsOptionVisible(SESettings.enableManualScoutRecall, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableScoutRecall, count == 0);
                    api.SetSettingsProperty(SESettings.enableManualScoutRecall, count == 0);
                },
            }
        },
        {
            Item.AdvancedAutopilot, new ISEItem
            {
                hudDescription = (count) => "AUTOPILOT PANEL WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.enableEnhancedAutopilot, false);
                    api.SetSettingsOptionVisible(SESettings.enableAutoAlign, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.enableEnhancedAutopilot, count > 0);
                    api.SetSettingsProperty(SESettings.enableAutoAlign, count > 0);
                },
            }
        },
        {
            Item.ExtraEjectButtons, new ISEItem
            {
                hudDescription = (count) => "EXTRA EJECT BUTTONS WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.extraEjectButtons, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.extraEjectButtons, count > 0);
                },
            }
        },
        {
            Item.ShipFuelCapacityUpgrade, new ISEItem
            {
                hudDescription = (count) => "BIGGER FUEL TANK WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.enableJetpackRefuelDrain, false);
                    api.SetSettingsOptionVisible(SESettings.fuelDrainMultiplier, false);
                    api.SetSettingsOptionVisible(SESettings.enableShipFuelTransfer, false);
                    api.SetSettingsOptionVisible(SESettings.fuelTransferMultiplier, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.enableJetpackRefuelDrain, true);
                    api.SetSettingsProperty(SESettings.enableShipFuelTransfer, true);
                    float fuelMultiplier = 15f / (count * count + 1);
                    api.SetSettingsProperty(SESettings.fuelDrainMultiplier, fuelMultiplier); // Approximately 2.3 mins without upgrades.
                    api.SetSettingsProperty(SESettings.fuelTransferMultiplier, fuelMultiplier / 2f);
                },
            }
        },
        {
            Item.ShipOxygenCapacityUpgrade, new ISEItem
            {
                hudDescription = (count) => "BIGGER O2 TANK WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableShipOxygen, false);
                    api.SetSettingsOptionVisible(SESettings.oxygenDrainMultiplier, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableShipOxygen, false);
                    api.SetSettingsProperty(SESettings.oxygenDrainMultiplier, 1500f / (count + 1)); // Approximately 0.5 min without upgrades.
                },
            }
        },
        {
            Item.HullReinforcement, new ISEItem
            {
                hudDescription = (count) => "BETTER SHIP HULL WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.shipDamageMultiplier, false);
                    api.SetSettingsOptionVisible(SESettings.shipDamageSpeedMultiplier, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.shipDamageMultiplier, (count > 0) ? 1f : 4f);
                    api.SetSettingsProperty(SESettings.shipDamageSpeedMultiplier, (count > 0) ? 1f : .4f);
                },
            }
        },
        {
            Item.LessBrokenShip, new ISEItem
            {
                hudDescription = (count) => count == 1 ? "SHIP COMPONENTS WILL BE FIXED NEXT LOOP" : "SHIP HULL WILL BE FIXED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.randomComponentDamage, false);
                    api.SetSettingsOptionVisible(SESettings.randomHullDamage, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.randomComponentDamage, count < 1 ? .1f : 0f);
                    api.SetSettingsProperty(SESettings.randomHullDamage, count < 2 ? .4f : 0f);
                },
            }
        },
        {
            Item.Headlights, new ISEItem
            {
                hudDescription = (count) => count == 1 ? "HEADLIGHTS WILL BE INSTALLED NEXT LOOP" : "SHIP LIGHTS WILL BE PERMANENTLY ENABLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableHeadlights, false);
                    api.SetSettingsOptionVisible(SESettings.disableAutoLights, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableHeadlights, count == 0);
                    api.SetSettingsProperty(SESettings.disableAutoLights, count > 1);
                },
            }
        },
        {
            Item.GravityCrystal, new ISEItem
            {
                hudDescription = (count) => count == 1 ? "GRAVITY CRYSTAL WILL BE FIXED NEXT LOOP" : "GRAVITY CRYSTAL WILL BE REMOVABLE NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableGravityCrystal, false);
                    api.SetSettingsOptionVisible(SESettings.enableRemovableGravityCrystal, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableGravityCrystal, count == 0);
                    api.SetSettingsProperty(SESettings.enableRemovableGravityCrystal, count > 1);
                },
            }
        },
        {
            Item.ShipLights, new ISEItem
            {
                hudDescription = (count) => "SHIP INTERIOR LIGHTS WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableShipLights, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableShipLights, count == 0);
                },
            }
        },
        {
            Item.Seatbelt, new ISEItem
            {
                hudDescription = (count) => "SEATBELT WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableSeatbelt, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableSeatbelt, count == 0);
                },
            }
        },
        {
            Item.Medkit, new ISEItem
            {
                hudDescription = (count) => "MEDKIT WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableShipMedkit, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableShipMedkit, count == 0);
                },
            }
        },
        {
            Item.DamageIndicators, new ISEItem
            {
                hudDescription = (count) => "DAMAGE INDICATORS WILL BE FIXED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableDamageIndicators, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableDamageIndicators, count == 0);
                },
            }
        },
        {
            Item.SignalShip, new ISEItem
            {
                hudDescription = (count) => "SHIP REMOTE SIGNAL WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addShipSignal, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addShipSignal, count > 0);
                },
            }
        },
        {
            Item.PortableCampfire, new ISEItem
            {
                hudDescription = (count) => "PORTABLE CAMPFIRE WILL BE ADDED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addPortableCampfire, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addPortableCampfire, count > 0);
                },
            }
        },
        {
            Item.PortableTractorBeam, new ISEItem
            {
                hudDescription = (count) => "PORTABLE TRACTOR BEAM WILL BE ADDED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addPortableTractorBeam, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addPortableTractorBeam, count > 0);
                },
            }
        },
        {
            Item.PortableFuelCanister, new ISEItem
            {
                hudDescription = (count) => "PORTABLE FUEL CANISTER WILL BE ADDED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addFuelCanister, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addFuelCanister, count > 0);
                },
            }
        },
        {
            Item.RepairWrench, new ISEItem
            {
                hudDescription = (count) => "REPAIR WRENCH WILL BE ADDED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.repairWrenchType, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.repairWrenchType, count > 0 ? "Enabled" : "Disabled");
                },
            }
        },
        {
            Item.Tether, new ISEItem
            {
                hudDescription = (count) => "TETHER HOOKS WILL BE ADDED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addTether, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addTether, count > 0);
                },
            }
        },
        {
            Item.ResourcePump, new ISEItem
            {
                hudDescription = (count) => "RESOURCE PUMP WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addResourcePump, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addResourcePump, count > 0);
                },
            }
        },
        {
            Item.GravityLandingGear, new ISEItem
            {
                hudDescription = (count) => "GRAVITY LANDING GEAR WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.enableGravityLandingGear, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.enableGravityLandingGear, count > 0);
                },
            }
        },
        {
            Item.ThrustModulator, new ISEItem
            {
                hudDescription = (count) => "THRUST MODULATOR WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.enableThrustModulator, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.enableThrustModulator, count > 0);
                },
            }
        },
        {
            Item.Hatch, new ISEItem
            {
                hudDescription = (count) => "HATCH WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableHatch, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableHatch, count == 0);
                },
            }
        },
        {
            Item.ShipTractorBeam, new ISEItem
            {
                hudDescription = (count) => "TRACTOR BEAM WILL BE MORE RELIABLE NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.singleUseTractorBeam, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.singleUseTractorBeam, count == 0);
                },
            }
        },
        {
            Item.AutomaticShipOxygenIntake, new ISEItem
            {
                hudDescription = (count) => "AUTOMATIC O2 INTAKE WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.shipOxygenRefill, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.shipOxygenRefill, count > 0);
                },
            }
        },
        {
            Item.MinimapMarkers, new ISEItem
            {
                hudDescription = (count) => "MINIMAP MARKERS WILL BE VISIBLE NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.disableMinimapMarkers, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.disableMinimapMarkers, count == 0);
                },
            }
        },
        {
            Item.ExpeditionFlag, new ISEItem
            {
                hudDescription = (count) => "EXPEDITION FLAG WILL BE ADDED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addExpeditionFlag, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addExpeditionFlag, count > 0);
                },
            }
        },
        {
            Item.Radio, new ISEItem
            {
                hudDescription = (count) => "RADIO WILL BE ADDED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addRadio, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addRadio, count > 0);
                },
            }
        },
        {
            Item.Clock, new ISEItem
            {
                hudDescription = (count) => "CLOCK WILL BE INSTALLED NEXT LOOP",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addShipClock, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addShipClock, count > 0);
                },
            }
        },
        {
            Item.Ernesto, new ISEItem
            {
                hudDescription = (count) => "INVITE SENT TO ERNESTO",
                onInit = (api) => {
                    api.SetSettingsOptionVisible(SESettings.addErnesto, false);
                },
                onApply = (api, count) => {
                    api.SetSettingsProperty(SESettings.addErnesto, count > 0);
                },
            }
        },
    };

    private static Dictionary<Item, long> itemCounts = new();
    public static List<Item> SEItems = new();
    public static void InitializeSettings()
    {
        IShipEnhancements api = APRandomizer.ShipEnhancementsAPI;
        if (api == null)
            return;

        foreach (var item in items.Keys)
        {
            SEItems.Add(item);
            // TODO: Add only if enabled in yaml.
            items[item].onInit(api);
            itemCounts.Add(item, 0);
        }
        api.SetSettingsOptionVisible(SESettings.disableLandingCamera, false);
        api.SetSettingsOptionVisible(SESettings.disableScoutLaunching, false);
        api.SetSettingsOptionVisible(SESettings.disableEjectButton, false);
        api.SetSettingsOptionVisible(SESettings.disableShipSuit, false);
        api.SetSettingsOptionVisible(SESettings.shipWarpCoreType, false);


                    // Item implementations.


        api.GetPreShipInitializeEvent().AddListener(() => { UpdateState(); });
    }

    public static void SetItemCount(Item item, long count)
    {
        if (itemCounts.ContainsKey(item))
        {
            itemCounts[item] = count;
            if (count > 0)
            {
                var nd = new NotificationData(NotificationTarget.Player, items[item].hudDescription(count), 10);
                NotificationManager.SharedInstance.PostNotification(nd, false);
            }
        }
        else
        {
            APRandomizer.InGameAPConsole?.AddText($"Could not activate item: {item}. Item is disabled in yaml!");
        }
    }

    public static void UpdateState()
    {
        IShipEnhancements api = APRandomizer.ShipEnhancementsAPI;
        if (api == null)
            return;
        // Iterate itemCounts as it contains only enabled items.
        foreach (var itemCount in itemCounts)
        {
            items[itemCount.Key].onApply(api, itemCount.Value);
        }
        // These settings have overlapping functionality with AP.
        api.SetSettingsProperty(SESettings.disableLandingCamera, false);
        api.SetSettingsProperty(SESettings.disableScoutLaunching, false);
        api.SetSettingsProperty(SESettings.disableEjectButton, false);
        api.SetSettingsProperty(SESettings.disableShipSuit, false);
        api.SetSettingsProperty(SESettings.shipWarpCoreType, "disabled");


    }
}

