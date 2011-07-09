#pragma once


// PTXReaderSettings dialog

class PTXReaderSettings : public CDialog
{
	DECLARE_DYNAMIC(PTXReaderSettings)

public:
	PTXReaderSettings(CWnd* pParent = NULL);   // standard constructor
	virtual ~PTXReaderSettings();

// Dialog Data
	enum { IDD = IDD_POCKETPC_PORTRAIT };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	CComboBox m_ctrlConnection;
	CComboBox m_ctrlComPort;
	CButton m_ctrlConnect;
	CStatic m_ctrlInfo;
	CListBox m_ctrlList;
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButton1();
private:
	void DisplayComPort(bool searchRFIDUSBReader);


};
