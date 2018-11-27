//-----------------------------------------------------------------------------------------------------------------------------
//	mapihooks.dll redirects MAPI32 calls to SmtpMailClient
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
//
//-----------------------------------------------------------------------------------------------------------------------------

#include <stdlib.h>
#include <stdio.h>
#include <crtdbg.h>
#include <string.h>


#include "mapiHooks.h"
#include "trace.h"



HINSTANCE hInstance = NULL ;							// This instance of the DLL

char strCMDPath[MAX_PATH] = "" ;						// alloc global memory for path 

//-----------------------------------------------------------------------------------------------------------------------------
// The DLL's main procedure
//-----------------------------------------------------------------------------------------------------------------------------
BOOL WINAPI DllMain (HANDLE hInst, ULONG ul_reason_for_call, LPVOID lpReserved)
{
	DWORD dwType = REG_SZ;
	HKEY hKey = 0;
	DWORD value_length = MAX_PATH;

	// Read the commandline to execute from registry
	if (RegOpenKey(HKEY_CURRENT_USER, "SOFTWARE\\Clients\\Mail\\SmtpMailClient", &hKey) == ERROR_SUCCESS)
	{
		if (RegQueryValueEx(hKey, "EXEPath", NULL, &dwType, (LPBYTE) strCMDPath, &value_length) != ERROR_SUCCESS)
		{
			*strCMDPath = NULL;
		}
		RegCloseKey(hKey);
	}

	TRACE("mapiHooks : DLL Version %s startet\n", MAPIHOOKS_Version);
	TRACE("mapiHooks : Registry EXEPath = %s\n", strCMDPath );
	
	// Find out why we're being called
	switch (ul_reason_for_call)
	{
		case DLL_PROCESS_ATTACH:
			TRACE( "mapiHooks : DLL attached to process\n");
			//MessageBoxA(0, "mapiHooks : DLL attached to process", "Info", MB_OK | MB_ICONINFORMATION);
			break;
		
		case DLL_PROCESS_DETACH:
			TRACE("mapiHooks : DLL detached from process\n");
			break;

		case DLL_THREAD_ATTACH:
			TRACE("mapiHooks : DLL attached to thread\n");
			break;

		case DLL_THREAD_DETACH:
			TRACE("mapiHooks : DLL detached from thread\n");
			break;

		default:
			TRACE("mapiHooks : DLL unknown reason for call\n");
			return TRUE;
	}
	return TRUE;
}


//-----------------------------------------------------------------------------------------------------------------------------
// The DLL functions
//-----------------------------------------------------------------------------------------------------------------------------

extern "C" ULONG DllExport MAPISendMail(LHANDLE lhSession, ULONG_PTR ulUIParam, lpMapiMessage lpMessage, FLAGS flFlags, ULONG ulReserved)
{
	STARTUPINFO si;
	PROCESS_INFORMATION pi;

	char TmpPath[MAX_PATH];
	
	ZeroMemory(&si, sizeof(si));
	si.cb = sizeof(si);
	ZeroMemory(&pi, sizeof(pi));
	

	TRACE("mapiHooks : MAPISendMail() called, flFlags = %lu\n", flFlags);
	
	// --------lpMessage struct
	TRACE("lpmessage: lpszSubject = %s\n", lpMessage->lpszSubject);
	//TRACE("lpmessage: lpszNoteText = %s\n", lpMessage->lpszNoteText);
	//TRACE("lpmessage: lpszMessageType = %s\n", lpMessage->lpszMessageType);
	//TRACE("lpmessage: lpszDateReceived = %s\n", lpMessage->lpszDateReceived);
	//TRACE("lpmessage: lpszConversationID = %s\n", lpMessage->lpszConversationID);
	//TRACE("lpmessage: flFlags = %lu\n", lpMessage->flFlags);
	//TRACE("lpmessage:lpOriginator->lpszAddress = %s\n", lpMessage->lpOriginator->lpszAddress);
	//TRACE("lpmessage:lpOriginator->lpszName = %s\n", lpMessage->lpOriginator->lpszName);
	//TRACE("lpmessage:nRecipCount = %d\n", lpMessage->nRecipCount);
	//TRACE("lpmessage:lpRecips->lpszAddress = %s\n", lpMessage->lpRecips->lpszAddress);
	//TRACE("lpmessage:lpRecips->lpszName = %s\n", lpMessage->lpRecips->lpszName);
	TRACE("lpmessage:nFileCount = %d\n", lpMessage->nFileCount);
	
	TRACE("lpmessage:lpFiles->lpszFileName = %s\n", lpMessage->lpFiles->lpszFileName);
	TRACE("lpmessage:lpFiles->lpszPathName = %s\n", lpMessage->lpFiles->lpszPathName);

	if (lpMessage->nFileCount > 0)
	{
		if (lpMessage->lpFiles->lpszFileName == NULL)
		{
			// no filename given, assume lpszPathName contains the complet path including filename
			// put double quotes around the argument string. May be it contains BLANKs
			strcat(strCMDPath, " \"");
			strcat(strCMDPath, lpMessage->lpFiles->lpszPathName);
			strcat(strCMDPath, "\"");
		}
		else if (strstr(lpMessage->lpFiles->lpszPathName, lpMessage->lpFiles->lpszFileName) != NULL)
		{
			// assume lpszPathName contains the complet path including filename
			// put double quotes around the argument string. May be it contains BLANKs
			strcat(strCMDPath, " \"");
			strcat(strCMDPath, lpMessage->lpFiles->lpszPathName);
			strcat(strCMDPath, "\"");
		}
		else
		{
			// Pathname did not contain orginal filename; make a copy

			strcpy(TmpPath, lpMessage->lpFiles->lpszPathName);

			char* i = strrchr(TmpPath, '\\') ;		//find last \ in Path
			*i = 0;									// and cut it off
			strcat(TmpPath, "\\");
			strcat(TmpPath, lpMessage->lpFiles->lpszFileName);

			TRACE("mapiHooks : create temp-file: <%s>\n", TmpPath);

			CopyFile(lpMessage->lpFiles->lpszPathName, TmpPath, true);

			// put double quotes around the argument string. May be it contains BLANKs
			strcat(strCMDPath, " \"");
			strcat(strCMDPath, TmpPath);
			strcat(strCMDPath, "\"");
		}

		TRACE("mapiHooks : create process <%s>\n", strCMDPath);
		// Start the child process. 
		if (!CreateProcess(	NULL,			// No module name (use command line)
							strCMDPath,     // Command line
							NULL,           // Process handle not inheritable
							NULL,           // Thread handle not inheritable
							FALSE,          // Set handle inheritance to FALSE
							0,              // No creation flags
							NULL,           // Use parent's environment block
							NULL,           // Use parent's starting directory 
							&si,            // Pointer to STARTUPINFO structure
							&pi))            // Pointer to PROCESS_INFORMATION structure
		{
			TRACE("CreateProcess failed (%d).\n", GetLastError());
			return MAPI_E_FAILURE;
		}

		// Wait until child process exits.
		// Files are deleted aus soon wie are returning so give SmtpMail a chance to send the files
		WaitForSingleObject(pi.hProcess, INFINITE);

		if (strstr(lpMessage->lpFiles->lpszPathName, lpMessage->lpFiles->lpszFileName) == NULL)
		{
			// delete the tempory (copied) file 
			remove(TmpPath);

			TRACE("mapiHooks : delete temp-file: <%s>\n", TmpPath);
		}

		// Close process and thread handles. 
		CloseHandle(pi.hProcess);
		CloseHandle(pi.hThread);
	}

	TRACE("mapiHooks : return MAPISendMail\n");
	return S_OK; 

}

