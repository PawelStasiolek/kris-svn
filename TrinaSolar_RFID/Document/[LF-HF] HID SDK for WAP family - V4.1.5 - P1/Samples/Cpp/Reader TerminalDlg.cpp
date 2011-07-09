// Reader TerminalDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Reader Terminal.h"
#include "Reader TerminalDlg.h"
#include "ReaderDLL.h"
#include "..\..\Driver\Cpp\RFIDDriver.h"
#include <RFIDIOCTL.h>

using namespace PsionTeklogix::RFID;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


//Global reader handles
void *comm_handle = NULL;
void *reader_handle = NULL;

//Global Variable to store the com port name
char com_port[10];

/////////////////////////////////////////////////////////////////////////////
// CReaderTerminalDlg dialog

CReaderTerminalDlg::CReaderTerminalDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CReaderTerminalDlg::IDD, pParent)
	//, portNumber(0)
{
	//{{AFX_DATA_INIT(CReaderTerminalDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CReaderTerminalDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CReaderTerminalDlg)
  DDX_Control(pDX, IDC_EDIT_ANSWER, m_edit_answer);
  DDX_Control(pDX, IDC_EDIT_COMMAND, m_edit_command);
  DDX_Control(pDX, IDC_BUTTON_OPEN, m_btn_open);
  DDX_Control(pDX, IDC_BUTTON_COMMAND, m_btn_send);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CReaderTerminalDlg, CDialog)
	//{{AFX_MSG_MAP(CReaderTerminalDlg)
	ON_BN_CLICKED(IDC_BUTTON_OPEN, OnButtonOpen)
	ON_BN_CLICKED(IDC_BUTTON_CLEARVIEW, OnButtonClearview)
	ON_BN_CLICKED(IDC_BUTTON_COMMAND, OnButtonCommand)
	ON_WM_DESTROY()
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BUTTON_OPEN2, OnButtonOpen2)
	ON_BN_CLICKED(IDC_BUTTON_OPEN3, OnButtonOpen3)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CReaderTerminalDlg message handlers

bool blScan = false;

BOOL CReaderTerminalDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	CenterWindow(GetDesktopWindow());	// center to the hpc screen

	// TODO: Add extra initialization here
  m_edit_command.SetWindowText(_T("v"));    // default command
  m_contReceiveMode = true;                
	
  CString dummy;
  dummy.Format(_T("CFReaderDLL Version %0.2f\r\n"), (float)RDR_GetDLLVersion());
  m_edit_answer.SetWindowText(dummy);
  m_edit_command.SetFocus();
  m_edit_command.SetSel(0xFF00);

  readerOpened = false;
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// open/close serial port
void CReaderTerminalDlg::OnButtonOpen() 
{
  CString dummy;
  CString comPort;
  char buffer[256];
  char input_buffer[50], detect_buffer[256];
  RFIDDriver rfidDriver;

  // Check if RFID Driver is installed
  if (! rfidDriver.IsInstalled())
  {
    dummy = "RFID Driver not installed\r\n";
    AddText(dummy);
	return;
  }

  m_btn_open.EnableWindow(false);
  if (readerOpened == false)
  {
    presetSettings preset;

	DWORD result;

	

	// Enable driver
    result = rfidDriver.Enable();

	if (result != RFID_SUCCESS) // an error occurs
	{
		// Get error information comparing the result value with RFIDIOCTL.h file
		dummy.Format(_T("RFID driver Error: %d\r\n"), result);
		AddText(dummy);
		m_btn_open.EnableWindow(true);
		return;
	}

	// Get Com Port number
    comPort.Format(_T("COM%d:"), rfidDriver.ComPort());

    readerOpened = true;

    // open serial port with autodetection
    preset.baudRate = 9600;
    preset.protocol = 0;

	// Enable baudrates higher than 115200
	RDR_SetHighBaudrates(1);

    if (RDR_OpenComm(theApp.UnicodeToAnsi(comPort, buffer), 2, &preset) == 0)
    {
      dummy = "ERROR opening comm device\r\n";
      readerOpened = false;
    }
    else
    {
      char stationID;

      // detect station ID
      stationID = RDR_DetectReader();

      if ((stationID == 0) || (RDR_OpenReader(stationID, 0) == 0)) // 0
      {
        RDR_SetCommContRcv(1);
        dummy = "ERROR can not find any reader\r\n";
        RDR_CloseComm();
        readerOpened = false;
      }
      else
      {
        RDR_SetCommContRcv(1);
        m_btn_open.SetWindowText(_T("Close"));
        memset(buffer, 0, 256);
        memcpy(buffer, RDR_GetReaderType(buffer), 256);
        dummy.Format(_T("%s opened\r\n"), theApp.AnsiToUnicode(buffer));
        m_btn_send.EnableWindow(true);
      }
    }
    AddText(dummy);
  }
  else
  {
    // close serial port
    RDR_SetCommContRcv(0);
    KillTimer(m_Timer);
    RDR_CloseReader();
    RDR_CloseComm();
    m_btn_send.EnableWindow(false);
    m_btn_open.SetWindowText(_T("Open"));
    readerOpened = false;
    dummy = "comm device closed\r\n";
    AddText(dummy);

	// Disable RFID Driver
  	rfidDriver.Disable();
  }

  m_btn_open.EnableWindow(true);
  m_edit_command.SetFocus();
  m_edit_command.SetSel(0xFF00);
}

