using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AuroraEngine
{
    public partial class NWScript : AuroraScript {
        static StateSystem stateManager;
        static MovieSystem movieSystem;
        static MusicSystem musicSystem;
        static DialogSystem dialogSystem;

        static NWScript()
        {
            stateManager = GameObject.Find("State System").GetComponent<StateSystem>();
            movieSystem = GameObject.Find("Movie System").GetComponent<MovieSystem>();
            musicSystem = GameObject.Find("Music System").GetComponent<MusicSystem>();
            dialogSystem = GameObject.Find("Dialog System").GetComponent<DialogSystem>();
        }

        public static int Random (int nMaxInteger)
        {
            int r = UnityEngine.Random.Range(0, nMaxInteger);
            return r;
        }
        public static void PrintString (string sString)
        {
            Debug.Log(sString);
        }
        public static void PrintFloat (float fFloat, int nWidth = 18, int nDecimals = 9)
        {
            Debug.Log(fFloat);
        }
        public static string FloatToString (float fFloat, int nWidth = 18, int nDecimals = 9)
        {
            return fFloat.ToString();
        }
        public static void PrintInteger (int nInteger)
        {
            Debug.Log(nInteger);
        }
        public static void PrintObject (AuroraObject oObject)
        {
            Debug.Log(oObject);
        }
        public static void AssignCommand(AuroraObject oActionSubject, NCSContext aActionToDelay)
        {
            stateManager.AssignCommand(oActionSubject, aActionToDelay);
        }
        public static void DelayCommand(float fSeconds, NCSContext aActionToDelay)
        {
            stateManager.DelayCommand(stateManager.GetObjectSelf(), fSeconds, aActionToDelay);
        }
        public static void ExecuteScript(string sScript, AuroraObject oTarget, int nScriptVar = -1)
        {
            stateManager.RunScript(sScript, oTarget, nScriptVar);
        }
        public static void ClearAllActions ()
        {
            stateManager.GetObjectSelf().actions.Clear();
        }
        public static void SetFacing (float fDirection)
        {
            Debug.LogWarning("Need to figure out how SetFacing works");
            Vector3 rotation = stateManager.GetObjectSelf().transform.rotation.eulerAngles;
            stateManager.GetObjectSelf().transform.rotation = Quaternion.Euler(
                new Vector3(
                    rotation.x,
                    fDirection + 90, // Is this right?
                    rotation.z
                )
            );
        }
        public static int SwitchPlayerCharacter (int nNPC)
        {
            Console.WriteLine ("Function SwitchPlayerCharacter not implemented");
            throw new NotImplementedException ();
        }
        public static void SetTime (int nHour, int nMinute, int nSecond, int nMillisecond)
        {
            stateManager.nHour = nHour;
            stateManager.nMinute = nMinute;
            stateManager.nSecond = nSecond;
            stateManager.nMillisecond = nMillisecond;
        }
        public static int SetPartyLeader (int nNPC)
        {
            //Console.WriteLine ("Function SetPartyLeader not implemented");
            //throw new NotImplementedException ();

            // TODO: Implement this
            Debug.LogWarning("Switching party members not yet implemented");
            return 0;
        }
        public static void SetAreaUnescapable (int bUnescapable)
        {
            Console.WriteLine("Function SetAreaUnescapable not implemented");
            throw new NotImplementedException();
        }
        public static int GetAreaUnescapable ()
        {
            Console.WriteLine("Function GetAreaUnescapable not implemented");
            throw new NotImplementedException();
        }
        public static int GetTimeHour ()
        {
            return stateManager.nHour;
        }
        public static int GetTimeMinute ()
        {
            return stateManager.nMinute;
        }
        public static int GetTimeSecond ()
        {
            return stateManager.nSecond;
        }
        public static int GetTimeMillisecond ()
        {
            return stateManager.nMillisecond;
        }
        public static void ActionRandomWalk ()
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionRandomWalk(self));
        }
        public static void ActionMoveToLocation (AuroraLocation lDestination, int bRun = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionMoveToLocation(self, lDestination, Convert.ToBoolean(bRun)));
        }
        public static void ActionMoveToObject (AuroraObject oMoveTo, int bRun = 0, float fRange = 1.0f)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionMoveToObject(self, oMoveTo, Convert.ToBoolean(bRun), fRange));
        }
        public static void ActionMoveAwayFromObject (AuroraObject oFleeFrom, int bRun = 0, float fMoveAwayRange = 40.0f)
        {
            Debug.LogWarning("ActionMoveAwayFromObject not yet implemented");
            //AuroraObject self = stateManager.GetObjectSelf();
            //self.AddAction(new ActionMoveAwayFromObject(self, oFleeFrom, Convert.ToBoolean(bRun), fMoveAwayRange));
        }
        public static AuroraObject GetArea (AuroraObject oTarget)
        {
            return stateManager.currentModule.area;
        }
        public static AuroraObject GetEnteringObject ()
        {
            AuroraObject caller = stateManager.GetObjectSelf();
            switch (caller.auroraObjectType)
            {
                case AuroraObject.AuroraObjectType.DOOR:
                case AuroraObject.AuroraObjectType.PLACEABLE:
                    return caller.lastTriggerer;
                default:
                    return caller.lastEntered;
            }
        }
        public static AuroraObject GetExitingObject ()
        {
            AuroraObject caller = stateManager.GetObjectSelf();
            return caller.lastExited;
        }
        public static AuroraVector GetPosition (AuroraObject oTarget)
        {
            return new AuroraVector (
                oTarget.transform.position.x,
                oTarget.transform.position.z,
                oTarget.transform.position.y
            );
        }
        public static float GetFacing (AuroraObject oTarget)
        {
            Debug.LogWarning("Need to figure out how GetFacing works");
            return oTarget.transform.rotation.eulerAngles.y;
        }
        public static AuroraObject GetItemPossessor (AuroraObject oItem)
        {
            return oItem.possessor;
        }
        public static AuroraObject GetItemPossessedBy (AuroraObject oCreature, string sItemTag)
        {
            if (oCreature.possessions.ContainsKey(sItemTag))
            {
                return oCreature.possessions[sItemTag];
            }
            return null;
        }
        public static AuroraObject CreateItemOnObject (string sItemTemplate, AuroraObject oTarget = null, int nStackSize = 1)
        {
            if (sItemTemplate == "")
            {
                return null;
            }
            
            // TODO: Support stack sizes?
            Debug.Log("CreateItemOnObject not yet properly implemented; I'm working on it");

            if (oTarget.GetType() == typeof(Creature))
            {
                AuroraUTC utc = (AuroraUTC)oTarget.template;
                utc.ItemList.Add(new AuroraUTC.AItem()
                {
                    InventoryRes = sItemTemplate
                });
            } else if (oTarget.GetType() == typeof(Placeable))
            {
                AuroraUTP utp = (AuroraUTP)oTarget.template;
                utp.ItemList.Add(new AuroraUTP.AItem()
                {
                    InventoryRes = sItemTemplate
                });
            } else
            {
                Debug.LogWarning("Could not add object " + sItemTemplate + " to target " + oTarget + " of type + " + oTarget.GetType().Name);
            }

            return new AuroraObject();
        }
        public static void ActionEquipItem (AuroraObject oItem, int nInventorySlot, int bInstant = 0)
        {
            // TODO: bInstant?
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionEquipItem(self, oItem, nInventorySlot, Convert.ToBoolean(bInstant)));
        }
        public static void ActionUnequipItem (AuroraObject oItem, int bInstant = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionUnequipItem(self, oItem, Convert.ToBoolean(bInstant)));

        }
        public static void ActionPickUpItem (AuroraObject oItem)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionPickUpItem(self, oItem));
        }
        public static void ActionPutDownItem (AuroraObject oItem)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionDropItem(self, oItem));
        }
        public static AuroraObject GetLastAttacker (AuroraObject oAttackee = null)
        {
            oAttackee = oAttackee ?? stateManager.GetObjectSelf ();
            return oAttackee.lastAttacker;
        }
        public static void ActionAttack (AuroraObject oAttackee, int bPassive = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionAttack(self, oAttackee, Convert.ToBoolean(bPassive)));
        }
        public static AuroraObject GetNearestCreature (int nFirstCriteriaType, int nFirstCriteriaValue, AuroraObject oTarget = null, int nNth = 1, int nSecondCriteriaType = -1, int nSecondCriteriaValue = -1, int nThirdCriteriaType = -1, int nThirdCriteriaValue = -1)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();

            return stateManager.Nearest(oTarget, typeof(Creature), nNth);
        }
        public static void ActionSpeakString (string sStringToSpeak, int nTalkVolume = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionSpeakString(self, sStringToSpeak, nTalkVolume));
        }
        public static void ActionPlayAnimation (int nAnimation, float fSpeed = 1.0f, float fDurationSeconds = 0.0f)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionPlayAnimation(self, nAnimation, fSpeed, fDurationSeconds));
        }
        public static float GetDistanceToObject (AuroraObject oObject)
        {
            return Vector3.Distance(
                stateManager.GetObjectSelf().transform.position,
                oObject.transform.position
            );
        }
        public static int GetIsObjectValid (AuroraObject oObject)
        {
            return Convert.ToInt32(oObject != AuroraObject.GetObjectInvalid());
        }
        public static void ActionOpenDoor (AuroraObject oDoor)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionOpenDoor(self, oDoor));
        }
        public static void ActionCloseDoor (AuroraObject oDoor)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionCloseDoor(self, oDoor));
        }
        public static void SetCameraFacing (float fDirection)
        {
            Debug.LogWarning("SetCameraFacing not yet implemented");
        }
        public static void PlaySound (string sSoundName)
        {
            Debug.LogWarning("Sound system not yet implemented");
        }
        public static AuroraObject GetSpellTargetObject ()
        {
            Console.WriteLine ("Function GetSpellTargetObject not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionCastSpellAtObject (int nSpell, AuroraObject oTarget, int nMetaMagic = 0, int bCheat = 0, int nDomainLevel = 0, int nProjectilePathType = 0, int bInstantSpell = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionCastSpellAtObject(
                self,
                nSpell,
                oTarget,
                nMetaMagic,
                Convert.ToBoolean(bCheat),
                nDomainLevel,
                nProjectilePathType,
                Convert.ToBoolean(bInstantSpell)
            ));
        }
        public static int GetCurrentHitPoints (AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf ();

            switch (oObject.auroraObjectType)
            {
                case AuroraObject.AuroraObjectType.CREATURE:
                    AuroraUTC utc = (AuroraUTC)oObject.template;
                    return utc.CurrentHitPoints;
                case AuroraObject.AuroraObjectType.DOOR:
                    AuroraUTD utd = (AuroraUTD)oObject.template;
                    return utd.CurrentHP;
                case AuroraObject.AuroraObjectType.PLACEABLE:
                    AuroraUTP utp = (AuroraUTP)oObject.template;
                    return utp.CurrentHP;
                default:
                    return 0;
            }
        }

        public static int GetMaxHitPoints (AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf();

            switch (oObject.auroraObjectType)
            {
                case AuroraObject.AuroraObjectType.CREATURE:
                    AuroraUTC utc = (AuroraUTC)oObject.template;
                    return utc.MaxHitPoints;
                case AuroraObject.AuroraObjectType.DOOR:
                    AuroraUTD utd = (AuroraUTD)oObject.template;
                    return utd.HP;
                case AuroraObject.AuroraObjectType.PLACEABLE:
                    AuroraUTP utp = (AuroraUTP)oObject.template;
                    return utp.HP;
                default:
                    return 0;
            }
        }
        public static AuroraEffect EffectAssuredHit ()
        {
            return new EffectAssuredHit();
        }
        public static AuroraObject GetLastItemEquipped ()
        {
            Console.WriteLine ("Function GetLastItemEquipped not implemented");
            throw new NotImplementedException ();
        }
        public static int GetSubScreenID ()
        {
            Console.WriteLine ("Function GetSubScreenID not implemented");
            throw new NotImplementedException ();
        }
        public static void CancelCombat (AuroraObject oidCreature)
        {
            Debug.LogWarning("Combat cancelling (and combat in general) not yet implemented");
            //Console.WriteLine ("Function CancelCombat not implemented");
            //throw new NotImplementedException ();
        }
        public static int GetCurrentForcePoints (AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetCurrentForcePoints not implemented");
            throw new NotImplementedException ();
        }
        public static int GetMaxForcePoints (AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetMaxForcePoints not implemented");
            throw new NotImplementedException ();
        }
        public static void PauseGame (int bPause)
        {
            Console.WriteLine ("Function PauseGame not implemented");
            throw new NotImplementedException ();
        }
        public static void SetPlayerRestrictMode (int bRestrict)
        {
            Debug.LogWarning("Not sure what restrict mode does yet...");
        }
        #region String Operations
        public static int GetStringLength (string sString)
        {
            return sString.Length;
        }
        public static string GetStringUpperCase (string sString)
        {
            return sString.ToUpper();
        }
        public static string GetStringLowerCase (string sString)
        {
            return sString.ToLower();
        }
        public static string GetStringRight (string sString, int nCount)
        {
            if (sString.Length - nCount < 0)
            {
                return "";
            }
            return sString.Substring(sString.Length - nCount);
        }
        public static string GetStringLeft (string sString, int nCount)
        {
            if (nCount > sString.Length)
            {
                return "";
            }
            return sString.Substring(0, nCount);
        }
        public static string InsertString (string sDestination, string sString, int nPosition)
        {
            return sDestination.Insert(nPosition, sString);
        }
        public static string GetSubString (string sString, int nStart, int nCount)
        {
            return sString.Substring(nStart, nCount);
        }
        public static int FindSubString (string sString, string sSubString)
        {
            return sString.IndexOf(sSubString);
        }
        #endregion "String Operations"

        #region Maths Operations
        public static float fabs (float fValue)
        {
            return Math.Abs(fValue);
        }
        public static float cos (float fValue)
        {
            return (float)Math.Cos((float)fValue);
        }
        public static float sin (float fValue)
        {
            return (float)Math.Sin((float)fValue);
        }
        public static float tan (float fValue)
        {
            return (float)Math.Tan((float)fValue);
        }
        public static float acos (float fValue)
        {
            return (float)Math.Acos((float)fValue);
        }
        public static float asin (float fValue)
        {
            return (float)Math.Asin((float)fValue);
        }
        public static float atan (float fValue)
        {
            return (float)Math.Atan((float)fValue);
        }
        public static float log (float fValue)
        {
            return (float)Math.Log((float)fValue);
        }
        public static float pow (float fValue, float fExponent)
        {
            return (float)Math.Pow((float)fValue, (float)fExponent);
        }
        public static float sqrt (float fValue)
        {
            return (float)Math.Sqrt((float)fValue);
        }
        public static int abs (int nValue)
        {
            return Math.Abs(nValue);
        }
        #endregion "Maths Operations"
        public static AuroraEffect EffectHeal (int nDamageToHeal)
        {
            Debug.LogWarning("Effects are not yet implemented");
            return null;
        }
        public static AuroraEffect EffectDamage (int nDamageAmount, int nDamageType = 0, int nDamagePower = 0)
        {
            Debug.LogWarning("Effects are not yet implemented");
            return null;
        }
        public static AuroraEffect EffectAbilityIncrease (int nAbilityToIncrease, int nModifyBy)
        {
            Debug.LogWarning("Effects are not yet implemented");
            return null;
        }
        public static AuroraEffect EffectDamageResistance (int nDamageType, int nAmount, int nLimit = 0)
        {
            Debug.LogWarning("Effects are not yet implemented");
            return null;
        }
        public static AuroraEffect EffectResurrection ()
        {
            Debug.LogWarning("Effects are not yet implemented");
            return null;
        }
        public static int GetPlayerRestrictMode (AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf ();
            Debug.LogWarning("PlayRestrictMode not yet implemented");
            return 0;
        }
        public static int GetCasterLevel (AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetCasterLevel not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect GetFirstEffect (AuroraObject oCreature)
        {
            return stateManager.GetFirstEffect(oCreature);
            throw new NotImplementedException("GetFirstEffect not yet implemented");
        }
        public static AuroraEffect GetNextEffect (AuroraObject oCreature)
        {
            return stateManager.GetNextEffect();
        }
        public static void RemoveEffect (AuroraObject oCreature, AuroraEffect eEffect)
        {
            oCreature.effects.Remove(eEffect);
        }
        public static int GetIsEffectValid (AuroraEffect eEffect)
        {
            Debug.LogWarning("Effects not yet implemented, so GetIsEffectValid will always return FALSE");
            return 0;
        }
        public static int GetEffectDurationType (AuroraEffect eEffect)
        {
            return eEffect.DurationType;
        }
        public static int GetEffectSubType (AuroraEffect eEffect)
        {
            return eEffect.SubType;
        }
        public static AuroraObject GetEffectCreator (AuroraEffect eEffect)
        {
            return eEffect.creator;
        }
        public static string IntToString (int nInteger)
        {
            return nInteger.ToString();
        }
        public static AuroraObject GetFirstObjectInArea (AuroraObject oArea = null, int nObjectFilter = 0)
        {
            return stateManager.GetFirstObjectInArea(nObjectFilter);
        }
        public static AuroraObject GetNextObjectInArea (AuroraObject oArea = null, int nObjectFilter = 0)
        {
            return stateManager.GetNextObjectInArea();
        }

        public static int dN (int N, int nNumDice)
        {
            int total = 0;
            for (int i = 0; i < nNumDice; i++)
            {
                total += UnityEngine.Random.Range(0, N);
            }
            return total;
        }

        public static int d2 (int nNumDice = 1)
        {
            return dN(2, nNumDice);
        }
        public static int d3 (int nNumDice = 1)
        {
            return dN(3, nNumDice);
        }
        public static int d4 (int nNumDice = 1)
        {
            return dN(4, nNumDice);
        }
        public static int d6 (int nNumDice = 1)
        {
            return dN(6, nNumDice);
        }
        public static int d8 (int nNumDice = 1)
        {
            return dN(8, nNumDice);
        }
        public static int d10 (int nNumDice = 1)
        {
            return dN(10, nNumDice);
        }
        public static int d12 (int nNumDice = 1)
        {
            return dN(12, nNumDice);
        }
        public static int d20 (int nNumDice = 1)
        {
            return dN(20, nNumDice);
        }
        public static int d100 (int nNumDice = 1)
        {
            return dN(100, nNumDice);
        }
        public static float VectorMagnitude (AuroraVector vVector)
        {
            return (new Vector3(vVector.x, vVector.y, vVector.z).magnitude);
        }
        public static int GetMetaMagicFeat ()
        {
            Console.WriteLine ("Function GetMetaMagicFeat not implemented");
            throw new NotImplementedException ();
        }
        public static int GetObjectType (AuroraObject oTarget)
        {
            // TODO: Make this map correctly to Aurora types
            return (int)oTarget.auroraObjectType;
        }
        public static int GetRacialType (AuroraObject oCreature)
        {
            return oCreature.racialType;
        }
        public static int FortitudeSave (AuroraObject oCreature, int nDC, int nSaveType = 0, AuroraObject oSaveVersus = null)
        {
            oSaveVersus = oSaveVersus ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function FortitudeSave not implemented");
            throw new NotImplementedException ();
        }
        public static int ReflexSave (AuroraObject oCreature, int nDC, int nSaveType = 0, AuroraObject oSaveVersus = null)
        {
            oSaveVersus = oSaveVersus ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function ReflexSave not implemented");
            throw new NotImplementedException ();
        }
        public static int WillSave (AuroraObject oCreature, int nDC, int nSaveType = 0, AuroraObject oSaveVersus = null)
        {
            oSaveVersus = oSaveVersus ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function WillSave not implemented");
            throw new NotImplementedException ();
        }
        public static int GetSpellSaveDC ()
        {
            Console.WriteLine ("Function GetSpellSaveDC not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect MagicalEffect (AuroraEffect eEffect)
        {
            Console.WriteLine ("Function MagicalEffect not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect SupernaturalEffect (AuroraEffect eEffect)
        {
            Console.WriteLine ("Function SupernaturalEffect not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect ExtraordinaryEffect (AuroraEffect eEffect)
        {
            Console.WriteLine ("Function ExtraordinaryEffect not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectACIncrease (int nValue, int nModifyType = 0, int nDamageType = 0)
        {
            Console.WriteLine ("Function EffectACIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static int GetAC (AuroraObject oObject, int nForFutureUse = 0)
        {
            Console.WriteLine ("Function GetAC not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectSavingThrowIncrease (int nSave, int nValue, int nSaveType = 0)
        {
            Console.WriteLine ("Function EffectSavingThrowIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectAttackIncrease (int nBonus, int nModifierType = 0)
        {
            Console.WriteLine ("Function EffectAttackIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDamageReduction (int nAmount, int nDamagePower, int nLimit = 0)
        {
            Console.WriteLine ("Function EffectDamageReduction not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDamageIncrease (int nBonus, int nDamageType = 0)
        {
            Console.WriteLine ("Function EffectDamageIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static float RoundsToSeconds (int nRounds)
        {
            return nRounds * 6;
        }
        public static float HoursToSeconds (int nHours)
        {
            return nHours * 60 * 60;
        }
        public static float TurnsToSeconds (int nTurns)
        {
            return nTurns / 6;
        }
        public static void SoundObjectSetFixedVariance (AuroraObject oSound, float fFixedVariance)
        {
            Console.WriteLine ("Function SoundObjectSetFixedVariance not implemented");
            throw new NotImplementedException ();
        }
        public static int GetGoodEvilValue (AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetGoodEvilValue not implemented");
            throw new NotImplementedException ();
        }
        public static int GetPartyMemberCount ()
        {
            int count = 0;

            foreach (AuroraObject p in stateManager.party)
            {
                if (p != null)
                {
                    count += 1;
                }
            }

            return count;
        }
        public static int GetAlignmentGoodEvil (AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetAlignmentGoodEvil not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFirstObjectInShape (int nShape, float fSize, AuroraLocation lTarget, int bLineOfSight = 0, int nObjectFilter = 0, AuroraVector vOrigin = null)
        {
            //vOrigin = vOrigin ?? new float[] { 0.0f, 0.0f, 0.0f };
            Console.WriteLine ("Function GetFirstObjectInShape not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetNextObjectInShape (int nShape, float fSize, AuroraLocation lTarget, int bLineOfSight = 0, int nObjectFilter = 0, AuroraVector vOrigin = null)
        {
            //vOrigin = vOrigin ?? new float[] { 0.0f, 0.0f, 0.0f };
            Console.WriteLine ("Function GetNextObjectInShape not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectEntangle ()
        {
            Console.WriteLine ("Function EffectEntangle not implemented");
            throw new NotImplementedException ();
        }
        public static void SignalEvent (AuroraObject oObject, AuroraEvent evToRun)
        {
            // Schedule the event to trigger once the current script finishes
            stateManager.AddEvent(oObject, evToRun);
        }
        public static AuroraEvent EventUserDefined (int nUserDefinedEventNumber)
        {
            return new AuroraEvent(AuroraEvent.EventType.UserDefinedEvent, nUserDefinedEventNumber);
        }
        public static AuroraEffect EffectDeath (int nSpectacularDeath = 0, int nDisplayFeedback = 0)
        {
            Debug.LogWarning("Effects not yet implemented");
            return null;
            //Console.WriteLine ("Function EffectDeath not implemented");
            //throw new NotImplementedException ();
        }
        public static AuroraEffect EffectKnockdown ()
        {
            Console.WriteLine ("Function EffectKnockdown not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionGiveItem (AuroraObject oItem, AuroraObject oGiveTo)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionGiveItem(self, oItem, oGiveTo));
        }
        public static void ActionTakeItem (AuroraObject oItem, AuroraObject oTakeFrom)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionTakeItem(self, oItem, oTakeFrom));
        }
        public static AuroraVector VectorNormalize (AuroraVector vVector)
        {
            Vector3 norm = new Vector3(vVector.x, vVector.y, vVector.z);
            return new AuroraVector(norm.x, norm.y, norm.z);
        }
        public static int GetItemStackSize (AuroraObject oItem)
        {
            return oItem.stackSize;
        }
        public static int GetAbilityScore (AuroraObject oCreature, int nAbilityType)
        {
            Console.WriteLine ("Function GetAbilityScore not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsDead (AuroraObject oCreature)
        {
            return Convert.ToInt32(oCreature.isDead);
        }
        public static void PrintVector (AuroraVector vVector, int bPrepend)
        {
            Debug.Log(new Vector3(vVector.x, vVector.y, vVector.z));
        }
        public static AuroraVector Vector (float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            return new AuroraVector(x, y, z);
        }
        public static void SetFacingPoint (AuroraVector vTarget)
        {
            AuroraObject self = stateManager.GetObjectSelf();

            // Force the AuroraObject to look in this direction
            self.transform.LookAt(new Vector3(vTarget.x, vTarget.z, vTarget.y), Vector3.up);
        }
        public static AuroraVector AngleToVector (float fAngle)
        {
            Console.WriteLine ("Function AngleToVector not implemented");
            throw new NotImplementedException ();
        }
        public static float VectorToAngle (AuroraVector vVector)
        {
            Console.WriteLine ("Function VectorToAngle not implemented");
            throw new NotImplementedException ();
        }
        public static int TouchAttackMelee (AuroraObject oTarget, int bDisplayFeedback = 0)
        {
            Console.WriteLine ("Function TouchAttackMelee not implemented");
            throw new NotImplementedException ();
        }
        public static int TouchAttackRanged (AuroraObject oTarget, int bDisplayFeedback = 0)
        {
            Console.WriteLine ("Function TouchAttackRanged not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectParalyze ()
        {
            Console.WriteLine ("Function EffectParalyze not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectSpellImmunity (int nImmunityToSpell = 0)
        {
            Console.WriteLine ("Function EffectSpellImmunity not implemented");
            throw new NotImplementedException ();
        }
        public static void SetItemStackSize (AuroraObject oItem, int nStackSize)
        {
            oItem.stackSize = nStackSize;
        }
        public static float GetDistanceBetween (AuroraObject oObjectA, AuroraObject oObjectB)
        {
            return Vector3.Distance(oObjectA.transform.position, oObjectB.transform.position);
        }
        public static void SetReturnStrref (int bShow, int srStringRef = 0, int srReturnQueryStrRef = 0)
        {
            stateManager.returnShow = Convert.ToBoolean(bShow);
            stateManager.returnStrRef = srStringRef;
            stateManager.srReturnQueryStrRef = srReturnQueryStrRef;
        }
        public static AuroraEffect EffectForceJump (AuroraObject oTarget, int nAdvanced = 0)
        {
            Console.WriteLine ("Function EffectForceJump not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectSleep ()
        {
            Console.WriteLine ("Function EffectSleep not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetItemInSlot (int nInventorySlot, AuroraObject oCreature = null)
        {
            Debug.LogWarning("GetItemInSlot (and inventory in general) not yet implemented");
            oCreature = oCreature ?? stateManager.GetObjectSelf ();

            var equipped = ((AuroraUTC)oCreature.template).Equip_ItemList;
            foreach (var item in equipped)
            {
                if (item.structid == nInventorySlot)
                {
                    // Get the item
                    return null;
                }
            }

            return null;
        }
        public static AuroraEffect EffectTemporaryForcePoints (int nTempForce)
        {
            Console.WriteLine ("Function EffectTemporaryForcePoints not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectConfused ()
        {
            Console.WriteLine ("Function EffectConfused not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectFrightened ()
        {
            Console.WriteLine ("Function EffectFrightened not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectChoke ()
        {
            Console.WriteLine ("Function EffectChoke not implemented");
            throw new NotImplementedException ();
        }
        public static void SetGlobalString (string sIdentifier, string sValue)
        {
            Console.WriteLine ("Function SetGlobalString not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectStunned ()
        {
            Console.WriteLine ("Function EffectStunned not implemented");
            throw new NotImplementedException ();
        }
        public static void SetCommandable (int bCommandable, AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();

            if (oTarget.GetType() == typeof(Creature))
            {
                AuroraUTC utc = (AuroraUTC)oTarget.template;
                utc.Commandable = (byte)bCommandable;
            } else
            {
                Debug.LogWarning("SetCommandable not implemented for non-creature types yet");
            }
        }
        public static int GetCommandable (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();

            if (oTarget.GetType() == typeof(Creature))
            {
                AuroraUTC utc = (AuroraUTC)oTarget.template;
                return utc.Commandable;
            }
            else
            {
                Debug.LogWarning("GetCommandable not implemented for non-creature types yet; defaulting to 1");
                return 1;
            }
        }
        public static AuroraEffect EffectRegenerate (int nAmount, float fIntervalSeconds)
        {
            Console.WriteLine ("Function EffectRegenerate not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectMovementSpeedIncrease (int nNewSpeedPercent)
        {
            Console.WriteLine ("Function EffectMovementSpeedIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static int GetHitDice (AuroraObject oCreature)
        {
            // Gets the character level? Not 100% sure here
            return 1;
            //return ((AuroraUTC)oCreature.template).Level;
        }
        public static void ActionForceFollowObject (AuroraObject oFollow, float fFollowDistance = 0.0f)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionForceFollowObject(self, oFollow, fFollowDistance));
        }
        public static string GetTag (AuroraObject oObject)
        {
            // TODO: Use a proper check here, although I do think all templates have Tags
            dynamic template = oObject.template;
            return template.Tag;
        }
        public static int ResistForce (AuroraObject oSource, AuroraObject oTarget)
        {
            Console.WriteLine ("Function ResistForce not implemented");
            throw new NotImplementedException ();
        }
        public static int GetEffectType (AuroraEffect eEffect)
        {
            Console.WriteLine ("Function GetEffectType not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectAreaOfEffect (int nAreaEffectId, string sOnEnterScript = "", string sHeartbeatScript = "", string sOnExitScript = "")
        {
            Console.WriteLine ("Function EffectAreaOfEffect not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFactionEqual (AuroraObject oFirstObject, AuroraObject oSecondObject = null)
        {
            oSecondObject = oSecondObject ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFactionEqual not implemented");
            throw new NotImplementedException ();
        }
        public static void ChangeFaction (AuroraObject oObjectToChangeFaction, AuroraObject oMemberOfFactionToJoin)
        {
            Console.WriteLine ("Function ChangeFaction not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsListening (AuroraObject oObject)
        {
            return Convert.ToInt32(oObject.listening);
        }
        public static void SetListening (AuroraObject oObject, int bValue)
        {
            oObject.listening = Convert.ToBoolean(bValue);
        }
        public static void SetListenPattern (AuroraObject oObject, string sPattern, int nNumber = 0)
        {
            oObject.listenPattern = sPattern;
            oObject.listenNumber = nNumber;
        }
        public static int TestStringAgainstPattern (string sPattern, string sStringToTest)
        {
            Console.WriteLine ("Function TestStringAgainstPattern not implemented");
            throw new NotImplementedException ();
        }
        public static string GetMatchedSubstring (int nString)
        {
            Console.WriteLine ("Function GetMatchedSubstring not implemented");
            throw new NotImplementedException ();
        }
        public static int GetMatchedSubstringsCount ()
        {
            Console.WriteLine ("Function GetMatchedSubstringsCount not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectVisualEffect (int nVisualEffectId, int nMissEffect = 0)
        {
            Debug.LogWarning("Visual effects not implemented yet");
            return null;
        }
        public static AuroraObject GetFactionWeakestMember (AuroraObject oFactionMember = null, int bMustBeVisible = 0)
        {
            oFactionMember = oFactionMember ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFactionWeakestMember not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFactionStrongestMember (AuroraObject oFactionMember = null, int bMustBeVisible = 0)
        {
            oFactionMember = oFactionMember ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFactionStrongestMember not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFactionMostDamagedMember (AuroraObject oFactionMember = null, int bMustBeVisible = 0)
        {
            oFactionMember = oFactionMember ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFactionMostDamagedMember not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFactionLeastDamagedMember (AuroraObject oFactionMember = null, int bMustBeVisible = 0)
        {
            oFactionMember = oFactionMember ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFactionLeastDamagedMember not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFactionGold (AuroraObject oFactionMember)
        {
            Console.WriteLine ("Function GetFactionGold not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFactionAverageReputation (AuroraObject oSourceFactionMember, AuroraObject oTarget)
        {
            Console.WriteLine ("Function GetFactionAverageReputation not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFactionAverageGoodEvilAlignment (AuroraObject oFactionMember)
        {
            Console.WriteLine ("Function GetFactionAverageGoodEvilAlignment not implemented");
            throw new NotImplementedException ();
        }
        public static float SoundObjectGetFixedVariance (AuroraObject oSound)
        {
            Console.WriteLine ("Function SoundObjectGetFixedVariance not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFactionAverageLevel (AuroraObject oFactionMember)
        {
            Console.WriteLine ("Function GetFactionAverageLevel not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFactionAverageXP (AuroraObject oFactionMember)
        {
            Console.WriteLine ("Function GetFactionAverageXP not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFactionMostFrequentClass (AuroraObject oFactionMember)
        {
            Console.WriteLine ("Function GetFactionMostFrequentClass not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFactionWorstAC (AuroraObject oFactionMember = null, int bMustBeVisible = 0)
        {
            oFactionMember = oFactionMember ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFactionWorstAC not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFactionBestAC (AuroraObject oFactionMember = null, int bMustBeVisible = 0)
        {
            oFactionMember = oFactionMember ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFactionBestAC not implemented");
            throw new NotImplementedException ();
        }
        public static string GetGlobalString (string sIdentifier)
        {
            return stateManager.GetGlobalString(sIdentifier);
        }
        public static int GetListenPatternNumber ()
        {
            Debug.LogWarning("GetListenPatternNumber not yet implemented");
            return 0;
            //Console.WriteLine ("Function GetListenPatternNumber not implemented");
            //throw new NotImplementedException ();
        }
        public static void ActionJumpToObject (AuroraObject oToJumpTo, int bWalkStraightLineToPoint = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionJumpToObject(self, oToJumpTo, Convert.ToBoolean(bWalkStraightLineToPoint)));
        }
        public static AuroraObject GetWaypointByTag (string sWaypointTag)
        {
            return stateManager.GetObjectByTag(sWaypointTag);
        }
        public static AuroraObject GetTransitionTarget (AuroraObject oTransition)
        {
            Console.WriteLine ("Function GetTransitionTarget not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectLinkEffects (AuroraEffect eChildEffect, AuroraEffect eParentEffect)
        {
            Console.WriteLine ("Function EffectLinkEffects not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetObjectByTag (string sTag, int nNth = 0)
        {
            return stateManager.GetObjectByTag(sTag, nNth);
        }
        public static void AdjustAlignment (AuroraObject oSubject, int nAlignment, int nShift)
        {
            Console.WriteLine ("Function AdjustAlignment not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionWait (float fSeconds)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionWait(self, fSeconds));
        }
        public static void SetAreaTransitionBMP (int nPredefinedAreaTransition, string sCustomAreaTransitionBMP = "")
        {
            Console.WriteLine ("Function SetAreaTransitionBMP not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionStartConversation (AuroraObject oObjectToConverse, string sDialogResRef = "", int bPrivateConversation = 0, int nConversationType = 0, int bIgnoreStartRange = 0, string sNameObjectToIgnore1 = "", string sNameObjectToIgnore2 = "", string sNameObjectToIgnore3 = "", string sNameObjectToIgnore4 = "", string sNameObjectToIgnore5 = "", string sNameObjectToIgnore6 = "", int bUseLeader = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            Debug.Log("Adding action ActionStartConversation to " + self);

            self.AddAction(new ActionStartConversation(
                self,
                oObjectToConverse,
                sDialogResRef,
                Convert.ToBoolean(bPrivateConversation),
                nConversationType,
                Convert.ToBoolean(bIgnoreStartRange),
                sNameObjectToIgnore1,
                sNameObjectToIgnore2,
                sNameObjectToIgnore3,
                sNameObjectToIgnore4,
                sNameObjectToIgnore5,
                sNameObjectToIgnore6,
                Convert.ToBoolean(bUseLeader)
            ));
        }
        public static void ActionPauseConversation ()
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionPauseConversation(self));
        }
        public static void ActionResumeConversation ()
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionResumeConversation(self));
        }
        public static AuroraEffect EffectBeam (int nBeamVisualEffect, AuroraObject oEffector, int nBodyPart, int bMissEffect = 0)
        {
            Console.WriteLine ("Function EffectBeam not implemented");
            throw new NotImplementedException ();
        }
        public static int GetReputation (AuroraObject oSource, AuroraObject oTarget)
        {
            Debug.LogWarning("Reputation system not yet implemented");
            return 0;
        }
        public static void AdjustReputation (AuroraObject oTarget, AuroraObject oSourceFactionMember, int nAdjustment)
        {
            Debug.LogWarning("Reputation system not yet implemented");
        }
        public static string GetModuleFileName ()
        {
            return stateManager.currentModule.moduleName;
        }
        public static AuroraObject GetGoingToBeAttackedBy (AuroraObject oTarget)
        {
            Console.WriteLine ("Function GetGoingToBeAttackedBy not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForceResistanceIncrease (int nValue)
        {
            Console.WriteLine ("Function EffectForceResistanceIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraLocation GetLocation (AuroraObject oObject)
        {
            AuroraLocation loc = new AuroraLocation();
            loc.position = new Vector3(
                oObject.transform.position.x,
                oObject.transform.position.z,
                oObject.transform.position.y
            );

            return loc;
        }
        public static void ActionJumpToLocation (AuroraLocation lLocation)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionJumpToLocation(self, lLocation));
        }
        public static AuroraLocation Location (AuroraVector vPosition, float fOrientation)
        {
            Console.WriteLine ("Function Location not implemented");
            throw new NotImplementedException ();
        }
        public static void ApplyEffectAtLocation (int nDurationType, AuroraEffect eEffect, AuroraLocation lLocation, float fDuration = 0.0f)
        {
            //AuroraObject self = stateManager.GetObjectSelf();
            //self.AddAction(new ApplyEffectAtLocation(
            //    self,
            //    nDurationType,
            //    eEffect,
            //    lLocation,
            //    fDuration
            //));
        }
        public static int GetIsPC (AuroraObject oCreature)
        {
            return Convert.ToInt32(oCreature == stateManager.PC);
        }
        public static float FeetToMeters (float fFeet)
        {
            return fFeet * 0.3048f;
        }
        public static float YardsToMeters (float fYards)
        {
            return fYards * 0.9144f;
        }
        public static void ApplyEffectToObject (int nDurationType, AuroraEffect eEffect, AuroraObject oTarget, float fDuration = 0.0f)
        {
            //AuroraObject self = stateManager.GetObjectSelf();
            //self.AddAction(new ApplyEffectToObject(
            //    self,
            //    nDurationType,
            //    eEffect,
            //    oTarget,
            //    fDuration
            //));
        }

        public static void SpeakString (string sStringToSpeak, int nTalkVolume = 0)
        {
            stateManager.SpeakString(sStringToSpeak, nTalkVolume);
        }
        public static AuroraLocation GetSpellTargetLocation ()
        {
            Console.WriteLine ("Function GetSpellTargetLocation not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraVector GetPositionFromLocation (AuroraLocation lLocation)
        {
            Console.WriteLine ("Function GetPositionFromLocation not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectBodyFuel ()
        {
            Console.WriteLine ("Function EffectBodyFuel not implemented");
            throw new NotImplementedException ();
        }
        public static float GetFacingFromLocation (AuroraLocation lLocation)
        {
            Console.WriteLine ("Function GetFacingFromLocation not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetNearestCreatureToLocation (int nFirstCriteriaType, int nFirstCriteriaValue, AuroraLocation lLocation, int nNth = 1, int nSecondCriteriaType = -1, int nSecondCriteriaValue = -1, int nThirdCriteriaType = -1, int nThirdCriteriaValue = -1)
        {
            Console.WriteLine ("Function GetNearestCreatureToLocation not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetNearestObject (int nObjectType = 0, AuroraObject oTarget = null, int nNth = 1)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();

            return stateManager.Nearest(oTarget, objectTypes[nObjectType], nNth);
        }
        public static AuroraObject GetNearestObjectToLocation (int nObjectType, AuroraLocation lLocation, int nNth = 1)
        {
            return stateManager.Nearest(lLocation, objectTypes[nObjectType], nNth);
        }
        public static AuroraObject GetNearestObjectByTag (string sTag, AuroraObject oTarget = null, int nNth = 1)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            return stateManager.GetClosestObjectByTag(sTag, oTarget, nNth);
        }
        public static float IntToFloat (int nInteger)
        {
            return (float)nInteger;
        }
        public static int FloatToInt (float fFloat)
        {
            return (int)Math.Round(fFloat);
        }
        public static int StringToInt (string sNumber)
        {
            return int.Parse(sNumber);
        }
        public static float StringToFloat (string sNumber)
        {
            return float.Parse(sNumber);
        }
        public static void ActionCastSpellAtLocation (int nSpell, AuroraLocation lTargetLocation, int nMetaMagic = 0, int bCheat = 0, int nProjectilePathType = 0, int bInstantSpell = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionCastSpellAtLocation(self, nSpell, lTargetLocation, nMetaMagic, Convert.ToBoolean(bCheat), nProjectilePathType, Convert.ToBoolean(bInstantSpell)));
        }
        public static int GetIsEnemy (AuroraObject oTarget, AuroraObject oSource = null)
        {
            // Need to figure out the rules behind this - should be simple for K1/K2 as there's no reputation system (so should be
            // as easy as "friend or foe").
            // NWN Lexicon: "This function considers faction feeling as well as personal reputation between the two creatures."
            
            oSource = oSource ?? stateManager.GetObjectSelf ();

            int sourceFaction = ((AuroraUTC)oSource.template).FactionID;
            int targetFaction = ((AuroraUTC)oTarget.template).FactionID;

            return (sourceFaction == targetFaction) ? 0 : 1;
        }
        public static int GetIsFriend (AuroraObject oTarget, AuroraObject oSource = null)
        {
            oSource = oSource ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetIsFriend not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsNeutral (AuroraObject oTarget, AuroraObject oSource = null)
        {
            oSource = oSource ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetIsNeutral not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetPCSpeaker ()
        {
            // TODO: Detect whether the player is in a dialog, and if they're not
            // return OBJECT_INVALID
            return stateManager.PC;
        }
        public static string GetStringByStrRef (int nStrRef)
        {
            return AuroraEngine.Resources.GetString(nStrRef);
        }
        public static void ActionSpeakStringByStrRef (int nStrRef, int nTalkVolume = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionSpeakStringByStrRef(self, nStrRef, nTalkVolume));
        }
        public static void DestroyObject (AuroraObject oDestroy, float fDelay = 0.0f, int bNoFade = 0, float fDelayUntilFade = 0.0f)
        {
            Debug.LogWarning("DestroyObject not yet implemented");
        }
        public static AuroraObject GetModule ()
        {
            Console.WriteLine ("Function GetModule not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject CreateObject (int nObjectType, string sTemplate, AuroraLocation lLocation, int bUseAppearAnimation = 0)
        {
            return stateManager.CreateObject(nObjectType, sTemplate, lLocation, bUseAppearAnimation);
        }
        public static AuroraEvent EventSpellCastAt (AuroraObject oCaster, int nSpell, int bHarmful = 0)
        {
            Console.WriteLine ("Function EventSpellCastAt not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastSpellCaster ()
        {
            Console.WriteLine ("Function GetLastSpellCaster not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLastSpell ()
        {
            Console.WriteLine ("Function GetLastSpell not implemented");
            throw new NotImplementedException ();
        }
        public static int GetUserDefinedEventNumber ()
        {
            return stateManager.userDefinedEventNumbers.Last();
        }
        public static int GetSpellId ()
        {
            Console.WriteLine ("Function GetSpellId not implemented");
            throw new NotImplementedException ();
        }
        public static string RandomName ()
        {
            Console.WriteLine ("Function RandomName not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectPoison (int nPoisonType)
        {
            Console.WriteLine ("Function EffectPoison not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLoadFromSaveGame ()
        {
            Debug.LogWarning("GetLoadFromSaveGame not yet implemented");
            return 0;
            //Console.WriteLine ("Function GetLoadFromSaveGame not implemented");
            //throw new NotImplementedException ();
        }
        public static AuroraEffect EffectAssuredDeflection (int nReturn = 0)
        {
            Console.WriteLine ("Function EffectAssuredDeflection not implemented");
            throw new NotImplementedException ();
        }
        public static string GetName (AuroraObject obj)
        {
            if (obj == null)
            {
                // TODO: Not sure if this is intended behaviour
                return "";
            }
            string objName = "Object";
            if (obj.GetType() == typeof(Creature))
            {
                string firstName = AuroraEngine.Resources.GetString((int)((AuroraUTC)obj.template).FirstName.stringref);
                string lastName = AuroraEngine.Resources.GetString((int)((AuroraUTC)obj.template).LastName.stringref);
                objName = firstName + (lastName != "" ? (" " + lastName) : "");
            }
            else if (obj.GetType() == typeof(Door))
            {
                objName = AuroraEngine.Resources.GetString((int)((AuroraUTD)obj.template).LocName.stringref);
            }
            else if (obj.GetType() == typeof(Placeable))
            {
                objName = AuroraEngine.Resources.GetString((int)((AuroraUTP)obj.template).LocName.stringref);
            }
            return objName;
        }
        public static AuroraObject GetLastSpeaker ()
        {
            /* From NWN Lexicon:
               If called within a conversation (e.g., as part of the "StartingConditional" script for a PC line of text 
               AFTER the NPC has spoken previously), the function will not return the last NPC speaker, but will return OBJECT_INVALID.

              The value is apparently set after the whole conversation with an NPC is completed, not after each line 
              of conversation. This means you can't use this function during a conversation to grab the tag of the NPC that is speaking.
            */

            
            Debug.LogWarning("GetLastSpeaker not yet implemented");
            return null;
        }
        public static int BeginConversation (string sResRef = "", AuroraObject oObjectToDialog = null)
        {
            oObjectToDialog = oObjectToDialog ?? AuroraObject.GetObjectInvalid ();
            Console.WriteLine ("Function BeginConversation not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastPerceived ()
        {
            AuroraObject self = stateManager.GetObjectSelf();
            
            return self.lastPerceived;
        }
        public static int GetLastPerceptionHeard ()
        {
            // Hearing perception is not used in KotOR
            return 0;
        }
        public static int GetLastPerceptionInaudible ()
        {
            return 0;
        }
        public static int GetLastPerceptionSeen ()
        {
            return 1;
        }
        public static AuroraObject GetLastClosedBy ()
        {
            Console.WriteLine ("Function GetLastClosedBy not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLastPerceptionVanished ()
        {
            return Convert.ToInt32(stateManager.GetObjectSelf().lastPerceptionVanished);
        }
        public static AuroraObject GetFirstInPersistentObject (AuroraObject oPersistentObject = null, int nResidentObjectType = 0, int nPersistentZone = 0)
        {
            oPersistentObject = oPersistentObject ?? stateManager.GetObjectSelf ();

            return stateManager.FirstPersistentObject(oPersistentObject, nResidentObjectType, nPersistentZone);
        }
        public static AuroraObject GetNextInPersistentObject (AuroraObject oPersistentObject = null, int nResidentObjectType = 0, int nPersistentZone = 0)
        {
            return stateManager.NextPersistentObject();
        }
        public static AuroraObject GetAreaOfEffectCreator (AuroraObject oAreaOfEffectObject = null)
        {
            oAreaOfEffectObject = oAreaOfEffectObject ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetAreaOfEffectCreator not implemented");
            throw new NotImplementedException ();
        }
        public static int ShowLevelUpGUI ()
        {
            Console.WriteLine ("Function ShowLevelUpGUI not implemented");
            throw new NotImplementedException ();
        }
        public static void SetItemNonEquippable (AuroraObject oItem, int bNonEquippable)
        {
            Console.WriteLine ("Function SetItemNonEquippable not implemented");
            throw new NotImplementedException ();
        }
        public static int GetButtonMashCheck ()
        {
            Console.WriteLine ("Function GetButtonMashCheck not implemented");
            throw new NotImplementedException ();
        }
        public static void SetButtonMashCheck (int nCheck)
        {
            Console.WriteLine ("Function SetButtonMashCheck not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForcePushTargeted (AuroraLocation lCentre, int nIgnoreTestDirectLine = 0)
        {
            Debug.LogWarning ("Function EffectForcePushTargeted not implemented");
            return null;
            //throw new NotImplementedException ();
        }
        public static AuroraEffect EffectHaste ()
        {
            Debug.LogWarning("Function AuroraEffect not implemented");
            return null;
        }
        public static void GiveItem (AuroraObject oItem, AuroraObject oGiveTo)
        {
            Console.WriteLine ("Function GiveItem not implemented");
            throw new NotImplementedException ();
        }
        public static string ObjectToString (AuroraObject oObject)
        {
            if (oObject == null)
            {
                return "7f000000";
            }

            // TODO: Implement ObjectToString
            return "00000000";
            //return oObject.ToString();
        }
        public static AuroraEffect EffectImmunity (int nImmunityType)
        {
            Console.WriteLine ("Function EffectImmunity not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsImmune (AuroraObject oCreature, int nImmunityType, AuroraObject oVersus = null)
        {
            oVersus = oVersus ?? AuroraObject.GetObjectInvalid ();
            Console.WriteLine ("Function GetIsImmune not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDamageImmunityIncrease (int nDamageType, int nPercentImmunity)
        {
            Console.WriteLine ("Function EffectDamageImmunityIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static int GetEncounterActive (AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetEncounterActive not implemented");
            throw new NotImplementedException ();
        }
        public static void SetEncounterActive (int nNewValue, AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SetEncounterActive not implemented");
            throw new NotImplementedException ();
        }
        public static int GetEncounterSpawnsMax (AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetEncounterSpawnsMax not implemented");
            throw new NotImplementedException ();
        }
        public static void SetEncounterSpawnsMax (int nNewValue, AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SetEncounterSpawnsMax not implemented");
            throw new NotImplementedException ();
        }
        public static int GetEncounterSpawnsCurrent (AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetEncounterSpawnsCurrent not implemented");
            throw new NotImplementedException ();
        }
        public static void SetEncounterSpawnsCurrent (int nNewValue, AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SetEncounterSpawnsCurrent not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetModuleItemAcquired ()
        {
            Console.WriteLine ("Function GetModuleItemAcquired not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetModuleItemAcquiredFrom ()
        {
            Console.WriteLine ("Function GetModuleItemAcquiredFrom not implemented");
            throw new NotImplementedException ();
        }
        public static void SetCustomToken (int nCustomTokenNumber, string sTokenValue)
        {
            dialogSystem.SetCustomToken(nCustomTokenNumber, sTokenValue);
            Console.WriteLine ("Function SetCustomToken not implemented");
            throw new NotImplementedException ();
        }
        public static int GetHasFeat (int nFeat, AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            foreach (AuroraUTC.AFeat feat in ((AuroraUTC)oCreature.template).FeatList)
            {
                // TODO: Not convinced by this
                if (feat.structid == nFeat)
                {
                    return 1;
                }
            }
            return 0;
        }
        public static int GetHasSkill (int nSkill, AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            Debug.Log(oCreature);
            foreach (AuroraUTC.ASkill skill in ((AuroraUTC)oCreature.template).SkillList)
            {
                // TODO: Not convinced by this
                if (skill.structid == nSkill)
                {
                    return 1;
                }
            }
            return 0;
        }
        public static void ActionUseFeat (int nFeat, AuroraObject oTarget)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionUseFeat(self, nFeat, oTarget));
        }
        public static void ActionUseSkill (int nSkill, AuroraObject oTarget, int nSubSkill = 0, AuroraObject oItemUsed = null)
        {
            oItemUsed = oItemUsed ?? AuroraObject.GetObjectInvalid ();
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionUseSkill(self, nSkill, oTarget, nSubSkill, oItemUsed));
        }
        public static int GetObjectSeen (AuroraObject oTarget, AuroraObject oSource = null)
        {
            // Can oSource see oTarget?
            oSource = oSource ?? stateManager.GetObjectSelf ();

            return (Convert.ToInt32(oSource.SeesObject(oTarget)));
        }
        public static int GetObjectHeard (AuroraObject oTarget, AuroraObject oSource = null)
        {
            oSource = oSource ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetObjectHeard not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastPlayerDied ()
        {
            Console.WriteLine ("Function GetLastPlayerDied not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetModuleItemLost ()
        {
            Console.WriteLine ("Function GetModuleItemLost not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetModuleItemLostBy ()
        {
            Console.WriteLine ("Function GetModuleItemLostBy not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionDoCommand (NCSContext action)
        {
            // This allows functions to be run like commands (in the command queue of an AuroraObject)
            // So, we have to create a new command which runs the given function

            AuroraObject self = stateManager.GetObjectSelf();

            ActionObjDoCommand cmd = new ActionObjDoCommand(self, action);
            self.actions.Add(cmd);
        }
        public static AuroraEvent EventConversation ()
        {
            Console.WriteLine ("Function EventConversation not implemented");
            throw new NotImplementedException ();
        }
        public static void SetEncounterDifficulty (int nEncounterDifficulty, AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SetEncounterDifficulty not implemented");
            throw new NotImplementedException ();
        }
        public static int GetEncounterDifficulty (AuroraObject oEncounter = null)
        {
            oEncounter = oEncounter ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetEncounterDifficulty not implemented");
            throw new NotImplementedException ();
        }
        public static float GetDistanceBetweenLocations (AuroraLocation lLocationA, AuroraLocation lLocationB)
        {
            return Vector3.Distance(lLocationA.position, lLocationB.position);
        }
        public static int GetReflexAdjustedDamage (int nDamage, AuroraObject oTarget, int nDC, int nSaveType = 0, AuroraObject oSaveVersus = null)
        {
            oSaveVersus = oSaveVersus ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetReflexAdjustedDamage not implemented");
            throw new NotImplementedException ();
        }
        public static void PlayAnimation (int nAnimation, float fSpeed = 1.0f, float fSeconds = 0.0f)
        {
            // TODO: Use fSpeed and fSeconds
            stateManager.GetObjectSelf().PlayAnimation(nAnimation);
        }
        public static AuroraTalent TalentSpell (int nSpell)
        {
            return new AuroraTalent(stateManager.GetObjectSelf(), nSpell, AuroraTalent.TalentType.SPELL);
        }
        public static AuroraTalent TalentFeat (int nFeat)
        {
            return new AuroraTalent(stateManager.GetObjectSelf(), nFeat, AuroraTalent.TalentType.FEAT);
        }
        public static AuroraTalent TalentSkill (int nSkill)
        {
            return new AuroraTalent(stateManager.GetObjectSelf(), nSkill, AuroraTalent.TalentType.SKILL);
        }
        public static int GetHasSpellEffect (int nSpell, AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetHasSpellEffect not implemented");
            throw new NotImplementedException ();
        }
        public static int GetEffectSpellId (AuroraEffect eSpellEffect)
        {
            Console.WriteLine ("Function GetEffectSpellId not implemented");
            throw new NotImplementedException ();
        }
        public static int GetCreatureHasTalent (AuroraTalent tTalent, AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf();

            switch (tTalent.talentType)
            {
                case AuroraTalent.TalentType.FEAT:
                    return GetHasFeat(tTalent.id, oCreature);
                case AuroraTalent.TalentType.SKILL:
                    // TODO: What exactly to do here?
                    throw new Exception("Unsure what to do with TalentType = SKILL");
                case AuroraTalent.TalentType.SPELL:
                    return GetHasSpell(tTalent.id, oCreature);
            }

            return 0;
        }
        public static AuroraTalent GetCreatureTalentRandom (int nCategory, AuroraObject oCreature = null, int nInclusion = 0)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetCreatureTalentRandom not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraTalent GetCreatureTalentBest (int nCategory, int nCRMax, AuroraObject oCreature = null, int nInclusion = 0, int nExcludeType = -1, int nExcludeId = -1)
        {
            Debug.LogWarning("GetCreatureTalentBest returns feat -1 for now...");
            oCreature = oCreature ?? stateManager.GetObjectSelf();
            return new AuroraTalent(oCreature, -1, AuroraTalent.TalentType.FEAT);
            //Console.WriteLine ("Function GetCreatureTalentBest not implemented");
            //throw new NotImplementedException ();
        }
        public static void ActionUseTalentOnObject (AuroraTalent tChosenTalent, AuroraObject oTarget)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionUseTalentOnObject(self, tChosenTalent, oTarget));
        }
        public static void ActionUseTalentAtLocation (AuroraTalent tChosenTalent, AuroraLocation lTargetLocation)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionUseTalentAtLocation(self, tChosenTalent, lTargetLocation));
        }
        public static int GetGoldPieceValue (AuroraObject oItem)
        {
            return (int)((AuroraUTI)oItem.template).Cost;
        }
        public static int GetIsPlayableRacialType (AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetIsPlayableRacialType not implemented");
            throw new NotImplementedException ();
        }
        public static void JumpToLocation (AuroraLocation lDestination)
        {
            stateManager.GetObjectSelf().transform.position = lDestination.GetVector();
        }
        public static AuroraEffect EffectTemporaryHitpoints (int nHitPoints)
        {
            Console.WriteLine ("Function EffectTemporaryHitpoints not implemented");
            throw new NotImplementedException ();
        }
        public static int GetSkillRank (int nSkill, AuroraObject oTarget = null)
        {
            // TODO: Make sure this is correct - I'm not sure if structid is what I'm wanting to compare to,
            // but what else is there?
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            AuroraUTC utc = ((AuroraUTC)oTarget.template);
            foreach (AuroraUTC.ASkill skill in utc.SkillList)
            {
                if (skill.structid == nSkill)
                {
                    return skill.Rank;
                }
            }

            return 0;
        }
        public static AuroraObject GetAttackTarget (AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            return oCreature.attackTarget;
        }
        public static int GetLastAttackType (AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetLastAttackType not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLastAttackMode (AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            return oCreature.lastAttackMode;
        }
        public static float GetDistanceBetween2D (AuroraObject oObjectA, AuroraObject oObjectB)
        {
            // Seems this behaviour is relied upon by the walkways script?
            if (oObjectA == null || oObjectB == null)
            {
                return -1f;
            }

            return Vector2.Distance(
                new Vector2(oObjectA.transform.position.x, oObjectB.transform.position.z),
                new Vector2(oObjectA.transform.position.x, oObjectB.transform.position.z)
            );
        }
        public static int GetIsInCombat (AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            return Convert.ToInt32(oCreature.inCombat);
        }
        public static int GetLastAssociateCommand (AuroraObject oAssociate = null)
        {
            oAssociate = oAssociate ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetLastAssociateCommand not implemented");
            throw new NotImplementedException ();
        }
        public static void GiveGoldToCreature (AuroraObject oCreature, int nGP)
        {
            oCreature.gold += nGP;
        }
        public static void SetIsDestroyable (int bDestroyable, int bRaiseable = 0, int bSelectableWhenDead = 0)
        {
            AuroraUTC template = (AuroraUTC)stateManager.GetObjectSelf().template;
            template.IsDestroyable = (byte)bDestroyable;
            template.IsRaiseable = (byte)bRaiseable;
            template.DeadSelectable = (byte)bSelectableWhenDead;
        }
        public static void SetLocked (AuroraObject oTarget, int bLocked)
        {
            oTarget.locked = Convert.ToBoolean(bLocked);
        }
        public static int GetLocked (AuroraObject oTarget)
        {
            return Convert.ToInt32(oTarget.locked);
        }
        public static AuroraObject GetClickingObject ()
        {
            return stateManager.GetObjectSelf().clickingObject;
        }
        public static void SetAssociateListenPatterns (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SetAssociateListenPatterns not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastWeaponUsed (AuroraObject oCreature)
        {
            return oCreature.lastWeaponUsed;
        }
        public static void ActionInteractObject (AuroraObject oPlaceable)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionInteractObject(self, oPlaceable));
        }
        public static AuroraObject GetLastUsedBy ()
        {
            return stateManager.GetObjectSelf().lastUsedBy;
        }
        public static int GetAbilityModifier (int nAbility, AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetAbilityModifier not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIdentified (AuroraObject oItem)
        {
            return Convert.ToInt32(oItem.identified);
        }
        public static void SetIdentified (AuroraObject oItem, int bIdentified)
        {
            oItem.identified = Convert.ToBoolean(bIdentified);
        }
        public static float GetDistanceBetweenLocations2D (AuroraLocation lLocationA, AuroraLocation lLocationB)
        {
            return Vector2.Distance(
                new Vector2(lLocationA.position.x, lLocationA.position.y),
                new Vector2(lLocationB.position.x, lLocationB.position.y)
            );
        }
        public static float GetDistanceToObject2D (AuroraObject oObject)
        {
            AuroraObject self = stateManager.GetObjectSelf();

            // Seems this behaviour is relied upon by the walkways script?
            if (oObject == null || self == null)
            {
                return -1f;
            }

            return Vector2.Distance(
                new Vector2(oObject.transform.position.x, oObject.transform.position.z),
                new Vector2(self.transform.position.x, self.transform.position.z)
            );
        }
        public static AuroraObject GetBlockingDoor ()
        {
            Console.WriteLine ("Function GetBlockingDoor not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsDoorActionPossible (AuroraObject oTargetDoor, int nDoorAction)
        {
            Console.WriteLine ("Function GetIsDoorActionPossible not implemented");
            throw new NotImplementedException ();
        }
        public static void DoDoorAction (AuroraObject oTargetDoor, int nDoorAction)
        {
            Console.WriteLine ("Function DoDoorAction not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFirstItemInInventory (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFirstItemInInventory not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetNextItemInInventory (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetNextItemInInventory not implemented");
            throw new NotImplementedException ();
        }
        public static int GetClassByPosition (int nClassPosition, AuroraObject oCreature = null)
        {
            // TODO: Not convinced this is correct...
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            return 0;
            //return ((AuroraUTC)oCreature.template).ClassList[nClassPosition].Class;
        }
        public static int GetLevelByPosition (int nClassPosition, AuroraObject oCreature = null)
        {
            // Same concern as GetClassByPosit4ion
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            return 1;
            //return ((AuroraUTC)oCreature.template).ClassList[nClassPosition].ClassLevel;
        }
        public static int GetLevelByClass (int nClassType, AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();

            AuroraUTC template = ((AuroraUTC)oCreature.template);
            foreach (AuroraUTC.AClass cls in template.ClassList)
            {
                if (cls.Class != nClassType)
                {
                    continue;
                }

                return cls.ClassLevel;
            }

            return 0;
        }
        public static int GetDamageDealtByType (int nDamageType)
        {
            Console.WriteLine ("Function GetDamageDealtByType not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTotalDamageDealt ()
        {
            Console.WriteLine ("Function GetTotalDamageDealt not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastDamager ()
        {
            return stateManager.GetObjectSelf().lastDamager;
        }
        public static AuroraObject GetLastDisarmed ()
        {
            return stateManager.GetObjectSelf().lastDisarmed;
        }
        public static AuroraObject GetLastDisturbed ()
        {
            return stateManager.GetObjectSelf().lastDisturbed;
        }
        public static AuroraObject GetLastLocked ()
        {
            return stateManager.GetObjectSelf().lastLocked;
        }
        public static AuroraObject GetLastUnlocked ()
        {
            return stateManager.GetObjectSelf().lastUnlocked;
        }
        public static AuroraEffect EffectSkillIncrease (int nSkill, int nValue)
        {
            Console.WriteLine ("Function EffectSkillIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static int GetInventoryDisturbType ()
        {
            Console.WriteLine ("Function GetInventoryDisturbType not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetInventoryDisturbItem ()
        {
            Console.WriteLine ("Function GetInventoryDisturbItem not implemented");
            throw new NotImplementedException ();
        }
        public static void ShowUpgradeScreen (AuroraObject oItem = null)
        {
            oItem = oItem ?? AuroraObject.GetObjectInvalid ();
            Console.WriteLine ("Function ShowUpgradeScreen not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect VersusAlignmentEffect (AuroraEffect eEffect, int nLawChaos = 0, int nGoodEvil = 0)
        {
            Console.WriteLine ("Function VersusAlignmentEffect not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect VersusRacialTypeEffect (AuroraEffect eEffect, int nRacialType)
        {
            Console.WriteLine ("Function VersusRacialTypeEffect not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect VersusTrapEffect (AuroraEffect eEffect)
        {
            Console.WriteLine ("Function VersusTrapEffect not implemented");
            throw new NotImplementedException ();
        }
        public static int GetGender (AuroraObject oCreature)
        {
            return ((AuroraUTC)oCreature.template).Gender;
        }
        public static int GetIsTalentValid (AuroraTalent tTalent)
        {
            // TODO: I think I can make this convention up myself but not 100% sure
            return tTalent.id >= 0 ? 1 : 0;
        }
        public static void ActionMoveAwayFromLocation (AuroraLocation lMoveAwayFrom, int bRun = 0, float fMoveAwayRange = 40.0f)
        {
            Debug.LogWarning("ActionMoveAwayFromLocation not yet implemented");
            //AuroraObject self = stateManager.GetObjectSelf();
            //self.AddAction(new ActionMoveAwayFromLocation(self, lMoveAwayFrom, Convert.ToBoolean(bRun), fMoveAwayRange));
        }
        public static AuroraObject GetAttemptedAttackTarget ()
        {
            return stateManager.GetObjectSelf().attemptedAttackTarget;
        }
        public static int GetTypeFromTalent (AuroraTalent tTalent)
        {
            Console.WriteLine ("Function GetTypeFromTalent not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIdFromTalent (AuroraTalent tTalent)
        {
            Console.WriteLine ("Function GetIdFromTalent not implemented");
            throw new NotImplementedException ();
        }
        public static void PlayPazaak (int nOpponentPazaakDeck, string sEndScript, int nMaxWager, int bShowTutorial = 0, AuroraObject oOpponent = null)
        {
            oOpponent = oOpponent ?? AuroraObject.GetObjectInvalid ();
            Console.WriteLine ("Function PlayPazaak not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLastPazaakResult ()
        {
            Console.WriteLine ("Function GetLastPazaakResult not implemented");
            throw new NotImplementedException ();
        }
        public static void DisplayFeedBackText (AuroraObject oCreature, int nTextConstant)
        {
            Console.WriteLine ("Function DisplayFeedBackText not implemented");
            throw new NotImplementedException ();
        }
        public static void AddJournalQuestEntry (string szPlotID, int nState, int bAllowOverrideHigher = 0)
        {
            Console.WriteLine ("Function AddJournalQuestEntry not implemented");
            throw new NotImplementedException ();
        }
        public static void RemoveJournalQuestEntry (string szPlotID)
        {
            Console.WriteLine ("Function RemoveJournalQuestEntry not implemented");
            throw new NotImplementedException ();
        }
        public static int GetJournalEntry (string szPlotID)
        {
            Console.WriteLine ("Function GetJournalEntry not implemented");
            throw new NotImplementedException ();
        }
        public static int PlayRumblePattern (int nPattern)
        {
            //Gamepad.current.SetMotorSpeeds(0.5f, 0.5f);
            Debug.LogWarning("Rumble pattern not yet implemented");
            return 0;
        }
        public static int StopRumblePattern (int nPattern)
        {
            //Gamepad.current.SetMotorSpeeds(0f, 0f);
            Debug.LogWarning("Rumble pattern not yet implemented");
            return 0;
        }
        public static AuroraEffect EffectDamageForcePoints (int nDamage)
        {
            Console.WriteLine ("Function EffectDamageForcePoints not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectHealForcePoints (int nHeal)
        {
            Console.WriteLine ("Function EffectHealForcePoints not implemented");
            throw new NotImplementedException ();
        }
        public static void SendMessageToPC (AuroraObject oPlayer, string szMessage)
        {
            Console.WriteLine ("Function SendMessageToPC not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetAttemptedSpellTarget ()
        {
            return stateManager.GetObjectSelf().attemptedSpellTarget;
        }
        public static AuroraObject GetLastOpenedBy ()
        {
            return stateManager.GetObjectSelf().lastOpenedBy;
            Console.WriteLine ("Function GetLastOpenedBy not implemented");
            throw new NotImplementedException ();
        }
        public static int GetHasSpell (int nSpell, AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            AuroraUTC utc = (AuroraUTC)oCreature.template;

            foreach (AuroraUTC.AClass cls in utc.ClassList)
            {
                foreach (AuroraUTC.AClass.AKnown0 known in cls.KnownList0)
                {
                    if (known.Spell == nSpell)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }
        public static void OpenStore (AuroraObject oStore, AuroraObject oPC, int nBonusMarkUp = 0, int nBonusMarkDown = 0)
        {
            Console.WriteLine ("Function OpenStore not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionSurrenderToEnemies ()
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionSurrenderToEnemies(self));
        }
        public static AuroraObject GetFirstFactionMember (AuroraObject oMemberOfFaction, int bPCOnly = 0)
        {
            Console.WriteLine ("Function GetFirstFactionMember not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetNextFactionMember (AuroraObject oMemberOfFaction, int bPCOnly = 0)
        {
            Console.WriteLine ("Function GetNextFactionMember not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionForceMoveToLocation (AuroraLocation lDestination, int bRun = 0, float fTimeout = 30.0f)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionForceMoveToLocation(self, lDestination, Convert.ToBoolean(bRun), fTimeout));
        }
        public static void ActionForceMoveToObject (AuroraObject oMoveTo, int bRun = 0, float fRange = 1.0f, float fTimeout = 30.0f)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionForceMoveToObject(self, oMoveTo, Convert.ToBoolean(bRun), fRange, fTimeout));
        }
        public static int GetJournalQuestExperience (string szPlotID)
        {
            Console.WriteLine ("Function GetJournalQuestExperience not implemented");
            throw new NotImplementedException ();
        }
        public static void JumpToObject (AuroraObject oToJumpTo, int nWalkStraightLineToPoint = 1)
        {
            stateManager.GetObjectSelf().actions.Insert(0, new ActionJumpToObject(
                stateManager.GetObjectSelf(), 
                oToJumpTo, 
                Convert.ToBoolean(nWalkStraightLineToPoint)
                )
            );
        }

        public static void SetMapPinEnabled (AuroraObject oMapPin, int nEnabled)
        {
            ((AuroraUTW)oMapPin.template).MapNoteEnabled = (byte)nEnabled;
        }
        public static AuroraEffect EffectHitPointChangeWhenDying (float fHitPointChangePerRound)
        {
            Console.WriteLine ("Function EffectHitPointChangeWhenDying not implemented");
            throw new NotImplementedException ();
        }
        public static void PopUpGUIPanel (AuroraObject oPC, int nGUIPanel)
        {
            Console.WriteLine ("Function PopUpGUIPanel not implemented");
            throw new NotImplementedException ();
        }
        public static void AddMultiClass (int nClassType, AuroraObject oSource)
        {
            Console.WriteLine ("Function AddMultiClass not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsLinkImmune (AuroraObject oTarget, AuroraEffect eEffect)
        {
            Console.WriteLine ("Function GetIsLinkImmune not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDroidStun ()
        {
            Console.WriteLine ("Function EffectDroidStun not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForcePushed ()
        {
            Console.WriteLine ("Function EffectForcePushed not implemented");
            throw new NotImplementedException ();
        }
        public static void GiveXPToCreature (AuroraObject oCreature, int nXpAmount)
        {
            // TODO: Have to add an Experience field to AuroraUTC;
            // this should be automatically generated once save game reading is implemented
            Console.WriteLine("Function GiveXPToCreature not implemented");
            throw new NotImplementedException();
        }
        public static void SetXP (AuroraObject oCreature, int nXpAmount)
        {
            // TODO: Have to add an Experience field to AuroraUTC;
            // this should be automatically generated once save game reading is implemented
            return;
        }
        public static int GetXP (AuroraObject oCreature)
        {
            // TODO: Have to add an Experience field to AuroraUTC;
            // this should be automatically generated once save game reading is implemented
            return 0;
        }
        public static string IntToHexString (int nInteger)
        {
            return nInteger.ToString("X8");
        }
        public static int GetBaseItemType (AuroraObject oItem)
        {
            return oItem.baseItemType;
        }
        public static int GetItemHasItemProperty (AuroraObject oItem, int nProperty)
        {
            Console.WriteLine("Function GetItemHasItemProperty not implemented");
            throw new NotImplementedException();
            //((AuroraUTI)oItem.template).PropertiesList[0].
            //return Convert.ToInt32(oItem.properties.Contains(nProperty));
        }
        public static void ActionEquipMostDamagingMelee (AuroraObject oVersus = null, int bOffHand = 0)
        {
            oVersus = oVersus ?? AuroraObject.GetObjectInvalid ();
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionEquipMostDamagingMelee(self, oVersus, Convert.ToBoolean(bOffHand)));
        }
        public static void ActionEquipMostDamagingRanged (AuroraObject oVersus = null)
        {
            oVersus = oVersus ?? AuroraObject.GetObjectInvalid();
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionEquipMostDamagingRanged(self, oVersus));
        }
        public static int GetItemACValue (AuroraObject oItem)
        {
            Console.WriteLine ("Function GetItemACValue not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForceResisted (AuroraObject oSource)
        {
            Console.WriteLine ("Function EffectForceResisted not implemented");
            throw new NotImplementedException ();
        }
        public static void ExploreAreaForPlayer (AuroraObject oArea, AuroraObject oPlayer)
        {
            Console.WriteLine ("Function ExploreAreaForPlayer not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionEquipMostEffectiveArmor ()
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionEquipMostEffectiveArmor(self));
        }
        public static int GetIsDay ()
        {
            Console.WriteLine ("Function GetIsDay not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsNight ()
        {
            Console.WriteLine ("Function GetIsNight not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsDawn ()
        {
            Console.WriteLine ("Function GetIsDawn not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsDusk ()
        {
            Console.WriteLine ("Function GetIsDusk not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsEncounterCreature (AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            return Convert.ToInt32(oCreature.isEncounterCreature);
        }
        public static AuroraObject GetLastPlayerDying ()
        {
            Console.WriteLine ("Function GetLastPlayerDying not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraLocation GetStartingLocation ()
        {
            Console.WriteLine ("Function GetStartingLocation not implemented");
            throw new NotImplementedException ();
        }
        public static void ChangeToStandardFaction (AuroraObject oCreatureToChange, int nStandardFaction)
        {
            ((AuroraUTC)oCreatureToChange.template).FactionID = (ushort)nStandardFaction;
        }
        public static void SoundObjectPlay (AuroraObject oSound)
        {
            Debug.LogWarning("Playing object sounds not yet implemented");
        }
        public static void SoundObjectStop (AuroraObject oSound)
        {
            Debug.LogWarning("Sounds not yet implemented");
            //Console.WriteLine ("Function SoundObjectStop not implemented");
            //throw new NotImplementedException ();
        }
        public static void SoundObjectSetVolume (AuroraObject oSound, int nVolume)
        {
            Console.WriteLine ("Function SoundObjectSetVolume not implemented");
            throw new NotImplementedException ();
        }
        public static void SoundObjectSetPosition (AuroraObject oSound, AuroraVector vPosition)
        {
            Console.WriteLine ("Function SoundObjectSetPosition not implemented");
            throw new NotImplementedException ();
        }
        public static void SpeakOneLinerConversation (string sDialogResRef = "", AuroraObject oTokenTarget = null)
        {
            oTokenTarget = oTokenTarget ?? AuroraObject.GetObjectTypeInvalid ();
            Console.WriteLine ("Function SpeakOneLinerConversation not implemented");
            throw new NotImplementedException ();
        }
        public static int GetGold (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            return oTarget.gold;
        }
        public static AuroraObject GetLastRespawnButtonPresser ()
        {
            Console.WriteLine ("Function GetLastRespawnButtonPresser not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForceFizzle ()
        {
            Console.WriteLine ("Function EffectForceFizzle not implemented");
            throw new NotImplementedException ();
        }
        public static void SetLightsaberPowered (AuroraObject oCreature, int bOverride, int bPowered = 0, int bShowTransition = 0)
        {
            Console.WriteLine ("Function SetLightsaberPowered not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsWeaponEffective (AuroraObject oVersus = null, int bOffHand = 0)
        {
            oVersus = oVersus ?? AuroraObject.GetObjectInvalid ();
            Console.WriteLine ("Function GetIsWeaponEffective not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLastSpellHarmful ()
        {
            Console.WriteLine ("Function GetLastSpellHarmful not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEvent EventActivateItem (AuroraObject oItem, AuroraLocation lTarget, AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? AuroraObject.GetObjectInvalid ();
            Console.WriteLine ("Function EventActivateItem not implemented");
            throw new NotImplementedException ();
        }
        public static void MusicBackgroundPlay (AuroraObject oArea)
        {
            AuroraGIT moduleGit = stateManager.currentModule.git;
            int musicIdx = moduleGit.AreaProperties.AmbientSndDay;
            musicSystem.StartBackgroundMusic(Resources.From2DA("ambientmusic", musicIdx, "resource"));
        }
        public static void MusicBackgroundStop (AuroraObject oArea)
        {
            musicSystem.StopBackgroundMusic();
        }
        public static void MusicBackgroundSetDelay (AuroraObject oArea, int nDelay)
        {
            Console.WriteLine ("Function MusicBackgroundSetDelay not implemented");
            throw new NotImplementedException ();
        }
        public static void MusicBackgroundChangeDay (AuroraObject oArea, int nTrack)
        {
            Console.WriteLine ("Function MusicBackgroundChangeDay not implemented");
            throw new NotImplementedException ();
        }
        public static void MusicBackgroundChangeNight (AuroraObject oArea, int nTrack)
        {
            Console.WriteLine ("Function MusicBackgroundChangeNight not implemented");
            throw new NotImplementedException ();
        }
        public static void MusicBattlePlay (AuroraObject oArea)
        {
            AuroraGIT moduleGit = stateManager.currentModule.git;
            int musicIdx = moduleGit.AreaProperties.MusicBattle;
            musicSystem.StartBackgroundMusic(Resources.From2DA("ambientmusic", musicIdx, "resource"));
        }
        public static void MusicBattleStop (AuroraObject oArea)
        {
            musicSystem.StopBackgroundMusic();
        }
        public static void MusicBattleChange (AuroraObject oArea, int nTrack)
        {
            Console.WriteLine ("Function MusicBattleChange not implemented");
            throw new NotImplementedException ();
        }
        public static void AmbientSoundPlay (AuroraObject oArea)
        {
            Console.WriteLine ("Function AmbientSoundPlay not implemented");
            throw new NotImplementedException ();
        }
        public static void AmbientSoundStop (AuroraObject oArea)
        {
            Console.WriteLine ("Function AmbientSoundStop not implemented");
            throw new NotImplementedException ();
        }
        public static void AmbientSoundChangeDay (AuroraObject oArea, int nTrack)
        {
            Console.WriteLine ("Function AmbientSoundChangeDay not implemented");
            throw new NotImplementedException ();
        }
        public static void AmbientSoundChangeNight (AuroraObject oArea, int nTrack)
        {
            Console.WriteLine ("Function AmbientSoundChangeNight not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastKiller ()
        {
            return stateManager.GetObjectSelf().lastKiller;
        }
        public static AuroraObject GetSpellCastItem ()
        {
            Console.WriteLine ("Function GetSpellCastItem not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetItemActivated ()
        {
            Console.WriteLine ("Function GetItemActivated not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetItemActivator ()
        {
            Console.WriteLine ("Function GetItemActivator not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraLocation GetItemActivatedTargetLocation ()
        {
            Console.WriteLine ("Function GetItemActivatedTargetLocation not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetItemActivatedTarget ()
        {
            Console.WriteLine ("Function GetItemActivatedTarget not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsOpen (AuroraObject oObject)
        {
            return Convert.ToInt32(oObject.open);
        }
        public static void TakeGoldFromCreature (int nAmount, AuroraObject oCreatureToTakeFrom, int bDestroy = 0)
        {
            oCreatureToTakeFrom.gold -= nAmount;
            if (bDestroy != 0)
            {
                stateManager.GetObjectSelf().gold += nAmount;
            }
        }
        public static int GetIsInConversation (AuroraObject oObject)
        {
            return Convert.ToInt32(oObject.inConversation);
        }
        public static AuroraEffect EffectAbilityDecrease (int nAbility, int nModifyBy)
        {
            Console.WriteLine ("Function EffectAbilityDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectAttackDecrease (int nPenalty, int nModifierType = 0)
        {
            Console.WriteLine ("Function EffectAttackDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDamageDecrease (int nPenalty, int nDamageType = 0)
        {
            Console.WriteLine ("Function EffectDamageDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDamageImmunityDecrease (int nDamageType, int nPercentImmunity)
        {
            Console.WriteLine ("Function EffectDamageImmunityDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectACDecrease (int nValue, int nModifyType = 0, int nDamageType = 0)
        {
            Console.WriteLine ("Function EffectACDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectMovementSpeedDecrease (int nPercentChange)
        {
            Console.WriteLine ("Function EffectMovementSpeedDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectSavingThrowDecrease (int nSave, int nValue, int nSaveType = 0)
        {
            Console.WriteLine ("Function EffectSavingThrowDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectSkillDecrease (int nSkill, int nValue)
        {
            Console.WriteLine ("Function EffectSkillDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForceResistanceDecrease (int nValue)
        {
            Console.WriteLine ("Function EffectForceResistanceDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static int GetPlotFlag (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetPlotFlag not implemented");
            throw new NotImplementedException ();
        }
        public static void SetPlotFlag (AuroraObject oTarget, int nPlotFlag)
        {
            if (oTarget.GetType() == typeof(Creature))
            {
                ((AuroraUTC)oTarget.template).Plot = (byte)nPlotFlag;
            } else if (oTarget.GetType() == typeof(Item))
            {
                ((AuroraUTI)oTarget.template).Plot = (byte)nPlotFlag;
            }
        }
        public static AuroraEffect EffectInvisibility (int nInvisibilityType)
        {
            Console.WriteLine ("Function EffectInvisibility not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectConcealment (int nPercentage)
        {
            Console.WriteLine ("Function EffectConcealment not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForceShield (int nShield)
        {
            Debug.LogWarning("EffectForceShield not yet implemented");
            return null;
        }
        public static AuroraEffect EffectDispelMagicAll (int nCasterLevel)
        {
            Console.WriteLine ("Function EffectDispelMagicAll not implemented");
            throw new NotImplementedException ();
        }
        public static void SetDialogPlaceableCamera (int nCameraId)
        {
            // Force the dialog to cut to a camera
            dialogSystem.ForceCut(GameObject.Find("cam_" + nCameraId + 1));
        }
        public static int GetSoloMode ()
        {
            Debug.LogWarning("Solo mode not yet implemented");
            return 0;
            //Console.WriteLine ("Function GetSoloMode not implemented");
            //throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDisguise (int nDisguiseAppearance)
        {
            Console.WriteLine ("Function EffectDisguise not implemented");
            throw new NotImplementedException ();
        }
        public static int GetMaxStealthXP ()
        {
            Console.WriteLine ("Function GetMaxStealthXP not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectTrueSeeing ()
        {
            Console.WriteLine ("Function EffectTrueSeeing not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectSeeInvisible ()
        {
            Console.WriteLine ("Function EffectSeeInvisible not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectTimeStop ()
        {
            Console.WriteLine ("Function EffectTimeStop not implemented");
            throw new NotImplementedException ();
        }
        public static void SetMaxStealthXP (int nMax)
        {
            Console.WriteLine ("Function SetMaxStealthXP not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectBlasterDeflectionIncrease (int nChange)
        {
            Console.WriteLine ("Function EffectBlasterDeflectionIncrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectBlasterDeflectionDecrease (int nChange)
        {
            Console.WriteLine ("Function EffectBlasterDeflectionDecrease not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectHorrified ()
        {
            Console.WriteLine ("Function EffectHorrified not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectSpellLevelAbsorption (int nMaxSpellLevelAbsorbed, int nTotalSpellLevelsAbsorbed = 0, int nSpellSchool = 0)
        {
            Console.WriteLine ("Function EffectSpellLevelAbsorption not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDispelMagicBest (int nCasterLevel)
        {
            Console.WriteLine ("Function EffectDispelMagicBest not implemented");
            throw new NotImplementedException ();
        }
        public static int GetCurrentStealthXP ()
        {
            Console.WriteLine ("Function GetCurrentStealthXP not implemented");
            throw new NotImplementedException ();
        }
        public static int GetNumStackedItems (AuroraObject oItem)
        {
            return oItem.stackSize;
        }
        public static void SurrenderToEnemies ()
        {
            Console.WriteLine ("Function SurrenderToEnemies not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectMissChance (int nPercentage)
        {
            Console.WriteLine ("Function EffectMissChance not implemented");
            throw new NotImplementedException ();
        }
        public static void SetCurrentStealthXP (int nCurrent)
        {
            Console.WriteLine ("Function SetCurrentStealthXP not implemented");
            throw new NotImplementedException ();
        }
        public static int GetCreatureSize (AuroraObject oCreature)
        {
            return oCreature.creatureSize;
        }
        public static void AwardStealthXP (AuroraObject oTarget)
        {
            Debug.LogWarning("Stealth not yet implemented");
        }
        public static int GetStealthXPEnabled ()
        {
            Console.WriteLine ("Function GetStealthXPEnabled not implemented");
            throw new NotImplementedException ();
        }
        public static void SetStealthXPEnabled (int bEnabled)
        {
            Console.WriteLine ("Function SetStealthXPEnabled not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionUnlockObject (AuroraObject oTarget)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionUnlockObject(self, oTarget));
        }
        public static void ActionLockObject (AuroraObject oTarget)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionLockObject(self, oTarget));
        }
        public static AuroraEffect EffectModifyAttacks (int nAttacks)
        {
            Console.WriteLine ("Function EffectModifyAttacks not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastTrapDetected (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetLastTrapDetected not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectDamageShield (int nDamageAmount, int nRandomAmount, int nDamageType)
        {
            Console.WriteLine ("Function EffectDamageShield not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetNearestTrapToObject (AuroraObject oTarget = null, int nTrapDetected = 0)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetNearestTrapToObject not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetAttemptedMovementTarget ()
        {
            Console.WriteLine ("Function GetAttemptedMovementTarget not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetBlockingCreature (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetBlockingCreature not implemented");
            throw new NotImplementedException ();
        }
        public static int GetFortitudeSavingThrow (AuroraObject oTarget)
        {
            Console.WriteLine ("Function GetFortitudeSavingThrow not implemented");
            throw new NotImplementedException ();
        }
        public static int GetWillSavingThrow (AuroraObject oTarget)
        {
            Console.WriteLine ("Function GetWillSavingThrow not implemented");
            throw new NotImplementedException ();
        }
        public static int GetReflexSavingThrow (AuroraObject oTarget)
        {
            Console.WriteLine ("Function GetReflexSavingThrow not implemented");
            throw new NotImplementedException ();
        }
        public static float GetChallengeRating (AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetChallengeRating not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFoundEnemyCreature (AuroraObject oTarget = null)
        {
            oTarget = oTarget ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetFoundEnemyCreature not implemented");
            throw new NotImplementedException ();
        }
        public static int GetMovementRate (AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetMovementRate not implemented");
            throw new NotImplementedException ();
        }
        public static int GetSubRace (AuroraObject oCreature)
        {
            Debug.LogWarning("Not convinced this is returning the right value...");
            return ((AuroraUTC)oCreature.template).SubraceIndex;
        }
        public static int GetStealthXPDecrement ()
        {
            Console.WriteLine ("Function GetStealthXPDecrement not implemented");
            throw new NotImplementedException ();
        }
        public static void SetStealthXPDecrement (int nDecrement)
        {
            Console.WriteLine ("Function SetStealthXPDecrement not implemented");
            throw new NotImplementedException ();
        }
        public static void DuplicateHeadAppearance (AuroraObject oidCreatureToChange, AuroraObject oidCreatureToMatch)
        {
            Console.WriteLine ("Function DuplicateHeadAppearance not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionCastFakeSpellAtObject (int nSpell, AuroraObject oTarget, int nProjectilePathType = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionCastFakeSpellAtObject(self, nSpell, oTarget, nProjectilePathType));
        }
        public static void ActionCastFakeSpellAtLocation (int nSpell, AuroraLocation lTarget, int nProjectilePathType = 0)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionCastFakeSpellAtLocation(self, nSpell, lTarget, nProjectilePathType));
        }
        public static void CutsceneAttack (AuroraObject oTarget, int nAnimation, int nAttackResult, int nDamage)
        {
            //Debug.LogWarning("Cutscene attacks not yet implemented");
            AuroraObject self = stateManager.GetObjectSelf();

            // Make the attack guaranteed to have the desired effect
            ((Creature)self).ForceNextAttack(nAnimation, nAttackResult, nDamage);
            // Add an attack to the queue of self, with oTarget as the target
            self.AddAction(new ActionAttack(self, oTarget, false));
        }
        public static void SetCameraMode (AuroraObject oPlayer, int nCameraMode)
        {
            Console.WriteLine ("Function SetCameraMode not implemented");
            throw new NotImplementedException ();
        }
        public static void SetLockOrientationInDialog (AuroraObject oObject, int nValue)
        {
            Debug.LogWarning("SetLockOrientationInDialog not implemented yet");
        }
        public static void SetLockHeadFollowInDialog (AuroraObject oObject, int nValue)
        {
            oObject.lockHeadFollowInDialog = Convert.ToBoolean(nValue);
        }
        public static void CutsceneMove (AuroraObject oObject, AuroraVector vPosition, int nRun)
        {
            Console.WriteLine ("Function CutsceneMove not implemented");
            throw new NotImplementedException ();
        }
        public static void EnableVideoEffect (int nEffectType)
        {
            Console.WriteLine ("Function EnableVideoEffect not implemented");
            throw new NotImplementedException ();
        }
        public static void StartNewModule (string sModuleName, string sWayPoint = "", string sMovie1 = "", string sMovie2 = "", string sMovie3 = "", string sMovie4 = "", string sMovie5 = "", string sMovie6 = "")
        {
            Console.WriteLine ("Function StartNewModule not implemented");
            throw new NotImplementedException ();
        }
        public static void DisableVideoEffect ()
        {
            Console.WriteLine ("Function DisableVideoEffect not implemented");
            throw new NotImplementedException ();
        }
        public static int GetWeaponRanged (AuroraObject oItem)
        {
            Console.WriteLine ("Function GetWeaponRanged not implemented");
            throw new NotImplementedException ();
        }
        public static void DoSinglePlayerAutoSave ()
        {
            Console.WriteLine ("Function DoSinglePlayerAutoSave not implemented");
            throw new NotImplementedException ();
        }
        public static int GetGameDifficulty ()
        {
            Console.WriteLine ("Function GetGameDifficulty not implemented");
            throw new NotImplementedException ();
        }
        public static int GetUserActionsPending ()
        {
            // From nwscript.nss:
            //   This will test the combat action queu to see if the user has placed any actions on the queue.
            //   will only work during combat.
            Debug.LogWarning("GetUserActionsPending not yet implemented");
            return 0;
        }
        public static void RevealMap (AuroraVector vPoint, int nRadius = -1)
        {
            Debug.LogWarning("Revealing the map is not yet implemented");
            //vPoint = vPoint ?? new AuroraVector();
            //Console.WriteLine ("Function RevealMap not implemented");
            //throw new NotImplementedException ();
        }
        public static void SetTutorialWindowsEnabled (int bEnabled)
        {
            Console.WriteLine ("Function SetTutorialWindowsEnabled not implemented");
            throw new NotImplementedException ();
        }
        public static void ShowTutorialWindow (int nWindow)
        {
            // No need for tutorials!
            //Console.WriteLine ("Function ShowTutorialWindow not implemented");
            //throw new NotImplementedException ();
        }
        public static void StartCreditSequence (int bTransparentBackground)
        {
            Console.WriteLine ("Function StartCreditSequence not implemented");
            throw new NotImplementedException ();
        }
        public static int IsCreditSequenceInProgress ()
        {
            Console.WriteLine ("Function IsCreditSequenceInProgress not implemented");
            throw new NotImplementedException ();
        }
        #region SWMG Functions
        public static void SWMG_SetLateralAccelerationPerSecond (float fLAPS)
        {
            Console.WriteLine ("Function SWMG_SetLateralAccelerationPerSecond not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetLateralAccelerationPerSecond ()
        {
            Console.WriteLine ("Function SWMG_GetLateralAccelerationPerSecond not implemented");
            throw new NotImplementedException ();
        }
        #endregion SWMG Functions
        public static int GetCurrentAction (AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf ();
            
            if (oObject.actions.Count == 0)
            {
                return ACTION_QUEUEEMPTY;
            }

            return oObject.actions[0].ActionNumber;
        }
        public static float GetDifficultyModifier ()
        {
            Console.WriteLine ("Function GetDifficultyModifier not implemented");
            throw new NotImplementedException ();
        }
        public static int GetAppearanceType (AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetAppearanceType not implemented");
            throw new NotImplementedException ();
        }
        public static void FloatingTextStrRefOnCreature (int nStrRefToDisplay, AuroraObject oCreatureToFloatAbove, int bBroadcastToFaction = 0)
        {
            Console.WriteLine ("Function FloatingTextStrRefOnCreature not implemented");
            throw new NotImplementedException ();
        }
        public static void FloatingTextStringOnCreature (string sStringToDisplay, AuroraObject oCreatureToFloatAbove, int bBroadcastToFaction = 0)
        {
            Console.WriteLine ("Function FloatingTextStringOnCreature not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapDisarmable (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapDisarmable not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapDetectable (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapDetectable not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapDetectedBy (AuroraObject oTrapObject, AuroraObject oCreature)
        {
            Console.WriteLine ("Function GetTrapDetectedBy not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapFlagged (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapFlagged not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapBaseType (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapBaseType not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapOneShot (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapOneShot not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetTrapCreator (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapCreator not implemented");
            throw new NotImplementedException ();
        }
        public static string GetTrapKeyTag (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapKeyTag not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapDisarmDC (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapDisarmDC not implemented");
            throw new NotImplementedException ();
        }
        public static int GetTrapDetectDC (AuroraObject oTrapObject)
        {
            Console.WriteLine ("Function GetTrapDetectDC not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLockKeyRequired (AuroraObject oObject)
        {
            Console.WriteLine ("Function GetLockKeyRequired not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLockKeyTag (AuroraObject oObject)
        {
            Console.WriteLine ("Function GetLockKeyTag not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLockLockable (AuroraObject oObject)
        {
            Console.WriteLine ("Function GetLockLockable not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLockUnlockDC (AuroraObject oObject)
        {
            Console.WriteLine ("Function GetLockUnlockDC not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLockLockDC (AuroraObject oObject)
        {
            Console.WriteLine ("Function GetLockLockDC not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetPCLevellingUp ()
        {
            Console.WriteLine ("Function GetPCLevellingUp not implemented");
            throw new NotImplementedException ();
        }
        public static int GetHasFeatEffect (int nFeat, AuroraObject oObject = null)
        {
            oObject = oObject ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetHasFeatEffect not implemented");
            throw new NotImplementedException ();
        }
        public static void SetPlaceableIllumination (AuroraObject oPlaceable = null, int bIlluminate = 0)
        {
            oPlaceable = oPlaceable ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SetPlaceableIllumination not implemented");
            throw new NotImplementedException ();
        }
        public static int GetPlaceableIllumination (AuroraObject oPlaceable = null)
        {
            oPlaceable = oPlaceable ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function GetPlaceableIllumination not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsPlaceableObjectActionPossible (AuroraObject oPlaceable, int nPlaceableAction)
        {
            Console.WriteLine ("Function GetIsPlaceableObjectActionPossible not implemented");
            throw new NotImplementedException ();
        }
        public static void DoPlaceableObjectAction (AuroraObject oPlaceable, int nPlaceableAction)
        {
            Console.WriteLine ("Function DoPlaceableObjectAction not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFirstPC ()
        {
            return stateManager.PC;
        }
        public static AuroraObject GetNextPC ()
        {
            // TODO: Change this if I want to add networking down the track
            return stateManager.PC;
        }
        public static int SetTrapDetectedBy (AuroraObject oTrap, AuroraObject oDetector)
        {
            Console.WriteLine ("Function SetTrapDetectedBy not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsTrapped (AuroraObject oObject)
        {
            Console.WriteLine ("Function GetIsTrapped not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect SetEffectIcon (AuroraEffect eEffect, int nIcon)
        {
            Console.WriteLine ("Function SetEffectIcon not implemented");
            throw new NotImplementedException ();
        }
        public static void FaceObjectAwayFromObject (AuroraObject oFacer, AuroraObject oObjectToFaceAwayFrom)
        {
            Console.WriteLine ("Function FaceObjectAwayFromObject not implemented");
            throw new NotImplementedException ();
        }
        public static void PopUpDeathGUIPanel (AuroraObject oPC, int bRespawnButtonEnabled = 0, int bWaitForHelpButtonEnabled = 0, int nHelpStringReference = 0, string sHelpString = "")
        {
            Console.WriteLine ("Function PopUpDeathGUIPanel not implemented");
            throw new NotImplementedException ();
        }
        public static void SetTrapDisabled (AuroraObject oTrap)
        {
            Console.WriteLine ("Function SetTrapDisabled not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetLastHostileActor (AuroraObject oVictim = null)
        {
            oVictim = oVictim ?? stateManager.GetObjectSelf ();
            return oVictim.lastHostileActor;
        }
        public static void ExportAllCharacters ()
        {
            Console.WriteLine ("Function ExportAllCharacters not implemented");
            throw new NotImplementedException ();
        }
        public static int MusicBackgroundGetDayTrack (AuroraObject oArea)
        {
            Console.WriteLine ("Function MusicBackgroundGetDayTrack not implemented");
            throw new NotImplementedException ();
        }
        public static int MusicBackgroundGetNightTrack (AuroraObject oArea)
        {
            Console.WriteLine ("Function MusicBackgroundGetNightTrack not implemented");
            throw new NotImplementedException ();
        }
        public static void WriteTimestampedLogEntry (string sLogEntry)
        {
            Console.WriteLine ("Function WriteTimestampedLogEntry not implemented");
            throw new NotImplementedException ();
        }
        public static string GetModuleName ()
        {
            Console.WriteLine ("Function GetModuleName not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject GetFactionLeader (AuroraObject oMemberOfFaction)
        {
            Console.WriteLine ("Function GetFactionLeader not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetSpeedBlurEffect (int bEnabled, float fRatio = 0.75f)
        {
            Console.WriteLine ("Function SWMG_SetSpeedBlurEffect not implemented");
            throw new NotImplementedException ();
        }
        public static void EndGame (int nShowEndGameGui = 0)
        {
            Console.WriteLine ("Function EndGame not implemented");
            throw new NotImplementedException ();
        }
        public static int GetRunScriptVar ()
        {
            return stateManager.scriptVars.Last();
        }
        public static int GetCreatureMovmentType (AuroraObject oidCreature)
        {
            Console.WriteLine ("Function GetCreatureMovmentType not implemented");
            throw new NotImplementedException ();
        }
        public static void AmbientSoundSetDayVolume (AuroraObject oArea, int nVolume)
        {
            Console.WriteLine ("Function AmbientSoundSetDayVolume not implemented");
            throw new NotImplementedException ();
        }
        public static void AmbientSoundSetNightVolume (AuroraObject oArea, int nVolume)
        {
            Console.WriteLine ("Function AmbientSoundSetNightVolume not implemented");
            throw new NotImplementedException ();
        }
        public static int MusicBackgroundGetBattleTrack (AuroraObject oArea)
        {
            Console.WriteLine ("Function MusicBackgroundGetBattleTrack not implemented");
            throw new NotImplementedException ();
        }
        public static int GetHasInventory (AuroraObject oObject)
        {
            switch (oObject.auroraObjectType)
            {
                case AuroraObject.AuroraObjectType.CREATURE:
                case AuroraObject.AuroraObjectType.STORE:
                    return 1;
                case AuroraObject.AuroraObjectType.ITEM:
                    AuroraUTI item = (AuroraUTI)oObject.template;
                    // TODO: When is an item a container?
                    return 0;
                case AuroraObject.AuroraObjectType.PLACEABLE:
                    AuroraUTP plc = (AuroraUTP)oObject.template;
                    return plc.HasInventory;
                default:
                    return 0;
            }
        }
        public static float GetStrRefSoundDuration (int nStrRef)
        {
            Console.WriteLine ("Function GetStrRefSoundDuration not implemented");
            throw new NotImplementedException ();
        }
        public static void AddToParty (AuroraObject oPC, AuroraObject oPartyLeader)
        {
            // Adds the PC to the party
            Console.WriteLine ("Function AddToParty not implemented");
            throw new NotImplementedException ();
        }
        public static void RemoveFromParty (AuroraObject oPC)
        {
            // Removes the PC from the party
            Console.WriteLine ("Function RemoveFromParty not implemented");
            throw new NotImplementedException ();
        }
        public static int AddPartyMember (int nNPC, AuroraObject oCreature)
        {
            stateManager.party[nNPC] = oCreature;
            return 1;
        }
        public static int RemovePartyMember (int nNPC)
        {
            stateManager.party[nNPC] = null;
            return 1;
        }
        public static int IsObjectPartyMember (AuroraObject oCreature)
        {
            return Convert.ToInt32(stateManager.party.Contains(oCreature));
        }
        public static AuroraObject GetPartyMemberByIndex (int nIndex)
        {
            return stateManager.party[nIndex];
        }
        public static int GetGlobalBoolean (string sIdentifier)
        {
            return Convert.ToInt32(stateManager.GetGlobalBoolean(sIdentifier));
        }
        public static void SetGlobalBoolean(string sIdentifier, int nValue)
        {
            stateManager.SetGlobalBoolean(sIdentifier, Convert.ToBoolean(nValue));
        }
        public static int GetGlobalNumber (string sIdentifier)
        {
            return stateManager.GetGlobalInteger(sIdentifier);
        }
        public static void SetGlobalNumber (string sIdentifier, int nValue)
        {
            stateManager.SetGlobalInteger(sIdentifier, nValue);
        }
        public static void AurPostString (string sString, int nX, int nY, float fLife)
        {
            Debug.LogWarning("AurPostString not yet implemented");
            //Console.WriteLine ("Function AurPostString not implemented");
            //throw new NotImplementedException ();
        }

        #region SWMG Functions
        public static string SWMG_GetLastEvent ()
        {
            Console.WriteLine ("Function SWMG_GetLastEvent not implemented");
            throw new NotImplementedException ();
        }
        public static string SWMG_GetLastEventModelName ()
        {
            Console.WriteLine ("Function SWMG_GetLastEventModelName not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SWMG_GetObjectByName (string sName)
        {
            return stateManager.objects[sName];
        }
        public static void SWMG_PlayAnimation (AuroraObject oObject, string sAnimName, int bLooping = 1, int bQueue = 0, int bOverlay = 0)
        {
            Console.WriteLine ("Function SWMG_PlayAnimation not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetLastBulletHitDamage ()
        {
            Console.WriteLine ("Function SWMG_GetLastBulletHitDamage not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetLastBulletHitTarget ()
        {
            Console.WriteLine ("Function SWMG_GetLastBulletHitTarget not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SWMG_GetLastBulletHitShooter ()
        {
            Console.WriteLine ("Function SWMG_GetLastBulletHitShooter not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_AdjustFollowerHitPoints (AuroraObject oFollower, int nHP, int nAbsolute = 0)
        {
            Console.WriteLine ("Function SWMG_AdjustFollowerHitPoints not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_OnBulletHit ()
        {
            Console.WriteLine ("Function SWMG_OnBulletHit not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_OnObstacleHit ()
        {
            Console.WriteLine ("Function SWMG_OnObstacleHit not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SWMG_GetLastFollowerHit ()
        {
            Console.WriteLine ("Function SWMG_GetLastFollowerHit not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SWMG_GetLastObstacleHit ()
        {
            Console.WriteLine ("Function SWMG_GetLastObstacleHit not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetLastBulletFiredDamage ()
        {
            Console.WriteLine ("Function SWMG_GetLastBulletFiredDamage not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetLastBulletFiredTarget ()
        {
            Console.WriteLine ("Function SWMG_GetLastBulletFiredTarget not implemented");
            throw new NotImplementedException ();
        }
        public static string SWMG_GetObjectName (AuroraObject oid = null)
        {
            oid = oid ?? stateManager.GetObjectSelf ();
            return oid.name;
        }
        public static void SWMG_OnDeath ()
        {
            Console.WriteLine ("Function SWMG_OnDeath not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_IsFollower (AuroraObject oid = null)
        {
            oid = oid ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SWMG_IsFollower not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_IsPlayer (AuroraObject oid = null)
        {
            oid = oid ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SWMG_IsPlayer not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_IsEnemy (AuroraObject oid = null)
        {
            oid = oid ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SWMG_IsEnemy not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_IsTrigger (AuroraObject oid = null)
        {
            oid = oid ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SWMG_IsTrigger not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_IsObstacle (AuroraObject oid = null)
        {
            oid = oid ?? stateManager.GetObjectSelf ();
            Console.WriteLine ("Function SWMG_IsObstacle not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetFollowerHitPoints (AuroraObject oFollower, int nHP)
        {
            Console.WriteLine ("Function SWMG_SetFollowerHitPoints not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_OnDamage ()
        {
            Console.WriteLine ("Function SWMG_OnDamage not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetLastHPChange ()
        {
            Console.WriteLine ("Function SWMG_GetLastHPChange not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_RemoveAnimation (AuroraObject oObject, string sAnimName)
        {
            Console.WriteLine ("Function SWMG_RemoveAnimation not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetCameraNearClip ()
        {
            Console.WriteLine ("Function SWMG_GetCameraNearClip not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetCameraFarClip ()
        {
            Console.WriteLine ("Function SWMG_GetCameraFarClip not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetCameraClip (float fNear, float fFar)
        {
            Console.WriteLine ("Function SWMG_SetCameraClip not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SWMG_GetPlayer ()
        {
            Console.WriteLine ("Function SWMG_GetPlayer not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetEnemyCount ()
        {
            Console.WriteLine ("Function SWMG_GetEnemyCount not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SWMG_GetEnemy (int nEntry)
        {
            Console.WriteLine ("Function SWMG_GetEnemy not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetObstacleCount ()
        {
            Console.WriteLine ("Function SWMG_GetObstacleCount not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SWMG_GetObstacle (int nEntry)
        {
            Console.WriteLine ("Function SWMG_GetObstacle not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetHitPoints (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_GetHitPoints not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetMaxHitPoints (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_GetMaxHitPoints not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetMaxHitPoints (AuroraObject oFollower, int nMaxHP)
        {
            Console.WriteLine ("Function SWMG_SetMaxHitPoints not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetSphereRadius (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_GetSphereRadius not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetSphereRadius (AuroraObject oFollower, float fRadius)
        {
            Console.WriteLine ("Function SWMG_SetSphereRadius not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetNumLoops (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_GetNumLoops not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetNumLoops (AuroraObject oFollower, int nNumLoops)
        {
            Console.WriteLine ("Function SWMG_SetNumLoops not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraVector SWMG_GetPosition (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_GetPosition not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetGunBankCount (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_GetGunBankCount not implemented");
            throw new NotImplementedException ();
        }
        public static string SWMG_GetGunBankBulletModel (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankBulletModel not implemented");
            throw new NotImplementedException ();
        }
        public static string SWMG_GetGunBankGunModel (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankGunModel not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetGunBankDamage (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankDamage not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetGunBankTimeBetweenShots (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankTimeBetweenShots not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetGunBankLifespan (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankLifespan not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetGunBankSpeed (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankSpeed not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetGunBankTarget (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankTarget not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankBulletModel (AuroraObject oFollower, int nGunBank, string sBulletModel)
        {
            Console.WriteLine ("Function SWMG_SetGunBankBulletModel not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankGunModel (AuroraObject oFollower, int nGunBank, string sGunModel)
        {
            Console.WriteLine ("Function SWMG_SetGunBankGunModel not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankDamage (AuroraObject oFollower, int nGunBank, int nDamage)
        {
            Console.WriteLine ("Function SWMG_SetGunBankDamage not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankTimeBetweenShots (AuroraObject oFollower, int nGunBank, float fTBS)
        {
            Console.WriteLine ("Function SWMG_SetGunBankTimeBetweenShots not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankLifespan (AuroraObject oFollower, int nGunBank, float fLifespan)
        {
            Console.WriteLine ("Function SWMG_SetGunBankLifespan not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankSpeed (AuroraObject oFollower, int nGunBank, float fSpeed)
        {
            Console.WriteLine ("Function SWMG_SetGunBankSpeed not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankTarget (AuroraObject oFollower, int nGunBank, int nTarget)
        {
            Console.WriteLine ("Function SWMG_SetGunBankTarget not implemented");
            throw new NotImplementedException ();
        }
        public static string SWMG_GetLastBulletHitPart ()
        {
            Console.WriteLine ("Function SWMG_GetLastBulletHitPart not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_IsGunBankTargetting (AuroraObject oFollower, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_IsGunBankTargetting not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraVector SWMG_GetPlayerOffset ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerOffset not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetPlayerInvincibility ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerInvincibility not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetPlayerSpeed ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerSpeed not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetPlayerMinSpeed ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerMinSpeed not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetPlayerAccelerationPerSecond ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerAccelerationPerSecond not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraVector SWMG_GetPlayerTunnelPos ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerTunnelPos not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerOffset (AuroraVector vOffset)
        {
            Console.WriteLine ("Function SWMG_SetPlayerOffset not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerInvincibility (float fInvincibility)
        {
            Console.WriteLine ("Function SWMG_SetPlayerInvincibility not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerSpeed (float fSpeed)
        {
            Console.WriteLine ("Function SWMG_SetPlayerSpeed not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerMinSpeed (float fMinSpeed)
        {
            Console.WriteLine ("Function SWMG_SetPlayerMinSpeed not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerAccelerationPerSecond (float fAPS)
        {
            Console.WriteLine ("Function SWMG_SetPlayerAccelerationPerSecond not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerTunnelPos (AuroraVector vTunnel)
        {
            Console.WriteLine ("Function SWMG_SetPlayerTunnelPos not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraVector SWMG_GetPlayerTunnelNeg()
        {
            Console.WriteLine ("Function SWMG_GetPlayerTunnelNeg not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerTunnelNeg (AuroraVector vTunnel)
        {
            Console.WriteLine ("Function SWMG_SetPlayerTunnelNeg not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraVector SWMG_GetPlayerOrigin ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerOrigin not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerOrigin (AuroraVector vOrigin)
        {
            Console.WriteLine ("Function SWMG_SetPlayerOrigin not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetGunBankHorizontalSpread (AuroraObject oEnemy, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankHorizontalSpread not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetGunBankVerticalSpread (AuroraObject oEnemy, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankVerticalSpread not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetGunBankSensingRadius (AuroraObject oEnemy, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankSensingRadius not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetGunBankInaccuracy (AuroraObject oEnemy, int nGunBank)
        {
            Console.WriteLine ("Function SWMG_GetGunBankInaccuracy not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankHorizontalSpread (AuroraObject oEnemy, int nGunBank, float fHorizontalSpread)
        {
            Console.WriteLine ("Function SWMG_SetGunBankHorizontalSpread not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankVerticalSpread (AuroraObject oEnemy, int nGunBank, float fVerticalSpread)
        {
            Console.WriteLine ("Function SWMG_SetGunBankVerticalSpread not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankSensingRadius (AuroraObject oEnemy, int nGunBank, float fSensingRadius)
        {
            Console.WriteLine ("Function SWMG_SetGunBankSensingRadius not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetGunBankInaccuracy (AuroraObject oEnemy, int nGunBank, float fInaccuracy)
        {
            Console.WriteLine ("Function SWMG_SetGunBankInaccuracy not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetIsInvulnerable (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_GetIsInvulnerable not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_StartInvulnerability (AuroraObject oFollower)
        {
            Console.WriteLine ("Function SWMG_StartInvulnerability not implemented");
            throw new NotImplementedException ();
        }
        public static float SWMG_GetPlayerMaxSpeed ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerMaxSpeed not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerMaxSpeed (float fMaxSpeed)
        {
            Console.WriteLine ("Function SWMG_SetPlayerMaxSpeed not implemented");
            throw new NotImplementedException ();
        }
        #endregion SWMG Functions
        public static void AddJournalWorldEntry (int nIndex, string szEntry, string szTitle = "World Entry")
        {
            Console.WriteLine ("Function AddJournalWorldEntry not implemented");
            throw new NotImplementedException ();
        }
        public static void AddJournalWorldEntryStrref (int strref, int strrefTitle)
        {
            Console.WriteLine ("Function AddJournalWorldEntryStrref not implemented");
            throw new NotImplementedException ();
        }
        public static void BarkString (AuroraObject oCreature, int strRef)
        {
            Console.WriteLine ("Function BarkString not implemented");
            throw new NotImplementedException ();
        }
        public static void DeleteJournalWorldAllEntries ()
        {
            Console.WriteLine ("Function DeleteJournalWorldAllEntries not implemented");
            throw new NotImplementedException ();
        }
        public static void DeleteJournalWorldEntry (int nIndex)
        {
            Console.WriteLine ("Function DeleteJournalWorldEntry not implemented");
            throw new NotImplementedException ();
        }
        public static void DeleteJournalWorldEntryStrref (int strref)
        {
            Console.WriteLine ("Function DeleteJournalWorldEntryStrref not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectForceDrain (int nDamage)
        {
            Console.WriteLine ("Function EffectForceDrain not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectPsychicStatic ()
        {
            Console.WriteLine ("Function EffectPsychicStatic not implemented");
            throw new NotImplementedException ();
        }
        public static void PlayVisualAreaEffect (int nEffectID, AuroraLocation lTarget)
        {
            Console.WriteLine ("Function PlayVisualAreaEffect not implemented");
            throw new NotImplementedException ();
        }
        public static void SetJournalQuestEntryPicture (string szPlotID, AuroraObject oObject, int nPictureIndex, int bAllPartyMemebers = 0, int bAllPlayers = 0)
        {
            Console.WriteLine ("Function SetJournalQuestEntryPicture not implemented");
            throw new NotImplementedException ();
        }
        public static int GetLocalBoolean (AuroraObject oObject, int nIndex)
        {
            return Convert.ToInt32(oObject.localBools[nIndex]);
        }
        public static void SetLocalBoolean (AuroraObject oObject, int nIndex, int nValue)
        {
            oObject.localBools[nIndex] = Convert.ToBoolean(nValue);
        }
        public static int GetLocalNumber(AuroraObject oObject, int nIndex)
        {
            return oObject.localInts[nIndex];
        }
        public static void SetLocalNumber (AuroraObject oObject, int nIndex, int nValue)
        {
            oObject.localInts[nIndex] = nValue;
        }
        public static int SWMG_GetSoundFrequency (AuroraObject oFollower, int nSound)
        {
            Console.WriteLine ("Function SWMG_GetSoundFrequency not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetSoundFrequency (AuroraObject oFollower, int nSound, int nFrequency)
        {
            Console.WriteLine ("Function SWMG_SetSoundFrequency not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetSoundFrequencyIsRandom (AuroraObject oFollower, int nSound)
        {
            Console.WriteLine ("Function SWMG_GetSoundFrequencyIsRandom not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetSoundFrequencyIsRandom (AuroraObject oFollower, int nSound, int bIsRandom)
        {
            Console.WriteLine ("Function SWMG_SetSoundFrequencyIsRandom not implemented");
            throw new NotImplementedException ();
        }
        public static int SWMG_GetSoundVolume (AuroraObject oFollower, int nSound)
        {
            Console.WriteLine ("Function SWMG_GetSoundVolume not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetSoundVolume (AuroraObject oFollower, int nSound, int nVolume)
        {
            Console.WriteLine ("Function SWMG_SetSoundVolume not implemented");
            throw new NotImplementedException ();
        }
        public static float SoundObjectGetPitchVariance (AuroraObject oSound)
        {
            Console.WriteLine ("Function SoundObjectGetPitchVariance not implemented");
            throw new NotImplementedException ();
        }
        public static void SoundObjectSetPitchVariance (AuroraObject oSound, float fVariance)
        {
            Console.WriteLine ("Function SoundObjectSetPitchVariance not implemented");
            throw new NotImplementedException ();
        }
        public static int SoundObjectGetVolume (AuroraObject oSound)
        {
            Console.WriteLine ("Function SoundObjectGetVolume not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraLocation GetGlobalLocation (string sIdentifier)
        {
            Console.WriteLine ("Function GetGlobalLocation not implemented");
            throw new NotImplementedException ();
        }
        public static void SetGlobalLocation (string sIdentifier, AuroraLocation lValue)
        {
            stateManager.SetGlobalLocation(sIdentifier, lValue);
        }
        public static int AddAvailableNPCByObject (int nNPC, AuroraObject oCreature)
        {
            Console.WriteLine ("Function AddAvailableNPCByObject not implemented");
            throw new NotImplementedException ();
        }
        public static int RemoveAvailableNPC (int nNPC)
        {
            Console.WriteLine ("Function RemoveAvailableNPC not implemented");
            throw new NotImplementedException ();
        }
        public static int IsAvailableCreature (int nNPC)
        {
            Console.WriteLine ("Function IsAvailableCreature not implemented");
            throw new NotImplementedException ();
        }
        public static int AddAvailableNPCByTemplate (int nNPC, string sTemplate)
        {
            Console.WriteLine ("Function AddAvailableNPCByTemplate not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject SpawnAvailableNPC (int nNPC, AuroraLocation lPosition)
        {
            Console.WriteLine ("Function SpawnAvailableNPC not implemented");
            throw new NotImplementedException ();
        }
        public static int IsNPCPartyMember (int nNPC)
        {
            Debug.LogWarning("IsNPCPartyMember (and parties in general) not yet implemented");
            return 0;
        }
        public static void ActionBarkString (int strRef)
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionBarkString(self, strRef));
        }
        public static int GetIsConversationActive ()
        {
            return Convert.ToInt32(stateManager.conversationActive);
        }
        public static AuroraEffect EffectLightsaberThrow (AuroraObject oTarget1, AuroraObject oTarget2 = null, AuroraObject oTarget3 = null, int nAdvancedDamage = 0)
        {
            oTarget3 = oTarget3 ?? AuroraObject.GetObjectInvalid ();
            oTarget2 = oTarget2 ?? AuroraObject.GetObjectInvalid ();
            Console.WriteLine ("Function EffectLightsaberThrow not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectWhirlWind ()
        {
            Console.WriteLine ("Function EffectWhirlWind not implemented");
            throw new NotImplementedException ();
        }
        public static int GetPartyAIStyle ()
        {
            /* 
                int PARTY_AISTYLE_AGGRESSIVE    = 0;
                int PARTY_AISTYLE_DEFENSIVE     = 1;
                int PARTY_AISTYLE_PASSIVE       = 2;
            */

            Debug.LogWarning("Party AI Style not yet implemented");
            return 0;
        }
        public static int GetNPCAIStyle (AuroraObject oCreature)
        {
            /*
                int NPC_AISTYLE_DEFAULT_ATTACK  = 0;
                int NPC_AISTYLE_RANGED_ATTACK   = 1;
                int NPC_AISTYLE_MELEE_ATTACK    = 2;
                int NPC_AISTYLE_AID             = 3;
                int NPC_AISTYLE_GRENADE_THROWER = 4;
                int NPC_AISTYLE_JEDI_SUPPORT    = 5;
            */

            Debug.LogWarning("GetNPCAIStyle not yet implemented");
            return 0;
        }
        public static void SetPartyAIStyle (int nStyle)
        {
            Debug.LogWarning("SetPartyAIStyle not yet implemented");
        }
        public static void SetNPCAIStyle (AuroraObject oCreature, int nStyle)
        {
            Debug.LogWarning("SetNPCAIStyle not yet implemented");
        }
        public static void SetNPCSelectability (int nNPC, int nSelectability)
        {
            Console.WriteLine ("Function SetNPCSelectability not implemented");
            throw new NotImplementedException ();
        }
        public static int GetNPCSelectability (int nNPC)
        {
            Console.WriteLine ("Function GetNPCSelectability not implemented");
            throw new NotImplementedException ();
        }
        public static void ClearAllEffects ()
        {
            stateManager.GetObjectSelf().effects.Clear();
        }
        public static string GetLastConversation ()
        {
            return stateManager.lastConversation;
        }
        public static void ShowPartySelectionGUI (string sExitScript = "", int nForceNPC1 = -1, int nForceNPC2 = -1)
        {
            Console.WriteLine ("Function ShowPartySelectionGUI not implemented");
            throw new NotImplementedException ();
        }
        public static int GetStandardFaction (AuroraObject oObject)
        {
            // TODO: Is this correct?
            return ((AuroraUTC)oObject.template).FactionID;
        }
        public static void GivePlotXP (string sPlotName, int nPercentage)
        {
            Debug.LogWarning("Plot XP not yet implemented");
            //Console.WriteLine ("Function GivePlotXP not implemented");
            //throw new NotImplementedException ();
        }
        public static int GetMinOneHP (AuroraObject oObject)
        {
            return ((AuroraUTC)oObject.template).Min1HP;
        }
        public static void SetMinOneHP (AuroraObject oObject, int nMinOneHP)
        {
            ((AuroraUTC)oObject.template).Min1HP = (byte)nMinOneHP;
        }

        #region SWMG Functions
        public static AuroraVector SWMG_GetPlayerTunnelInfinite ()
        {
            Console.WriteLine ("Function SWMG_GetPlayerTunnelInfinite not implemented");
            throw new NotImplementedException ();
        }
        public static void SWMG_SetPlayerTunnelInfinite (AuroraVector vInfinite)
        {
            Console.WriteLine ("Function SWMG_SetPlayerTunnelInfinite not implemented");
            throw new NotImplementedException ();
        }
        #endregion SWMG Functions

        public static void SetGlobalFadeIn (float fWait = 0.0f, float fLength = 0.0f, float fR = 0.0f, float fG = 0.0f, float fB = 0.0f)
        {
            Camera.main.GetComponent<AuroraCamera>().SetGlobalFadeIn(fWait, fLength, fR, fG, fB);
        }
        public static void SetGlobalFadeOut (float fWait = 0.0f, float fLength = 0.0f, float fR = 0.0f, float fG = 0.0f, float fB = 0.0f)
        {
            Camera.main.GetComponent<AuroraCamera>().SetGlobalFadeOut(fWait, fLength, fR, fG, fB);
        }
        public static AuroraObject GetLastHostileTarget (AuroraObject oAttacker = null)
        {
            oAttacker = oAttacker ?? stateManager.GetObjectSelf ();
            return oAttacker.lastHostileTarget;
        }
        public static int GetLastAttackAction (AuroraObject oAttacker = null)
        {
            oAttacker = oAttacker ?? stateManager.GetObjectSelf ();
            return oAttacker.lastAttackAction;
        }
        public static int GetLastForcePowerUsed (AuroraObject oAttacker = null)
        {
            oAttacker = oAttacker ?? stateManager.GetObjectSelf ();
            return oAttacker.lastForcePowerUsed;
        }
        public static int GetLastCombatFeatUsed (AuroraObject oAttacker = null)
        {
            oAttacker = oAttacker ?? stateManager.GetObjectSelf ();
            return oAttacker.lastCombatFeatUsed;
        }
        public static int GetLastAttackResult (AuroraObject oAttacker = null)
        {
            oAttacker = oAttacker ?? stateManager.GetObjectSelf ();
            return oAttacker.lastAttackResult;
        }
        public static int GetWasForcePowerSuccessful (AuroraObject oAttacker = null)
        {
            oAttacker = oAttacker ?? stateManager.GetObjectSelf ();
            return oAttacker.wasForcePowerSuccessful;
        }
        public static AuroraObject GetFirstAttacker (AuroraObject oCreature = null)
        {
            throw new NotImplementedException("GetFirstAttacker not yet properly implemented");
            //oCreature = oCreature ?? stateManager.GetObjectSelf ();
            //return oCreature.attackers[0];
        }
        public static AuroraObject GetNextAttacker (AuroraObject oCreature = null)
        {
            // TODO: Make this work
            throw new NotImplementedException("GetFirstAttacker not yet properly implemented");
            //oCreature = oCreature ?? stateManager.GetObjectSelf ();
            //return oCreature.attackers[oCreature.attackers.Count - 1];
        }
        public static void SetFormation (AuroraObject oAnchor, AuroraObject oCreature, int nFormationPattern, int nPosition)
        {
            Console.WriteLine ("Function SetFormation not implemented");
            throw new NotImplementedException ();
        }
        public static void ActionFollowLeader ()
        {
            AuroraObject self = stateManager.GetObjectSelf();
            self.AddAction(new ActionFollowLeader(self));
        }
        public static void SetForcePowerUnsuccessful (int nResult, AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            oCreature.whyForcePowerUnsuccessful = nResult;
        }
        public static int GetIsDebilitated (AuroraObject oCreature = null)
        {
            Debug.LogWarning("GetIsDebilitated not yet implemented");
            return 0;
            //oCreature = oCreature ?? stateManager.GetObjectSelf ();
            //return Convert.ToInt32(oCreature.debilitated);
        }
        public static void PlayMovie (string sMovie)
        {
            movieSystem.PlayImmediate(sMovie);
        }
        public static void SaveNPCState (int nNPC)
        {
            Console.WriteLine ("Function SaveNPCState not implemented");
            throw new NotImplementedException ();
        }
        public static int GetCategoryFromTalent (AuroraTalent tTalent)
        {
            Console.WriteLine ("Function GetCategoryFromTalent not implemented");
            throw new NotImplementedException ();
        }
        public static void SurrenderByFaction (int nFactionFrom, int nFactionTo)
        {
            Console.WriteLine ("Function SurrenderByFaction not implemented");
            throw new NotImplementedException ();
        }
        public static void ChangeFactionByFaction (int nFactionFrom, int nFactionTo)
        {
            Console.WriteLine ("Function ChangeFactionByFaction not implemented");
            throw new NotImplementedException ();
        }
        public static void PlayRoomAnimation (string sRoom, int nAnimation)
        {
            Console.WriteLine ("Function PlayRoomAnimation not implemented");
            throw new NotImplementedException ();
        }
        public static void ShowGalaxyMap (int nPlanet)
        {
            Console.WriteLine ("Function ShowGalaxyMap not implemented");
            throw new NotImplementedException ();
        }
        public static void SetPlanetSelectable (int nPlanet, int bSelectable)
        {
            Console.WriteLine ("Function SetPlanetSelectable not implemented");
            throw new NotImplementedException ();
        }
        public static int GetPlanetSelectable (int nPlanet)
        {
            Console.WriteLine ("Function GetPlanetSelectable not implemented");
            throw new NotImplementedException ();
        }
        public static void SetPlanetAvailable (int nPlanet, int bAvailable)
        {
            Console.WriteLine ("Function SetPlanetAvailable not implemented");
            throw new NotImplementedException ();
        }
        public static int GetPlanetAvailable (int nPlanet)
        {
            Console.WriteLine ("Function GetPlanetAvailable not implemented");
            throw new NotImplementedException ();
        }
        public static int GetSelectedPlanet ()
        {
            Console.WriteLine ("Function GetSelectedPlanet not implemented");
            throw new NotImplementedException ();
        }
        public static void SoundObjectFadeAndStop (AuroraObject oSound, float fSeconds)
        {
            Console.WriteLine ("Function SoundObjectFadeAndStop not implemented");
            throw new NotImplementedException ();
        }
        public static void SetAreaFogColor (AuroraObject oArea, float fRed, float fGreen, float fBlue)
        {
            Console.WriteLine ("Function SetAreaFogColor not implemented");
            throw new NotImplementedException ();
        }
        public static void ChangeItemCost (string sItem, float fCostMultiplier)
        {
            Console.WriteLine ("Function ChangeItemCost not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsLiveContentAvailable (int nPkg)
        {
            Console.WriteLine ("Function GetIsLiveContentAvailable not implemented");
            throw new NotImplementedException ();
        }
        public static void ResetDialogState ()
        {
            Console.WriteLine ("Function ResetDialogState not implemented");
            throw new NotImplementedException ();
        }
        public static void SetGoodEvilValue (AuroraObject oCreature, int nAlignment)
        {
            Console.WriteLine ("Function SetGoodEvilValue not implemented");
            throw new NotImplementedException ();
        }
        public static int GetIsPoisoned (AuroraObject oObject)
        {
            return Convert.ToInt32(oObject.isPoisoned);
        }
        public static AuroraObject GetSpellTarget (AuroraObject oCreature = null)
        {
            oCreature = oCreature ?? stateManager.GetObjectSelf ();
            return (oCreature.spellTarget);
        }
        public static void SetSoloMode (int bActivate)
        {
            stateManager.soloMode = Convert.ToBoolean(bActivate);
        }
        public static AuroraEffect EffectCutSceneHorrified ()
        {
            Console.WriteLine ("Function EffectCutSceneHorrified not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectCutSceneParalyze ()
        {
            Console.WriteLine ("Function EffectCutSceneParalyze not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraEffect EffectCutSceneStunned ()
        {
            Console.WriteLine ("Function EffectCutSceneStunned not implemented");
            throw new NotImplementedException ();
        }
        public static void CancelPostDialogCharacterSwitch ()
        {
            Console.WriteLine ("Function CancelPostDialogCharacterSwitch not implemented");
            throw new NotImplementedException ();
        }
        public static void SetMaxHitPoints (AuroraObject oObject, int nMaxHP)
        {
            Console.WriteLine ("Function SetMaxHitPoints not implemented");
            throw new NotImplementedException ();
        }
        public static void NoClicksFor (float fDuration)
        {
            // TODO: Implement this
            //Console.WriteLine ("Function NoClicksFor not implemented");
            //throw new NotImplementedException ();
            Debug.LogWarning("No clicks for not yet implemented");
        }
        public static void HoldWorldFadeInForDialog ()
        {
            Console.WriteLine ("Function HoldWorldFadeInForDialog not implemented");
            throw new NotImplementedException ();
        }
        public static int ShipBuild ()
        {
            // TODO: Set this to true before release
            // This is a debug build for now
            return 0;
        }
        public static void SurrenderRetainBuffs ()
        {
            Console.WriteLine ("Function SurrenderRetainBuffs not implemented");
            throw new NotImplementedException ();
        }
        public static void SuppressStatusSummaryEntry (int nNumEntries = 1)
        {
            Console.WriteLine ("Function SuppressStatusSummaryEntry not implemented");
            throw new NotImplementedException ();
        }
        public static int GetCheatCode (int nCode)
        {
            Console.WriteLine ("Function GetCheatCode not implemented");
            throw new NotImplementedException ();
        }
        public static void SetMusicVolume (float fVolume = 1.0f)
        {
            // I won't implement this, as it's marked as "NEVER USE THIS"
            Console.WriteLine ("Function SetMusicVolume not implemented");
            throw new NotImplementedException ();
        }
        public static AuroraObject CreateItemOnFloor (string sTemplate, AuroraLocation lLocation, int bUseAppearAnimation = 0)
        {
            Console.WriteLine ("Function CreateItemOnFloor not implemented");
            throw new NotImplementedException ();
        }
        public static void SetAvailableNPCId (int nNPC, AuroraObjectID oidNPC)
        {
            Console.WriteLine ("Function SetAvailableNPCId not implemented");
            throw new NotImplementedException ();
        }
        public static int IsMoviePlaying ()
        {
            return Convert.ToInt32(movieSystem.playing);
        }
        public static void QueueMovie (string sMovie, int bSkippable)
        {
            // TODO: Make movies skippable when bSkippable is true
            movieSystem.AddToQueue(sMovie);
        }
        public static void PlayMovieQueue (int bAllowSeparateSkips)
        {
            // TODO: Enable "allow separate skips"
            movieSystem.StartPlaying();
        }
        public static void YavinHackCloseDoor (AuroraObject oidDoor)
        {
            Console.WriteLine ("Function YavinHackCloseDoor not implemented");
            throw new NotImplementedException ();
        }
    }
}