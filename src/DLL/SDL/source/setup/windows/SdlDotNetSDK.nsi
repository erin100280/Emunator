!verbose 3

!define PRODUCT_NAME "SdlDotNet SDK"
!define PRODUCT_TYPE "sdk"
!define PRODUCT_VERSION "6.1.1beta"
!define PRODUCT_PUBLISHER "SdlDotNet"
!define PRODUCT_PACKAGE "sdldotnet"
!define PRODUCT_WEB_SITE "http://cs-sdl.sourceforge.net"
!define PRODUCT_TUTORIALS_WEB_SITE "http://cs-sdl.sourceforge.net/index.php/Category:Tutorials"
!define PRODUCT_EXAMPLES_WEB_SITE "http://cs-sdl.sourceforge.net/index.php/Category:Examples"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\SdlDotNetSDK"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\SdlDotNetSDK"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"
!define PRODUCT_DIR "..\..\dist"
!define PRODUCT_PATH "${PRODUCT_DIR}\${PRODUCT_PACKAGE}-${PRODUCT_VERSION}"
!define PRODUCT_SOURCE "${PRODUCT_PATH}\source"
!define PRODUCT_EXAMPLES "${PRODUCT_PATH}\examples"
!define PRODUCT_BIN "${PRODUCT_PATH}\bin"
!define PRODUCT_DEPS "${PRODUCT_PATH}\lib"
!define PRODUCT_DOC "${PRODUCT_PATH}\doc"

;!define MUI_WELCOMEFINISHPAGE_BITMAP "SdlDotNetLogo.bmp"
;!define MUI_WELCOMEFINISHPAGE_BITMAP_NOSTRETCH
;!define MUI_UNWELCOMEFINISHPAGE_BITMAP "SdlDotNetLogo.bmp"
;!define MUI_UNWELCOMEFINISHPAGE_BITMAP_NOSTRETCH

BrandingText "� 2003-2010 David Hudson and Stefan Ekamn, http://cs-sdl.sourceforge.net/"
SetCompressor lzma
CRCCheck on

; File Association defines
;!include "fileassoc.nsh"

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

;--------------------------------
;Variables

Var STARTMENU_FOLDER
;--------------------------------
;Installer Pages

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "${PRODUCT_SOURCE}\COPYING"
; Components Page
!insertmacro MUI_PAGE_COMPONENTS
; Directory page
!insertmacro MUI_PAGE_DIRECTORY

;Start Menu Folder Page Configuration
!define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU" 
!define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\SdlDotNet" 
!define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
  
!insertmacro MUI_PAGE_STARTMENU Application $STARTMENU_FOLDER

; Instfiles page
!define MUI_FINISHPAGE_NOAUTOCLOSE
!insertmacro MUI_PAGE_INSTFILES

; Finish page
!insertmacro MUI_PAGE_FINISH

;------------------------------------
; Uninstaller pages
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!define MUI_UNFINISHPAGE_NOAUTOCLOSE 
!insertmacro MUI_UNPAGE_FINISH
;------------------------------------

; Language files
!insertmacro MUI_LANGUAGE "English"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "${PRODUCT_DIR}\${PRODUCT_PACKAGE}-${PRODUCT_VERSION}-${PRODUCT_TYPE}-setup.exe"
InstallDir "$PROGRAMFILES\SdlDotNet"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

; .NET Framework check
; http://msdn.microsoft.com/netframework/default.aspx?pull=/library/en-us/dnnetdep/html/redistdeploy1_1.asp
; Section "Detecting that the .NET Framework 2.0 is installed"
Function .onInit
	ReadRegDWORD $R0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727" Install
	StrCmp $R0 "" 0 CheckPreviousVersion
	MessageBox MB_OK "Microsoft .NET Framework 2.0 was not found on this system.$\r$\n$\r$\nUnable to continue this installation."
	Abort

  CheckPreviousVersion:
	ReadRegStr $R0 ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName"
	StrCmp $R0 "" CheckOSVersion 0
	MessageBox MB_OK "An old version of SdlDotNet is installed on this computer, please uninstall first.$\r$\n$\r$\nUnable to continue this installation."
	Abort
	
  CheckOSVersion:
        Call IsSupportedWindowsVersion
        Pop $R0
        StrCmp $R0 "False" NoAbort 0
	MessageBox MB_OK "The operating system you are using is not supported by SdlDotNet (95/98/ME/NT3.x/NT4.x)."
        Abort

  NoAbort:
FunctionEnd

