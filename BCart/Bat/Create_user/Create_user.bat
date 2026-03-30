SET DT=%date:~-10,4%%date:~-5,2%%date:~-2,2%_%time:~0,2%%time:~3,2%%time:~6,2%
SET DT2=%DT: =0%

C:\BCartBat\bin\Create_user\Create_user.exe>>C:\Logs\Create_user%DT2%.log
