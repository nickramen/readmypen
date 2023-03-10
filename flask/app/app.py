import datetime
from flask import Flask, render_template, request, redirect, url_for, send_from_directory, session, jsonify
import sqlite3
import json

app = Flask(__name__,template_folder='template')

app.config['SECRET_KEY'] = 'your_secret_key_here'

# Route for serving static files
@app.route('/assets/<path:path>')
def serve_static(path):
    return send_from_directory('assets', path)

@app.route('/index', methods=['GET'])
def index():
    
            
    return render_template('index.html')


@app.route('/login', methods=['GET'])
def login():
    
            
    return render_template('login.html')


@app.route('/signup', methods=['GET'])
def signup():
    
            
    return render_template('signup.html')


if __name__ == "__main__":
    app.run(host="0.0.0.0", debug=True)
