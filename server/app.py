from flask import Flask, abort, request

app = Flask(__name__)
app.config['SECRET_KEY'] = 'secret!'

@app.route("/")
def index():
    return "Hello, Unity!"

@app.get("/button")
def get_button():
    try:
        req = request.args
        button = req.get("button")
    except Exception as e:
        abort(e.code)