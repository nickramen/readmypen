import sqlite3

def create_connection():
    connection = sqlite3.connect("../db/src/database/mydb.sqlite3")
    return connection
