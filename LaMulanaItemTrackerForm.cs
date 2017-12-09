﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace LMRItemTracker
{
    public partial class LaMulanaItemTrackerForm : Form
    {
        private BackgroundWorker flagListener;

        public LaMulanaItemTrackerForm()
        {
            InitializeComponent();
            this.mantrasRecited = false;
            this.keySwordCollected = false;
            this.miracleCollected = false;
            this.mekuriCollected = false;
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            flagListener = new BackgroundWorker();
            flagListener.DoWork += new DoWorkEventHandler(flagListener_DoWork);
        }

        private void flagListener_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            e.Result = LMRItemTracker.Program.DoStuff(this, this._xmlStream);
        }

        public void toggleItem(string itemName, bool isAdd)
        {
            if (itemName.StartsWith("w-main-"))
            {
                toggleMainWeapon(itemName, isAdd);
            }
            else if (itemName.StartsWith("w-sub-"))
            {
                toggleSubWeapon(itemName, isAdd);
            }
            else if (itemName.StartsWith("w-soft-"))
            {
                toggleSoftware(itemName, isAdd);
            }
            else if (itemName.StartsWith("w-seal"))
            {
                toggleSeal(itemName, isAdd);
            }
            else if ("w-maternity".Equals(itemName))
            {
                toggleImage(maternityStatue, isAdd);
            }
            else if ("w-vessel".Equals(itemName))
            {
                toggleImage(vesselNotFound, !isAdd);
            }
            else if ("w-lamp".Equals(itemName))
            {
                toggleImage(lampOfTimeNotFound, !isAdd);
            }
            else if ("w-scanner".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(scanner, global::LMRItemTracker.Properties.Resources.Icon_handscanner);
                }
                else
                {
                    setImage(scanner, global::LMRItemTracker.Properties.Resources.Icon_handscanner_blank);
                }
            }
            else if ("w-grail".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(grail, global::LMRItemTracker.Properties.Resources.Icon_holygrail);
                }
                else
                {
                    setImage(grail, global::LMRItemTracker.Properties.Resources.Icon_holygrail_blank);
                }
            }
            else if ("w-doll".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(miniDoll, global::LMRItemTracker.Properties.Resources.Icon_minidoll);
                }
                else
                {
                    setImage(miniDoll, global::LMRItemTracker.Properties.Resources.Icon_minidoll_blank);
                }
            }
            else if ("w-magatama".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(magatamaJewel, global::LMRItemTracker.Properties.Resources.Icon_magatamajewel);
                }
                else
                {
                    setImage(magatamaJewel, global::LMRItemTracker.Properties.Resources.Icon_magatamajewel_blank);
                }
            }
            else if ("w-pepper".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(pepper, global::LMRItemTracker.Properties.Resources.Icon_pepper);
                }
                else
                {
                    setImage(pepper, global::LMRItemTracker.Properties.Resources.Icon_pepper_blank);
                }
            }
            else if ("w-woman".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(womanStatue, global::LMRItemTracker.Properties.Resources.Icon_womanstatue);
                }
                else
                {
                    setImage(womanStatue, global::LMRItemTracker.Properties.Resources.Icon_womanstatue_blank);
                }
            }
            else if ("w-serpent".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(serpentStaff, global::LMRItemTracker.Properties.Resources.Icon_serpentstaff);
                }
                else
                {
                    setImage(serpentStaff, global::LMRItemTracker.Properties.Resources.Icon_serpentstaff_blank);
                }
            }
            else if ("w-glove".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(glove, global::LMRItemTracker.Properties.Resources.Icon_glove);
                }
                else
                {
                    setImage(glove, global::LMRItemTracker.Properties.Resources.Icon_glove_blank);
                }
            }
            else if ("w-crucifix".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(crucifix, global::LMRItemTracker.Properties.Resources.Icon_crucifix);
                }
                else
                {
                    setImage(crucifix, global::LMRItemTracker.Properties.Resources.Icon_crucifix_blank);
                }
            }
            else if ("w-eye-truth".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(eyeOfTruth, global::LMRItemTracker.Properties.Resources.Icon_eyeoftruth);
                }
                else
                {
                    setImage(eyeOfTruth, global::LMRItemTracker.Properties.Resources.Icon_eyeoftruth_blank);
                }
            }
            else if ("w-scale".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(scalesphere, global::LMRItemTracker.Properties.Resources.Icon_scalesphere);
                }
                else
                {
                    setImage(scalesphere, global::LMRItemTracker.Properties.Resources.Icon_scalesphere_blank);
                }
            }
            else if ("w-gauntlet".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(gauntlet, global::LMRItemTracker.Properties.Resources.Icon_gauntlet);
                }
                else
                {
                    setImage(gauntlet, global::LMRItemTracker.Properties.Resources.Icon_gauntlet_blank);
                }
            }
            else if ("w-anchor".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(anchor, global::LMRItemTracker.Properties.Resources.Icon_anchor);
                }
                else
                {
                    setImage(anchor, global::LMRItemTracker.Properties.Resources.Icon_anchor_blank);
                }
            }
            else if ("w-book".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(bookOfTheDead, global::LMRItemTracker.Properties.Resources.Icon_bookofthedead);
                }
                else
                {
                    setImage(bookOfTheDead, global::LMRItemTracker.Properties.Resources.Icon_bookofthedead_blank);
                }
            }
            else if ("w-clothes".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(fairyClothes, global::LMRItemTracker.Properties.Resources.Icon_fairyclothes);
                }
                else
                {
                    setImage(fairyClothes, global::LMRItemTracker.Properties.Resources.Icon_fairyclothes_blank);
                }
            }
            else if ("w-scriptures".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(scriptures, global::LMRItemTracker.Properties.Resources.Icon_scriptures);
                }
                else
                {
                    setImage(scriptures, global::LMRItemTracker.Properties.Resources.Icon_scriptures_blank);
                }
            }
            else if ("w-bracelet".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(bracelet, global::LMRItemTracker.Properties.Resources.Icon_bracelet);
                }
                else
                {
                    setImage(bracelet, global::LMRItemTracker.Properties.Resources.Icon_bracelet_blank);
                }
            }
            else if ("w-perfume".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(perfume, global::LMRItemTracker.Properties.Resources.Icon_perfume);
                }
                else
                {
                    setImage(perfume, global::LMRItemTracker.Properties.Resources.Icon_perfume_blank);
                }
            }
            else if ("w-spaulder".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(spaulder, global::LMRItemTracker.Properties.Resources.Icon_spaulder);
                }
                else
                {
                    setImage(spaulder, global::LMRItemTracker.Properties.Resources.Icon_spaulder_blank);
                }
            }
            else if ("w-icecape".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(iceCape, global::LMRItemTracker.Properties.Resources.Icon_icecape);
                }
                else
                {
                    setImage(iceCape, global::LMRItemTracker.Properties.Resources.Icon_icecape_blank);
                }
            }
            else if ("w-talisman".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(talisman, global::LMRItemTracker.Properties.Resources.Icon_talisman);
                }
                else
                {
                    setImage(talisman, global::LMRItemTracker.Properties.Resources.Icon_talisman_blank);
                }
            }
            else if ("w-diary".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(diary, global::LMRItemTracker.Properties.Resources.Icon_diary);
                }
                else
                {
                    setImage(diary, global::LMRItemTracker.Properties.Resources.Icon_diary_blank);
                }
            }
            else if ("w-mulanatalisman".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(mulanaTalisman, global::LMRItemTracker.Properties.Resources.Icon_mulanatalisman);
                }
                else
                {
                    setImage(mulanaTalisman, global::LMRItemTracker.Properties.Resources.Icon_mulanatalisman_blank);
                }
            }
            else if ("w-dimension-key".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(dimensionalKey, global::LMRItemTracker.Properties.Resources.Icon_dimensionalkey);
                }
                else
                {
                    setImage(dimensionalKey, global::LMRItemTracker.Properties.Resources.Icon_dimensionalkey_blank);
                }
            }
            else if ("w-djed".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(mantra, global::LMRItemTracker.Properties.Resources.Icon_djedpillar_small);
                }
                else
                {
                    setImage(mantra, null);
                }
            }
            else if ("w-cog".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(cogOfTheSoul, global::LMRItemTracker.Properties.Resources.Icon_cogofthesoul);
                }
                else
                {
                    setImage(cogOfTheSoul, global::LMRItemTracker.Properties.Resources.Icon_cogofthesoul_blank);
                }
            }
            else if ("w-dragonbone".Equals(itemName))
            {
                updateCount(skullWallCount, isAdd, 4);
                if (isAdd)
                {
                    setImage(dragonBone, global::LMRItemTracker.Properties.Resources.Icon_dragonbone);
                }
                else
                {
                    setImage(dragonBone, global::LMRItemTracker.Properties.Resources.Icon_dragonbone_blank);
                }
            }
            else if ("w-cskull".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(crystalSkull, global::LMRItemTracker.Properties.Resources.Icon_crystalskull);
                }
                else
                {
                    setImage(crystalSkull, global::LMRItemTracker.Properties.Resources.Icon_crystalskull_blank);
                }
            }
            else if ("w-endless-key".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(keyOfEternity, global::LMRItemTracker.Properties.Resources.Icon_keyofeternity);
                }
                else
                {
                    setImage(keyOfEternity, global::LMRItemTracker.Properties.Resources.Icon_keyofeternity_blank);
                }
            }
            else if ("w-isispendant".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(isisPendant, global::LMRItemTracker.Properties.Resources.Icon_isispendant);
                }
                else
                {
                    setImage(isisPendant, global::LMRItemTracker.Properties.Resources.Icon_isispendant_blank);
                }
            }
            else if ("w-helmet".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(helmet, global::LMRItemTracker.Properties.Resources.Icon_helmet);
                }
                else
                {
                    setImage(helmet, global::LMRItemTracker.Properties.Resources.Icon_helmet_blank);
                }
            }
            else if ("w-grapple".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(grappleClaw, global::LMRItemTracker.Properties.Resources.Icon_grappleclaw);
                }
                else
                {
                    setImage(grappleClaw, global::LMRItemTracker.Properties.Resources.Icon_grappleclaw_blank);
                }
            }
            else if ("w-mirror".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(bronzeMirror, global::LMRItemTracker.Properties.Resources.Icon_bronzemirror);
                }
                else
                {
                    setImage(bronzeMirror, global::LMRItemTracker.Properties.Resources.Icon_bronzemirror_blank);
                }
            }
            else if ("w-ring".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(ring, global::LMRItemTracker.Properties.Resources.Icon_ring);
                }
                else
                {
                    setImage(ring, global::LMRItemTracker.Properties.Resources.Icon_ring_blank);
                }
            }
            else if ("w-plane".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(planeModel, global::LMRItemTracker.Properties.Resources.Icon_planemodel);
                }
                else
                {
                    setImage(planeModel, global::LMRItemTracker.Properties.Resources.Icon_planemodel_blank);
                }
            }
            else if ("w-ocarina".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(ocarina, global::LMRItemTracker.Properties.Resources.Icon_philosophersocarina);
                }
                else
                {
                    setImage(ocarina, global::LMRItemTracker.Properties.Resources.Icon_philosophersocarina_blank);
                }
            }
            else if ("w-feather".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(feather, global::LMRItemTracker.Properties.Resources.Icon_feather);
                }
                else
                {
                    setImage(feather, global::LMRItemTracker.Properties.Resources.Icon_feather_blank);
                }
            }
            else if ("w-hermes".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(hermesBoots, global::LMRItemTracker.Properties.Resources.Icon_hermesboots);
                }
                else
                {
                    setImage(hermesBoots, global::LMRItemTracker.Properties.Resources.Icon_hermesboots_blank);
                }
            }
            else if ("w-fruit".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(fruitOfEden, global::LMRItemTracker.Properties.Resources.Icon_fruitofeden);
                }
                else
                {
                    setImage(fruitOfEden, global::LMRItemTracker.Properties.Resources.Icon_fruitofeden_blank);
                }
            }
            else if ("w-twin-statue".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(twinStatue, global::LMRItemTracker.Properties.Resources.Icon_twinstatue);
                }
                else
                {
                    setImage(twinStatue, global::LMRItemTracker.Properties.Resources.Icon_twinstatue_blank);
                }
            }
            else if ("w-treasures".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(treasures, global::LMRItemTracker.Properties.Resources.Icon_treasures);
                }
                else
                {
                    setImage(treasures, global::LMRItemTracker.Properties.Resources.Icon_treasures_blank);
                }
            }
            else if ("w-pochettekey".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(pochetteKey, global::LMRItemTracker.Properties.Resources.Icon_pochettekey);
                }
                else
                {
                    setImage(pochetteKey, global::LMRItemTracker.Properties.Resources.Icon_pochettekey_blank);
                }
            }
            else if ("w-msx2".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(msx2, global::LMRItemTracker.Properties.Resources.Icon_msx2);
                }
                else
                {
                    setImage(msx2, global::LMRItemTracker.Properties.Resources.Icon_msx2_blank);
                }
            }
            else if ("w-medicine".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(vessel, global::LMRItemTracker.Properties.Resources.Icon_medicineofthemind);
                }
                else
                {
                    setImage(vessel, global::LMRItemTracker.Properties.Resources.Icon_vessel); // todo: what if we don't have vessel?
                }
            }
        }

        private void toggleMainWeapon(string itemName, bool isAdd)
        {
            if ("w-main-chain".Equals(itemName))
            {
                toggleImage(chainWhip, isAdd);
            }
            else if ("w-main-flail".Equals(itemName))
            {
                toggleImage(flailWhip, isAdd);
            }
            else if ("w-main-axe".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(axe, global::LMRItemTracker.Properties.Resources.Icon_axe);
                }
                else
                {
                    setImage(axe, global::LMRItemTracker.Properties.Resources.Icon_axe_blank);
                }
            }
            else if ("w-main-knife".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(knife, global::LMRItemTracker.Properties.Resources.Icon_knife);
                }
                else
                {
                    setImage(knife, global::LMRItemTracker.Properties.Resources.Icon_knife_blank);
                }
            }
            else if ("w-main-katana".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(katana, global::LMRItemTracker.Properties.Resources.Icon_katana);
                }
                else
                {
                    setImage(katana, global::LMRItemTracker.Properties.Resources.Icon_katana_blank);
                }
            }
            else if ("w-main-keysword".Equals(itemName))
            {
                this.keySwordCollected = isAdd;
                if (isAdd)
                {
                    if (this.mantrasRecited)
                    {
                        setImage(keySword, global::LMRItemTracker.Properties.Resources.Icon_keysword_awakened);
                    }
                    else
                    {
                        setImage(keySword, global::LMRItemTracker.Properties.Resources.Icon_keysword);
                    }
                }
                else
                {
                    setImage(keySword, global::LMRItemTracker.Properties.Resources.Icon_keysword_blank);
                }
            }
        }

        private void toggleSubWeapon(string itemName, bool isAdd)
        {
            if ("w-sub-shuriken".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(shuriken, global::LMRItemTracker.Properties.Resources.Icon_shuriken);
                }
                else
                {
                    setImage(shuriken, global::LMRItemTracker.Properties.Resources.Icon_shuriken_blank);
                }
            }
            else if ("w-sub-rshuriken".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(rollingShuriken, global::LMRItemTracker.Properties.Resources.Icon_rollingshuriken);
                }
                else
                {
                    setImage(rollingShuriken, global::LMRItemTracker.Properties.Resources.Icon_rollingshuriken_blank);
                }
            }
            else if ("w-sub-caltrops".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(caltrops, global::LMRItemTracker.Properties.Resources.Icon_caltrops);
                }
                else
                {
                    setImage(caltrops, global::LMRItemTracker.Properties.Resources.Icon_caltrops_blank);
                }
            }
            else if ("w-sub-spear".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(earthSpear, global::LMRItemTracker.Properties.Resources.Icon_earthspear);
                }
                else
                {
                    setImage(earthSpear, global::LMRItemTracker.Properties.Resources.Icon_earthspear_blank);
                }
            }
            else if ("w-sub-flare".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(flareGun, global::LMRItemTracker.Properties.Resources.Icon_flaregun);
                }
                else
                {
                    setImage(flareGun, global::LMRItemTracker.Properties.Resources.Icon_flaregun_blank);
                }
            }
            else if ("w-sub-bomb".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(bomb, global::LMRItemTracker.Properties.Resources.Icon_bomb);
                }
                else
                {
                    setImage(bomb, global::LMRItemTracker.Properties.Resources.Icon_bomb_blank);
                }
            }
            else if ("w-sub-chakram".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(chakram, global::LMRItemTracker.Properties.Resources.Icon_chakram);
                }
                else
                {
                    setImage(chakram, global::LMRItemTracker.Properties.Resources.Icon_chakram_blank);
                }
            }
            else if ("w-sub-pistol".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(pistol, global::LMRItemTracker.Properties.Resources.Icon_pistol);
                }
                else
                {
                    setImage(pistol, global::LMRItemTracker.Properties.Resources.Icon_pistol_blank);
                }
            }
        }

        private void toggleSeal(string itemName, bool isAdd)
        {
            if ("w-seal1".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(originSeal, global::LMRItemTracker.Properties.Resources.Icon_originseal);
                }
                else
                {
                    setImage(originSeal, global::LMRItemTracker.Properties.Resources.Icon_originseal_blank);
                }
            }
            else if ("w-seal2".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(birthSeal, global::LMRItemTracker.Properties.Resources.Icon_birthseal);
                }
                else
                {
                    setImage(birthSeal, global::LMRItemTracker.Properties.Resources.Icon_birthseal_blank);
                }
            }
            else if ("w-seal3".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(lifeSeal, global::LMRItemTracker.Properties.Resources.Icon_lifeseal);
                }
                else
                {
                    setImage(lifeSeal, global::LMRItemTracker.Properties.Resources.Icon_lifeseal_blank);
                }
            }
            else if ("w-seal4".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(deathSeal, global::LMRItemTracker.Properties.Resources.Icon_deathseal);
                }
                else
                {
                    setImage(deathSeal, global::LMRItemTracker.Properties.Resources.Icon_deathseal_blank);
                }
            }
        }

        private void toggleSoftware(string itemName, bool isAdd)
        {
            if ("w-soft-reader".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(reader, global::LMRItemTracker.Properties.Resources.Icon_reader);
                }
                else
                {
                    setImage(reader, global::LMRItemTracker.Properties.Resources.Icon_reader_blank);
                }
            }
            else if("w-soft-mantra".Equals(itemName))
            {
                if (isAdd)
                {
                    setBackgroundImage(mantra, global::LMRItemTracker.Properties.Resources.Icon_mantra);
                }
                else
                {
                    setBackgroundImage(mantra, global::LMRItemTracker.Properties.Resources.Icon_mantra_blank);
                }
            }
            else if ("w-soft-torude".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(torude, global::LMRItemTracker.Properties.Resources.Icon_torude);
                }
                else
                {
                    setImage(torude, global::LMRItemTracker.Properties.Resources.Icon_torude_blank);
                }
            }
            else if ("w-soft-mekuri".Equals(itemName))
            {
                if (isAdd)
                {
                    this.mekuriCollected = true;
                    if (this.miracleCollected)
                    {
                        setImage(keyFairy, global::LMRItemTracker.Properties.Resources.Icon_keyfairy);
                    }
                }
                else
                {
                    this.mekuriCollected = false;
                    setImage(keyFairy, global::LMRItemTracker.Properties.Resources.Icon_keyfairy_blank);
                }
            }
            else if ("w-soft-miracle".Equals(itemName))
            {
                if (isAdd)
                {
                    this.miracleCollected = true;
                    if (this.mekuriCollected)
                    {
                        setImage(keyFairy, global::LMRItemTracker.Properties.Resources.Icon_keyfairy);
                    }
                }
                else
                {
                    this.miracleCollected = false;
                    setImage(keyFairy, global::LMRItemTracker.Properties.Resources.Icon_keyfairy_blank);
                }
            }
            else if ("w-soft-mirai".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(mirai, global::LMRItemTracker.Properties.Resources.Icon_mirai);
                }
                else
                {
                    setImage(mirai, global::LMRItemTracker.Properties.Resources.Icon_mirai_blank);
                }
            }
            else if ("w-soft-yagomap".Equals(itemName) || "w-soft-yagostr".Equals(itemName))
            {
                updateCount(skullWallCount, isAdd, 4);
            }
        }

        internal void updateShield(string displayname, bool isAdd)
        {
            if ("shield-buckler".Equals(displayname))
            {
                if (isAdd)
                {
                    setImage(buckler, global::LMRItemTracker.Properties.Resources.Icon_buckler);
                }
                else
                {
                    setImage(buckler, global::LMRItemTracker.Properties.Resources.Icon_buckler_blank);
                }
            }
            else if ("shield-silver".Equals(displayname))
            {
                toggleImage(silverShield, isAdd);
            }
            else if ("shield-fake".Equals(displayname))
            {
                toggleImage(fakeSilverShield, isAdd);
            }
            else if ("shield-angel".Equals(displayname))
            {
                toggleImage(angelShield, isAdd);
            }
        }

        internal void updateLampOfTime(string displayname, bool isAdd)
        {
            if ("invus-lamp-lit".Equals(displayname))
            {
                if (isAdd)
                {
                    setImage(lampOfTime, global::LMRItemTracker.Properties.Resources.Icon_lampoftime);
                }
            }
            else if ("invus-lamp-unlit".Equals(displayname))
            {
                if (isAdd)
                {
                    setImage(lampOfTime, global::LMRItemTracker.Properties.Resources.Icon_lampoftime_unlit);
                }
            }
        }

        internal void updateTranslationTablets(byte cur)
        {
            translationTablets.Invoke(new Action(() =>
            {
                translationTablets.Text = cur + "/3";
                translationTablets.Refresh();
            }));
        }

        public void updateAnkhJewels(ushort cur)
        {
            ankhJewelCount.Invoke(new Action(() =>
            {
                ankhJewelCount.Text = "" + cur;
                ankhJewelCount.Refresh();
            }));
        }

        public void toggleBoss(string itemName, Boolean isAdd)
        {
            if ("boss-amphisbaena".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(amphisbaena, global::LMRItemTracker.Properties.Resources.Boss_amphisbaena);
                }
                else
                {
                    setImage(amphisbaena, global::LMRItemTracker.Properties.Resources.Boss_amphisbaena_blank);
                }
            }
            else if ("boss-sakit".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(sakit, global::LMRItemTracker.Properties.Resources.Boss_sakit);
                }
                else
                {
                    setImage(sakit, global::LMRItemTracker.Properties.Resources.Boss_sakit_blank);
                }
            }
            else if ("boss-ellmac".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(ellmac, global::LMRItemTracker.Properties.Resources.Boss_ellmac);
                }
                else
                {
                    setImage(ellmac, global::LMRItemTracker.Properties.Resources.Boss_ellmac_blank);
                }
            }
            else if ("boss-bahamut".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(bahamut, global::LMRItemTracker.Properties.Resources.Boss_bahamut);
                }
                else
                {
                    setImage(bahamut, global::LMRItemTracker.Properties.Resources.Boss_bahamut_blank);
                }
            }
            else if ("boss-viy".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(viy, global::LMRItemTracker.Properties.Resources.Boss_viy);
                }
                else
                {
                    setImage(viy, global::LMRItemTracker.Properties.Resources.Boss_viy_blank);
                }
            }
            else if ("boss-palenque".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(palenque, global::LMRItemTracker.Properties.Resources.Boss_palenque);
                }
                else
                {
                    setImage(palenque, global::LMRItemTracker.Properties.Resources.Boss_palenque_blank);
                }
            }
            else if ("boss-baphomet".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(baphomet, global::LMRItemTracker.Properties.Resources.Boss_baphomet);
                }
                else
                {
                    setImage(baphomet, global::LMRItemTracker.Properties.Resources.Boss_baphomet_blank);
                }
            }
            else if ("boss-tiamat".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(tiamat, global::LMRItemTracker.Properties.Resources.Boss_tiamat);
                }
                else
                {
                    setImage(tiamat, global::LMRItemTracker.Properties.Resources.Boss_tiamat_blank);
                }
            }
        }

        public void toggleMap(string itemName, Boolean isAdd)
        {
            updateCount(mapCount, isAdd, 18);
            if ("w-map-shrine".Equals(itemName))
            {
                updateCount(skullWallCount, isAdd, 4);
                if (isAdd)
                {
                    setImage(maps, global::LMRItemTracker.Properties.Resources.Icon_dragonbone_small);
                }
                else
                {
                    setImage(maps, null);
                }
            }
        }

        public void toggleMantra(string itemName, bool isAdd)
        {
            if ("mantra-keysword".Equals(itemName))
            {
                if (isAdd)
                {
                    this.mantrasRecited = true;
                    if (this.keySwordCollected)
                    {
                        setImage(keySword, global::LMRItemTracker.Properties.Resources.Icon_keysword_awakened);
                    }
                }
                else
                {
                    this.mantrasRecited = false;
                    if (this.keySwordCollected)
                    {
                        setImage(keySword, global::LMRItemTracker.Properties.Resources.Icon_keysword);
                    }
                }
            }
            else if ("mantra-amphisbaena".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(amphisbaena, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(amphisbaena, null);
                }
            }
            else if ("mantra-sakit".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(sakit, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(sakit, null);
                }
            }
            else if ("mantra-ellmac".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(ellmac, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(ellmac, null);
                }
            }
            else if ("mantra-bahamut".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(bahamut, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(bahamut, null);
                }
            }
            else if ("mantra-viy".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(viy, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(viy, null);
                }
            }
            else if ("mantra-palenque".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(palenque, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(palenque, null);
                }
            }
            else if ("mantra-baphomet".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(baphomet, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(baphomet, null);
                }
            }
            else if ("mantra-tiamat".Equals(itemName))
            {
                if (isAdd)
                {
                    setImage(tiamat, global::LMRItemTracker.Properties.Resources.Icon_djedpillar);
                }
                else
                {
                    setImage(tiamat, null);
                }
            }
        }

        private void LaMulanaItemTrackerForm_Load(object sender, EventArgs e)
        {
            try
            {
                this._assembly = Assembly.GetExecutingAssembly();
                this._xmlStream = _assembly.GetManifestResourceStream("LMRItemTracker.names.xml");
            }
            catch
            {
                MessageBox.Show("Error accessing resources!");
            }

            flagListener.RunWorkerAsync();
        }

        private void LaMulanaItemTrackerForm_DoubleClick(object sender, EventArgs e)
        {
            if (formColorDialog.ShowDialog() == DialogResult.OK)
                this.BackColor = formColorDialog.Color;
        }

        private void textDoubleClick(object sender, EventArgs e)
        {
            if (textColorDialog.ShowDialog() == DialogResult.OK)
            {
                this.mapCount.ForeColor = textColorDialog.Color;
                this.ankhJewelCount.ForeColor = textColorDialog.Color;
                this.translationTablets.ForeColor = textColorDialog.Color;
                this.skullWallCount.ForeColor = textColorDialog.Color;
            }
        }

        private void toggleImage(PictureBox pictureBox, bool visible)
        {
            pictureBox.Invoke(new Action(() =>
            {
                if (pictureBox.Visible != visible)
                {
                    pictureBox.Visible = visible;
                    pictureBox.Refresh();
                }
            }));
        }

        private void setImage(PictureBox pictureBox, System.Drawing.Image image)
        {
            pictureBox.Invoke(new Action(() =>
            {
                pictureBox.Image = image;
                pictureBox.Refresh();
            }));
        }

        private void setBackgroundImage(PictureBox pictureBox, System.Drawing.Image image)
        {
            pictureBox.Invoke(new Action(() =>
            {
                pictureBox.BackgroundImage = image;
                pictureBox.Refresh();
            }));
        }

        private void updateCount(Label label, bool isAdd, int max)
        {
            label.Invoke(new Action(() =>
            {
                int existingCount = Int32.Parse(label.Text.Substring(0, label.Text.IndexOf('/')));
                if (isAdd)
                {
                    if (existingCount < max)
                    {
                        label.Text = (existingCount + 1) + "/" + max;
                        label.Refresh();
                    }
                }
                else
                {
                    if (existingCount > 0)
                    {
                        label.Text = (existingCount - 1) + "/" + max;
                        label.Refresh();
                    }
                }
            }));
        }

        private void setAngelShieldIndex(object sender, EventArgs e)
        {
            shields.Controls.SetChildIndex(angelShield, 0);
        }
        private void setSilverShieldIndex(object sender, EventArgs e)
        {
            shields.Controls.SetChildIndex(silverShield, 1);
        }
        private void setFakeSilverShieldIndex(object sender, EventArgs e)
        {
            shields.Controls.SetChildIndex(fakeSilverShield, 2);
        }
        private void setBucklerIndex(object sender, EventArgs e)
        {
            shields.Controls.SetChildIndex(buckler, 3);
        }
    }
}
