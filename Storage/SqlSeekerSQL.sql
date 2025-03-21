DECLARE @tableNameFilter NVARCHAR(128) = '%%' -- Change this to filter objects 
DECLARE @sql NVARCHAR(MAX) = ''
DECLARE @databaseName NVARCHAR(128)
DECLARE @searchTable int = 1
DECLARE @searchStoredProcedure int = 1
DECLARE @searchView int = 1
DECLARE @searchFunction int = 1

DECLARE db_cursor CURSOR FOR
    SELECT name 
    FROM sys.databases 
    WHERE state_desc = 'ONLINE' 
    AND name NOT IN ('master', 'tempdb', 'model', 'msdb')

OPEN db_cursor
FETCH NEXT FROM db_cursor INTO @databaseName

WHILE @@FETCH_STATUS = 0
BEGIN
    IF LEN(@sql) > 0
        SET @sql = @sql + ' UNION ALL '
    
    -- Tables
    IF @searchTable = 1
        SET @sql = @sql + '
        SELECT 
            ''Table'' AS ObjectType,
            ''' + @databaseName + ''' AS DatabaseName, 
            s.name AS SchemaName, 
            t.name AS ObjectName, 
            ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + t.name AS FullName, 
            ISNULL((SELECT STRING_AGG(c.name, '', '')
                   FROM [' + @databaseName + '].sys.columns c
                   WHERE c.object_id = t.object_id), '''') AS Parameters,
            ''SELECT TOP 100 * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + t.name AS Example
        FROM [' + @databaseName + '].sys.tables AS t 
        JOIN [' + @databaseName + '].sys.schemas AS s ON t.schema_id = s.schema_id 
        WHERE t.type = ''U'' AND t.name LIKE ''' + @tableNameFilter + ''' '
    
    -- Stored Procedures
    IF @searchStoredProcedure = 1
    BEGIN
        IF LEN(@sql) > 0 AND @searchTable = 1
            SET @sql = @sql + ' UNION ALL '
            
        SET @sql = @sql + '
        SELECT 
            ''Stored Procedure'' AS ObjectType,
            ''' + @databaseName + ''' AS DatabaseName, 
            s.name AS SchemaName, 
            p.name AS ObjectName, 
            ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name AS FullName, 
            ISNULL((SELECT STRING_AGG(params.name + '''', '', '')
                   FROM [' + @databaseName + '].sys.parameters params
                   WHERE params.object_id = p.object_id), '''') AS Parameters,
            CASE 
                WHEN EXISTS (SELECT 1 FROM [' + @databaseName + '].sys.parameters WHERE object_id = p.object_id)
                THEN ''EXEC '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name + '' '' + 
                    ISNULL((SELECT STRING_AGG(params.name + '' = 2508'', '', '')
                           FROM [' + @databaseName + '].sys.parameters params
                           WHERE params.object_id = p.object_id), '''')
                ELSE ''EXEC '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + p.name
            END AS Example
        FROM [' + @databaseName + '].sys.procedures AS p 
        JOIN [' + @databaseName + '].sys.schemas AS s ON p.schema_id = s.schema_id 
        WHERE p.name LIKE ''' + @tableNameFilter + ''' '
    END
    
    -- Views
    IF @searchView = 1
    BEGIN
        IF LEN(@sql) > 0 AND (@searchTable = 1 OR @searchStoredProcedure = 1)
            SET @sql = @sql + ' UNION ALL '
            
        SET @sql = @sql + '
        SELECT 
            ''View'' AS ObjectType,
            ''' + @databaseName + ''' AS DatabaseName, 
            s.name AS SchemaName, 
            v.name AS ObjectName, 
            ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + v.name AS FullName, 
            ISNULL((SELECT STRING_AGG(c.name, '', '')
                   FROM [' + @databaseName + '].sys.columns c
                   WHERE c.object_id = v.object_id), '''') AS Parameters,
            ''SELECT TOP 100 * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + v.name AS Example
        FROM [' + @databaseName + '].sys.views AS v 
        JOIN [' + @databaseName + '].sys.schemas AS s ON v.schema_id = s.schema_id 
        WHERE v.name LIKE ''' + @tableNameFilter + ''' '
    END
    
    -- Functions
    IF @searchFunction = 1
    BEGIN
        IF LEN(@sql) > 0 AND (@searchTable = 1 OR @searchStoredProcedure = 1 OR @searchView = 1)
            SET @sql = @sql + ' UNION ALL '
            
        SET @sql = @sql + '
        SELECT 
            CASE f.type
                WHEN ''IF'' THEN ''Inline Table-valued Function''
                WHEN ''TF'' THEN ''Table-valued Function''
                WHEN ''FN'' THEN ''Scalar Function''
                ELSE ''Function''
            END AS ObjectType,
            ''' + @databaseName + ''' AS DatabaseName, 
            s.name AS SchemaName, 
            f.name AS ObjectName, 
            ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name AS FullName, 
            ISNULL((SELECT STRING_AGG(params.name + '' ('' + TYPE_NAME(params.user_type_id) + '')'', '', '')
                   FROM [' + @databaseName + '].sys.parameters params
                   WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') AS Parameters,
            CASE 
                WHEN EXISTS (SELECT 1 FROM [' + @databaseName + '].sys.parameters WHERE object_id = f.object_id AND parameter_id > 0)
                THEN 
                    CASE f.type
                        WHEN ''FN'' THEN ''SELECT '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''('' + 
                            ISNULL((SELECT STRING_AGG(''1'', '', '')
                                  FROM [' + @databaseName + '].sys.parameters params
                                  WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') + '')''
                        ELSE ''SELECT * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''('' + 
                            ISNULL((SELECT STRING_AGG(''1'', '', '')
                                  FROM [' + @databaseName + '].sys.parameters params
                                  WHERE params.object_id = f.object_id AND params.parameter_id > 0), '''') + '')''
                    END
                ELSE 
                    CASE f.type
                        WHEN ''FN'' THEN ''SELECT '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''()''
                        ELSE ''SELECT * FROM '' + ''' + @databaseName + ''' + ''.'' + s.name + ''.'' + f.name + ''()''
                    END
            END AS Example
        FROM [' + @databaseName + '].sys.objects AS f 
        JOIN [' + @databaseName + '].sys.schemas AS s ON f.schema_id = s.schema_id 
        WHERE f.type IN (''FN'', ''IF'', ''TF'') AND f.name LIKE ''' + @tableNameFilter + ''' '
    END
    
    FETCH NEXT FROM db_cursor INTO @databaseName
END

CLOSE db_cursor
DEALLOCATE db_cursor

-- Add ORDER BY to the final query
IF LEN(@sql) > 0
BEGIN
    SET @sql = 'SELECT * FROM (' + @sql + ') AS AllObjects ORDER BY ObjectType, DatabaseName, SchemaName, ObjectName'
    EXEC sp_executesql @sql
END