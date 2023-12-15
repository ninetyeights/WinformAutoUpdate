@echo off
Taskkill /f /im WinformAutoUpdate.exe
:exit
msiexec.exe /i "C:\Program Files (x86)\NinetyEights\TestAppSetup\TestAppSetup.msi" /QN
del "C:\Program Files (x86)\NinetyEights\TestAppSetup\TestAppSetup.msi"
cd "C:\Program Files (x86)\NinetyEights\TestAppSetup"
start WinformAutoUpdate.exe
pause