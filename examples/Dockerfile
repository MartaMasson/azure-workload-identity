FROM microsoft/windowsservercore

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

#Copy installers
RUN (New-Object System.Net.WebClient).DownloadFile('https://aka.ms/installazurecliwindows', 'AzureCLI.msi') ;\
    Start-Sleep -s 30 ;\
    Start-Process 'msiexec' -ArgumentList '/i AzureCLI.msi /quiet /qn /norestart /log c:\installLib.log';\
    Start-Sleep -s 30 ;\
    Remove-Item c:\tools\*.msi -force