Section "Source" SecSrc
  SetOverwrite ifnewer
  
  SetOutPath "$INSTDIR\source\tools"
  File /r "${PRODUCT_SOURCE}\tools\*"

  SetOutPath "$INSTDIR\source\tests"
  File /r "${PRODUCT_SOURCE}\tests\*"

  SetOutPath "$INSTDIR\source\src"
  File /r "${PRODUCT_SOURCE}\src\*"
  
  SetOutPath "$INSTDIR\source\examples"
  File /r "${PRODUCT_SOURCE}\examples\*"

  SetOutPath "$INSTDIR\source\setup"
  File /r "${PRODUCT_SOURCE}\setup\*"

  SetOutPath "$INSTDIR\source\lib"
  File /r "${PRODUCT_SOURCE}\lib\*"

  SetOutPath "$INSTDIR\source"
  File "${PRODUCT_SOURCE}\*"

  ;Store installation folder
  WriteRegStr HKCU "Software\SdlDotNet" "" $INSTDIR
  
SectionEnd

Section "Runtime" SecRuntime
  SetOverwrite ifnewer
  SetOutPath "$INSTDIR\bin"
  File "${PRODUCT_BIN}\*"

  SetOutPath "$INSTDIR\tools\prebuild"
  File "${PRODUCT_SOURCE}\tools\prebuild\*"

  SetOutPath "$INSTDIR\lib"
  File "${PRODUCT_DEPS}\*"
  
  ;Store installation folder
  WriteRegStr HKCU "Software\SdlDotNet" "" $INSTDIR
  
  SetOutPath "$SYSDIR"
  File "${PRODUCT_DEPS}\*"
  
  Push "SdlDotNet"
  Push $INSTDIR\bin
  Call AddManagedDLL
  Push "Tao.Sdl"
  Push $INSTDIR\bin
  Call AddManagedDLL
  
SectionEnd

