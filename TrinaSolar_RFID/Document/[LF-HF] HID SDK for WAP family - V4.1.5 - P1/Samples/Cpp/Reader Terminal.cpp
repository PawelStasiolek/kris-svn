// Reader Terminal.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "Reader Terminal.h"
#include "Reader TerminalDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CReaderTerminalApp

BEGIN_MESSAGE_MAP(CReaderTerminalApp, CWinApp)
	//{{AFX_MSG_MAP(CReaderTerminalApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CReaderTerminalApp construction

CReaderTerminalApp::CReaderTerminalApp()
	: CWinApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CReaderTerminalApp object

CReaderTerminalApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CReaderTerminalApp initialization

BOOL CReaderTerminalApp::InitInstance()
{
	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

	CReaderTerminalDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with Cancel
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}

char* CReaderTerminalApp::UnicodeToAnsi(CString uStr, char *aStr)
{
  for (int i = 0; i < uStr.GetLength(); i++)
    aStr[i] = (char)uStr.GetAt(i);
  aStr[uStr.GetLength()] = 0;

  return aStr;
}

CString CReaderTerminalApp::AnsiToUnicode(char *aStr)
{
  CString uStr;

  for (unsigned int i = 0; i < strlen(aStr); i++)
    uStr += aStr[i];
  return uStr;
}
