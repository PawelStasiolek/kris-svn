// Reader Terminal.h : main header file for the READER TERMINAL application
//

#if !defined(AFX_READERTERMINAL_H__449A1217_FD9F_41C4_88E4_54AD49BFDD29__INCLUDED_)
#define AFX_READERTERMINAL_H__449A1217_FD9F_41C4_88E4_54AD49BFDD29__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CReaderTerminalApp:
// See Reader Terminal.cpp for the implementation of this class
//

class CReaderTerminalApp : public CWinApp
{
public:
	CString AnsiToUnicode(char* aStr);
	char* UnicodeToAnsi(CString uStr, char* aStr);
	CReaderTerminalApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CReaderTerminalApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CReaderTerminalApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

extern CReaderTerminalApp theApp;
/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft eMbedded Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_READERTERMINAL_H__449A1217_FD9F_41C4_88E4_54AD49BFDD29__INCLUDED_)
