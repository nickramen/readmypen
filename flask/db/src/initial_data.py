import sqlite3

try:
    # make the database connection and cursor object
    myConnection = sqlite3.connect("database/mydb.sqlite3")
    cursor = myConnection.cursor() 

    # create a set of queries in executescript()
    # below set of queries will create and insert
    # data into table
    cursor.executescript("""
        PRAGMA foreign_keys = ON;
        
        CREATE TABLE tbRoles (
            rol_id INTEGER PRIMARY KEY,
            rol_description VARCHAR(50)
        );
        
        CREATE TABLE tbUsers (
            user_id INTEGER PRIMARY KEY, 
            user_username VARCHAR(50),
            user_password VARCHAR(50),
            user_email VARCHAR(50),
            user_status INTEGER(1),
            rol_id INTEGER REFERENCES tbRoles(rol_id),
            user_satisfaction INTEGER,
            is_deleted INTEGER(1) DEFAULT 0
        );
        
        CREATE TABLE tbPictures (
            pic_id INTEGER PRIMARY KEY,
            pic_picturepath VARCHAR(50),
            user_id INTEGER REFERENCES tbUsers(user_id)
        );
        
        INSERT INTO tbRoles VALUES (1,'Administrator');
        INSERT INTO tbRoles VALUES (2,'User');
        
        INSERT INTO tbUsers VALUES (1,'admin','admin123','test@gmail.com',1,1,0,0);
        INSERT INTO tbUsers VALUES (2,'nickramen','nickramen','mytest@gmail.com',1,2,5,0);
        INSERT INTO tbUsers VALUES (3,'nicole','nicole','nicole@gmail.com',1,2,4,0);
        
        INSERT INTO tbPictures VALUES (1,'This is path number 1',2);
        INSERT INTO tbPictures VALUES (2,'This is path number 2',2);
        INSERT INTO tbPictures VALUES (3,'This is path number 3',2);
        INSERT INTO tbPictures VALUES (4,'This is path number 4',2);
        INSERT INTO tbPictures VALUES (5,'This is path number 5',3);
        INSERT INTO tbPictures VALUES (6,'This is path number 6',3);
        INSERT INTO tbPictures VALUES (7,'This is path number 7',3);
        
    """)
    
    # commit the changes and close the database connection 
    myConnection.commit() 
    myConnection.close()
    
except Exception as ex:
    print(ex)