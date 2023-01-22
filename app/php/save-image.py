# from PIL import Image
# from io import BytesIO
# from flask import Flask, request
# app = Flask(__name__)

# @app.route('/save-image', methods=['POST'])
# def save_image():
#     image_data = request.data
#     image = Image.open(BytesIO(image_data))
#     image.save('../php/uploads/image.jpg')
#     return "Image saved"

# if __name__ == '__main__':
#     app.run(host='0.0.0.0', port=8000)
