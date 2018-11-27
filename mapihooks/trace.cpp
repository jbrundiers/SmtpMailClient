//-----------------------------------------------------------------------------------------------------------------------------
//	trace.cpp 
//
//	Copyright (C) 2017 Soft-Toolware. All Rights Reserved
//
//	The software is a free software.
//	It is distributed under the Code Project Open License (CPOL 1.02)
//	agreement. The full text of the CPOL is given in:
//	https://www.codeproject.com/info/cpol10.aspx
//	
//	The main points of CPOL 1.02 subject to the terms of the License are:
//
//	Source Code and Executable Files can be used in commercial applications;
//	Source Code and Executable Files can be redistributed; and
//	Source Code can be modified to create derivative works.
//	No claim of suitability, guarantee, or any warranty whatsoever is
//	provided. The software is provided "as-is".
#include <windows.h>
#include <stdio.h>
#include <stdarg.h>
#include <tchar.h>
#include "trace.h"

// Hint for using OutputDebugString():
//According to Microsoft, apparently for debugging x64 mixed mode applications the 
//debugger type of 'auto' (set in the Debugging->Debugger Type property page) defaults 
//to managed rather than mixed.This will need to be explicitly set to 'Mixed' for both 
//managed and native debug output to be seen when debugging a 64 bit build.


                             
void CDECL TRACE(LPCSTR lpszFormat, ...)
{
	va_list args;
	va_start(args, lpszFormat);

	int nBuf;
	TCHAR szBuffer[512];

	nBuf = _vstprintf(szBuffer, lpszFormat, args);
	va_end(args);
	OutputDebugString(szBuffer);
	return;
}

