// ALERTS
function myAlertMessage(message, type){
    const alertDiv2 = document.getElementById('login-alert');

    if(type == 'error'){
        alertDiv2.style.display = 'block';
        alertDiv2.innerText = '';
        alertDiv2.classList.remove('alert-success');
        alertDiv2.classList.add('alert-danger');
        alertDiv2.innerText = message;
    }
    else if(type == 'success'){
        alertDiv2.style.display = 'block';
        alertDiv2.innerText = '';
        alertDiv2.classList.remove('alert-danger');
        alertDiv2.classList.add('alert-success');
        alertDiv2.innerText = message;
        
    }
}

// ALERT
const alertDiv = document.getElementById('login-alert');
alertDiv.style.display = 'none';

// LOGIN
const login_username = document.getElementById('login-username');
const login_password = document.getElementById('login-password');

function loginButton() {
    if(login_username.value == "" || login_password.value == ""){
        myAlertMessage('Login failed. One or more fields are empty.', 'error')
        setTimeout(function() {
            alertDiv.style.display = 'none';
        }, 1000);
    }
    else{
        const form = document.querySelector('form');
        const formData = new FormData(form);
        fetch('/submit_login', {
            method: 'POST',
            body: formData
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                myAlertMessage('Login successful. Redirecting to dashboard', 'success')
                
                setTimeout(() => {
                    // if (data.rol_id == 1) {
                    //     window.location.href = 'http://127.0.0.1:5000/admin';
                    // } else if (data.rol_id == 2) {
                    //     window.location.href = 'http://127.0.0.1:5000/index';
                    // }
                    window.location.href = 'http://127.0.0.1:5000/index';
                }, 1000);
            } else {
                myAlertMessage('Login failed. Invalid username or password.', 'error')
                setTimeout(function() {
                    alertDiv.style.display = 'none';
                }, 1000);
            }
        })
        .catch(error => console.error(error));
    }
}

// SIGNUP 
const signup_username = document.getElementById('signup-username');
const signup_email = document.getElementById('signup-email');
const signup_password = document.getElementById('signup-password');
const signup_confirm_password = document.getElementById('signup-confirm-password');

function signupButton() {

    if(signup_username.value == "" || signup_email.value == "" || signup_password.value == "" || signup_confirm_password.value ==""){
        myAlertMessage('Signup failed. One or more fields are empty.', 'error')
        setTimeout(function() {
            alertDiv.style.display = 'none';
        }, 1000);
    }
    else if(signup_password.value == signup_confirm_password.value){

        const form = document.querySelector('form');
        const formData = new FormData(form);
        fetch('/submit_signup', {
            method: 'POST',
            body: formData
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                myAlertMessage('Signup successful. Now please log in.', 'success')
                setTimeout(function() {
                    window.location.href = 'http://127.0.0.1:5000/login';
                }, 1000);
            } else {
                myAlertMessage('Signup failed.', 'error')
                setTimeout(function() {
                    alertDiv.style.display = 'none';
                }, 2000);
            }
        })
        .catch(error => console.error(error));
    }
    else{
        myAlertMessage('Signup failed. Passwords do not match.', 'error')
        setTimeout(function() {
            alertDiv.style.display = 'none';
        }, 1000);
    }
}