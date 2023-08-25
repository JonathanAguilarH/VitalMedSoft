DECLARE @name VARCHAR(256)
DECLARE db_cursor CURSOR FOR
SELECT name FROM master.dbo.sysdatabases WHERE name IN ('VitalLabSoftBD')
OPEN db_cursor
FETCH NEXT FROM db_cursor INTO @name
WHILE @@FETCH_STATUS = 0
BEGIN
    BACKUP DATABASE @name TO DISK = 'C:\Users\Jon_A\OneDrive\GitHub\VitalLabSoft\BD\VITALLABSOFTBD.bak'
    FETCH NEXT FROM db_cursor INTO @name
END
CLOSE db_cursor
DEALLOCATE db_cursor
