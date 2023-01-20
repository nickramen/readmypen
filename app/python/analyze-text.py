from flask import Flask, render_template, request
import pyodbc

app = Flask(__name__)

@app.route('/', methods=['GET', 'POST'])
def index():
    if request.method == 'POST':
        pic_picturePath = request.form['fileToUpload']
        conn_str = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-N8HS364\SQLEXPRESS;DATABASE=db_readmypen;Trusted_Connection=yes;'
        conn = pyodbc.connect(conn_str)
        cursor = conn.cursor()
        cursor.execute("INSERT INTO tb_pictures (path) VALUES (pic_picturePath)", (pic_picturePath))
        
        conn.commit()
        cursor.close()
        conn.close()
    return render_template('/app/php/index.php')

if __name__ == '__main__':
    app.run(debug=True)










import cv2
import pytesseract
pytesseract.pytesseract.tesseract_cmd = r'C:\\Program Files\\Tesseract-OCR\\tesseract.exe'

img = cv2.imread('images/read-text-from-image1.png')
text = pytesseract.image_to_string(img)
print(text)