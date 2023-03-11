import datetime
from flask import Flask, render_template, request, redirect, url_for, send_from_directory, session, jsonify
import sqlite3
import json
from src.database import create_connection

app = Flask(__name__,template_folder='template')

app.config['SECRET_KEY'] = 'your_secret_key_here'

# Route for serving static files
@app.route('/assets/<path:path>')
def serve_static(path):
    return send_from_directory('assets', path)

@app.route('/index', methods=['GET'])
def index():
    
            
    return render_template('index.html')


# LOGIN AND SIGNUP
@app.route('/login', methods=['GET', 'POST'])
def login():
            
    return render_template('login.html')

# Log into the account and create user sessions
@app.route('/submit_login', methods=['GET', 'POST'])
def submit_login():
    
    with create_connection() as myConnection:
        cursor = myConnection.cursor()
        
        username = request.form['login-username']
        password = request.form['login-password']
        cursor.execute("SELECT user_id, user_username, rol_id FROM tbUsers WHERE user_username = ? AND user_password = ?", (username, password))
        user = cursor.fetchone()
        if user:
            session['user_id'] = user[0]
            session['user_username'] = user[1]
            session['rol_id'] = user[2]
            return jsonify({'success': True, 'rol_id': user[2]})
        else:
            return jsonify({'success': False})


@app.route('/signup', methods=['GET'])
def signup():
    
    return render_template('signup.html')


# Signup to the app, creates a new user account
@app.route('/submit_signup', methods=['GET', 'POST'])
def submit_signup():

    with create_connection() as myConnection:
        cursor = myConnection.cursor()
        
        username = request.form['signup-username']
        email = request.form['signup-email']
        password = request.form['signup-password']
        confirm_password = request.form['signup-confirm-password']
        
        if password != confirm_password:
            return jsonify({'success': False})
        else:
            try:
                # insert new user into tbUsers with default status(1=active) and rol_id (2=user)
                cursor.execute("INSERT INTO tbUsers (user_username, user_email, user_password, user_status, rol_id, user_satisfaction, is_deleted) VALUES (?, ?, ?, ?, ?, ?, ?)", (username, email, password, 1, 2, 0, 0))
                myConnection.commit()
                return jsonify({'success': True})
            except:
                return jsonify({'success': False})

if __name__ == "__main__":
    app.run(host="0.0.0.0", debug=True)
