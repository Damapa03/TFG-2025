extends Button

@onready var userInputText: TextEdit = $"../UserInputText"
@onready var passWordInputText: TextEdit = $"../PasswordInputText"

@export var menu_path = "res://scenes/testin.tscn"
@export var login_path = "res://scenes/ui/login.tscn"

var menu = load(menu_path)
var login = load(login_path)

func _on_pressed() -> void:
	if get_tree().current_scene.name == "Login" and !userInputText.text.is_empty() and !passWordInputText.text.is_empty():
		get_tree().change_scene_to_packed(menu)
		return
	
	if get_tree().current_scene.name == "Register":
		get_tree().change_scene_to_packed(login)
