
#if !defined(_MAPIHOOKS_)
#define _MAPIHOOKS_

#define MAPIHOOKS_Version "1.0.0.1"

#include <windows.h>

// Return codes from Microsoft org. MAPI.h
#define MAPI_E_USER_ABORT               ((HRESULT)1L)
#define MAPI_E_FAILURE                  ((HRESULT)2L)
#define MAPI_E_LOGON_FAILURE            ((HRESULT)3L)
#define MAPI_E_LOGIN_FAILURE            MAPI_E_LOGON_FAILURE
#define MAPI_E_DISK_FULL                ((HRESULT)4L)
#define MAPI_E_INSUFFICIENT_MEMORY      ((HRESULT)5L)
#define MAPI_E_ACCESS_DENIED            ((HRESULT)6L)
#define MAPI_E_TOO_MANY_SESSIONS        ((HRESULT)8L)
#define MAPI_E_TOO_MANY_FILES           ((HRESULT)9L)
#define MAPI_E_TOO_MANY_RECIPIENTS      ((HRESULT)10L)
#define MAPI_E_ATTACHMENT_NOT_FOUND     ((HRESULT)11L)
#define MAPI_E_ATTACHMENT_OPEN_FAILURE  ((HRESULT)12L)
#define MAPI_E_ATTACHMENT_WRITE_FAILURE ((HRESULT)13L)
#define MAPI_E_UNKNOWN_RECIPIENT        ((HRESULT)14L)
#define MAPI_E_BAD_RECIPTYPE            ((HRESULT)15L)
#define MAPI_E_NO_MESSAGES              ((HRESULT)16L)
#define MAPI_E_INVALID_MESSAGE          ((HRESULT)17L)
#define MAPI_E_TEXT_TOO_LARGE           ((HRESULT)18L)
#define MAPI_E_INVALID_SESSION          ((HRESULT)19L)
#define MAPI_E_TYPE_NOT_SUPPORTED       ((HRESULT)20L)
#define MAPI_E_AMBIGUOUS_RECIPIENT      ((HRESULT)21L)
#define MAPI_E_AMBIG_RECIP              MAPI_E_AMBIGUOUS_RECIPIENT
#define MAPI_E_MESSAGE_IN_USE           ((HRESULT)22L)
#define MAPI_E_NETWORK_FAILURE          ((HRESULT)23L)
#define MAPI_E_INVALID_EDITFIELDS       ((HRESULT)24L)
#define MAPI_E_INVALID_RECIPS           ((HRESULT)25L)
#define MAPI_E_NOT_SUPPORTED            ((HRESULT)26L)




/////////////////////////////////////////////////////////////////////////////
// Define the import/export tags

#define DllImport __declspec(dllimport)
#define DllExport __declspec(dllexport)


/////////////////////////////////////////////////////////////////////////////
//
// All neeeded info copied from mapi.h


typedef ULONG FLAGS;
typedef ULONG LHANDLE;
typedef ULONG FAR *LPLHANDLE, FAR *LPULONG;


typedef struct {
	ULONG ulReserved;
	ULONG ulRecipClass;
	LPSTR lpszName;
	LPSTR lpszAddress;
	ULONG ulEIDSize;
	LPVOID lpEntryID;
} MapiRecipDesc, *lpMapiRecipDesc;

typedef struct {
	ULONG ulReserved;
	ULONG flFlags;
	ULONG nPosition;
	LPSTR lpszPathName;
	LPSTR lpszFileName;
	LPVOID lpFileType;
} MapiFileDesc, *lpMapiFileDesc;

typedef struct {
	ULONG ulReserved;
	LPSTR lpszSubject;
	LPSTR lpszNoteText;
	LPSTR lpszMessageType;
	LPSTR lpszDateReceived;
	LPSTR lpszConversationID;
	FLAGS flFlags;
	lpMapiRecipDesc lpOriginator;
	ULONG nRecipCount;
	lpMapiRecipDesc lpRecips;
	ULONG nFileCount;
	lpMapiFileDesc lpFiles;
} MapiMessage, *lpMapiMessage;


// DLL functions:
	
extern "C" ULONG DllExport MAPIInitialize(LPVOID lpMapiInit);
extern "C" void DllExport MAPIUninitialize(void);
extern "C" ULONG DllExport MAPILogon(ULONG_PTR ulUIParam, LPSTR lpszProfileName, LPSTR lpszPassword, FLAGS flFlags, ULONG ulReserved, LPLHANDLE lplhSession);
extern "C" ULONG DllExport MAPILogoff(LHANDLE lhSession, ULONG_PTR ulUIParam, FLAGS flFlags, ULONG ulReserved);
extern "C" ULONG DllExport MAPISendMail(LHANDLE lhSession, ULONG_PTR ulUIParam, lpMapiMessage lpMessage, FLAGS flFlags, ULONG ulReserved);
extern "C" ULONG DllExport MAPISendDocuments(ULONG_PTR ulUIParam, LPSTR lpszDelimChar, LPSTR lpszFilePaths, LPSTR lpszFileNames, ULONG ulReserved);
extern "C" ULONG DllExport MAPIFindNext(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszMessageType, LPSTR lpszSeedMessageID, FLAGS flFlags, ULONG ulReserved, LPSTR lpszMessageID);
extern "C" ULONG DllExport MAPIReadMail(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszMessageID, FLAGS flFlags, ULONG ulReserved, lpMapiMessage *lppMessage);
extern "C" ULONG DllExport MAPISaveMail(LHANDLE lhSession, ULONG_PTR ulUIParam, lpMapiMessage lpMessage, FLAGS flFlags, ULONG ulReserved, LPSTR lpszMessageID);
extern "C" ULONG DllExport MAPIDeleteMail(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszMessageID, FLAGS flFlags, ULONG ulReserved);
extern "C" ULONG DllExport MAPIAddress(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszCaption, ULONG nEditFields, LPSTR lpszLabels, ULONG nRecips, lpMapiRecipDesc lpRecip, FLAGS flFlags, ULONG ulReserved, LPULONG lpnNewRecips, lpMapiRecipDesc *lppNewRecips);
extern "C" ULONG DllExport MAPIDetails(LHANDLE lhSession, ULONG_PTR ulUIParam, lpMapiRecipDesc lpRecip, FLAGS flFlags, ULONG ulReserved);
extern "C" ULONG DllExport MAPIResolveName(LHANDLE lhSession, ULONG_PTR ulUIParam, LPSTR lpszName, FLAGS flFlags, ULONG ulReserved, lpMapiRecipDesc *lppRecip);
extern "C" ULONG DllExport MAPIFreeBuffer(LPVOID pv);

#endif // !defined(_MAPIHOOKS_)
