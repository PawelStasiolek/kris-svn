// Reader TerminalDlg.h : header file
//

#if !defined(AFX_READERTERMINALDLG_H__14D62C57_737E_46C0_AE09_75148ED298DB__INCLUDED_)
#define AFX_READERTERMINALDLG_H__14D62C57_737E_46C0_AE09_75148ED298DB__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

/////////////////////////////////////////////////////////////////////////////
// CReaderTerminalDlg dialog

class CReaderTerminalDlg : public CDialog
{
// Construction
public:
  bool readerOpened;
	CString GetErrorText(DWORD lasterror);
	bool m_contReceiveMode;
	void AddText(CString text);
	CString m_Serial;
	CReaderTerminalDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CReaderTerminalDlg)
	enum { IDD = IDD_READERTERMINAL_DIALOG };
  CEdit m_edit_answer;
  CEdit m_edit_device;
  CEdit m_edit_command;
  CButton m_btn_open;
  CButton m_btn_send;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CReaderTerminalDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;
  UINT m_Timer;

	// Generated message map functions
	//{{AFX_MSG(CReaderTerminalDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnButtonOpen();
	afx_msg void OnButtonClearview();
	afx_msg void OnButtonCommand();
	afx_msg void OnDestroy();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnButtonOpen2();
	afx_msg void OnButtonOpen3();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

public:
	int portNumber;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft eMbedded Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_READERTERMINALDLG_H__14D62C57_737E_46C0_AE09_75148ED298DB__INCLUDED_)
