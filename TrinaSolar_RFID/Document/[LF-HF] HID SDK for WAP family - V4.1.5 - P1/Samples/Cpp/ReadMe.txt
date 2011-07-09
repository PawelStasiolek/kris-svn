========================================================================
Prerequeries
========================================================================
You have to download and install the Psion Teklogix HDK v2.01 or later on your PC 
It is availale via TekNet on Psion Teklogix web site (http://www.psionteklogix.com)

You have also to download and install the Psion Teklogix RFID SDK v1.06 or later on your PC 
It is availale via FTP Server on the following link ftp://Solutions:Solutions@ftp.teklogix.fr/ftpemea/RFID/RFID%20Products/LF-HF/Standard%20Products/RFID%20SDK/

========================================================================
Description
========================================================================
PTXReaderSettings is a form which allows the integration of the AAITG Readers 
on the Psion Teklogix Terminal (sample done with WorkAbout Pro G2).
First, this form configures te registry and set the power to the RFID Reader.
Then, the Reader Ternimal is launched.

========================================================================
WARNING
========================================================================
The following DLL has to be installed directly on the device (application folder)
. CFReader.dll

========================================================================
     Microsoft Foundation Class Library for Windows CE: Reader Terminal
========================================================================


AppWizard has created this Reader Terminal application for you.  This application
not only demonstrates the basics of using the Microsoft Foundation classes
but is also a starting point for writing your application.

This file contains a summary of what you will find in each of the files that
make up your Reader Terminal application.

Reader Terminal.h
    This is the main header file for the application.  It includes other
    project specific headers (including Resource.h) and declares the
    CReaderTerminalApp application class.

Reader Terminal.cpp
    This is the main application source file that contains the application
    class CReaderTerminalApp.

Reader Terminal.rc
    This is a listing of all of the Microsoft Windows CE resources that the
    program uses.  It includes the icons, bitmaps, and cursors that are stored
    in the RES subdirectory.  This file can be directly edited in Microsoft
	eMbedded Visual C++.

res\Reader Terminal.ico
    This is an icon file, which is used as the application's icon.  This
    icon is included by the main resource file Reader Terminal.rc.

res\Reader Terminal.rc2
    This file contains resources that are not edited by Microsoft 
	eMbedded Visual C++.  You should place all resources not
	editable by the resource editor in this file.

Reader Terminal.vcc
    This file contains information used by ClassWizard to edit existing
    classes or add new classes.  ClassWizard also uses this file to store
    information needed to create and edit message maps and dialog data
    maps and to create prototype member functions.

/////////////////////////////////////////////////////////////////////////////

AppWizard creates one dialog class:

Reader TerminalDlg.h, Reader TerminalDlg.cpp - the dialog
    These files contain your CReaderTerminalDlg class.  This class defines
    the behavior of your application's main dialog.  The dialog's
    template is in Reader Terminal.rc, which can be edited in Microsoft
	Developer Studio.



/////////////////////////////////////////////////////////////////////////////
Other standard files:

StdAfx.h, StdAfx.cpp
    These files are used to build a precompiled header (PCH) file
    named Reader Terminal.pch and a precompiled types file named StdAfx.obj.

Resource.h
    This is the standard header file, which defines new resource IDs.
    Microsoft eMbedded Visual C++ reads and updates this file.

/////////////////////////////////////////////////////////////////////////////
Other notes:

AppWizard uses "TODO:" to indicate parts of the source code you
should add to or customize.

If your application uses MFC in a shared DLL, and your application is 
in a language other than the operating system's current language, you
will need to copy the corresponding localized resources MFCWCXXX.DLL from
the Microsoft eMbedded Visual C++ CD-ROM onto the system or system32 directory,
and rename it to be MFCLOC.DLL.  ("XXX" stands for the language abbreviation.
For example, MFCWCDEU.DLL contains resources translated to German.)  If you
don't do this, some of the UI elements of your application will remain in the
language of the operating system.

/////////////////////////////////////////////////////////////////////////////
