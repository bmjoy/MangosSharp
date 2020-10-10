﻿
namespace Mangos.Common.Enums.Spell
{
    public enum SpellAttributesCustom : uint
    {
        SPELL_ATTR_CU_CONE_BACK = 0x1U,
        SPELL_ATTR_CU_CONE_LINE = 0x2U,
        SPELL_ATTR_CU_SHARE_DAMAGE = 0x4U,
        SPELL_ATTR_CU_AURA_HOT = 0x8U,
        SPELL_ATTR_CU_AURA_DOT = 0x10U,
        SPELL_ATTR_CU_AURA_CC = 0x20U,
        SPELL_ATTR_CU_AURA_SPELL = 0x40U,
        SPELL_ATTR_CU_DIRECT_DAMAGE = 0x80U,
        SPELL_ATTR_CU_CHARGE = 0x100U,
        SPELL_ATTR_CU_LINK_CAST = 0x200U,
        SPELL_ATTR_CU_LINK_HIT = 0x400U,
        SPELL_ATTR_CU_LINK_AURA = 0x800U,
        SPELL_ATTR_CU_LINK_REMOVE = 0x1000U,
        SPELL_ATTR_CU_MOVEMENT_IMPAIR = 0x2000U
    }
}