extends Button

@onready var userInputText: TextEdit = $"../UserInputText"
@onready var passWordInputText: TextEdit = $"../PasswordInputText"
var emailInputText: TextEdit

@export var menu_path = "res://scenes/testin.tscn"
@export var register_path = "res://scenes/ui/register.tscn"

var menu = load(menu_path)
var register = load(register_path)

func _ready() -> void:
	if get_tree().current_scene.name == "Register":
		emailInputText = $"../EmailInputText"


func _on_pressed() -> void:
	if get_tree().current_scene.name == "Register" and !userInputText.text.is_empty() and !passWordInputText.text.is_empty() and !emailInputText.text.is_empty():
		get_tree().change_scene_to_packed(menu)
		return
	
	if get_tree().current_scene.name == "Login":
		get_tree().change_scene_to_packed(register)
