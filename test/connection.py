from flask import Flask, request
import pyodbc
import os

app = Flask(__name__)

# Connect to the SQL Server database
conn_str = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-N8HS364\SQLEXPRESS;DATABASE=db_readmypen;Trusted_Connection=yes;'
conn = pyodbc.connect(conn_str)

@app.route('/upload', methods=['POST'])
def upload():
    file = request.files['file']
    file.save('///C:/xampp/htdocs/readmypen/test/uploads')
    path = os.path.join(os.getcwd(), '///C:/xampp/htdocs/readmypen/test/uploads', file.filename)
    # file.save(path)

    # Create a cursor and execute the INSERT query
    query = conn.cursor()
    query.execute("INSERT INTO tb_pictures (pic_path) VALUES (?)", (path))
    query.commit()
    query.close()
    conn.close()
    return 'File uploaded successfully'

if __name__ == '__main__':
    app.run(debug=True)