extern "C" ULONG DllExport MAPISendDocuments(ULONG_PTR ulUIParam, LPSTR lpszDelimChar, LPSTR lpszFilePaths, LPSTR lpszFileNames, ULONG ulReserved)
{
	TRACE("mapiHooks : MAPISendDocuments() called\n");
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIFindNext(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszMessageType, LPSTR lpszSeedMessageID, FLAGS flFlags, ULONG ulReserved, LPSTR lpszMessageID)
{
	TRACE("mapiHooks : not supported MAPIFindNext() called\n");
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIReadMail(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszMessageID, FLAGS flFlags, ULONG ulReserved, lpMapiMessage *lppMessage )
{
	TRACE("mapiHooks : not supported MAPIReadMail() called\n"); 
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPISaveMail(LHANDLE lhSession, ULONG_PTR ulUIParam, lpMapiMessage lpMessage, FLAGS flFlags, ULONG ulReserved, LPSTR lpszMessageID)
{
	TRACE("mapiHooks : not supported MAPISaveMail() called\n");
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIDeleteMail(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszMessageID, FLAGS flFlags, ULONG ulReserved)
{
	TRACE("mapiHooks : not supported MAPIDeleteMail() called\n"); 
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIAddress(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszCaption, ULONG nEditFields, LPSTR lpszLabels, ULONG nRecips, lpMapiRecipDesc lpRecip, FLAGS flFlags, ULONG ulReserved, LPULONG lpnNewRecips, lpMapiRecipDesc *lppNewRecips )
{
	TRACE("mapiHooks : not supported MAPIAddress() called\n");
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIDetails(LHANDLE lhSession, ULONG_PTR ulUIParam, lpMapiRecipDesc lpRecip, FLAGS flFlags, ULONG ulReserved)
{
	TRACE("mapiHooks : not supported MAPIDetails() called\n");
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIResolveName(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszName, FLAGS flFlags, ULONG ulReserved, lpMapiRecipDesc *lppRecip )
{
	TRACE("mapiHooks : not supported MAPIResolveName() called\n");
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIFreeBuffer(LPVOID pv)
{
	TRACE("mapiHooks : not supported MAPIFreeBuffer() called\n");
	return MAPI_E_NOT_SUPPORTED;
}

extern "C" ULONG DllExport MAPIInitialize(LPVOID lpMapiInit)
{
	TRACE("mapiHooks : MAPIInitialize() called\n");
	return S_OK;
}

extern "C" void DllExport MAPIUninitialize(void)
{
	TRACE("mapiHooks : MAPIUnnitialize() called\n");
	return;
}

extern "C" ULONG DllExport MAPILogon(ULONG_PTR ulUIParam, LPSTR lpszProfileName, LPSTR lpszPassword, FLAGS flFlags, ULONG ulReserved, LPLHANDLE lplhSession)
{
	TRACE("mapiHooks : MAPILogon() called\n");
	return S_OK;
}

extern "C" ULONG DllExport MAPILogoff(LHANDLE lhSession, ULONG_PTR ulUIParam, FLAGS flFlags, ULONG ulReserved)
{
	TRACE("mapiHooks : MAPILogoff() called\n");
	return S_OK;
}