Section "Examples" SecExamples
  SetOverwrite ifnewer

  CreateDirectory "$SMPROGRAMS\SdlDotNet"
  CreateDirectory "$SMPROGRAMS\SdlDotNet\Examples"
  SetOutPath "$INSTDIR\examples"
  File /r "${PRODUCT_EXAMPLES}\*"
  CreateShortCut "$SMPROGRAMS\SdlDotNet\Examples\SdlDotNetExamples.lnk" "$INSTDIR\examples\SdlDotNetExamples.exe"
  CreateShortCut "$SMPROGRAMS\SdlDotNet\Examples\SdlDotNetCDPlayer.lnk" "$INSTDIR\examples\SdlDotNetCDPlayer.exe"
  CreateDirectory "$SMPROGRAMS\SdlDotNet\Documentation"
  CreateShortCut "$SMPROGRAMS\SdlDotNet\Documentation\SdlDotNet Help.lnk" "$INSTDIR\doc\SdlDotNet.chm"
  
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}_Tutorials.url" "InternetShortcut" "URL" "${PRODUCT_TUTORIALS_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\SdlDotNet\Documentation\Tutorials.lnk" "$INSTDIR\${PRODUCT_NAME}_Tutorials.url"
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}_Examples.url" "InternetShortcut" "URL" "${PRODUCT_EXAMPLES_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\SdlDotNet\Documentation\Examples.lnk" "$INSTDIR\${PRODUCT_NAME}_Examples.url"

  ;Store installation folder
  WriteRegStr HKCU "Software\SdlDotNet" "" $INSTDIR
  
SectionEnd

Section "Documentation" SecDocs
  SetOverwrite ifnewer
  SetOutPath "$INSTDIR\doc"
  File /r ${PRODUCT_PATH}\doc\*.*

  ;Store installation folder
  WriteRegStr HKCU "Software\SdlDotNet" "" $INSTDIR
SectionEnd

;Language strings
LangString TEXT_IO_TITLE ${LANG_ENGLISH} "Installation Options"
LangString TEXT_IO_SUBTITLE ${LANG_ENGLISH} "SdlDotNet Installation Options."
LangString DESC_SecExamples ${LANG_ENGLISH} "Installs examples using various features of SdlDotNet."
LangString DESC_SecSrc ${LANG_ENGLISH} "Installs the source code."
LangString DESC_SecDocs ${LANG_ENGLISH} "Installs documentation"
LangString DESC_SecRuntime ${LANG_ENGLISH} "Installs the runtime libaries."

;Assign language strings to sections
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
!insertmacro MUI_DESCRIPTION_TEXT ${SecExamples} $(DESC_SecExamples)
!insertmacro MUI_DESCRIPTION_TEXT ${SecSrc} $(DESC_SecSrc)
!insertmacro MUI_DESCRIPTION_TEXT ${SecDocs} $(DESC_SecDocs)
!insertmacro MUI_DESCRIPTION_TEXT ${SecRuntime} $(DESC_SecRuntime)
!insertmacro MUI_FUNCTION_DESCRIPTION_END


Section -AdditionalIcons
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\SdlDotNet\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\SdlDotNet\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd

Section Uninstall
  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"

  Call un.GACUnInstall

  Push "SdlDotNet"
  Push $INSTDIR\bin
  Call un.DeleteManagedDLLKey
  
  Push "Tao.Sdl"
  Push $INSTDIR\bin
  Call un.DeleteManagedDLLKey

  RMDir /r "$INSTDIR"

  Delete "$SMPROGRAMS\SdlDotNet\*.*"

  ; set OutPath to somewhere else because the current working directory cannot be deleted!
  SetOutPath "$DESKTOP"
  
  RMDir /r "$SMPROGRAMS\SdlDotNet"
 
  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"

  RMDir /r "$INSTDIR"
SectionEnd

; GetWindowsVersion, taken from NSIS help, modified for our purposes
Function IsSupportedWindowsVersion

   Push $R0
   Push $R1

   ReadRegStr $R0 HKLM \
   "SOFTWARE\Microsoft\Windows NT\CurrentVersion" CurrentVersion

   IfErrors 0 lbl_winnt

   ; we are not NT
   ReadRegStr $R0 HKLM \
   "SOFTWARE\Microsoft\Windows\CurrentVersion" VersionNumber

   StrCpy $R1 $R0 1
   StrCmp $R1 '4' 0 lbl_error

   StrCpy $R1 $R0 3

   StrCmp $R1 '4.0' lbl_win32_95
   StrCmp $R1 '4.9' lbl_win32_ME lbl_win32_98

   lbl_win32_95:
     StrCpy $R0 'False'
   Goto lbl_done

   lbl_win32_98:
     StrCpy $R0 'False'
   Goto lbl_done

   lbl_win32_ME:
     StrCpy $R0 'False'
   Goto lbl_done

   lbl_winnt:

   StrCpy $R1 $R0 1

   StrCmp $R1 '3' lbl_winnt_x
   StrCmp $R1 '4' lbl_winnt_x

   StrCpy $R1 $R0 3

   StrCmp $R1 '5.0' lbl_winnt_2000
   StrCmp $R1 '5.1' lbl_winnt_XP
   StrCmp $R1 '5.2' lbl_winnt_2003 lbl_error

   lbl_winnt_x:
     StrCpy $R0 'False'
   Goto lbl_done

   lbl_winnt_2000:
     Strcpy $R0 'True'
   Goto lbl_done

   lbl_winnt_XP:
     Strcpy $R0 'True'
   Goto lbl_done

   lbl_winnt_2003:
     Strcpy $R0 'True'
   Goto lbl_done

   lbl_error:
     Strcpy $R0 'False'
   lbl_done:

   Pop $R1
   Exch $R0

FunctionEnd

Function GACInstall
  nsExec::Exec '"$INSTDIR/tools/prebuild/prebuild.exe" /install "$INSTDIR/bin/Tao.Sdl.dll"'
  nsExec::Exec '"$INSTDIR/tools/prebuild/prebuild.exe" /install "$INSTDIR/bin/SdlDotNet.dll"'

FunctionEnd

Function un.GACUnInstall
  nsExec::Exec '"$INSTDIR/tools/prebuild/prebuild.exe" /remove "$INSTDIR/bin/Tao.Sdl.dll"'
  nsExec::Exec '"$INSTDIR/tools/prebuild/prebuild.exe" /remove "$INSTDIR/bin/SdlDotNet.dll"'

FunctionEnd

Function un.DeleteManagedDLLKey
  Exch $R0
  Exch
  Exch $R1
 
  DeleteRegKey HKLM "SOFTWARE\Microsoft\.NETFramework\AssemblyFolders\$R1" 
  DeleteRegKey HKCU "SOFTWARE\Microsoft\.NETFramework\AssemblyFolders\$R1" 
  DeleteRegKey HKLM "SOFTWARE\Microsoft\VisualStudio\8.0\AssemblyFolders\$R1"
 
  Pop $R1
  Pop $R0
FunctionEnd

Function AddManagedDLL
  Exch $R0
  Exch
  Exch $R1
 
  call GACInstall
  WriteRegStr HKLM "SOFTWARE\Microsoft\.NETFramework\AssemblyFolders\$R1" "" "$R0"
  WriteRegStr HKCU "SOFTWARE\Microsoft\.NETFramework\AssemblyFolders\$R1" "" "$R0"
  WriteRegStr HKLM "SOFTWARE\Microsoft\VisualStudio\8.0\AssemblyFolders\$R1" "" "$R0"
 
  Pop $R1
  Pop $R0
FunctionEnd