// adds text to answer text field
void CReaderTerminalDlg::AddText(CString text)
{
  CString dummy;

  if (text.GetLength() > 0)
  {
    m_edit_answer.SetRedraw(false);
    m_edit_answer.GetWindowText(dummy);
    dummy += text;
    m_edit_answer.SetWindowText(dummy);
    m_edit_answer.SetSel(dummy.GetLength(), dummy.GetLength());
    m_edit_answer.SetRedraw(true);
    m_edit_answer.UpdateWindow();
  }
}

// clear answer box
void CReaderTerminalDlg::OnButtonClearview() 
{
  m_edit_answer.SetWindowText(_T(""));
}

// send command to reader
void CReaderTerminalDlg::OnButtonCommand() 
{
  CString command,resultat="";  
  m_edit_command.GetWindowText(command);
  command.MakeLower();
  command.Replace(_T("<cr>"), _T("\r"));
  if (readerOpened == true) // send only if communication is initialized
  {
    char data[256];
	char buffer[256];
	memset(data, 0, 256);
	memset(buffer, 0, 256);
    // write command
    RDR_SendCommandGetData(theApp.UnicodeToAnsi(command, buffer), data, buffer);
	//theApp.AnsiToUnicode(buffer);
	for (int i = 0; i <= buffer[0]; i++)
    resultat += buffer[i];
	AddText(resultat + _T("\r\n"));

	
  } 
  else
	  AddText(_T("Erreur envoi\r\n"));

  m_edit_command.SetFocus();
  m_edit_command.SetSel(0xFF00);
}

// get last error string
CString CReaderTerminalDlg::GetErrorText(DWORD lasterror)
{
  CString text;

  LPVOID lpMsgBuf;
  FormatMessage( 
    FORMAT_MESSAGE_ALLOCATE_BUFFER | 
    FORMAT_MESSAGE_FROM_SYSTEM | 
    FORMAT_MESSAGE_IGNORE_INSERTS,
    NULL,
    lasterror,
    0, // Default language
    (LPTSTR) &lpMsgBuf,
    0,
    NULL 
    );

  text.Format(_T("%s"), lpMsgBuf);
  LocalFree( lpMsgBuf );
  return text;
}

void CReaderTerminalDlg::OnDestroy() 
{
	CDialog::OnDestroy();

  RDR_CloseReader();
  RDR_CloseComm();
}

void CReaderTerminalDlg::OnTimer(UINT nIDEvent) 
{
  CString dummy = "";
  char buffer[256];
  static bool ResumeEntered = false;
  static bool ResumeErrorMsg = false;

  memset(buffer, 0, 256);
  memcpy(buffer, RDR_GetData(buffer), 256);

  //theApp.AnsiToUnicode(buffer);
  for (int i = 1; i <= buffer[0]; i++)
    dummy += buffer[i];
  AddText(dummy);

  if ((RDR_GetResumeState() == -1) && (ResumeErrorMsg == false))
  {
    ResumeErrorMsg = true;
    AddText(_T("Power Up: Error\r\n"));
    // do some error handling here
    // ...
  }
  if ((RDR_GetResumeState() == 0) && (ResumeEntered == true))
  {
    AddText(_T("Power Up: Finished\r\n"));
    m_btn_send.EnableWindow(true);
    ResumeEntered = false;
  }
  if ((RDR_GetResumeState() == 1) && (ResumeEntered == false))
  {
    AddText(_T("Power Up: Waiting...\r\n"));
    m_btn_send.EnableWindow(false);
    ResumeEntered = true;
  }

  CDialog::OnTimer(nIDEvent);
}



void CReaderTerminalDlg::OnButtonOpen2() 
{
	// Send continuous read command
    RDR_AbortContinuousReadExt();   
	RDR_SendCommand("c", "");

	m_Timer = SetTimer(1, 50, NULL);
}

void CReaderTerminalDlg::OnButtonOpen3() 
{
	RDR_AbortContinuousReadExt();

	KillTimer(m_Timer);	
}
