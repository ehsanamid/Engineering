﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data.SQLite;
using DCS.DCSTables;
using System.Reflection;


namespace DCS
{


    public enum OPCODES : int
    {
        UNKNOWN = 0,
        BOOL_MOVE_BOOL,
        BYTE_MOVE_BYTE,
        WORD_MOVE_WORD,
        DWORD_MOVE_DWORD,
        LWORD_MOVE_LWORD,
        SINT_MOVE_SINT,
        INT_MOVE_INT,
        DINT_MOVE_DINT,
        LINT_MOVE_LINT,
        USINT_MOVE_USINT,
        UINT_MOVE_UINT,
        UDINT_MOVE_UDINT,
        ULINT_MOVE_ULINT,
        REAL_MOVE_REAL,
        LREAL_MOVE_LREAL,
        TOD_MOVE_TOD,
        DT_MOVE_DT,
        TIME_MOVE_TIME,
        DATE_MOVE_DATE,
        STRING_MOVE_STRING,
        WSTRING_MOVE_WSTRING,
        BOOL_AND_BOOL_BOOL,
        BYTE_AND_BYTE_BYTE,
        WORD_AND_WORD_WORD,
        DWORD_AND_DWORD_DWORD,
        LWORD_AND_LWORD_LWORD,
        BOOL_OR_BOOL_BOOL,
        BYTE_OR_BYTE_BYTE,
        WORD_OR_WORD_WORD,
        DWORD_OR_DWORD_DWORD,
        LWORD_OR_LWORD_LWORD,
        BOOL_XOR_BOOL_BOOL,
        BYTE_XOR_BYTE_BYTE,
        WORD_XOR_WORD_WORD,
        DWORD_XOR_DWORD_DWORD,
        LWORD_XOR_LWORD_LWORD,
        BOOL_NOT_BOOL,
        BYTE_NOT_BYTE,
        WORD_NOT_WORD,
        DWORD_NOT_DWORD,
        LWORD_NOT_LWORD,
        SINT_ADD_SINT_SINT,
        INT_ADD_INT_INT,
        DINT_ADD_DINT_DINT,
        LINT_ADD_LINT_LINT,
        USINT_ADD_USINT_USINT,
        UINT_ADD_UINT_UINT,
        UDINT_ADD_UDINT_UDINT,
        ULINT_ADD_ULINT_ULINT,
        REAL_ADD_REAL_REAL,
        LREAL_ADD_LREAL_LREAL,
        TIME_ADD_TIME_TIME,
        TOD_ADD_TOD_TIME,
        DT_ADD_DT_TIME,
        SINT_SUB_SINT_SINT,
        INT_SUB_INT_INT,
        DINT_SUB_DINT_DINT,
        LINT_SUB_LINT_LINT,
        USINT_SUB_USINT_USINT,
        UINT_SUB_UINT_UINT,
        UDINT_SUB_UDINT_UDINT,
        ULINT_SUB_ULINT_ULINT,
        TIME_SUB_TIME_TIME,
        TIME_SUB_DATE_DATE,
        TOD_SUB_TOD_TIME,
        TIME_SUB_TOD_TOD,
        DT_SUB_DT_TIME,
        TIME_SUB_DT_DT,
        REAL_SUB_REAL_REAL,
        LREAL_SUB_LREAL_LREAL,
        SINT_MOD_SINT_SINT,
        INT_MOD_INT_INT,
        DINT_MOD_DINT_DINT,
        LINT_MOD_LINT_LINT,
        USINT_MOD_USINT_USINT,
        UINT_MOD_UINT_UINT,
        UDINT_MOD_UDINT_UDINT,
        ULINT_MOD_ULINT_ULINT,
        REAL_MOD_REAL_REAL,
        LREAL_MOD_LREAL_LREAL,
        SINT_EXPT_SINT_SINT,
        INT_EXPT_INT_INT,
        DINT_EXPT_DINT_DINT,
        LINT_EXPT_LINT_LINT,
        USINT_EXPT_USINT_USINT,
        UINT_EXPT_UINT_UINT,
        UDINT_EXPT_UDINT_UDINT,
        ULINT_EXPT_ULINT_ULINT,
        REAL_EXPT_REAL_REAL,
        LREAL_EXPT_LREAL_LREAL,
        BYTE_SHL_BYTE_UINT,
        WORD_SHL_WORD_UINT,
        DWORD_SHL_DWORD_UINT,
        LWORD_SHL_LWORD_UINT,
        BYTE_SHR_BYTE_UINT,
        WORD_SHR_WORD_UINT,
        DWORD_SHR_DWORD_UINT,
        LWORD_SHR_LWORD_UINT,
        BYTE_ROR_BYTE_UINT,
        WORD_ROR_WORD_UINT,
        DWORD_ROR_DWORD_UINT,
        LWORD_ROR_LWORD_UINT,
        BYTE_ROL_BYTE_UINT,
        WORD_ROL_WORD_UINT,
        DWORD_ROL_DWORD_UINT,
        LWORD_ROL_LWORD_UINT,
        BOOL_MAX_BOOL_BOOL,
        BYTE_MAX_BYTE_BYTE,
        WORD_MAX_WORD_WORD,
        DWORD_MAX_DWORD_DWORD,
        LWORD_MAX_LWORD_LWORD,
        SINT_MAX_SINT_SINT,
        INT_MAX_INT_INT,
        DINT_MAX_DINT_DINT,
        LINT_MAX_LINT_LINT,
        USINT_MAX_USINT_USINT,
        UINT_MAX_UINT_UINT,
        UDINT_MAX_UDINT_UDINT,
        ULINT_MAX_ULINT_ULINT,
        REAL_MAX_REAL_REAL,
        LREAL_MAX_LREAL_LREAL,
        BOOL_MIN_BOOL_BOOL,
        BYTE_MIN_BYTE_BYTE,
        WORD_MIN_WORD_WORD,
        DWORD_MIN_DWORD_DWORD,
        LWORD_MIN_LWORD_LWORD,
        SINT_MIN_SINT_SINT,
        INT_MIN_INT_INT,
        DINT_MIN_DINT_DINT,
        LINT_MIN_LINT_LINT,
        USINT_MIN_USINT_USINT,
        UINT_MIN_UINT_UINT,
        UDINT_MIN_UDINT_UDINT,
        ULINT_MIN_ULINT_ULINT,
        REAL_MIN_REAL_REAL,
        LREAL_MIN_LREAL_LREAL,
        BOOL_LIMIT_BOOL_BOOL_BOOL,
        BYTE_LIMIT_BYTE_BYTE_BYTE,
        WORD_LIMIT_WORD_WORD_WORD,
        DWORD_LIMIT_DWORD_DWORD_DWORD,
        LWORD_LIMIT_LWORD_LWORD_LWORD,
        SINT_LIMIT_SINT_SINT_SINT,
        INT_LIMIT_INT_INT_INT,
        DINT_LIMIT_DINT_DINT_DINT,
        LINT_LIMIT_LINT_LINT_LINT,
        USINT_LIMIT_USINT_USINT_USINT,
        UINT_LIMIT_UINT_UINT_UINT,
        UDINT_LIMIT_UDINT_UDINT_UDINT,
        ULINT_LIMIT_ULINT_ULINT_ULINT,
        REAL_LIMIT_REAL_REAL_REAL,
        LREAL_LIMIT_LREAL_LREAL_LREAL,
        TIME_LIMIT_TIME_TIME_TIME,
        DATE_LIMIT_DATE_DATE_DATE,
        DT_LIMIT_DT_DT_DT,
        TOD_LIMIT_TOD_TOD_TOD,
        BOOL_GT_BOOL_BOOL,
        BOOL_GT_BYTE_BYTE,
        BOOL_GT_WORD_WORD,
        BOOL_GT_DWORD_DWORD,
        BOOL_GT_LWORD_LWORD,
        BOOL_GT_SINT_SINT,
        BOOL_GT_INT_INT,
        BOOL_GT_DINT_DINT,
        BOOL_GT_LINT_LINT,
        BOOL_GT_USINT_USINT,
        BOOL_GT_UINT_UINT,
        BOOL_GT_UDINT_UDINT,
        BOOL_GT_ULINT_ULINT,
        BOOL_GT_REAL_REAL,
        BOOL_GT_LREAL_LREAL,
        BOOL_GT_TIME_TIME,
        BOOL_GT_DATE_DATE,
        BOOL_GT_TOD_TOD,
        BOOL_GT_DT_DT,
        BOOL_GE_BOOL_BOOL,
        BOOL_GE_BYTE_BYTE,
        BOOL_GE_WORD_WORD,
        BOOL_GE_DWORD_DWORD,
        BOOL_GE_LWORD_LWORD,
        BOOL_GE_SINT_SINT,
        BOOL_GE_INT_INT,
        BOOL_GE_DINT_DINT,
        BOOL_GE_LINT_LINT,
        BOOL_GE_USINT_USINT,
        BOOL_GE_UINT_UINT,
        BOOL_GE_UDINT_UDINT,
        BOOL_GE_ULINT_ULINT,
        BOOL_GE_REAL_REAL,
        BOOL_GE_LREAL_LREAL,
        BOOL_GE_TIME_TIME,
        BOOL_GE_DATE_DATE,
        BOOL_GE_TOD_TOD,
        BOOL_GE_DT_DT,
        BOOL_LT_BOOL_BOOL,
        BOOL_LT_BYTE_BYTE,
        BOOL_LT_WORD_WORD,
        BOOL_LT_DWORD_DWORD,
        BOOL_LT_LWORD_LWORD,
        BOOL_LT_SINT_SINT,
        BOOL_LT_INT_INT,
        BOOL_LT_DINT_DINT,
        BOOL_LT_LINT_LINT,
        BOOL_LT_USINT_USINT,
        BOOL_LT_UINT_UINT,
        BOOL_LT_UDINT_UDINT,
        BOOL_LT_ULINT_ULINT,
        BOOL_LT_REAL_REAL,
        BOOL_LT_LREAL_LREAL,
        BOOL_LT_TIME_TIME,
        BOOL_LT_DATE_DATE,
        BOOL_LT_TOD_TOD,
        BOOL_LT_DT_DT,
        BOOL_LE_BOOL_BOOL,
        BOOL_LE_BYTE_BYTE,
        BOOL_LE_WORD_WORD,
        BOOL_LE_DWORD_DWORD,
        BOOL_LE_LWORD_LWORD,
        BOOL_LE_SINT_SINT,
        BOOL_LE_INT_INT,
        BOOL_LE_DINT_DINT,
        BOOL_LE_LINT_LINT,
        BOOL_LE_USINT_USINT,
        BOOL_LE_UINT_UINT,
        BOOL_LE_UDINT_UDINT,
        BOOL_LE_ULINT_ULINT,
        BOOL_LE_REAL_REAL,
        BOOL_LE_LREAL_LREAL,
        BOOL_LE_TIME_TIME,
        BOOL_LE_DATE_DATE,
        BOOL_LE_TOD_TOD,
        BOOL_LE_DT_DT,
        BOOL_EQ_BOOL_BOOL,
        BOOL_EQ_BYTE_BYTE,
        BOOL_EQ_WORD_WORD,
        BOOL_EQ_DWORD_DWORD,
        BOOL_EQ_LWORD_LWORD,
        BOOL_EQ_SINT_SINT,
        BOOL_EQ_INT_INT,
        BOOL_EQ_DINT_DINT,
        BOOL_EQ_LINT_LINT,
        BOOL_EQ_USINT_USINT,
        BOOL_EQ_UINT_UINT,
        BOOL_EQ_UDINT_UDINT,
        BOOL_EQ_ULINT_ULINT,
        BOOL_EQ_REAL_REAL,
        BOOL_EQ_LREAL_LREAL,
        BOOL_EQ_TIME_TIME,
        BOOL_EQ_DATE_DATE,
        BOOL_EQ_TOD_TOD,
        BOOL_EQ_DT_DT,
        BOOL_NE_BOOL_BOOL,
        BOOL_NE_BYTE_BYTE,
        BOOL_NE_WORD_WORD,
        BOOL_NE_DWORD_DWORD,
        BOOL_NE_LWORD_LWORD,
        BOOL_NE_SINT_SINT,
        BOOL_NE_INT_INT,
        BOOL_NE_DINT_DINT,
        BOOL_NE_LINT_LINT,
        BOOL_NE_USINT_USINT,
        BOOL_NE_UINT_UINT,
        BOOL_NE_UDINT_UDINT,
        BOOL_NE_ULINT_ULINT,
        BOOL_NE_REAL_REAL,
        BOOL_NE_LREAL_LREAL,
        BOOL_NE_TIME_TIME,
        BOOL_NE_DATE_DATE,
        BOOL_NE_TOD_TOD,
        BOOL_NE_DT_DT,
        TIME_DIV_TIME_SINT,
        TIME_DIV_TIME_INT,
        TIME_DIV_TIME_DINT,
        TIME_DIV_TIME_LINT,
        TIME_DIV_TIME_USINT,
        TIME_DIV_TIME_UINT,
        TIME_DIV_TIME_UDINT,
        TIME_DIV_TIME_ULINT,
        TIME_DIV_TIME_REAL,
        TIME_DIV_TIME_LREAL,
        SINT_DIV_SINT_SINT,
        INT_DIV_INT_INT,
        DINT_DIV_DINT_DINT,
        LINT_DIV_LINT_LINT,
        USINT_DIV_USINT_USINT,
        UINT_DIV_UINT_UINT,
        UDINT_DIV_UDINT_UDINT,
        ULINT_DIV_ULINT_ULINT,
        REAL_DIV_REAL_REAL,
        LREAL_DIV_LREAL_LREAL,
        END_DIV_OPCODE_,
        BEGIN_MUL_OPCODE_,
        TIME_MUL_TIME_SINT,
        TIME_MUL_TIME_INT,
        TIME_MUL_TIME_DINT,
        TIME_MUL_TIME_LINT,
        TIME_MUL_TIME_USINT,
        TIME_MUL_TIME_UINT,
        TIME_MUL_TIME_UDINT,
        TIME_MUL_TIME_ULINT,
        TIME_MUL_TIME_REAL,
        TIME_MUL_TIME_LREAL,
        SINT_MUL_SINT_SINT,
        INT_MUL_INT_INT,
        DINT_MUL_DINT_DINT,
        LINT_MUL_LINT_LINT,
        USINT_MUL_USINT_USINT,
        UINT_MUL_UINT_UINT,
        UDINT_MUL_UDINT_UDINT,
        ULINT_MUL_ULINT_ULINT,
        REAL_MUL_REAL_REAL,
        LREAL_MUL_LREAL_LREAL,
        END_MUL_OPCODE_,
        BEGIN_MUX_USINT_OPCODE_,
        TIME_MUX_USINT_TIME_TIME,
        DATE_MUX_USINT_DATE_DATE,
        TOD_MUX_USINT_TOD_TOD,
        DT_MUX_USINT_DT_DT,
        BOOL_MUX_USINT_BOOL_BOOL,
        BYTE_MUX_USINT_BYTE_BYTE,
        WORD_MUX_USINT_WORD_WORD,
        DWORD_MUX_USINT_DWORD_DWORD,
        LWORD_MUX_USINT_LWORD_LWORD,
        SINT_MUX_USINT_SINT_SINT,
        INT_MUX_USINT_INT_INT,
        DINT_MUX_USINT_DINT_DINT,
        LINT_MUX_USINT_LINT_LINT,
        USINT_MUX_USINT_USINT_USINT,
        UINT_MUX_USINT_UINT_UINT,
        UDINT_MUX_USINT_UDINT_UDINT,
        ULINT_MUX_USINT_ULINT_ULINT,
        REAL_MUX_USINT_REAL_REAL,
        LREAL_MUX_USINT_LREAL_LREAL,
        END_MUX_USINT_OPCODE_,
        BEGIN_IF_BOOL_OPCODE_,
        BOOL_IF_BOOL_BOOL,
        BYTE_IF_BOOL_BYTE,
        WORD_IF_BOOL_WORD,
        DWORD_IF_BOOL_DWORD,
        LWORD_IF_BOOL_LWORD,
        SINT_IF_BOOL_SINT,
        INT_IF_BOOL_INT,
        DINT_IF_BOOL_DINT,
        LINT_IF_BOOL_LINT,
        USINT_IF_BOOL_USINT,
        UINT_IF_BOOL_UINT,
        UDINT_IF_BOOL_UDINT,
        ULINT_IF_BOOL_ULINT,
        REAL_IF_BOOL_REAL,
        LREAL_IF_BOOL_LREAL,
        TIME_IF_BOOL_TIME,
        DATE_IF_BOOL_DATE,
        TOD_IF_BOOL_TOD,
        DT_IF_BOOL_DT,
        STRING_IF_BOOL_STRING,
        BOOL_IFE_BOOL_BOOL_BOOL,
        BYTE_IFE_BOOL_BYTE_BYTE,
        WORD_IFE_BOOL_WORD_WORD,
        DWORD_IFE_BOOL_DWORD_DWORD,
        LWORD_IFE_BOOL_LWORD_LWORD,
        SINT_IFE_BOOL_SINT_SINT,
        INT_IFE_BOOL_INT_INT,
        DINT_IFE_BOOL_DINT_DINT,
        LINT_IFE_BOOL_LINT_LINT,
        USINT_IFE_BOOL_USINT_USINT,
        UINT_IFE_BOOL_UINT_UINT,
        UDINT_IFE_BOOL_UDINT_UDINT,
        ULINT_IFE_BOOL_ULINT_ULINT,
        REAL_IFE_BOOL_REAL_REAL,
        LREAL_IFE_BOOL_LREAL_LREAL,
        TIME_IFE_BOOL_TIME_TIME,
        DATE_IFE_BOOL_DATE_DATE,
        TOD_IFE_BOOL_TOD_TOD,
        DT_IFE_BOOL_DT_DT,
        STRING_IFE_BOOL_STRING_STRING,
        DATE_SEL_BOOL_DATE_DATE,
        TOD_SEL_BOOL_TOD_TOD,
        DT_SEL_BOOL_DT_DT,
        BOOL_SEL_BOOL_BOOL_BOOL,
        BYTE_SEL_BOOL_BYTE_BYTE,
        WORD_SEL_BOOL_WORD_WORD,
        DWORD_SEL_BOOL_DWORD_DWORD,
        LWORD_SEL_BOOL_LWORD_LWORD,
        SINT_SEL_BOOL_SINT_SINT,
        INT_SEL_BOOL_INT_INT,
        DINT_SEL_BOOL_DINT_DINT,
        LINT_SEL_BOOL_LINT_LINT,
        USINT_SEL_BOOL_USINT_USINT,
        UINT_SEL_BOOL_UINT_UINT,
        UDINT_SEL_BOOL_UDINT_UDINT,
        ULINT_SEL_BOOL_ULINT_ULINT,
        REAL_SEL_BOOL_REAL_REAL,
        LREAL_SEL_BOOL_LREAL_LREAL,
        TIME_SEL_BOOL_TIME_TIME,
        LREAL_SQRT_LREAL,
        REAL_SQRT_REAL,
        LREAL_LN_LREAL,
        REAL_LN_REAL,
        LREAL_LOG_LREAL,
        REAL_LOG_REAL,
        LREAL_EXP_LREAL,
        REAL_EXP_REAL,
        LREAL_SIN_LREAL,
        REAL_SIN_REAL,
        LREAL_COS_LREAL,
        REAL_COS_REAL,
        LREAL_TAN_LREAL,
        REAL_TAN_REAL,
        LREAL_ASIN_LREAL,
        REAL_ASIN_REAL,
        LREAL_ACOS_LREAL,
        REAL_ACOS_REAL,
        LREAL_ATAN_LREAL,
        REAL_ATAN_REAL,
        SINT_ABS_SINT,
        INT_ABS_INT,
        DINT_ABS_DINT,
        LINT_ABS_LINT,
        USINT_ABS_USINT,
        UINT_ABS_UINT,
        UDINT_ABS_UDINT,
        ULINT_ABS_ULINT,
        REAL_ABS_REAL,
        LREAL_ABS_LREAL,
        BOOL_TO_BOOL,
        BOOL_TO_BYTE,
        BOOL_TO_WORD,
        BOOL_TO_DWORD,
        BOOL_TO_LWORD,
        BOOL_TO_SINT,
        BOOL_TO_INT,
        BOOL_TO_DINT,
        BOOL_TO_LINT,
        BOOL_TO_USINT,
        BOOL_TO_UINT,
        BOOL_TO_UDINT,
        BOOL_TO_ULINT,
        BOOL_TO_REAL,
        BOOL_TO_LREAL,
        BOOL_TO_TIME,
        BOOL_TO_DATE,
        BOOL_TO_TOD,
        BOOL_TO_DT,
        BYTE_TO_BOOL,
        BYTE_TO_BYTE,
        BYTE_TO_WORD,
        BYTE_TO_DWORD,
        BYTE_TO_LWORD,
        BYTE_TO_SINT,
        BYTE_TO_INT,
        BYTE_TO_DINT,
        BYTE_TO_LINT,
        BYTE_TO_USINT,
        BYTE_TO_UINT,
        BYTE_TO_UDINT,
        BYTE_TO_ULINT,
        BYTE_TO_REAL,
        BYTE_TO_LREAL,
        BYTE_TO_TIME,
        BYTE_TO_DATE,
        BYTE_TO_TOD,
        BYTE_TO_DT,
        WORD_TO_BOOL,
        WORD_TO_BYTE,
        WORD_TO_WORD,
        WORD_TO_DWORD,
        WORD_TO_LWORD,
        WORD_TO_SINT,
        WORD_TO_INT,
        WORD_TO_DINT,
        WORD_TO_LINT,
        WORD_TO_USINT,
        WORD_TO_UINT,
        WORD_TO_UDINT,
        WORD_TO_ULINT,
        WORD_TO_REAL,
        WORD_TO_LREAL,
        WORD_TO_TIME,
        WORD_TO_DATE,
        WORD_TO_TOD,
        WORD_TO_DT,
        DWORD_TO_BOOL,
        DWORD_TO_BYTE,
        DWORD_TO_WORD,
        DWORD_TO_DWORD,
        DWORD_TO_LWORD,
        DWORD_TO_SINT,
        DWORD_TO_INT,
        DWORD_TO_DINT,
        DWORD_TO_LINT,
        DWORD_TO_USINT,
        DWORD_TO_UINT,
        DWORD_TO_UDINT,
        DWORD_TO_ULINT,
        DWORD_TO_REAL,
        DWORD_TO_LREAL,
        DWORD_TO_TIME,
        DWORD_TO_DATE,
        DWORD_TO_TOD,
        DWORD_TO_DT,
        LWORD_TO_BOOL,
        LWORD_TO_BYTE,
        LWORD_TO_WORD,
        LWORD_TO_DWORD,
        LWORD_TO_LWORD,
        LWORD_TO_SINT,
        LWORD_TO_INT,
        LWORD_TO_DINT,
        LWORD_TO_LINT,
        LWORD_TO_USINT,
        LWORD_TO_UINT,
        LWORD_TO_UDINT,
        LWORD_TO_ULINT,
        LWORD_TO_REAL,
        LWORD_TO_LREAL,
        LWORD_TO_TIME,
        LWORD_TO_DATE,
        LWORD_TO_TOD,
        LWORD_TO_DT,
        SINT_TO_BOOL,
        SINT_TO_BYTE,
        SINT_TO_WORD,
        SINT_TO_DWORD,
        SINT_TO_LWORD,
        SINT_TO_SINT,
        SINT_TO_INT,
        SINT_TO_DINT,
        SINT_TO_LINT,
        SINT_TO_USINT,
        SINT_TO_UINT,
        SINT_TO_UDINT,
        SINT_TO_ULINT,
        SINT_TO_REAL,
        SINT_TO_LREAL,
        SINT_TO_TIME,
        SINT_TO_DATE,
        SINT_TO_TOD,
        SINT_TO_DT,
        INT_TO_BOOL,
        INT_TO_BYTE,
        INT_TO_WORD,
        INT_TO_DWORD,
        INT_TO_LWORD,
        INT_TO_SINT,
        INT_TO_INT,
        INT_TO_DINT,
        INT_TO_LINT,
        INT_TO_USINT,
        INT_TO_UINT,
        INT_TO_UDINT,
        INT_TO_ULINT,
        INT_TO_REAL,
        INT_TO_LREAL,
        INT_TO_TIME,
        INT_TO_DATE,
        INT_TO_TOD,
        INT_TO_DT,
        DINT_TO_BOOL,
        DINT_TO_BYTE,
        DINT_TO_WORD,
        DINT_TO_DWORD,
        DINT_TO_LWORD,
        DINT_TO_SINT,
        DINT_TO_INT,
        DINT_TO_DINT,
        DINT_TO_LINT,
        DINT_TO_USINT,
        DINT_TO_UINT,
        DINT_TO_UDINT,
        DINT_TO_ULINT,
        DINT_TO_REAL,
        DINT_TO_LREAL,
        DINT_TO_TIME,
        DINT_TO_DATE,
        DINT_TO_TOD,
        DINT_TO_DT,
        LINT_TO_BOOL,
        LINT_TO_BYTE,
        LINT_TO_WORD,
        LINT_TO_DWORD,
        LINT_TO_LWORD,
        LINT_TO_SINT,
        LINT_TO_INT,
        LINT_TO_DINT,
        LINT_TO_LINT,
        LINT_TO_USINT,
        LINT_TO_UINT,
        LINT_TO_UDINT,
        LINT_TO_ULINT,
        LINT_TO_REAL,
        LINT_TO_LREAL,
        LINT_TO_TIME,
        LINT_TO_DATE,
        LINT_TO_TOD,
        LINT_TO_DT,
        USINT_TO_BOOL,
        USINT_TO_BYTE,
        USINT_TO_WORD,
        USINT_TO_DWORD,
        USINT_TO_LWORD,
        USINT_TO_SINT,
        USINT_TO_INT,
        USINT_TO_DINT,
        USINT_TO_LINT,
        USINT_TO_USINT,
        USINT_TO_UINT,
        USINT_TO_UDINT,
        USINT_TO_ULINT,
        USINT_TO_REAL,
        USINT_TO_LREAL,
        USINT_TO_TIME,
        USINT_TO_DATE,
        USINT_TO_TOD,
        USINT_TO_DT,
        UINT_TO_BOOL,
        UINT_TO_BYTE,
        UINT_TO_WORD,
        UINT_TO_DWORD,
        UINT_TO_LWORD,
        UINT_TO_SINT,
        UINT_TO_INT,
        UINT_TO_DINT,
        UINT_TO_LINT,
        UINT_TO_USINT,
        UINT_TO_UINT,
        UINT_TO_UDINT,
        UINT_TO_ULINT,
        UINT_TO_REAL,
        UINT_TO_LREAL,
        UINT_TO_TIME,
        UINT_TO_DATE,
        UINT_TO_TOD,
        UINT_TO_DT,
        UDINT_TO_BOOL,
        UDINT_TO_BYTE,
        UDINT_TO_WORD,
        UDINT_TO_DWORD,
        UDINT_TO_LWORD,
        UDINT_TO_SINT,
        UDINT_TO_INT,
        UDINT_TO_DINT,
        UDINT_TO_LINT,
        UDINT_TO_USINT,
        UDINT_TO_UINT,
        UDINT_TO_UDINT,
        UDINT_TO_ULINT,
        UDINT_TO_REAL,
        UDINT_TO_LREAL,
        UDINT_TO_TIME,
        UDINT_TO_DATE,
        UDINT_TO_TOD,
        UDINT_TO_DT,
        ULINT_TO_BOOL,
        ULINT_TO_BYTE,
        ULINT_TO_WORD,
        ULINT_TO_DWORD,
        ULINT_TO_LWORD,
        ULINT_TO_SINT,
        ULINT_TO_INT,
        ULINT_TO_DINT,
        ULINT_TO_LINT,
        ULINT_TO_USINT,
        ULINT_TO_UINT,
        ULINT_TO_UDINT,
        ULINT_TO_ULINT,
        ULINT_TO_REAL,
        ULINT_TO_LREAL,
        ULINT_TO_TIME,
        ULINT_TO_DATE,
        ULINT_TO_TOD,
        ULINT_TO_DT,
        REAL_TO_BOOL,
        REAL_TO_BYTE,
        REAL_TO_WORD,
        REAL_TO_DWORD,
        REAL_TO_LWORD,
        REAL_TO_SINT,
        REAL_TO_INT,
        REAL_TO_DINT,
        REAL_TO_LINT,
        REAL_TO_USINT,
        REAL_TO_UINT,
        REAL_TO_UDINT,
        REAL_TO_ULINT,
        REAL_TO_REAL,
        REAL_TO_LREAL,
        REAL_TO_TIME,
        REAL_TO_DATE,
        REAL_TO_TOD,
        REAL_TO_DT,
        LREAL_TO_BOOL,
        LREAL_TO_BYTE,
        LREAL_TO_WORD,
        LREAL_TO_DWORD,
        LREAL_TO_LWORD,
        LREAL_TO_SINT,
        LREAL_TO_INT,
        LREAL_TO_DINT,
        LREAL_TO_LINT,
        LREAL_TO_USINT,
        LREAL_TO_UINT,
        LREAL_TO_UDINT,
        LREAL_TO_ULINT,
        LREAL_TO_REAL,
        LREAL_TO_LREAL,
        LREAL_TO_TIME,
        LREAL_TO_DATE,
        LREAL_TO_TOD,
        LREAL_TO_DT,
        TIME_TO_BOOL,
        TIME_TO_BYTE,
        TIME_TO_WORD,
        TIME_TO_DWORD,
        TIME_TO_LWORD,
        TIME_TO_SINT,
        TIME_TO_INT,
        TIME_TO_DINT,
        TIME_TO_LINT,
        TIME_TO_USINT,
        TIME_TO_UINT,
        TIME_TO_UDINT,
        TIME_TO_ULINT,
        TIME_TO_REAL,
        TIME_TO_LREAL,
        TIME_TO_TIME,
        DATE_TO_BOOL,
        DATE_TO_BYTE,
        DATE_TO_WORD,
        DATE_TO_DWORD,
        DATE_TO_LWORD,
        DATE_TO_SINT,
        DATE_TO_INT,
        DATE_TO_DINT,
        DATE_TO_LINT,
        DATE_TO_USINT,
        DATE_TO_UINT,
        DATE_TO_UDINT,
        DATE_TO_ULINT,
        DATE_TO_REAL,
        DATE_TO_LREAL,
        DATE_TO_DATE,
        DATE_TO_DT,
        TOD_TO_BOOL,
        TOD_TO_BYTE,
        TOD_TO_WORD,
        TOD_TO_DWORD,
        TOD_TO_LWORD,
        TOD_TO_SINT,
        TOD_TO_INT,
        TOD_TO_DINT,
        TOD_TO_LINT,
        TOD_TO_USINT,
        TOD_TO_UINT,
        TOD_TO_UDINT,
        TOD_TO_ULINT,
        TOD_TO_REAL,
        TOD_TO_LREAL,
        TOD_TO_TOD,
        TOD_TO_DT,
        DT_TO_BOOL,
        DT_TO_BYTE,
        DT_TO_WORD,
        DT_TO_DWORD,
        DT_TO_LWORD,
        DT_TO_SINT,
        DT_TO_INT,
        DT_TO_DINT,
        DT_TO_LINT,
        DT_TO_USINT,
        DT_TO_UINT,
        DT_TO_UDINT,
        DT_TO_ULINT,
        DT_TO_REAL,
        DT_TO_LREAL,
        DT_TO_DT,
        STRING_TO_BOOL,
        STRING_TO_BYTE,
        STRING_TO_WORD,
        STRING_TO_DWORD,
        STRING_TO_LWORD,
        STRING_TO_SINT,
        STRING_TO_INT,
        STRING_TO_DINT,
        STRING_TO_LINT,
        STRING_TO_USINT,
        STRING_TO_UINT,
        STRING_TO_UDINT,
        STRING_TO_ULINT,
        STRING_TO_REAL,
        STRING_TO_LREAL,
        STRING_TO_DT,
        STRING_TO_STRING,
        STRING_TO_WSTRING,
        WSTRING_TO_BOOL,
        WSTRING_TO_BYTE,
        WSTRING_TO_WORD,
        WSTRING_TO_DWORD,
        WSTRING_TO_LWORD,
        WSTRING_TO_SINT,
        WSTRING_TO_INT,
        WSTRING_TO_DINT,
        WSTRING_TO_LINT,
        WSTRING_TO_USINT,
        WSTRING_TO_UINT,
        WSTRING_TO_UDINT,
        WSTRING_TO_ULINT,
        WSTRING_TO_REAL,
        WSTRING_TO_LREAL,
        WSTRING_TO_DT,
        WSTRING_TO_STRING,
        WSTRING_TO_WSTRING,
        BOOL_TO_STRING,
        BYTE_TO_STRING,
        WORD_TO_STRING,
        DWORD_TO_STRING,
        LWORD_TO_STRING,
        SINT_TO_STRING,
        INT_TO_STRING,
        DINT_TO_STRING,
        LINT_TO_STRING,
        USINT_TO_STRING,
        UINT_TO_STRING,
        UDINT_TO_STRING,
        ULINT_TO_STRING,
        REAL_TO_STRING,
        LREAL_TO_STRING,
        DT_TO_STRING,
        //STRING_TO_STRING,
        //WSTRING_TO_STRING,
        BOOL_TO_WSTRING,
        BYTE_TO_WSTRING,
        WORD_TO_WSTRING,
        DWORD_TO_WSTRING,
        LWORD_TO_WSTRING,
        SINT_TO_WSTRING,
        INT_TO_WSTRING,
        DINT_TO_WSTRING,
        LINT_TO_WSTRING,
        USINT_TO_WSTRING,
        UINT_TO_WSTRING,
        UDINT_TO_WSTRING,
        ULINT_TO_WSTRING,
        REAL_TO_WSTRING,
        LREAL_TO_WSTRING,
        DT_TO_WSTRING,
        //STRING_TO_WSTRING,
        //WSTRING_TO_WSTRING,

