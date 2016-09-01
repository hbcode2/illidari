﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx;
using Styx.Common;
using Styx.Helpers;
using Styx.WoWInternals.WoWObjects;

namespace Illidari.Core.IllidariSettings
{
    public class IllidariSettings : Settings
    {
        /// <summary>
        /// Creating a new instance will either create a default settings file or pull in the existing settings file.
        /// </summary>
        public IllidariSettings()
            : base(System.IO.Path.Combine(CharacterSettingsDirectory, Main.CRName + "Routine.xml"))
        {

        }

        #region General
        [Setting, DefaultValue(false)]
        public bool GeneralDebug { get; set; }

        #region Mobility
        [Setting, DefaultValue(true)]
        public bool GeneralFacing { get; set; }
        [Setting, DefaultValue(true)]
        public bool GeneralMovement { get; set; }
        [Setting, DefaultValue(true)]
        public bool GeneralTargeting { get; set; }
        #endregion

        #endregion

        #region Havoc

        #region Potion / Flask
        [Setting, DefaultValue(40)]
        public int HavocHealthPotionHp { get; set; }
        [Setting, DefaultValue("")]
        public string HavocHealthPotionListSetting { get; set; }
        
        public List<uint> HavocHealthPotionList
        {
            get
            {
                List<uint> hpList = new List<uint>();
                if (string.IsNullOrEmpty(HavocHealthPotionListSetting)) { return hpList; }
                string[] potions = HavocHealthPotionListSetting.Split('|');
                foreach (var item in potions)
                {
                    if (string.IsNullOrEmpty(item) || item.SafeGetInt() == 0) { continue; }
                    hpList.Add(item.SafeGetInt());
                }
                return hpList;
            }
        }

        [Setting, DefaultValue(false)]
        public bool HavocUseAgilityFlask { get; set; }
        [Setting, DefaultValue(CooldownTypes.Manual)]
        public CooldownTypes HavocUseAgilityPotionCooldown { get; set; }
        #endregion

        #region Blur Settings
        [Setting, DefaultValue(60)]
        public int HavocBlurHp { get; set; }
        [Setting, DefaultValue("OR")]
        public string HavocBlurOperator { get; set; }
        [Setting, DefaultValue(4)]
        public int HavocBlurUnits { get; set; }
        #endregion

        #region Darkness Settings
        [Setting, DefaultValue(50)]
        public int HavocDarknessHp { get; set; }
        [Setting, DefaultValue(5)]
        public int HavocDarknessUnits { get; set; }
        [Setting, DefaultValue("OR")]
        public string HavocDarknessOperator { get; set; }
        #endregion

        #region Chaos Nova Settings
        [Setting, DefaultValue(40)]
        public int HavocChaosNovaHp { get; set; }
        [Setting, DefaultValue("OR")]
        public string HavocChaosNovaOperator { get; set; }
        [Setting, DefaultValue(3)]
        public int HavocChaosNovaUnits { get; set; }
        #endregion

        #region Fel Rush / Vengeful Retreat
        [Setting, DefaultValue(true)]
        public bool HavocFelRushOnPull { get; set; }
        [Setting, DefaultValue(true)]
        public bool HavocFelRushSingleTarget { get; set; }
        [Setting, DefaultValue(true)]
        public bool HavocFelRushAoe { get; set; }
        [Setting, DefaultValue(true)]
        public bool HavocVengefulReatreatSingleTarget { get; set; }
        [Setting, DefaultValue(true)]
        public bool HavocVengefulReatreatAoe { get; set; }
        #endregion

        #region DPS cooldowns
        [Setting, DefaultValue(CooldownTypes.Cooldown)]
        public CooldownTypes HavocUseMetamorphosisCooldown { get; set; }
        #endregion

        #endregion

        #region Vengeance
        [Setting, DefaultValue(false)]
        public bool VengeanceAllowTaunt { get; set; }

        #region Mitigation
        [Setting, DefaultValue(true)]
        public bool VengeanceAllowDemonSpikes { get; set; }
        [Setting, DefaultValue(90)]
        public int VengeanceDemonSpikesHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool VengeanceEmpowerWards { get; set; }

        [Setting, DefaultValue(true)]
        public bool VengeanceAllowSoulCleave { get; set; }
        [Setting, DefaultValue(80)]
        public int VengeanceSoulCleaveHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool VengeanceAllowFieryBrand { get; set; }
        [Setting, DefaultValue(70)]
        public int VengeanceFieryBrandHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool VengeanceAllowMetamorphosis { get; set; }
        [Setting, DefaultValue(60)]
        public int VengeanceMetamorphosisHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool VengeanceAllowSoulBarrier { get; set; }
        [Setting, DefaultValue(40)]
        public int VengeanceSoulBarrierHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool VengeanceAllowSoulCarver { get; set; }
        [Setting, DefaultValue(65)]
        public int VengeanceSoulCarverHp { get; set; }

        #endregion

        #region Combat
        [Setting, DefaultValue(true)]
        public bool VengeanceCombatAllowSoulCleave { get; set; }
        [Setting, DefaultValue(80)]
        public int VengeanceCombatSoulCleavePain { get; set; }

        [Setting, DefaultValue(false)]
        public bool VengeancePreferPullWithFelblade { get; set; }

        #endregion  

        [Setting, DefaultValue(false)]
        public bool VengeanceAllowInterruptConsumeMagic { get; set; }
        [Setting, DefaultValue(false)]
        public bool VengeanceAllowInterruptSigilOfSilence { get; set; }
        [Setting, DefaultValue(false)]
        public bool VengeanceAllowInterruptSigilOfMisery { get; set; }
        [Setting, DefaultValue(false)]
        public bool VengeanceAllowStunSigilOfMisery { get; set; }
        [Setting, DefaultValue(0)]
        public int VengeanceStunSigilOfMiseryCount { get; set; }
        #endregion

        public enum CooldownTypes
        {
            Manual,
            EliteBoss,
            BossOnly,
            Cooldown
        }
    }
}
