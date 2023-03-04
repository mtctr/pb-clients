docker exec -it sqlserver "bash"
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "1q2w3e4r@#$" -q "EXEC sp_configure 'remote access', 0; GO  RECONFIGURE;  GO";