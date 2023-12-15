@echo off
Taskkill /f /im WinformAutoUpdate.exe
:exit
msiexec.exe /i "C:\Users\clove\Downloads\TestAppSetup.msi" /QN
del "C:\Users\clove\Downloads\TestAppSetup.msi"
cd "C:\Program Files (x86)\NinetyEights\TestAppSetup"
start WinformAutoUpdate.exe