# PostgresTutorial
This Tutorial aims to work with Postgres and dynamically read the schema

# API
there is 3 API

    GetAllSchemas: which retrive all schema from the database. 
    https://localhost:44349/Database/GetAllSchemas
    
    GetAllTables: which retrive all tables in a certain schema
    https://localhost:44349/Database/GetAllTables/<schema name>
    
    GetAllColumns: which retrive all Columns in a certain schema.
    https://localhost:44349/Database/GetAllColumns/<Table name>
    
    
 # Example
 https://localhost:44349/Database/GetAllSchemas
 
 ["default_schema","information_schema","pg_catalog","pg_toast"]

https://localhost:44349/Database/GetAllTables/default_schema

["sport"]

https://localhost:44349/Database/GetAllColumns/sport

{"name":"sport","fields":{"id":"bigint","createddate":"timestamp without time zone","name":"character varying","description":"character varying"}}

    