        TIME_MAX_TIME_TIME,
        DATE_MAX_DATE_DATE,
        DT_MAX_DT_DT,
        TOD_MAX_TOD_TOD,
        TIME_MIN_TIME_TIME,
        DATE_MIN_DATE_DATE,
        DT_MIN_DT_DT,
        TOD_MIN_TOD_TOD,
        H_M_S_MI_SYSTIME_A,
        Y_M_D_DW_SYSDATE_A,
        UDINT_RGB_DINT_DINT_DINT,
        RETURN_VALUE,
        RETURN_STRING,
        CALLFB,
        CALLF,
        FORMATED_STRING_REAL_UINT,
        DINT_GETYEAR_DINT,
        DINT_GETMONTH_DINT,
        DINT_GETDAY_DINT,
        DINT_GETHOUR_DINT,
        DINT_GETMINUTE_DINT,
        DINT_GETSECOND_DINT,
        DINT_GETMILLSECOND_DINT,
        BOOLS_TO_DINT,
        FBD_CALL_ALARMANC,
        FBD_CALL_CMP,
        FBD_CALL_CTD,
        FBD_CALL_CTU,
        FBD_CALL_CTUD,
        FBD_CALL_DERIVATIVE,
        FBD_CALL_F_TRIG,
        FBD_CALL_HYSTERESIS,
        FBD_CALL_INTEGRAL,
        FBD_CALL_LAG,
        FBD_CALL_PID,
        FBD_CALL_PIDCAS,
        FBD_CALL_PIDOVR,
        FBD_CALL_R_TRIG,
        FBD_CALL_RAMP,
        FBD_CALL_RS,
        FBD_CALL_RTC,
        FBD_CALL_SELPRI,
        FBD_CALL_SELREAD,
        FBD_CALL_SEMA,
        FBD_CALL_SETPRI,
        FBD_CALL_SIG_GEN,
        FBD_CALL_SPLIT,
        FBD_CALL_SR,
        FBD_CALL_STACKIN,
        FBD_CALL_SWDOUT,
        FBD_CALL_SWSOUT,
        FBD_CALL_TOF,
        FBD_CALL_TON,
        FBD_CALL_TP,
        FBD_CALL_TPLS,
        FBD_CALL_TSTP,
        FBD_CALL_WKHOUR,
        FBD_CALL_TOTALIZER,
        FBD_CALL_RAMP_GEN,
        FBD_CALL_BLINK,


    }

    
   
 
    
}